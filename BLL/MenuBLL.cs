using CoffeeShopManagement.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShopManagement.BLL
{
    public class MenuBLL
    {
        private static MenuBLL instance;

        public static MenuBLL Instance
        {
            get { if (instance == null) instance = new MenuBLL(); return instance; }
            private set { MenuBLL.instance = value; }
        }
        private MenuBLL() { }
        
        // Lấy ra danh sách gồm: tên thức ăn, số lượng, đơn giá, thành tiền của món ăn đó 
        public List<DTO.Menu> GetListMenuByTable(int id)
        {
         
            return MenuDAO.Instance.GetListMenuByTable(id); 
        }
    }
}
