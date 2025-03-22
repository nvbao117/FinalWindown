using CoffeeShopManagement.DTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace CoffeeShopManagement.DAO
{
    public class BillInfoDAO
    {
        private static BillInfoDAO instance;

        public static BillInfoDAO Instance
        {
            get { if (instance == null) instance = new BillInfoDAO(); return instance; }
            private set { BillInfoDAO.instance = value; }
        }

        public BillInfoDAO() { }

        // Lấy danh sách BillInfo từ idBill truyền vào
        public List<BillInfo> GetBillInfos(int id)
        {
            List<BillInfo> listBillInfor = new List<BillInfo>();
            try
            {
                DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM BillInfo WHERE idBill = " + id);

                foreach (DataRow item in data.Rows)
                {
                    BillInfo info = new BillInfo(item);
                    listBillInfor.Add(info);
                }
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error in GetBillInfos: {ex.Message}");
            }
            return listBillInfor;
        }

        // Cập nhật số lượng món ăn trong hóa đơn
        public void UpdateFoodCountInBill(int idBill, int foodID, int count)
        {
            try
            {
                string query = "UPDATE BillInfo SET count = @count WHERE idBill = @idBill AND idFood = @foodID";
                DataProvider.Instance.ExecuteNonQuery(query, new object[] { count, idBill, foodID });
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error in UpdateFoodCountInBill: {ex.Message}");
            }
        }

        // Lấy số lượng món ăn trong hóa đơn
        public int GetFoodCountInBill(int idBill, int foodID)
        {
            try
            {
                string query = "SELECT COUNT FROM BillInfo WHERE idBill = @idBill AND idFood = @foodID";
                object result = DataProvider.Instance.ExecuteScalar(query, new object[] { idBill, foodID });
                return result == DBNull.Value ? 0 : (int)result;
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error in GetFoodCountInBill: {ex.Message}");
                return 0;
            }
        }

        // Kiểm tra món ăn có tồn tại trong hóa đơn không
        public bool IsFoodExistsInBill(int idBill, int foodID)
        {
            try
            {
                string query = "SELECT COUNT(*) FROM BillInfo WHERE idBill = @idBill AND idFood = @idFood ";
                object result = DataProvider.Instance.ExecuteScalar(query, new object[] { idBill, foodID });
                return (int)result > 0;
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error in IsFoodExistsInBill: {ex.Message}");
                return false;
            }
        }

        // Thêm BillInfo mới
        public void InsertBillInfo(int idBill, int idFood, int count)
        {
            try
            {
                DataProvider.Instance.ExecuteQuery("USP_InsertBillInfo @idBill , @idFood , @count ", new object[] { idBill, idFood, count });
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error in InsertBillInfo: {ex.Message}");
            }
        }

        // Xóa BillInfo từ idFood truyền vào
        public void DeleteBillInfoByFoodID(int id)
        {
            try
            {
                DataProvider.Instance.ExecuteQuery("DELETE BillInfo WHERE idFood = " + id);
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error in DeleteBillInfoByFoodID: {ex.Message}");
            }
        }
    }
}
