using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;
using Microsoft.Data.SqlClient;

namespace QuanLyNhaHang.DAL
{
    public class DataProvider
    {
        private static DataProvider? instance;
        public static DataProvider Instance
        {
            get
            {
                if (instance == null) instance = new DataProvider();
                return instance;
            }
            private set => instance = value;
        }

        private DataProvider() { }

        private static string? _workingConnectionStr;
        private static readonly object _lock = new object();

        // Danh sách SQL Server Instance của các máy thành viên trong nhóm
        private static readonly string[] CandidateServers = new[]
        {
            @".\SQLEXPRESS",
            @".\VOHOANGVU",
            @"localhost\SQLEXPRESS",
            @".",
            @"localhost",
            @"(localdb)\mssqllocaldb"
        };

        public static string ConnectionStr
        {
            get
            {
                if (!string.IsNullOrEmpty(_workingConnectionStr))
                {
                    return _workingConnectionStr;
                }

                lock (_lock)
                {
                    if (!string.IsNullOrEmpty(_workingConnectionStr))
                    {
                        return _workingConnectionStr;
                    }

                    // 1. Kiểm tra file cấu hình connection.txt nếu người dùng muốn cố định
                    try
                    {
                        string configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "connection.txt");
                        if (File.Exists(configPath))
                        {
                            string customStr = File.ReadAllText(configPath).Trim();
                            if (!string.IsNullOrEmpty(customStr))
                            {
                                _workingConnectionStr = customStr;
                                return _workingConnectionStr;
                            }
                        }
                    }
                    catch { }

                    // 2. Tự động dò tìm SQL Server instance đang hoạt động (SQLEXPRESS, VOHOANGVU,...)
                    foreach (var server in CandidateServers)
                    {
                        string testStr = $"Server={server};Database=QuanLyNhaHang;Trusted_Connection=True;TrustServerCertificate=True;Connect Timeout=2;";
                        try
                        {
                            using (var testConn = new SqlConnection(testStr))
                            {
                                testConn.Open();
                                _workingConnectionStr = $"Server={server};Database=QuanLyNhaHang;Trusted_Connection=True;TrustServerCertificate=True;";
                                return _workingConnectionStr;
                            }
                        }
                        catch
                        {
                            // Thử tiếp server khác trong danh sách
                        }
                    }

                    // 3. Dự phòng mặc định
                    _workingConnectionStr = @"Server=.\SQLEXPRESS;Database=QuanLyNhaHang;Trusted_Connection=True;TrustServerCertificate=True;";
                    return _workingConnectionStr;
                }
            }
            set
            {
                _workingConnectionStr = value;
            }
        }

        private void AttachParameters(SqlCommand command, string query, object[]? parameter)
        {
            if (parameter != null)
            {
                var matches = Regex.Matches(query, @"@\w+");
                var paramNames = new List<string>();
                foreach (Match m in matches)
                {
                    if (!paramNames.Contains(m.Value))
                    {
                        paramNames.Add(m.Value);
                    }
                }

                for (int i = 0; i < parameter.Length && i < paramNames.Count; i++)
                {
                    command.Parameters.AddWithValue(paramNames[i], parameter[i] ?? DBNull.Value);
                }
            }
        }

        // 1. Thực thi câu lệnh SELECT trả về DataTable
        public DataTable ExecuteQuery(string query, object[]? parameter = null)
        {
            DataTable data = new DataTable();
            using (SqlConnection connection = new SqlConnection(ConnectionStr))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);

                AttachParameters(command, query, parameter);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data);
                connection.Close();
            }
            return data;
        }

        // 2. Thực thi câu lệnh INSERT, UPDATE, DELETE trả về số dòng bị ảnh hưởng
        public int ExecuteNonQuery(string query, object[]? parameter = null)
        {
            int data = 0;
            using (SqlConnection connection = new SqlConnection(ConnectionStr))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);

                AttachParameters(command, query, parameter);

                data = command.ExecuteNonQuery();
                connection.Close();
            }
            return data;
        }

        // 3. Thực thi câu lệnh trả về giá trị đơn (SELECT COUNT, MAX, IDENTITY...)
        public object? ExecuteScalar(string query, object[]? parameter = null)
        {
            object? data = null;
            using (SqlConnection connection = new SqlConnection(ConnectionStr))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);

                AttachParameters(command, query, parameter);

                data = command.ExecuteScalar();
                connection.Close();
            }
            return data;
        }
    }
}
