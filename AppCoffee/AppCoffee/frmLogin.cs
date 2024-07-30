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
    
    public partial class frmLogin : Form
    {

        DBConnect db = new DBConnect();
        List<TaiKhoan> lstUser = DSTaiKhoan.Instance.LstUser;
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string sql = $"exec KiemTraDangNhap '{txtTen.Text}', '{txtMatKhau.Text}'";
            int kq = (int)db.Getscalar(sql);
            if (kq == 0) // nếu không có tài khoản nào trong database thì mật khẩu hoặc tài khoản không đúng
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không đúng !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTen.Clear();
                txtMatKhau.Clear();
                txtTen.Focus();
            }
            else // ngược lại thì đăng nhập thành công
            {
                sql = "select tenDangNhap from TaiKhoan where tenDangNhap = '" + txtTen.Text + "'AND matKhau = '" + txtMatKhau.Text + "' ";
                string user = (string)db.Getscalar(sql); // dùng lệnh select tenDangNhap để bắt lại tên đăng nhập của nhân viên 
                sql = "select chucVu from TaiKhoan where tenDangNhap = '" + txtTen.Text + "'AND matKhau = '" + txtMatKhau.Text + "' ";
                string chucvu = (string)db.Getscalar(sql); // dùng lệnh select  chucVu để bắt lại chức vụ của tài khoản đó để kiểm tra là nhân viên hay là quản lý
                sql = "select tenHienThi from TaiKhoan where tenDangNhap = '" + txtTen.Text + "'AND matKhau = '" + txtMatKhau.Text + "' "; 
                string tenhienthi = (string)db.Getscalar(sql); // dùng lệnh  select tenHienThi để bắt lại tên hiển thị của nhân viên
                mainApp f = new mainApp(user,chucvu,tenhienthi); 
                f.Show(); // show phần mềm quản lý khi đăng nhập thành công
                this.Hide();
            }  

        }

      

        private void frmLogin_Load(object sender, EventArgs e)
        {
           
        }
    }
}
