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
    public class CategoryBLL
    {
        private static CategoryBLL instance;

        public static CategoryBLL Instance
        {
            get { if (instance == null) instance = new CategoryBLL(); return instance; }
            private set { CategoryBLL.instance = value; }
        }

        private CategoryBLL() { }

        // Lấy ra danh sách Category 
        public List<Category> GetListCategory()
        {
            try
            {
                return CategoryDAO.Instance.GetListCategory();
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine(ex.Message);
                return new List<Category>();
            }
        }

        // Tìm danh mục bằng tên
        public List<Category> SearchCategoryByName(string name)
        {
            try
            {
                return CategoryDAO.Instance.SearchCategoryByName(name);
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine(ex.Message);
                return new List<Category>();
            }
        }

        // Đếm số lượng danh mục hiện có
        public int GetCategoryCount()
        {
            try
            {
                return CategoryDAO.Instance.GetCategoryCount();
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine(ex.Message);
                return 0;
            }
        }

        // Lấy ra Category từ idCategory truyền vào
        public Category GetCategoryByID(int id)
        {
            try
            {
                return CategoryDAO.Instance.GetCategoryByID(id);
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        // Các hàm thêm, sửa, xóa Category 
        public bool InsertCategory(string name)
        {
            try
            {
                return CategoryDAO.Instance.InsertCategory(name);
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        // Đổi tên danh mục
        public bool UpdateCategory(int id, string name)
        {
            try
            {
                return CategoryDAO.Instance.UpdateCategory(id, name);
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        // Xóa danh mục
        public bool DeleteCategory(int idCategory)
        {
            try
            {
                return CategoryDAO.Instance.DeleteCategory(idCategory);
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
