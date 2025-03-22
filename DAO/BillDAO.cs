using CoffeeShopManagement.DTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace CoffeeShopManagement.DAO
{
    public class BillDAO
    {
        private static BillDAO instance;

        public static BillDAO Instance
        {
            get { if (instance == null) instance = new BillDAO(); return instance; }
            private set { BillDAO.instance = value; }
        }

        private BillDAO() { }

        // Lấy số lượng bill chưa thanh toán từ idTable truyền vào
        public int GetUnCheckBillIDByTableID(int id)
        {
            try
            {
                DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM Bill WHERE idTable = " + id + " AND status = 0");

                if (data.Rows.Count > 0)
                {
                    Bill bill = new Bill(data.Rows[0]);
                    return bill.ID;
                }

                return -1;
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error in GetUnCheckBillIDByTableID: {ex.Message}");
                return -1;
            }
        }

        // Lấy danh sách bill chưa thanh toán từ idTable truyền vào
        public List<Bill> GetBillsByTableID(int idTable)
        {
            List<Bill> bills = new List<Bill>();
            try
            {
                string query = "SELECT * FROM Bill WHERE idTable = @idTable AND status = 0";
                DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { idTable });

                foreach (DataRow item in data.Rows)
                {
                    Bill bill = new Bill(item);
                    bills.Add(bill);
                }
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error in GetBillsByTableID: {ex.Message}");
            }
            return bills;
        }

        public List<Bill> GetBillsByTableIDCheckOut(int idTable)
        {
            List<Bill> bills = new List<Bill>();
            try
            {
                string query = "SELECT * FROM Bill WHERE idTable = @idTable ";
                DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { idTable });

                foreach (DataRow item in data.Rows)
                {
                    Bill bill = new Bill(item);
                    bills.Add(bill);
                }
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error in GetBillsByTableIDCheckOut: {ex.Message}");
            }
            return bills;
        }

        // Thêm bill vào Database
        public void InsertBill(int id)
        {
            try
            {
                DataProvider.Instance.ExecuteNonQuery("EXEC USP_InsertBill @idTable", new object[] { id });
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error in InsertBill: {ex.Message}");
            }
        }

        // Xóa Bill trong cơ sở dữ liệu
        public void DeleteBill(int idBill)
        {
            try
            {
                string queryDeleteBillInfo = "DELETE FROM BillInfo WHERE idBill = @idBill";
                DataProvider.Instance.ExecuteNonQuery(queryDeleteBillInfo, new object[] { idBill });

                string queryDeleteBill = "DELETE FROM Bill WHERE id = @idBill";
                DataProvider.Instance.ExecuteNonQuery(queryDeleteBill, new object[] { idBill });
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error in DeleteBill: {ex.Message}");
            }
        }

        // Lấy danh sách bill từ ngày...đến ngày...
        public DataTable GetBillListByDate(DateTime checkIn, DateTime checkOut)
        {
            try
            {
                return DataProvider.Instance.ExecuteQuery("EXEC USP_GetListBillByDate @checkIn , @checkOut ", new object[] { checkIn, checkOut });
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error in GetBillListByDate: {ex.Message}");
                return null;
            }
        }

        // Lấy doanh thu theo tháng
        public DataTable GetMonthlyRevenue(DateTime checkIn, DateTime checkOut)
        {
            try
            {
                return DataProvider.Instance.ExecuteQuery("EXEC USP_GetMonthlyRevenue @checkIn , @checkOut", new object[] { checkIn, checkOut });
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error in GetMonthlyRevenue: {ex.Message}");
                return null;
            }
        }

        // Lấy 10 (Số lượng bill trong 1 trang) bill  
        public DataTable GetBillListByDateAndPage(DateTime checkIn, DateTime checkOut, int pageNum)
        {
            try
            {
                return DataProvider.Instance.ExecuteQuery("EXEC USP_GetListBillByDateAndPage @checkIn , @checkOut , @page", new object[] { checkIn, checkOut, pageNum });
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error in GetBillListByDateAndPage: {ex.Message}");
                return null;
            }
        }

        // Lấy số lượng bill 
        public int GetNumBillListByDate(DateTime checkIn, DateTime checkOut)
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("EXEC USP_GetNumBillByDate @checkIn , @checkOut ", new object[] { checkIn, checkOut });
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error in GetNumBillListByDate: {ex.Message}");
                return 0;
            }
        }

        // Lấy idBill lớn nhất từ Database 
        public int GetMaxIDBill()
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("SELECT MAX(id) FROM Bill");
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error in GetMaxIDBill: {ex.Message}");
                return 1;
            }
        }

        // Thanh toán
        public void CheckOut(int id, int discount, float totalPrice)
        {
            try
            {
                string query = "UPDATE Bill SET dateCheckOut = GETDATE(), status = 1, discount = " + discount + ", totalPrice = " + totalPrice + " WHERE id = " + id;
                DataProvider.Instance.ExecuteNonQuery(query);
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error in CheckOut: {ex.Message}");
            }
        }
    }
}
