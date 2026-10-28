using System;
using System.Collections.Generic;
using System.Data;
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

        // Chuỗi kết nối SQL Server chuẩn
        private readonly string connectionStr = "Server=.\\VOHOANGVU;Database=QuanLyNhaHang;Trusted_Connection=True;TrustServerCertificate=True;";

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
            using (SqlConnection connection = new SqlConnection(connectionStr))
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
            using (SqlConnection connection = new SqlConnection(connectionStr))
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
            using (SqlConnection connection = new SqlConnection(connectionStr))
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
