using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace AppCoffee
{
    public partial class quanLy : Form
    {
        DBConnect db;
        public string User; // tên user
        public string Chucvu; // lưu chức vụ
        public string Tenhienthi; // lưu tên hiển thị
        public quanLy()
        {
            InitializeComponent();
            db = new DBConnect();
        }
        public quanLy(string user, string chucvu, string tenhienthi)
        {
            InitializeComponent();
            db = new DBConnect();
            this.User = user; // gán tên đăng nhập
            this.Chucvu = chucvu; // gán chức vụ
            this.Tenhienthi = tenhienthi; // gán tên hiển thị
        }


        //tabTable Bàn

        public void load_CBOTrangThai()
        {
            DataTable table = new DataTable();
            table.Columns.Add("TinhTrang", typeof(string));
            table.Columns.Add("TrangThai", typeof(bool));
            table.Rows.Add("Trống", false);
            table.Rows.Add("Có khách", true);
            cboBan_TrangThai.DataSource = table;
            cboBan_TrangThai.ValueMember = "TrangThai";
            cboBan_TrangThai.DisplayMember = "TinhTrang";
        }
        //Hàm binding Ban từ DataGridView Ban
        private void binding_Ban()
        {
            txtBan_ID.DataBindings.Clear();
            txtBan_ID.DataBindings.Add("Text", dgvBan.DataSource, "idBan");
            txtBan_Ten.DataBindings.Clear();
            txtBan_Ten.DataBindings.Add("Text", dgvBan.DataSource, "tenBan");
            cboBan_TrangThai.DataBindings.Clear();
            cboBan_TrangThai.DataBindings.Add("SelectedValue", dgvBan.DataSource, "TrangThai");
        }

        private void quanLy_Load(object sender, EventArgs e)
        {
            grpBan.Visible = false;
            btnBan_Xoa.Enabled = btnBan_Sua.Enabled = false;
            grpXoaSua_Mon.Visible = false;
            btnMon_Xoa.Enabled = btnMon_Sua.Enabled = false;
            grpTaiKhoan.Visible = false;
            btnTaiKhoan_Sua.Enabled = btnTaiKhoan_Xoa.Enabled = false;
            grpLoai.Visible = false;
            btnLoai_Sua.Enabled = btnLoai_Xoa.Enabled = false;
            load_DanhSach();
        }
        //Hàm xử lý việc xem bàn
        public void xemBan()
        {
            string sql = "select* from dbo.xemBan()";
            DataTable dt = db.GetDataTable(sql);
            dgvBan.DataSource = dt;
            load_CBOTrangThai();
            binding_Ban();
        }
        public bool checkDuplicate_Ban(string ten)
        {
            string sql = "select count(*) from Ban where tenBan = N'" + ten + "'";
            int kq = (int)db.Getscalar(sql);
            if (kq > 0)
                return true;
            return false;
        }
        //Hàm xử lý việc thêm Bàn 
        private bool themBan()
        {
            if (txtBan_Ten.Text == string.Empty) //Nếu TextBox Tên Bàn trống thì trả về false
                return false;
            string ten = txtBan_Ten.Text;
            if (checkDuplicate_Ban(ten)) //Nếu Tên Bàn trùng thì sẽ trả về false
                return false;
            bool trangthai = bool.Parse(cboBan_TrangThai.SelectedValue.ToString());
            int tt = 0;
            if (trangthai)
                tt = 1;
            string sql = "insert into Ban(tenBan, trangThai) values(N'" + ten + "', " + tt.ToString() + ")";
            int kq = db.GetNonQuery(sql);
            if (kq == 0)
                return false;
            return true;
        }
        //Hàm xử lý việc xóa Bàn
        private bool xoaBan()
        {
            int kq;
            string id = txtBan_ID.Text;
            string sql = "delete from Ban where idBan = " + id;
            kq = db.GetNonQuery(sql);
            if (kq == 0)
                return false;
            return true;
        }

        private bool suaBan()
        {
            int kq;
            string id = txtBan_ID.Text;
            string ten = txtBan_Ten.Text;
            bool trangthai = bool.Parse(cboBan_TrangThai.SelectedValue.ToString());
            int tt = 0;
            if (trangthai)
                tt = 1;
            //string sql = "update Ban set tenBan = N'" + ten + "', trangThai = " + tt.ToString() + " where idBan = " + id;
            string sql = "exec suaBan " + id + ", N'" + ten + "', " + tt.ToString();
            kq = db.GetNonQuery(sql);
            if (kq == 0)
                return false;
            return true;
        }


        private void btnBan_Xem_Click(object sender, EventArgs e)
        {
            try
            {
                xemBan();
            }
            catch (Exception)
            {
                MessageBox.Show("Không xem được.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBan_Them_Click(object sender, EventArgs e)
        {
            bool result = themBan();
            if (result)
            {
                xemBan();
                MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Thêm thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnBan_Xoa_Click(object sender, EventArgs e)
        {
            bool result = xoaBan();
            if (result)
            {
                xemBan();
                chkBan_XoaSua.Checked = false; //Bỏ check của CheckBox Xóa/Sửa
                MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Xóa thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnBan_Sua_Click(object sender, EventArgs e)
        {
            bool result = suaBan();
            if (result)
            {
                xemBan();
                chkBan_XoaSua.Checked = false;  //Bỏ check của CheckBox Xóa/Sửa
                MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Sửa thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnBan_Tim_Click(object sender, EventArgs e)
        {
            dgvBan.DataSource = null; //Xóa DataSource
            string sql = "select * from dbo.timBan('%" + txtBan_Tim.Text + "%')"; 
            DataTable dt = db.GetDataTable(sql);
            dgvBan.DataSource = dt;
            binding_Ban();
        }

        private void chkBan_XoaSua_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBan_XoaSua.Checked) //Nếu check vào CheckBox Xóa/Sửa thì nút Xóa và Sửa sẽ Enable
            {
                grpBan.Visible = true;
                btnBan_Sua.Enabled = true;
                btnBan_Xoa.Enabled = true;
            }
            else //Nếu không thì nút Xóa và Sửa sẽ Disable
            {
                grpBan.Visible = false;
                btnBan_Sua.Enabled = false;
                btnBan_Xoa.Enabled = false;
            }
        }

        //tabTable Món

        public void load_CBOLoai()
        {
            string sql = "select * from Loai";
            DataTable dt = db.GetDataTable(sql);
            cboMon_Loai.DataSource = dt;
            cboMon_Loai.DisplayMember = "tenLoai";
            cboMon_Loai.ValueMember = "idLoai";
        }

        public string getDisplayMember(int tt)
        {
            if (tt == 1)
                return "Còn";
            return "Hết";
        }

        public bool getValueMember(int i)
        {
            if (i == 1)
                return true;
            return false;
        }

        private void load_CBO_TinhTrang_Mon()
        {
            DataTable table = new DataTable();
            table.Columns.Add("TinhTrang", typeof(string));
            table.Columns.Add("TrangThai", typeof(bool));
            table.Rows.Add("Hết", false);
            table.Rows.Add("Còn", true);
            cboMon_TinhTrang.DataSource = table;
            cboMon_TinhTrang.ValueMember = "TrangThai";
            cboMon_TinhTrang.DisplayMember = "TinhTrang";
        }
        public void xemMon()
        {
            string sql = "select * from Mon";
            DataTable dt = db.GetDataTable(sql);
            dgvMon.DataSource = dt;
            load_CBOLoai();
            load_CBO_TinhTrang_Mon();
            //cboMon_TinhTrang.ValueMember = "trangThai";
            binding_Mon();
        }
        public bool checkDuplicate_Mon(string ten)
        {
            string sql = "select count(*) from Mon where tenMon = N'" + ten + "'";
            int kq = (int)db.Getscalar(sql);
            if (kq > 0)
                return true;
            return false;
        }
        //Hàm xử lý việc thêm Bàn 
        private bool themMon()
        {
            if (txtMon_Ten.Text == string.Empty) //Nếu TextBox Tên Bàn trống thì trả về false
                return false;
            string ten = txtMon_Ten.Text;
            if (checkDuplicate_Ban(ten)) //Nếu Tên Bàn trùng thì sẽ trả về false
                return false;
            bool trangthai = bool.Parse(cboMon_TinhTrang.SelectedValue.ToString());
            int loai = int.Parse(cboMon_Loai.SelectedValue.ToString());
            int gia = int.Parse(txtMon_Gia.Text);
            string mota = txtMon_MoTa.Text;
            int tt = 0;
            if (trangthai)
                tt = 1;
            string sql = "insert into Mon(tenMon, idLoai, gia, moTa, trangThai) values(N'" + ten + "', " + loai.ToString() + ", " + gia.ToString() + ", N'" + mota + "', " + tt.ToString() + ")";
            int kq = db.GetNonQuery(sql);
            if (kq == 0)
                return false;
            return true;
        }
        //Hàm xử lý việc xóa Bàn
        private bool xoaMon()
        {
            int kq;
            string id = txtMon_ID.Text;
            //string sql = "delete from Mon where idMon = " + id;
            string sql = "exec xoaMon " + id;
            kq = db.GetNonQuery(sql);
            if (kq == 0)
                return false;
            return true;
        }

        private bool suaMon()
        {
            int kq;
            string id = txtMon_ID.Text;
            string ten = txtMon_Ten.Text;
            bool trangthai = bool.Parse(cboMon_TinhTrang.SelectedValue.ToString());
            int loai = int.Parse(cboMon_Loai.SelectedValue.ToString());
            int gia = int.Parse(txtMon_Gia.Text);
            string mota = txtMon_MoTa.Text;
            int tt = 0;
            if (trangthai)
                tt = 1;
            string sql = "update Mon set tenMon = N'" + ten + "', trangThai = " + tt.ToString() + ", gia = " + gia.ToString() + ", idLoai = " + loai + ", moTa = N'" + mota + "' where idMon = " + id;
            kq = db.GetNonQuery(sql);
            if (kq == 0)
                return false;
            return true;
        }
        //Hàm binding từ DataGridView Món
        private void binding_Mon()
        {
            txtMon_ID.DataBindings.Clear();
            txtMon_ID.DataBindings.Add("Text", dgvMon.DataSource, "idMon");
            txtMon_Ten.DataBindings.Clear();
            txtMon_Ten.DataBindings.Add("Text", dgvMon.DataSource, "tenMon");
            txtMon_Gia.DataBindings.Clear();
            txtMon_Gia.DataBindings.Add("Text", dgvMon.DataSource, "gia");
            cboMon_Loai.DataBindings.Clear();
            cboMon_Loai.DataBindings.Add("SelectedValue", dgvMon.DataSource, "idLoai");
            txtMon_MoTa.DataBindings.Clear();
            txtMon_MoTa.DataBindings.Add("Text", dgvMon.DataSource, "moTa");
            cboMon_TinhTrang.DataBindings.Clear();
            cboMon_TinhTrang.DataBindings.Add("SelectedValue", dgvMon.DataSource, "trangThai");
        }


        private void btnMon_Xem_Click(object sender, EventArgs e)
        {
            try
            {
                xemMon();
            }
            catch (Exception)
            {
                MessageBox.Show("Không xem được.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMon_Them_Click(object sender, EventArgs e)
        {
            bool result = themMon();
            if (result)
            {
                xemMon();
                MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Thêm thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnMon_Xoa_Click(object sender, EventArgs e)
        {
            DialogResult kq;
            kq = MessageBox.Show("Bạn sẽ phải xóa chi tiết hóa đơn có chứ món này?\n Cân nhắc: Chỉnh lại trạng thái của món", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.Yes)
            {
                bool result = xoaMon();
                if (result)
                {
                    xemMon();
                    chkXoaSua_Mon.Checked = false;
                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Xóa thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }   
        }

        private void btnMon_Sua_Click(object sender, EventArgs e)
        {
            bool result = suaMon();
            if (result)
            {
                xemMon();
                chkXoaSua_Mon.Checked = false;
                MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Sửa thất bại", "Thông báo",  MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnMon_Tim_Click(object sender, EventArgs e)
        {
            dgvMon.DataSource = null;
            string sql = "select * from Mon where tenMon like N'%" + txtMon_Tim.Text + "%'";
            DataTable dt = db.GetDataTable(sql);
            dgvMon.DataSource = dt;
            binding_Mon();
        }

        private void chkXoaSua_Mon_CheckedChanged(object sender, EventArgs e)
        {
            if (chkXoaSua_Mon.Checked)
            {
                grpXoaSua_Mon.Visible = true;
                btnMon_Sua.Enabled = btnMon_Xoa.Enabled = true;
            }
            else
            {
                grpXoaSua_Mon.Visible = false;
                btnMon_Sua.Enabled = btnMon_Xoa.Enabled = false;
            }
        }

        //tabTable Tài khoản
        //Binding từ dữ liệu của DataGridView TaiKhoan
        private void binding_TaiKhoan()
        {
            txtTaiKhoan_ID.DataBindings.Clear();
            txtTaiKhoan_ID.DataBindings.Add("Text", dgvTaiKhoan.DataSource, "idTaiKhoan");
            txtTaiKhoan.DataBindings.Clear();
            txtTaiKhoan.DataBindings.Add("Text", dgvTaiKhoan.DataSource, "tenDangNhap");
            txtTaiKhoan_Ten.DataBindings.Clear();
            txtTaiKhoan_Ten.DataBindings.Add("Text", dgvTaiKhoan.DataSource, "tenHienThi");
            txtTaiKhoan_MatKhau.DataBindings.Clear();
            txtTaiKhoan_MatKhau.DataBindings.Add("Text", dgvTaiKhoan.DataSource, "matKhau");
            txtGetMatKhau.DataBindings.Clear();
            txtGetMatKhau.DataBindings.Add("Text", dgvTaiKhoan.DataSource, "matKhau");
            txtTaiKhoan_ChucVu.DataBindings.Clear();
            txtTaiKhoan_ChucVu.DataBindings.Add("Text", dgvTaiKhoan.DataSource, "chucVu");
        }
        public void xemTaiKhoan()
        {
            string sql = "select * from TaiKhoan";
            DataTable dt = db.GetDataTable(sql);
            dgvTaiKhoan.DataSource = dt;
            binding_TaiKhoan();
        }
        //Hàm thực hiện việc thêm tài khoản
        private bool themTaiKhoan()
        {
            int kq;
            string tendn = txtTaiKhoan.Text;
            string tenht = txtTaiKhoan_Ten.Text;
            string matkhau = txtGetMatKhau.Text;
            string chucvu = txtTaiKhoan_ChucVu.Text;
            string sql = "insert into TaiKhoan(tenHienThi, tenDangNhap, matKhau, chucVu) values( N'" + tenht + "', '" + tendn + "', '" + matkhau + "', N'" + chucvu + "')";
            kq = db.GetNonQuery(sql);
            if (kq == 0)
                return false;
            return true;
        }
        //Hàm thực hiện việc xóa tài khoản
        private bool xoaTaiKhoan()
        {
            int kq;
            string id = txtTaiKhoan_ID.Text;
            string sql = "delete from TaiKhoan where idTaiKhoan = '" + id + "'";
            kq = db.GetNonQuery(sql);
            if (kq == 0)
                return false;
            return true;
        }
        //Hàm thực hiện việc sửa tài khoản
        private bool suaTaiKhoan()
        {
            int kq;
            string id = txtTaiKhoan_ID.Text;
            string tendn = txtTaiKhoan.Text;
            string tenht = txtTaiKhoan_Ten.Text;
            string matkhau = txtGetMatKhau.Text;
            string chucvu = txtTaiKhoan_ChucVu.Text;
            string sql = "update TaiKhoan set tenDangNhap = '" + tendn + "', tenHienThi = N'" + tenht + "', matKhau = '" + matkhau + "', chucVu = N'" + chucvu + "' where idTaiKhoan = " + id;
            kq = db.GetNonQuery(sql);
            if (kq == 0)
                return true;
            return true;
        }



        private void btnTaiKhoan_Xem_Click(object sender, EventArgs e)
        {
            try
            {
                xemTaiKhoan();
            }
            catch (Exception)
            {
                MessageBox.Show("Không xem được.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTaiKhoan_Them_Click(object sender, EventArgs e)
        {
            bool result = themTaiKhoan();
            if (result)
            {
                xemTaiKhoan();
                txtTaiKhoan.Clear();
                txtTaiKhoan_ID.Clear();
                txtTaiKhoan_Ten.Clear();
                txtTaiKhoan_MatKhau.Clear();
                txtTaiKhoan_ChucVu.Clear();
                txtGetMatKhau.Clear();
                MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Thêm thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnTaiKhoan_Xoa_Click(object sender, EventArgs e)
        {
            bool result = xoaTaiKhoan();
            if (result)
            {
                xemTaiKhoan();
                chkTaiKhoan_XoaSua.Checked = false;
                MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Xóa thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnTaiKhoan_Sua_Click(object sender, EventArgs e)
        {
            bool result = suaTaiKhoan();
            if (result)
            {
                xemTaiKhoan();
                chkTaiKhoan_XoaSua.Checked = false;
                MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Sửa thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnTaiKhoan_Tim_Click(object sender, EventArgs e)
        {
            dgvTaiKhoan.DataSource = null;
            string sql = "select * from TaiKhoan where tenDangNhap like N'%" + txtTaiKhoan_Tim.Text + "%'";
            DataTable dt = db.GetDataTable(sql);
            dgvTaiKhoan.DataSource = dt;
            binding_TaiKhoan();
        }

        private void chkTaiKhoan_XoaSua_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTaiKhoan_XoaSua.Checked)
            {
                grpTaiKhoan.Visible = true;
                btnTaiKhoan_Xoa.Enabled = btnTaiKhoan_Sua.Enabled = true;
            }
            else
            {
                grpTaiKhoan.Visible = false;
                btnTaiKhoan_Xoa.Enabled = btnTaiKhoan_Sua.Enabled = false;
            }
        }
        //Format DataGridViews
        private void dgvTaiKhoan_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvTaiKhoan.Columns[e.ColumnIndex].Name == "matKhau") //Hiển thị cột mật khẩu là chuỗi các dấu *
            {
                if (e.Value != null) 
                {
                    string password = e.Value.ToString();
                    string fix = password.Replace(" ", "");
                    e.Value = new string('*', fix.Length);
                }
            }
        }
        //Mỗi khi nhập mật khẩu thì sẽ thay ký tự là dấu *
        private void txtTaiKhoan_MatKhau_TextChanged(object sender, EventArgs e)
        {
            string password = txtTaiKhoan_MatKhau.Text;
            string fix = password.Replace(" ", "");
            string maskedPassword = new string('*', fix.Length); //Gán chuối là dấu * với chiều dài là chiều dài của chuối trong TextBox Mật Khẩu
            txtTaiKhoan_MatKhau.Text = maskedPassword; //Gán TextBox mật khẩu hiển thị là chuỗi dấu *
            //txtGetMatKhau.Text = txtTaiKhoan_MatKhau.Text;
            if (txtTaiKhoan_MatKhau.Text.Length == 0) //Nếu textbox mật khẩu trống thì textbox chứa mật khẩu thật sẽ được xóa
                txtGetMatKhau.Clear();
        }

        private void txtTaiKhoan_MatKhau_KeyPress(object sender, KeyPressEventArgs e)
        {
            char enteredChar = e.KeyChar;

            if (char.IsLetterOrDigit(enteredChar) || char.IsPunctuation(enteredChar))
            {
                txtGetMatKhau.Text += enteredChar; //TextBox chứa ký tự mật khẩu thật bị ẩn sẽ chứa mật khẩu khi nhập ký tự vào textbox mật khẩu hiển thị
            }
            //e.Handled = true; 
        }

        private void quanLy_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult kq;
            kq = MessageBox.Show("Bạn có muốn thoát ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.No)
                e.Cancel = true;
            mainApp main = new mainApp(User, Chucvu, Tenhienthi);
            main.Show();
        }

        private void cboThang_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterForMonth();
            update();
        }

        public void update()
        {
            int tongSl = 0;
            int tongTien = 0;
            foreach (DataGridViewRow i in dgv_DoanhThu.Rows)
            {
                tongSl += int.Parse(i.Cells[1].Value.ToString());
                tongTien += int.Parse(i.Cells[2].Value.ToString());
            }    
            txt_tongSl.Text = tongSl.ToString();
            txt_tongTien.Text = tongTien.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmBieuDo bd = new frmBieuDo();
            bd.ShowDialog();
        }
        //Table Loai
        private void binding_Loai()
        {
            txtMaLoai.DataBindings.Clear();
            txtMaLoai.DataBindings.Add("Text", dgvLoai.DataSource, "idLoai");
            txtTenLoai.DataBindings.Clear();
            txtTenLoai.DataBindings.Add("Text", dgvLoai.DataSource, "tenLoai");
        }
        //Cập nhật DataTable và gán DataSource của DataGridView Loại 
        public void xemLoai()
        {
            string sql = "select * from dbo.xemLoai()";
            DataTable dt = db.GetDataTable(sql);
            dgvLoai.DataSource = dt;
            binding_Loai();
        }
        //Hàm xử lý việc thêm Loại
        private bool themLoai()
        {
            int kq;
            string ten = txtTenLoai.Text;
            string sql = "insert into Loai(tenLoai) values(N'" + ten + "')";
            kq = db.GetNonQuery(sql);
            if (kq == 0)
                return false;
            return true;
        }//Kiểm tra xem còn tồn tại món trong loại đó không
        public bool checkMon(int id)
        {
            string sql = "select count(*) from Mon where idLoai = " + id.ToString();
            int kq = (int)db.Getscalar(sql);
            if (kq > 0)
                return true;
            return false;
        }
        //Hàm xử lý việc xóa Loại
        private bool xoaLoai()
        {
            int kq;
            int id = int.Parse(txtMaLoai.Text);
            if (checkMon(id))
                return false;
            string sql = "delete from Loai where idLoai = " + id.ToString();
            kq = db.GetNonQuery(sql);
            if (kq == 0)
                return false;
            return true;
        }
        //Hàm xử lý việc sửa Loại
        private bool suaLoai()
        {
            int kq;
            string id = txtMaLoai.Text;
            string ten = txtTenLoai.Text;
            string sql = "update Loai set tenLoai = N'" + ten + "' where idLoai = " + id;
            kq = db.GetNonQuery(sql);
            if (kq == 0)
                return false;
            return true;
        }

        private void btnLoai_Them_Click_1(object sender, EventArgs e)
        {
            bool result = themLoai();
            if (result)
            {
                xemLoai();
                MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Thêm thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnLoai_Xoa_Click_1(object sender, EventArgs e)
        {
            bool result = xoaLoai();
            if (result)
            {
                xemLoai();
                chkXoaSua_Loai.Checked = false;
                MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Xóa thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnLoai_Sua_Click_1(object sender, EventArgs e)
        {
            bool result = suaLoai();
            if (result)
            {
                xemLoai();
                chkXoaSua_Loai.Checked = false;
                MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Sửa thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnLoai_Tim_Click_1(object sender, EventArgs e)
        {
            dgvLoai.DataSource = null; //Xóa DataSource
            string sql = "select * from dbo.timLoai('%" + txtLoai_Tim.Text + "%')";
            DataTable dt = db.GetDataTable(sql);
            dgvLoai.DataSource = dt;
            binding_Loai();
        }

        private void chkXoaSua_Loai_CheckedChanged(object sender, EventArgs e)
        {
            if (chkXoaSua_Loai.Checked)
            {
                grpLoai.Visible = true;
                btnLoai_Sua.Enabled = btnLoai_Xoa.Enabled = true;
            }
            else
            {
                grpLoai.Visible = false;
                btnLoai_Xoa.Enabled = btnLoai_Sua.Enabled = false;
            }
        }

        private void btnLoai_Xem_Click_1(object sender, EventArgs e)
        {
            try
            {
                xemLoai();
            }
            catch (Exception)
            {
                MessageBox.Show("Không xem được.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void load_DanhSach ()
        {
            string strDT = "select Mon.tenMon as [Tên món], COUNT(ChiTietHoaDon.idMon) as [Số lượng], SUM(ChiTietHoaDon.thanhTien) as [Tổng tiền],MONTH(HoaDon.ngayNhap) as [Tháng] from ChiTietHoaDon,Mon,HoaDon where HoaDon.idHoaDon = ChiTietHoaDon.idHoaDon and ChiTietHoaDon.idMon = Mon.idMon and HoaDon.trangThai = 'True' group by Mon.tenMon, MONTH(ngayNhap)\r\n";
            SqlDataAdapter da_DoanhThu;
            da_DoanhThu = new SqlDataAdapter(strDT, db.Con);
            SqlCommandBuilder buider = new SqlCommandBuilder(da_DoanhThu);
            var ds = new DataSet();
            da_DoanhThu.Fill(ds);
            dgv_DoanhThu.DataSource = ds.Tables[0];
            update();
        }

        public void FilterForMonth()
        {
            int Thang = int.Parse(cboThang.SelectedItem.ToString());
            string strDT = "select Mon.tenMon as [Tên món], COUNT(ChiTietHoaDon.idMon) as [Số lượng], SUM(ChiTietHoaDon.thanhTien) as [Tổng tiền],MONTH(HoaDon.ngayNhap) as [Tháng] from ChiTietHoaDon,Mon,HoaDon where HoaDon.idHoaDon = ChiTietHoaDon.idHoaDon and ChiTietHoaDon.idMon = Mon.idMon and Month(ngayNhap) = " + Thang + "  group by Mon.tenMon, MONTH(ngayNhap)";
            SqlDataAdapter da_DoanhThu;
            da_DoanhThu = new SqlDataAdapter(strDT, db.Con);
            SqlCommandBuilder buider = new SqlCommandBuilder(da_DoanhThu);
            var ds = new DataSet();
            da_DoanhThu.Fill(ds);
            dgv_DoanhThu.DataSource = ds.Tables[0];
        }


    }
}
