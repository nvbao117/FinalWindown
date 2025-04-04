﻿using CoffeeShopManagement.BLL;
using CoffeeShopManagement.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeShopManagement
{
    public partial class CategoryForm : Form
    {
        BindingSource categoryList = new BindingSource();
        public CategoryForm()
        {
            InitializeComponent();
            UIHelper.RestoreFormPosition(this);
            LoadInfo();
        }

        void LoadInfo()
        {
            LoadListCategory();
            dtgvCategory.DataSource = categoryList;
            AddCategoryBinding();
            pnlAdmin.BackColor = Color.FromArgb(255, 255, 255);
            lblAdmin.ForeColor = Color.Black;
            Account acc = UIHelper.userNameFromLogin;
            lblDisplayName.Text = acc.DisPlayName;
            if (acc.Type == 0)
            {
                lblAdminName.Text = "Nhân viên";
                lblAdmin.Enabled = false;
                pnlAdmin.Enabled = false;
                pnlAdmin.BackColor = Color.DarkGray;
            }
            else
            {
                lblAdminName.Text = "Admin";
            }
            lblDisplayName.Text = acc.DisPlayName;
        }

        void LoadListCategory()
        {
            categoryList.DataSource = CategoryBLL.Instance.GetListCategory();
        }

        void AddCategoryBinding()
        {
            txbID.DataBindings.Add(new Binding("Text", dtgvCategory.DataSource, "ID", true, DataSourceUpdateMode.Never));
            txbCategoryName.DataBindings.Add(new Binding("Text", dtgvCategory.DataSource, "Name", true, DataSourceUpdateMode.Never));
        }

        private void lblHiden_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void lblExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void pnlTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            UIHelper.MoveWindow(this, e);
        }

        private void ChangeForm_Click(object sender, EventArgs e)
        {
            List<Panel> panels = new List<Panel> { pnlHome, pnlAdmin, pnlUser, pnlOrder, pnlCheckOut, pnlHelp };

            UIHelper.ChangePanelColor(sender, panels, UIHelper.userNameFromLogin, this);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            UIHelper.SaveFormPosition(this);
            Form admin = new Admin();
            UIHelper.RestoreFormPosition(admin);
            admin.Show();
            this.Close();
        }

        private void txbFind_TextChanged(object sender, EventArgs e)
        {
            categoryList.DataSource = SearchCategory(txbFind.Text);
        }

        List<Category> SearchCategory(string name)
        {
            List<Category> listFood = CategoryBLL.Instance.SearchCategoryByName(name);

            return listFood;
        }

        private event EventHandler insertCategory;
        public event EventHandler InsertCategory
        {
            add { insertCategory += value; }
            remove { insertCategory -= value; }
        }

        private event EventHandler deleteCategory;
        public event EventHandler DeleteCategory
        {
            add { deleteCategory += value; }
            remove { deleteCategory -= value; }
        }

        private event EventHandler updateCategory;
        public event EventHandler UpdateCategory
        {
            add { updateCategory += value; }
            remove { updateCategory -= value; }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string name = txbCategoryName.Text;

            if (CategoryBLL.Instance.InsertCategory(name))
            {
                MessageBox.Show("Thêm danh mục thành công!");
                LoadListCategory();

                if (insertCategory != null)
                {
                    insertCategory(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm danh mục!");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            int idCategory = Convert.ToInt32(txbID.Text);
            string name = txbCategoryName.Text;

            if (CategoryBLL.Instance.UpdateCategory(idCategory, name))
            {
                MessageBox.Show("Sửa danh mục thành công!");
                LoadListCategory();
                if (updateCategory != null)
                {
                    updateCategory(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Có lỗi khi sửa danh mục!");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Việc xóa danh mục này sẽ xóa tất cả các món ăn có trong danh mục cũng như xóa tất cả các món ăn đó trong bill. Bạn có chắc chắn muốn xóa?",
                                                  "Cảnh báo",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                int idCategory = Convert.ToInt32(txbID.Text);

                if (CategoryBLL.Instance.DeleteCategory(idCategory))
                {
                    MessageBox.Show("Xóa danh mục thành công!");
                    LoadListCategory();
                    if (deleteCategory != null)
                    {
                        deleteCategory(this, new EventArgs());
                    }
                }
                else
                {
                    MessageBox.Show("Có lỗi khi xóa danh mục!");
                }
            }
            else
            {
                MessageBox.Show("Đã hủy thao tác này", "Thông báo");
            }

        }

        private void CategoryForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            UIHelper.SaveFormPosition(this);
        }
    }
}
