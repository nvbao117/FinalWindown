using CoffeeShopManagement.DAO;
using CoffeeShopManagement.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShopManagement.BLL
{
    public class FoodBLL
    {
        private static FoodBLL instance;

        public static FoodBLL Instance
        {
            get { if (instance == null) instance = new FoodBLL(); return instance; }
            private set { FoodBLL.instance = value; }
        }

        private FoodBLL() { }

        // Lấy danh sách Food từ idCategory truyền vào
        public List<Food> GetFoodByCategoryID(int id)
        {
            try
            {
                return FoodDAO.Instance.GetFoodByCategoryID(id);
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error in GetFoodByCategoryID: {ex.Message}");
                return new List<Food>();
            }
        }

        // Lấy ra danh sách thức uống
        public List<Food> GetListFood()
        {
            try
            {
                return FoodDAO.Instance.GetListFood();
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error in GetListFood: {ex.Message}");
                return new List<Food>();
            }
        }

        // Lấy ra thức uống từ foodName
        public Food GetFoodByName(string name)
        {
            try
            {
                return FoodDAO.Instance.GetFoodByName(name);
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error in GetFoodByName: {ex.Message}");
                return null;
            }
        }

        // Lấy thức uống khi có ID
        public Food GetFoodByID(int id)
        {
            try
            {
                return FoodDAO.Instance.GetFoodByID(id);
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error in GetFoodByID: {ex.Message}");
                return null;
            }
        }

        // Lấy số lượng thức uống hiện có
        public int GetFoodCount()
        {
            try
            {
                return FoodDAO.Instance.GetFoodCount();
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
                return FoodDAO.Instance.InsertFood(name, id, price);
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
                return FoodDAO.Instance.UpdateFood(idFood, name, idCategory, price);
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
                return FoodDAO.Instance.DeleteFood(idFood);
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
            try
            {
                return FoodDAO.Instance.SearchFoodByName(name);
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error in SearchFoodByName: {ex.Message}");
                return new List<Food>();
            }
        }

        // Xóa các món có cùng Category
        public void DeteleFoodByCategoryID(int categoryID)
        {
            try
            {
                FoodDAO.Instance.DeteleFoodByCategoryID(categoryID);
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error in DeteleFoodByCategoryID: {ex.Message}");
            }
        }
    }
}
