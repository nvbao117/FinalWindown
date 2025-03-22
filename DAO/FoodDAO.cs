using CoffeeShopManagement.DTO;
using System.Collections.Generic;
using System.Data;
using System;  
namespace CoffeeShopManagement.DAO
{
    public class FoodDAO
    {
        private static FoodDAO instance;

        public static FoodDAO Instance
        {
            get { if (instance == null) instance = new FoodDAO(); return instance; }
            private set { FoodDAO.instance = value; }
        }

        private FoodDAO() { }

        // Lấy danh sách Food từ idCategory truyền vào
        public List<Food> GetFoodByCategoryID(int id)
        {
            List<Food> list = new List<Food>();
            try
            {
                string query = "SELECT * FROM Food WHERE idCategory = " + id;
                DataTable data = DataProvider.Instance.ExecuteQuery(query);

                foreach (DataRow item in data.Rows)
                {
                    Food food = new Food(item);
                    list.Add(food);
                }
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error in GetFoodByCategoryID: {ex.Message}");
            }
            return list;
        }

        // Lấy ra danh sách thức uống
        public List<Food> GetListFood()
        {
            List<Food> list = new List<Food>();
            try
            {
                string query = "SELECT id AS [ID], name AS [Name], idCategory AS [IDCategory], price AS [Price] FROM Food";
                DataTable data = DataProvider.Instance.ExecuteQuery(query);

                foreach (DataRow item in data.Rows)
                {
                    Food food = new Food(item);
                    list.Add(food);
                }
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error in GetListFood: {ex.Message}");
            }
            return list;
        }

        // Lấy ra thức uống từ foodName
        public Food GetFoodByName(string name)
        {
            try
            {
                string query = "SELECT TOP 1 * FROM Food WHERE name LIKE @name ";
                DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { "%" + name + "%" });

                if (data.Rows.Count > 0)
                {
                    return new Food(data.Rows[0]);
                }
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error in GetFoodByName: {ex.Message}");
            }
            return null;
        }

        // Lấy thức uống khi có ID
        public Food GetFoodByID(int id)
        {
            try
            {
                string query = "SELECT TOP 1 * FROM Food WHERE ID = @id ";
                DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { id });

                if (data.Rows.Count > 0)
                {
                    return new Food(data.Rows[0]);
                }
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error in GetFoodByID: {ex.Message}");
            }
            return null;
        }

        // Lấy số lượng thức uống hiện có
        public int GetFoodCount()
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("SELECT COUNT(*) FROM Food");
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error in GetFoodCount: {ex.Message}");
                return 0;
            }
        }

        // Các hàm thêm, sửa, xóa thức uống
        public bool InsertFood(string name, int id, float price)
        {
            try
            {
                string query = string.Format("INSERT Food (name, idCategory, price) VALUES (N'{0}', {1}, {2})", name, id, price);
                int result = DataProvider.Instance.ExecuteNonQuery(query);

                return result > 0;
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error in InsertFood: {ex.Message}");
                return false;
            }
        }

        // Sửa tên, loại, giá thức uống
        public bool UpdateFood(int idFood, string name, int idCategory, float price)
        {
            try
            {
                string query = string.Format("UPDATE Food SET name = N'{0}', idCategory = {1}, price = {2} WHERE id = {3} ", name, idCategory, price, idFood);
                int result = DataProvider.Instance.ExecuteNonQuery(query);

                return result > 0;
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error in UpdateFood: {ex.Message}");
                return false;
            }
        }

        // Xóa thức uống
        public bool DeleteFood(int idFood)
        {
            try
            {
                BillInfoDAO.Instance.DeleteBillInfoByFoodID(idFood);

                string query = string.Format("DELETE Food WHERE id = {0}", idFood);
                int result = DataProvider.Instance.ExecuteNonQuery(query);

                return result > 0;
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error in DeleteFood: {ex.Message}");
                return false;
            }
        }

        // Tìm kiếm thức uống từ tên thức uống truyền vào
        public List<Food> SearchFoodByName(string name)
        {
            List<Food> list = new List<Food>();
            try
            {
                string query = string.Format("SELECT * FROM Food WHERE [dbo].[fuConvertToUnsign1] (name) LIKE N'%' + [dbo].[fuConvertToUnsign1](N'{0}') + '%'", name);
                DataTable data = DataProvider.Instance.ExecuteQuery(query);

                foreach (DataRow item in data.Rows)
                {
                    Food food = new Food(item);
                    list.Add(food);
                }
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error in SearchFoodByName: {ex.Message}");
            }
            return list;
        }

        // Xóa các món có cùng Category
        public void DeteleFoodByCategoryID(int categoryID)
        {
            try
            {
                DataProvider.Instance.ExecuteQuery("DELETE Food WHERE Food.idCategory = " + categoryID);
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error in DeteleFoodByCategoryID: {ex.Message}");
            }
        }
    }
}
