using CoffeeShopManagement.DAO;
using CoffeeShopManagement.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeShopManagement.BLL
{
    public class TableBLL
    {
        private static TableBLL instance;

        public static int tableWidth = 106;
        public static int tableHeight = 106;

        public static TableBLL Instance
        {
            get { if (instance == null) instance = new TableBLL(); return instance; }
            private set => instance = value;
        }

        public TableBLL() { }

        // Hàm đổi bàn
        public void SwitchTable(int id1, int id2)
        {
            try
            {
                TableDAO.Instance.SwitchTable(id1, id2);
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error in SwitchTable: {ex.Message}");
            }
        }

        public void MergeTable(int id1, int id2)
        {
            try
            {
                TableDAO.Instance.MergeTable(id1, id2);
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error in MergeTable: {ex.Message}");
            }
        }

        // Lấy ra danh sách bàn 
        public List<TableFood> LoadTableList()
        {
            try
            {
                return TableDAO.Instance.LoadTableList();
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error in LoadTableList: {ex.Message}");
                return new List<TableFood>();
            }
        }

        public int GetTableCount()
        {
            try
            {
                return TableDAO.Instance.GetTableCount();
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error in GetTableCount: {ex.Message}");
                return 0;
            }
        }

        // Lấy ra bàn có id trùng với idTable truyền vào
        public TableFood GetTableByID(int idTable)
        {
            try
            {
                return TableDAO.Instance.GetTableByID(idTable);
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error in GetTableByID: {ex.Message}");
                return null;
            }
        }

        // Lấy bàn từ tên bàn
        public TableFood GetTableByName(string tableName)
        {
            try
            {
                return TableDAO.Instance.GetTableByName(tableName);
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error in GetTableByName: {ex.Message}");
                return null;
            }
        }

        // Thay đổi trạng thái bàn
        public void UpdateTableStatus(int tableID, string status)
        {
            try
            {
                TableDAO.Instance.UpdateTableStatus(tableID, status);
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error in UpdateTableStatus: {ex.Message}");
            }
        }

        // Các hàm thêm, sửa, xóa bàn 
        public bool InsertTable(string name, string status)
        {
            try
            {
                return TableDAO.Instance.InsertTable(name, status);
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error in InsertTable: {ex.Message}");
                return false;
            }
        }

        // Sửa tên bàn 
        public bool UpdateTable(string name, int id)
        {
            try
            {
                return TableDAO.Instance.UpdateTable(name, id);
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error in UpdateTable: {ex.Message}");
                return false;
            }
        }

        // Xóa bàn
        public bool DeleteTable(int idTable)
        {
            try
            {
                return TableDAO.Instance.DeleteTable(idTable);
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error in DeleteTable: {ex.Message}");
                return false;
            }
        }

        public List<TableFood> SearchTableByName(string name)
        {
            try
            {
                return TableDAO.Instance.SearchTableByName(name);
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error in SearchTableByName: {ex.Message}");
                return new List<TableFood>();
            }
        }
    }
}
