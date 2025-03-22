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
    public class BillBLL
    {
        private static BillBLL instance;

        public static BillBLL Instance
        {
            get { if (instance == null) instance = new BillBLL(); return instance; }
            private set { BillBLL.instance = value; }
        }

        private BillBLL() { }

        // Lấy số lượng bill chưa thanh toán từ idTable truyền vào
        public int GetUnCheckBillIDByTableID(int id)
        {
            try
            {
                return BillDAO.Instance.GetUnCheckBillIDByTableID(id);
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine(ex.Message);
                return -1;
            }
        }

        // Lấy danh sách bill chưa thanh toán từ idTable truyền vào
        public List<Bill> GetBillsByTableID(int idTable)
        {
            try
            {
                return BillDAO.Instance.GetBillsByTableID(idTable);
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine(ex.Message);
                return new List<Bill>();
            }
        }

        public List<Bill> GetBillsByTableIDCheckOut(int idTable)
        {
            try
            {
                return BillDAO.Instance.GetBillsByTableIDCheckOut(idTable);
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine(ex.Message);
                return new List<Bill>();
            }
        }

        // Thêm bill vào Database
        public void InsertBill(int id)
        {
            try
            {
                BillDAO.Instance.InsertBill(id);
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine(ex.Message);
            }
        }

        // Xóa Bill trong cơ sở dữ liệu
        public void DeleteBill(int idBill)
        {
            try
            {
                BillDAO.Instance.DeleteBill(idBill);
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine(ex.Message);
            }
        }

        // Lấy danh sách bill từ ngày...đến ngày...
        public DataTable GetBillListByDate(DateTime checkIn, DateTime checkOut)
        {
            try
            {
                return BillDAO.Instance.GetBillListByDate(checkIn, checkOut);
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        // Lấy doanh thu theo tháng
        public DataTable GetMonthlyRevenue(DateTime checkIn, DateTime checkOut)
        {
            try
            {
                return BillDAO.Instance.GetMonthlyRevenue(checkIn, checkOut);
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        // Lấy 10 (Số lượng bill trong 1 trang) bill  
        public DataTable GetBillListByDateAndPage(DateTime checkIn, DateTime checkOut, int pageNum)
        {
            try
            {
                return BillDAO.Instance.GetBillListByDateAndPage(checkIn, checkOut, pageNum);
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        // Lấy số lượng bill 
        public int GetNumBillListByDate(DateTime checkIn, DateTime checkOut)
        {
            try
            {
                return BillDAO.Instance.GetNumBillListByDate(checkIn, checkOut);
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine(ex.Message);
                return 0;
            }
        }

        // Lấy idBill lớn nhất từ Database 
        public int GetMaxIDBill()
        {
            try
            {
                return BillDAO.Instance.GetMaxIDBill();
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine(ex.Message);
                return -1;
            }
        }

        // Thanh toán
        public void CheckOut(int id, int discount, float totalPrice)
        {
            try
            {
                BillDAO.Instance.CheckOut(id, discount, totalPrice);
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine(ex.Message);
            }
        }
    }
}
