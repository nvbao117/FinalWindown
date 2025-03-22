using CoffeeShopManagement.DAO;
using CoffeeShopManagement.DTO;
using System.Collections.Generic;
using System.Data;
using System; 
namespace CoffeeShopManagement
{
    public class CategoryDAO
    {
        private static CategoryDAO instance;

        public static CategoryDAO Instance
        {
            get { if (instance == null) instance = new CategoryDAO(); return instance; }
            private set { CategoryDAO.instance = value; }
        }

        private CategoryDAO() { }

        // Lấy ra danh sách Category 
        public List<Category> GetListCategory()
        {
            List<Category> list = new List<Category>();
            try
            {
                string query = "SELECT id AS [ID], name AS [Name] FROM FoodCategory";
                DataTable data = DataProvider.Instance.ExecuteQuery(query);

                foreach (DataRow item in data.Rows)
                {
                    Category category = new Category(item);
                    list.Add(category);
                }
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error in GetListCategory: {ex.Message}");
            }
            return list;
        }

        // Tìm danh mục bằng tên
        public List<Category> SearchCategoryByName(string name)
        {
            List<Category> list = new List<Category>();
            try
            {
                string query = string.Format("SELECT * FROM FoodCategory WHERE [dbo].[fuConvertToUnsign1] (name) LIKE N'%' + [dbo].[fuConvertToUnsign1](N'{0}') + '%'", name);
                DataTable data = DataProvider.Instance.ExecuteQuery(query);

                foreach (DataRow item in data.Rows)
                {
                    Category cat = new Category(item);
                    list.Add(cat);
                }
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error in SearchCategoryByName: {ex.Message}");
            }
            return list;
        }

        // Đếm số lượng danh mục hiện có
        public int GetCategoryCount()
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("SELECT COUNT(*) FROM FoodCategory");
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error in GetCategoryCount: {ex.Message}");
                return 0;
            }
        }

        // Lấy ra Category từ idCategory truyền vào
        public Category GetCategoryByID(int id)
        {
            Category category = null;
            try
            {
                string query = "SELECT * FROM FoodCategory WHERE id = " + id;
                DataTable data = DataProvider.Instance.ExecuteQuery(query);

                foreach (DataRow item in data.Rows)
                {
                    category = new Category(item);
                    return category;
                }
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error in GetCategoryByID: {ex.Message}");
            }
            return category;
        }

        // Các hàm thêm, sửa, xóa Category 
        public bool InsertCategory(string name)
        {
            try
            {
                string query = string.Format("INSERT FoodCategory (name) VALUES (N'{0}')", name);
                int result = DataProvider.Instance.ExecuteNonQuery(query);

                return result > 0;
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error in InsertCategory: {ex.Message}");
                return false;
            }
        }

        // Đổi tên danh mục
        public bool UpdateCategory(int id, string name)
        {
            try
            {
                string query = string.Format("UPDATE FoodCategory SET name = N'{0}' WHERE id = {1} ", name, id);
                int result = DataProvider.Instance.ExecuteNonQuery(query);

                return result > 0;
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error in UpdateCategory: {ex.Message}");
                return false;
            }
        }

        // Xóa danh mục
        public bool DeleteCategory(int idCategory)
        {
            try
            {
                List<Food> foodList = FoodDAO.Instance.GetFoodByCategoryID(idCategory);

                foreach (Food item in foodList)
                {
                    BillInfoDAO.Instance.DeleteBillInfoByFoodID(item.ID);
                }

                FoodDAO.Instance.DeteleFoodByCategoryID(idCategory);

                string query = string.Format("DELETE FoodCategory WHERE id = {0}", idCategory);
                int result = DataProvider.Instance.ExecuteNonQuery(query);

                return result > 0;
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error in DeleteCategory: {ex.Message}");
                return false;
            }
        }
    }
}
