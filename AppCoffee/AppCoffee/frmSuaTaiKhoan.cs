using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppCoffee
{
    public partial class account : Form
    {
       public string User;
        DBConnect db = new DBConnect();
        public account()
        {
            InitializeComponent();
        }
        public account(string user)
        {
            InitializeComponent();
            this.User = user;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // nếu tích vào ô đổi mật khẩu thì những textbox liên quan sẽ hiện lên
            if(chkmk.Checked)
            {
                txtmkold.Enabled = label4.Enabled = txtmknew.Enabled = label5.Enabled = txtnhaplaimk.Enabled = label6.Enabled = true;
                btnthaydoi.Enabled = false;
            }    
        }

        private void btnthaydoi_Click_1(object sender, EventArgs e)
        {
            if (txtmknew.Text != txtnhaplaimk.Text) // check nếu mật khẩu mới mà nhập lại mẫu khẩu không khớp thì thay đổi không thành cônc
            {
                MessageBox.Show("Mật khẩu mới không khớp với nhau", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // cập nhật lại mật khẩu mới nếu đúng tài khoản và nhập đúng mật khẩu cũ
            //string sql = "Update TaiKhoan set matKhau = '" + txtmknew.Text + "' Where matKhau ='" + txtmkold.Text + "' AND tenDangNhap ='" + txttentk.Text + "'";
            //int kq = db.GetNonQuery(sql);
            string sql = $"SELECT dbo.KiemTraXacNhanMatKhau('{txttentk.Text.Trim()}', '{txtmkold.Text}', '{txtmknew.Text}', '{txtnhaplaimk.Text}')";
            bool kq = Convert.ToBoolean(db.Getscalar(sql));
            if (kq)
            {
                sql = "Update TaiKhoan set matKhau = '" + txtmknew.Text + "' Where matKhau ='" + txtmkold.Text + "' AND tenDangNhap ='" + txttentk.Text + "'";
                db.GetNonQuery(sql);
                MessageBox.Show("Thay đổi thành công", "Thông báo", MessageBoxButtons.OK);
                txtmkold.Enabled = label4.Enabled = txtmknew.Enabled = label5.Enabled = txtnhaplaimk.Enabled = label6.Enabled = false;
                btnthaydoi.Enabled = false;
                txtmkold.Text = txtmknew.Text = txtnhaplaimk.Text = "";
            }
            // ngược lại không cập nhật nếu mật khẩu cũ không đúng
            else
            {
                MessageBox.Show("Mật khẩu cũ không đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void account_Load(object sender, EventArgs e)
        {
            // load tên đăng nhập và tên hiện thị
            txttentk.Text = User;
            string sql = "select tenHienThi from TaiKhoan where tenDangNhap = '" + User + "'";
            string tenhienthi = (string)db.Getscalar(sql);
            txttenhienthi.Text = tenhienthi;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            // check nếu nhập đầy đủ thông tin thì button thay đổi sẽ hiện
            if (!string.IsNullOrEmpty(txtmkold.Text) && !string.IsNullOrEmpty(txtmknew.Text) && !string.IsNullOrEmpty(txtnhaplaimk.Text))
            {

                btnthaydoi.Enabled = true;
            }
            else
            {

                btnthaydoi.Enabled = false;
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            // check nếu nhập đầy đủ thông tin thì button thay đổi sẽ hiện
            if (!string.IsNullOrEmpty(txtmkold.Text) && !string.IsNullOrEmpty(txtmknew.Text) && !string.IsNullOrEmpty(txtnhaplaimk.Text))
            {

                btnthaydoi.Enabled = true;
            }
            else
            {

                btnthaydoi.Enabled = false;
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            // check nếu nhập đầy đủ thông tin thì button thay đổi sẽ hiện
            if (!string.IsNullOrEmpty(txtmkold.Text) && !string.IsNullOrEmpty(txtmknew.Text) && !string.IsNullOrEmpty(txtnhaplaimk.Text))
            {
               
                btnthaydoi.Enabled = true;
            }
            else
            {
                
                btnthaydoi.Enabled = false;
            }
        }

       
    }
}
