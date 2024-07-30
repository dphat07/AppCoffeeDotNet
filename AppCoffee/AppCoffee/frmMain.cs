using System;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using System.Data.SqlClient;
using System.Data;

using System.Windows;
using System.Collections.Generic;
using System.Security.Cryptography;
using CrystalDecisions.CrystalReports.Engine;

namespace AppCoffee
{
    public partial class mainApp : Form
    {
        DBConnect db = new DBConnect(); // class giao tiếp với database
        Button btnSelecting; // lưu lại nút đang được chọn
        Button btnDoi; // lưu lại nút muốn đổi
        int idBan; // lưu lại id của bàn muốn đổi
        int idBanSelecting; // lưu lại id bàn đang được chọn
        int count = 0; 
        List<Mon> dsMon; // list danh sách món muốn lưu
        DataTable dataTab; // Lưu dữ liệu cho datatable
        DataTable dataTabTenMon; // Lưu dữ liệu cho datatable tên món
        SqlDataReader rdr; // lưu dữ liệu đọc từ SqlDataReader
        int typeClose = 0;
        bool flagDangXuat = false;
        public string User; // tên user
        public string Chucvu; // lưu chức vụ
        public string Tenhienthi; // lưu tên hiển thị
        public mainApp()
        {
            InitializeComponent();
        }
        public mainApp(string user, string chucvu, string tenhienthi)
        {
            InitializeComponent();
            this.User = user; // gán tên đăng nhập
            this.Chucvu = chucvu; // gán chức vụ
            this.Tenhienthi = tenhienthi; // gán tên hiển thị
        }

        // Hàm tạo form đóng
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            switch(typeClose)
            {
                case 0:
                    {
                        if (MessageBox.Show("Bạn có muốn thoát chương trình không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                            e.Cancel = true; // hủy đóng form
                        }
                        break;
                    }
                case 1:
                    {
                        if (MessageBox.Show("Bạn có muốn đăng xuất chương trình không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                            flagDangXuat = true;
                            e.Cancel = true; // hủy đóng form
                        }
                        break;
                    }
            }    
            typeClose = 0;
        }

        // Hàm load form
        private void Form_quanlyquancafe_Load(object sender, EventArgs e)
        {
            updateComboLoaiMon();
            loadBan();
            pnl_1.Enabled = pnl_4.Enabled = pnl_5.Enabled = false;
            tàiKhoảnToolStripMenuItem.Text = User.Trim();
            string sql = $"SELECT dbo.PhanQuyenFunction('{User.Trim()}')";
            bool kq = Convert.ToBoolean(db.Getscalar(sql));
            //string admin = "Admin";
            if (kq) // kiểm tra quyền xem tài khoản đó là quản lý hay nhân viên
            {
                quảnLýToolStripMenuItem.Enabled = true; // nếu là quản lý thì được vào trang quản lý
            }
            else
                quảnLýToolStripMenuItem.Enabled = false; // nếu là nhân viên thì không được truy cập
            txt_nameStaff.Text = Tenhienthi;
        }

        // Hàm check xem nhập sai kí tự cho tên khách hàng không
        private void txt_nameGuest_TextChanged(object sender, EventArgs e)
        {
            Control ctr = (Control)sender; // lấy control của thẻ text
            string inputText = ctr.Text;
            this.errBaoLoi.Clear(); // xóa thông báo lỗi
            if (inputText.Trim().Length != 0)  // kiểm tra nếu trống thì không cho tiếp tục
            {
                btnXacNhan.Enabled = true;
                foreach (char character in inputText) // duyệt qua từng phần tử của text
                {
                    if (Char.IsDigit(character)) // nếu là số thì bắt lỗi
                    {
                        this.errBaoLoi.SetError(ctr, "Họ tên không được chứa số!"); // thông báo lỗi
                        btnXacNhan.Enabled = false; // khóa btn lại
                        return;
                    }
                }
            }
            else
            {
                btnXacNhan.Enabled = false;
            }
        }

        // Hàm kiểm tra khi rời khỏi txt
        private void txt_nameGuest_Leave(object sender, EventArgs e)
        {
            Control ctr = (Control)sender; // lấy control của thẻ text
            if (ctr.Text.Length == 0) // nếu chưa nhập gì 
                this.errBaoLoi.SetError(ctr, "Phải nhập họ tên khách hàng!"); // thông báo nhập
            else
                this.errBaoLoi.Clear();
        }

        // Hàm đăng xuất
        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            typeClose = 1;
            frmLogin f = new frmLogin(); // khởi tạo form
            Close(); // đóng form hiện tại
            if(flagDangXuat)
                flagDangXuat = false;
            else
                f.Show(); // show form mới
        }

        // Load loại món vào combobox
        public void updateComboLoaiMon()
        {
            dataTab = new DataTable(); // khởi tạo table
            string str = "select * from thongTinLoai()";
            dataTab = db.GetDataTable(str); // gán giá trị cho table
            cob_loaiMon.DataSource = dataTab; // đưa giá trị vào cob
            cob_loaiMon.DisplayMember = "tenLoai"; // set display
            cob_loaiMon.ValueMember = "idLoai"; // set value
            cob_loaiMon.SelectedIndex = -1; // set vị trí khi mới khởi tạo
        }

        // update tên món lên datagridview
        public void updateComboTenMon()
        {
            dataTabTenMon = new DataTable(); // khởi tạo table
            string str = "exec xemMonTheoLoai " + cob_loaiMon.SelectedValue + "";
            dataTabTenMon = db.GetDataTable(str);// gán giá trị cho table
            dgv_tenMon.DataSource = loadDataToGridView(loadDataToClass());// đưa giá trị vào cdgv
            txtGiaTri.DataBindings.Clear();
            txtGiaTri.DataBindings.Add("Text", dgv_tenMon.DataSource, "Giá"); // binding 
        }

        // bắt sự kiện thay đổi combobox
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (count > 2) // khi mới khởi tạo không muốn cho bắt dữ liệu
            {
                updateComboTenMon(); // bắt dữ liệu vào dgv
            }
            count++;
        }

        // Lấy id của hóa đơn khi biết trạng thái và bàn
        public int getIdHoaDon(string y)
        {
            int x = 0;
            string str = "select dbo.timIdHoaDon(" + y + ")";
            rdr = db.GetReader(str); // gán giá trị cho rdr để duyệt
            while (rdr.Read())
            {
                x = int.Parse(rdr.GetValue(0).ToString()); // gán giá trị id cho x;
            }
            db.Close();
            return x;
        }

        // Lấy id của món khi biết tên món
        public int getIdTenMon(string y)
        {
            int x = 0;
            string str = "select dbo.timIdMon(N'" + y + "')";
            rdr = db.GetReader(str); // gán giá trị cho rdr để duyệt
            while (rdr.Read())
            {
                x = int.Parse(rdr.GetValue(0).ToString()); // gán giá trị id cho x;
            }
            db.Close();
            return x;
        }

        // load thông tin hóa đơn lên bảng datagridview Hóa đơn
        public void loadThongTinHoaDon(string x)
        {
            dataTab = new  DataTable();
            string str = "select * from thongTinHoaDon(" + getIdHoaDon(x) + ")";
            dataTab = db.GetDataTable(str); // gán giá trị cho table
            dgv_thongTinHoaDon.DataSource = dataTab; // đưa thông tin cho dgv
        }

        // load thông tin hóa đơn
        public void loadHoaDon()
        {
            string str = "select * from LoadThongTinHoaDon(" + txtSoBan.Text + ")";
            rdr = db.GetReader(str); // gán giá trị cho rdr
            while (rdr.Read())
            {
                txt_TongTienHoaDon.Text = rdr.GetValue(4).ToString(); // gán tổng tiền
                txt_GiamGia.Text = (double.Parse(rdr.GetValue(5).ToString()) * 100).ToString() + "%"; // gán giảm giá
                txt_thanhTien.Text = rdr.GetValue(6).ToString(); // gán thành tiền
            }
        }

        // load bàn lên app 
        public void loadBan()
        {
            string str = "select * from LoadBan()";
            rdr= db.GetReader(str); // giá giá trị cho rdr
            while (rdr.Read())
            {
                Button btn = new Button() { Width = 112, Height = 94 }; // khởi tạo nút
                btn.Click += Btn_Click; // khởi tạo hành động click
                var x = rdr.GetValue(2).ToString().Trim().Split(' '); // lấy số bàn
                btn.Text = x[1]; // gán cho số bàn cho btn
                btn.ContextMenuStrip = contextMenuStrip1; // gán contextmenutrip cho nút
                if (bool.Parse(rdr.GetValue(1).ToString()) == true) // kiểm tra nếu trạng thái mà true thì đỏ
                    btn.BackColor = System.Drawing.Color.Red;
                else // kiểm tra nếu trạng thái mà true thì xám
                    btn.BackColor = System.Drawing.Color.Silver;
                flp_Ban.Controls.Add(btn); // gán btn vào flp
            }
            db.Close();
        }

        // sự kiện click vào nút bàn
        private void Btn_Click(object sender, EventArgs e)
        {
            testClickBan(sender as Button);
        }

        // Sử lý khi click vào bàn
        public void testClickBan(Button btn)
        {
            string str;
            // kiểm tra xem đã click vào bàn nào chưa 
            if (btnSelecting != null) // nếu rồi thì vào trong xử lý
            {
                str = "select dbo.loadTrangThaiClickBan(" + btnSelecting.Text + ")";
                rdr = db.GetReader(str);
                while (rdr.Read())
                {
                    // nếu là trạng thái true là đã có bàn đặt thì đánh màu đỏ
                    if (int.Parse(rdr.GetValue(0).ToString()) == 1)
                        btnSelecting.BackColor = System.Drawing.Color.Red;
                    else // ngược lại đánh màu xám
                        btnSelecting.BackColor = System.Drawing.Color.Silver;
                }
                db.Close();
            }
            // set nut mới cho biến btnSelecting
            btnSelecting = new Button();
            btnSelecting = btn;
            // set id cho biến idBanSelecting
            idBanSelecting = int.Parse(btn.Text);
            // set màu xanh cho thẻ đang chọn
            btn.BackColor = System.Drawing.Color.Cyan;
            txtSoBan.Text = txt_countTable.Text = btn.Text; // gán số bàn
            // kiếm tra xem hóa bàn đã bận hay chưa để load thông tin
            str = "select * from LoadThongTinHoaDon(" + btn.Text + ")";
            rdr = db.GetReader(str);
            while (rdr.Read())
            { // trường hợp bàn bận thì ta load thông tin
                txt_nameGuest.Text = rdr.GetValue(1).ToString(); // gán tên
                loadThongTinHoaDon(btn.Text); // thông tin hóa đơn đc load
                pnl_5.Enabled = pnl_4.Enabled = pnl_1.Enabled = true; //cách chức năng khác được bật
                pnl_1.Enabled = btnXacNhan.Enabled = false; // khóa lại nhập thông tin khách
                loadHoaDon(); // load các thông tin tổng tiền, giảm giá, thành tiền
                btn_thanhToan.Enabled = false;
            }
            if (!rdr.HasRows)// trường hợp bàn không bận thì trả về trạng thái ban đầu 
            {
                txt_nameGuest.Text = ""; // gán tên
                pnl_5.Enabled = pnl_4.Enabled = false; // khóa những nút chưa có quyền hạn
                pnl_1.Enabled = true; // nhập thông tin khách được bật
                dgv_thongTinHoaDon.DataSource = null; // xét lại thông dgv hóa đơn
                txt_TongTienHoaDon.Clear(); // xóa dữ liệu cũ
                txt_GiamGia.Clear(); // xóa dữ liệu cũ
                txt_thanhTien.Clear(); // xóa dữ liệu cũ
            }
            db.Close();
        }

        public bool testNull(string str)
        {
            if (str.Trim().Length == 0)
            {
                return false;
            }
            return true;
        }

        // click vào button thêm món
        private void btn_themMon_Click(object sender, EventArgs e)
        {
            if (testNull(txtGiaTri.Text) && testNull(txtTongTien.Text))
            {
                int x = getIdHoaDon(txtSoBan.Text);
                if (x != 0)
                {
                    try
                    {
                        int y = -1;
                        string str;
                        // kiểm tra xem đã được thêm vào hóa đơn chưa
                        foreach (DataGridViewRow i in dgv_thongTinHoaDon.Rows)
                        {
                            if (getIdTenMon(i.Cells[1].Value.ToString()) == getIdTenMon(dgv_tenMon.SelectedRows[0].Cells[1].Value.ToString()))
                                y = 1;
                        }
                        // nếu trùng thì cộng số lượng vào
                        if (y != -1)
                        {
                            str = "update ChiTietHoaDon set soLuong = soLuong + " + nud_soLuong.Value + " where idHoaDon = " + getIdHoaDon(txtSoBan.Text) + " and idMon = " + getIdTenMon(dgv_thongTinHoaDon.SelectedRows[0].Cells[1].Value.ToString()) + " ";
                        }
                        else // nếu chưa trùng thì thêm mới
                        {
                            str = "insert into ChiTietHoaDon values (" + x + ", " + getIdTenMon(dgv_tenMon.SelectedRows[0].Cells[1].Value.ToString()) + ", " + nud_soLuong.Value.ToString() + ", " + txtGiaTri.Text + ", 0) ";
                        }
                        str += "update HoaDon set tongTien = (select sum(thanhTien) from ChiTietHoaDon as CTHD where CTHD.idHoaDon = " + getIdHoaDon(txtSoBan.Text) + ") where idHoaDon = " + getIdHoaDon(txtSoBan.Text) + "";
                        db.GetNonQuery(str);
                        loadThongTinHoaDon(txtSoBan.Text); // load lại thông tin hóa đơn
                        loadHoaDon(); // load lại hóa đơn
                    }
                    catch
                    {
                        MessageBox.Show("Không thể thêm món!");
                    }
                }
                else
                    MessageBox.Show("Không thể thêm món!");
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
            }
        }

        // kiểm tra đổi món
        public void doiMon()
        {
            string str;
            try
            {
                // kiểm tra xem đổi món có trung món muốn đổi không
                if (getIdTenMon(dgv_tenMon.SelectedRows[0].Cells[1].Value.ToString()) != getIdTenMon(dgv_thongTinHoaDon.SelectedRows[0].Cells[1].Value.ToString()))
                {
                    int y = -1;
                    // kiểm tra xem đã được thêm vào hóa đơn chưa
                    foreach (DataGridViewRow i in dgv_thongTinHoaDon.Rows)
                    {
                        if (getIdTenMon(i.Cells[1].Value.ToString()) == getIdTenMon(dgv_tenMon.SelectedRows[0].Cells[1].Value.ToString()))
                            y = 1;
                    }
                    if(y == 1) // nếu đổi món khác trùng thì update
                    {
                        str = "update ChiTietHoaDon set soLuong = soLuong + " + nud_soLuong.Value + " where idHoaDon = " + getIdHoaDon(txtSoBan.Text) + " and idMon = " + getIdTenMon(dgv_tenMon.SelectedRows[0].Cells[1].Value.ToString()) + " ";
                        str += "delete from ChiTietHoaDon where idHoaDon = " + getIdHoaDon(txtSoBan.Text) + " and idMon = " + getIdTenMon(dgv_thongTinHoaDon.SelectedRows[0].Cells[1].Value.ToString()) + " ";
                    }
                    else // nếu đổi món khác không trùng thì đổi món khác
                    {
                        str = "update ChiTietHoaDon set idMon = " + getIdTenMon(dgv_tenMon.SelectedRows[0].Cells[1].Value.ToString()) + ", soLuong = " + nud_soLuong.Value + ", gia = " + txtGiaTri.Text + " where idHoaDon = " + getIdHoaDon(txtSoBan.Text) + " and idMon = " + getIdTenMon(dgv_thongTinHoaDon.SelectedRows[0].Cells[1].Value.ToString()) + " ";
                    }    
                    str += "update HoaDon set tongTien = (select sum(thanhTien) from ChiTietHoaDon as CTHD where CTHD.idHoaDon = " + getIdHoaDon(txtSoBan.Text) + ") where idHoaDon = " + getIdHoaDon(txtSoBan.Text) + "";
                    db.GetNonQuery(str);
                    MessageBox.Show("Món đổi thành công", "Thông báo");
                }
                else
                {
                    MessageBox.Show("Món trùng không thể đổi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("KhÔng thể đổi món!");
            }
        }

        // Xóa món
        public void xoaMon()
        {
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    string str = "delete from ChiTietHoaDon where idHoaDon = " + getIdHoaDon(txtSoBan.Text) + " and idMon = " + getIdTenMon(dgv_thongTinHoaDon.SelectedRows[0].Cells[1].Value.ToString()) + " ";
                    db.GetNonQuery(str);
                    string str1 = "exec sumThanhTien " + getIdHoaDon(txtSoBan.Text) + "";
                    if (db.Getscalar(str1).ToString() == "") // nếu thành tiền bằng 0
                    {
                        str = "update HoaDon set tongTien = 0 where idHoaDon = " + getIdHoaDon(txtSoBan.Text) + "";
                    }
                    else // nếu thành tiền khác 0
                    {
                        int tongTien = (int)db.Getscalar(str1);
                        str = "update HoaDon set tongTien = "+tongTien+" where idHoaDon = " + getIdHoaDon(txtSoBan.Text) + "";
                    }    
                    db.GetNonQuery(str);
                }
                catch
                {
                    MessageBox.Show("Không thể xóa món!");
                }
            }
        }

        // Clear dữ liệu cho các control trong pnl
        public void clearData(Panel pnl)
        {
            foreach (Control i in pnl.Controls)
            {
                if (i is TextBox) // trường hợp là text
                {
                    TextBox txt = (TextBox)i; 
                    if (txt.Name != "txt_countTable" && txt.Name != "txt_nameStaff") // trường hợp là text bàn
                    {
                        txt.Clear();
                    }
                }
                else if (i is ComboBox) // trường hợp là combobox
                {
                    ComboBox cob = (ComboBox)i;
                    cob.SelectedItem = ""; // gán bằng trống
                }
                else if (i is NumericUpDown) // trường hợp là NumericUpDown
                {
                    NumericUpDown nup = (NumericUpDown)i;
                    nup.Value = 1; // gán bằng 1
                }
                else if (i is DataGridView) // trường hợp là DataGridView
                {
                    DataGridView dgv = (DataGridView)i;
                    dgv.DataSource = null; // gán bằng null
                }
            }
        }

        // update lại trạng thái cho bàn
        public void updateBan()
        {

            try
            {
                string str = "update Ban set trangThai = 'False' where tenBan = N'Bàn " + txtSoBan.Text + "'";
                db.GetNonQuery(str);
            }
            catch
            {
                MessageBox.Show("KhÔng thể đổi trạng thái bàn !");
            }
        }

        // xử lý nút thanh toán
        private void button5_Click(object sender, EventArgs e)
        {
            if (testGiaTri(txt_thanhTien.Text))
            {
                try
                {
                    string str = "update HoaDon set trangThai = 'true' where idBan = " + txtSoBan.Text + "";
                    db.GetNonQuery(str);
                    updateBan(); // update lại trạng thía bàn
                    clearData(pnl_1); // clear lại 
                    clearData(pnl_4); // clear lại 
                    MessageBox.Show("Thanh toán thành công!");
                }
                catch
                {
                    MessageBox.Show("Không thể thanh toán!");
                }
            }
            else
            {
                MessageBox.Show("Không thể thanh toán khi chưa có sản phẩm!");
            }
        }

        // đổi bàn set lại màu cho nút bàn
        public void loadColorBanDoi()
        {
            string str = "select dbo.loadTrangThaibangIdBan(" + idBan + ")";
            bool x = (bool)db.Getscalar(str);
            if (x)
                btnDoi.BackColor = System.Drawing.Color.Red;
            else
                btnDoi.BackColor = System.Drawing.Color.Silver;
        }

        // Xét trường hợp đổi bàn
        private void đổiBànToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string str = "select dbo.loadTrangThaiBan(" + txtSoBan.Text + ")";
            int count = (int)db.Getscalar(str);
            // nếu contextmenutrip mà đang để thành chữ đôiủ bàn thì đổi thành hoàn thành đổi bàn
            if (tsmi_doiban.Text == "Đổi bàn")
            {
                if(count != 0)
                {
                    btnDoi = new Button();
                    btnDoi = btnSelecting; // gán lại button cho btnDoi
                    tsmi_doiban.Text = "Hoàn thành đổi bàn";
                    idBan = idBanSelecting;
                }    
                else
                {
                    MessageBox.Show("Bàn này trống không thể đổi", "Thông báo");
                }    
            }
            else // nếu contextmenutrip mà đang để thành chữ hoàn thành đổi bàn thì ta thực hiện đổi chữ về đổi bàn và thực hiện câu lệnh đổi bàn
            {
                if (count == 0)
                {
                    tsmi_doiban.Text = "Đổi bàn";
                    str = "select dbo.loadSoLuongCuaHoaDon(" + idBanSelecting + ")";
                    int x = (int)db.Getscalar(str);
                    if (x == 0)
                    {
                        str = "update HoaDon set idBan = " + idBanSelecting + " where idBan = " + idBan + " and trangThai = 'false' ";
                        str += "update Ban set trangThai = 'false' where idBan = " + idBan + " ";
                        str += "update Ban set trangThai = 'true' where idBan = " + idBanSelecting + "";
                        db.GetNonQuery(str);
                        testClickBan(btnSelecting);
                        loadColorBanDoi();
                        MessageBox.Show("Đổi bàn thành công", "Thông báo");
                    }
                    else
                        MessageBox.Show("Bàn đã đầy không thể đổi vào bàn này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Bàn này trống không thể hoàn thành đổi", "Thông báo");
                }
            }

        }

        // tìm kiếm tên để lấy ra danh sách trong search món
        private List<Mon> find(string ten)
        {
            List<Mon> lstFind = new List<Mon>();
            foreach (Mon monAn in dsMon)
            {
                if (monAn.TenMonAn.Contains(ten)) // món ăn có tên có kí tự thì nhận
                { 
                    lstFind.Add(monAn); // thêm vào anh sách
                }
            }
            return lstFind;
        }

        //sự thay đổi trong text tìm kiếm 
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            List<Mon> ds = new List<Mon>();
            ds = find(txt_timKiemMon.Text); // lấy được danh sách
            dgv_tenMon.DataSource = loadDataToGridView(ds); // load vào datagrid
            txtGiaTri.DataBindings.Clear(); 
            txtGiaTri.DataBindings.Add("Text", dgv_tenMon.DataSource, "Giá"); //binding
        }

        // lấy dữ liệu trong datatable
        private List<Mon> loadDataToClass()
        {
            dsMon = new List<Mon>();
            foreach (DataRow row in dataTabTenMon.Rows)
            {
                int id = int.Parse(row["idMon"].ToString());
                string tenmon = row["tenMon"].ToString();
                int loaimon = int.Parse(row["idLoai"].ToString());
                int gia = int.Parse(row["gia"].ToString());
                string mota = row["moTa"].ToString();
                bool trangThai = bool.Parse(row["trangThai"].ToString());
                Mon food = new Mon(id, tenmon, gia, loaimon, mota, trangThai);
                dsMon.Add(food);
            }
            return dsMon;
        }

        // load dữ liệu vào trong datagridview của tên món
        private DataTable loadDataToGridView(List<Mon> listMon)
        {
            int count = 1;
            DataTable table = new DataTable();
            table.Columns.Add("STT", typeof(string));
            table.Columns.Add("Tên món", typeof(string));
            table.Columns.Add("Giá", typeof(int));
            foreach (Mon mon in listMon)
            {
                DataRow row = table.NewRow();
                row["STT"] = count;
                row["Tên món"] = mon.TenMonAn;
                row["Giá"] = mon.GiaMonAn;
                table.Rows.Add(row);
                count++;
            }
            
            return table;
        }

        // click vào contextmenutrip đổi món
        private void đổiMónToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            doiMon(); // hàm đổi món
            loadThongTinHoaDon(txtSoBan.Text); // load lại thông tin hóa đơn
            loadHoaDon(); 
        }

        // click vào contextmenutrip xóa món
        private void xóaMónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            xoaMon();// hàm xoas món
            loadThongTinHoaDon(txtSoBan.Text); // load lại thông tin hóa đơn
            loadHoaDon();
        } 

        // Click vào thông tin cá nhân
        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            account ac = new account(User);
            ac.Show();
        }

        // set tổng tiền khi có sự thay đổi tại giá trị
        private void txtGiaTri_TextChanged(object sender, EventArgs e)
        {
            txtTongTien.Text = (int.Parse(txtGiaTri.Text) * int.Parse(nud_soLuong.Value.ToString())).ToString();
        }

        // button xác nhận khách hàng
        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            // sét trường hợp thiếu thông tin
            if (txt_nameGuest.Text.Trim().Length > 0 && txt_countTable.Text.Trim().Length > 0 && txt_nameStaff.Text.Trim().Length > 0)
            {
                try
                {
                    string str = "insert into HoaDon values(N'" + txt_nameGuest.Text + "', GETDATE()," + idBanSelecting + ", 0, 0, 0, 'false') ";
                    str += "update Ban set trangThai = 'true' where idBan = " + txt_countTable.Text + "";
                    db.GetNonQuery(str);    
                    loadBan(); // load lại bàn khi thêm xong
                    pnl_3.Enabled = true;
                    txtSoBan.Text = txt_countTable.Text;
                    btnXacNhan.Enabled = false;
                    testClickBan(btnSelecting);
                }
                catch
                {
                    MessageBox.Show("Không thể thêm khách!");
                }
            }
            else
            {
                MessageBox.Show("Bạn phải nhập true đủ nội dung!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // test giá trị = 0 hoặc != 0
        public bool testGiaTri(string str) 
        {
            if (int.Parse(str.Trim()) == 0)
            {
                return false;
            }
            return true;
        }


        // hàm xử lý bấm vào in hóa đơn
        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            if (testGiaTri(txt_thanhTien.Text))
            {
                int idHoaDon = getIdHoaDon(txtSoBan.Text);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = db.Con; // gán SqlConnect cho cmd
                cmd.CommandType = CommandType.StoredProcedure; // gán kiểu cho cmd
                cmd.CommandText = "spInHoaDon"; // gán text cho cmd
                cmd.Parameters.Clear(); // clear tham số
                cmd.Parameters.AddWithValue("@IDHOADON", idHoaDon); // gán id hóa đơn cho nó
                SqlDataAdapter aDap = new SqlDataAdapter(); // tạo adapter
                aDap.SelectCommand = cmd;
                DataTable dt = new DataTable(); // tạo table
                aDap.Fill(dt); // fill dữ liệu vào table
                CrystalReportHoaDon r = new CrystalReportHoaDon(); //khởi tạo đối tượng crystal
                r.SetDataSource(dt); // set giá trị 
                frmHoaDon f = new frmHoaDon(); // khởi tạo đối tượng form hóa đơn
                f.crystalReportViewer1.ReportSource = r; // set sourse cho form
                f.ShowDialog(); // show kết quả
                btn_thanhToan.Enabled = true;
            }
            else
            {
                MessageBox.Show("Không thể in hóa đơn khi chưa có sản phẩm!");
            }
        }

        // mở form quản lý
        private void quảnLýKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            typeClose = 2;
            quanLy fQuanLy = new quanLy(User, Chucvu, Tenhienthi);
            Close();
            fQuanLy.Show();
        }

        // Hàm xử lý hủy bàn
        private void hủyBànToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int idHD = getIdHoaDon(txtSoBan.Text);
            string str = "select dbo.loadChiTietHoaDon(" + idHD + ")";
            string str1 = "select dbo.loadTrangThaiBan(" + txtSoBan.Text + ")";
            int count = (int)db.Getscalar(str);
            int flag = (int)db.Getscalar(str1);
            // kiểm tra bàn đó có đang bận không và đã có hóa đơn nào trong chi tiết chưa mới được hủy
            if (count == 0 && flag != 0)
            {
                str = "delete from HoaDon where idHoaDon = '" + idHD + "' ";
                str += "update Ban set trangThai = 'False' where tenBan = N'Bàn " + txtSoBan.Text + "'";
                db.GetNonQuery(str);
                MessageBox.Show("Hủy bàn thành công!", "Thông báo");
            }
            else
            {
                MessageBox.Show("Hủy bàn không thành công!", "Thông báo");
            }
        }
    }
}