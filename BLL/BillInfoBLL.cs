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
    public class BillInfoBLL
    {
        private static BillInfoBLL instance;

        public static BillInfoBLL Instance
        {
            get { if (instance == null) instance = new BillInfoBLL(); return instance; }
            private set { BillInfoBLL.instance = value; }
        }

        public BillInfoBLL() { }

        // Lấy danh sách BillInfo từ idBill truyền vào
        public List<BillInfo> GetBillInfos(int id)
        {
            try
            {
                return BillInfoDAO.Instance.GetBillInfos(id);
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine(ex.Message);
                return new List<BillInfo>();
            }
        }

        // Cập nhật số lượng món ăn trong hóa đơn
        public void UpdateFoodCountInBill(int idBill, int foodID, int count)
        {
            try
            {
                BillInfoDAO.Instance.UpdateFoodCountInBill(idBill, foodID, count);
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine(ex.Message);
            }
        }

        // Lấy số lượng món ăn trong hóa đơn
        public int GetFoodCountInBill(int idBill, int foodID)
        {
            try
            {
                return BillInfoDAO.Instance.GetFoodCountInBill(idBill, foodID);
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine(ex.Message);
                return 0;
            }
        }

        // Kiểm tra món ăn có tồn tại trong hóa đơn không
        public bool IsFoodExistsInBill(int idBill, int foodID)
        {
            try
            {
                return BillInfoDAO.Instance.IsFoodExistsInBill(idBill, foodID);
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        // Thêm BillInfo mới
        public void InsertBillInfo(int idBill, int idFood, int count)
        {
            try
            {
                BillInfoDAO.Instance.InsertBillInfo(idBill, idFood, count);
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine(ex.Message);
            }
        }

        // Xóa BillInfo từ idFood truyền vào
        public void DeleteBillInfoByFoodID(int id)
        {
            try
            {
                BillInfoDAO.Instance.DeleteBillInfoByFoodID((int)id);
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine(ex.Message);
            }
        }
    }
}
