using System.Data;
using System.Data.SqlClient;
using System; 
namespace CoffeeShopManagement.DAO
{
    public class DataProvider
    {
        private static DataProvider instance;
        public static DataProvider Instance
        {
            get { if (instance == null) instance = new DataProvider(); return DataProvider.instance; }
            private set { DataProvider.instance = value; }
        }

        private DataProvider() { }

        private string connectionSTR = @"Data Source=(local);Initial Catalog=CoffeeShopManagementData;Integrated Security=True;TrustServerCertificate=True";

        // Thực thi một câu lệnh SQL SELECT và trả về kết quả dưới dạng DataTable
        public DataTable ExecuteQuery(string query, object[] parameter = null)
        {
            DataTable data = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionSTR))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);

                    if (parameter != null)
                    {
                        string[] listPara = query.Split(' ');

                        int i = 0;
                        foreach (string item in listPara)
                        {
                            if (item.Contains("@"))
                            {
                                command.Parameters.AddWithValue(item, parameter[i]);
                                i++;
                            }
                        }
                    }

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(data);

                    connection.Close();
                }
            }
            catch (SqlException ex)
            {
                // Log SQL exception
                Console.WriteLine($"SQL Error in ExecuteQuery: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Log general exception
                Console.WriteLine($"Error in ExecuteQuery: {ex.Message}");
            }
            return data;
        }

        // Thực thi một câu lệnh SQL không trả về dữ liệu (chẳng hạn như INSERT, UPDATE, DELETE) và trả về số lượng bản ghi bị ảnh hưởng
        public int ExecuteNonQuery(string query, object[] parameter = null)
        {
            int data = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionSTR))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(query, connection);

                    if (parameter != null)
                    {
                        string[] listPara = query.Split(' ');

                        int i = 0;
                        foreach (string item in listPara)
                        {
                            if (item.Contains("@"))
                            {
                                command.Parameters.AddWithValue(item, parameter[i]);
                                i++;
                            }
                        }
                    }

                    data = command.ExecuteNonQuery();

                    connection.Close();
                }
            }
            catch (SqlException ex)
            {
                // Log SQL exception
                Console.WriteLine($"SQL Error in ExecuteNonQuery: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Log general exception
                Console.WriteLine($"Error in ExecuteNonQuery: {ex.Message}");
            }
            return data;
        }

        // Thực thi một câu lệnh SQL và trả về giá trị đầu tiên của kết quả
        public object ExecuteScalar(string query, object[] parameter = null)
        {
            object data = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionSTR))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);

                    if (parameter != null)
                    {
                        string[] listPara = query.Split(' ');

                        int i = 0;
                        foreach (string item in listPara)
                        {
                            if (item.Contains("@"))
                            {
                                command.Parameters.AddWithValue(item, parameter[i]);
                                i++;
                            }
                        }
                    }

                    data = command.ExecuteScalar();

                    connection.Close();
                }
            }
            catch (SqlException ex)
            {
                // Log SQL exception
                Console.WriteLine($"SQL Error in ExecuteScalar: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Log general exception
                Console.WriteLine($"Error in ExecuteScalar: {ex.Message}");
            }
            return data;
        }
    }
}
