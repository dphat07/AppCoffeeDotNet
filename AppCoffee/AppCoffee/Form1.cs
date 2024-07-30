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

namespace AppCoffee
{
    public partial class mainApp : Form
    {
        Button btnSelecting;
        int idBan;
        int idBanSelecting;
        int count = 0;
        List<Food> foodList;
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter adp;
        DataSet dataSet;
        SqlDataReader rdr;
        DataColumn[] key = new DataColumn[1];
        public mainApp()
        {
            InitializeComponent();
            string strCon = "Data Source=DESKTOP-D3EMUEJ;Initial Catalog=quanCaffe9;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;MultipleActiveResultSets=true";
            con = new SqlConnection(strCon);
        }

        private bool checkIsNumber(string str)
        {
            return str.All(Char.IsDigit);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show("Bạn có muốn thoát chương trình không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void Form_quanlyquancafe_Load(object sender, EventArgs e)
        {
            updateComboLoaiMon();
            setColor();
            //pnl_1.Enabled = pnl_2.Enabled = pnl_3.Enabled = pnl_6.Enabled = false;
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            foreach (Control item in flowLayoutPanel1.Controls)
            {
                if(item is Button)
                {
                    Button button = (Button)item;
                    if(button.Focused)
                    {
                        pnl_1.Enabled = true;
                    }
                }
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (txt_nameGuest.Text.Trim().Length > 0 && txt_countTable.Text.Trim().Length > 0 && txt_nameStaff.Text.Trim().Length > 0)
            {
                try
                {
                    string str = "insert into HoaDon values(N'" + txt_nameGuest.Text + "', GETDATE(), null, '" + txt_countTable.Text + "', N'Chưa thanh toán') ";
                    str += "update Ban set trangThai = N'Đầy' where id = " + txt_countTable.Text + "";
                    con.Open();
                    cmd = new SqlCommand(str, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    setColor();
                    pnl_3.Enabled = true;
                    txtSoBan.Text = txt_countTable.Text;
                    btnXacNhan.Enabled = false;
                }
                catch
                {
                    MessageBox.Show("Không thể thêm khách!");
                }
            }
            else
            {
                MessageBox.Show("Bạn phải nhập đầy đủ nội dung!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }    
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void txt_nameGuest_TextChanged(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            string inputText = ctr.Text;
            foreach (char character in inputText)
            {
                if (Char.IsDigit(character))
                {
                    this.errBaoLoi.SetError(ctr, "Họ tên không được chứa số!");
                    return;
                }
            }
            this.errBaoLoi.Clear();
        }

        private void txt_nameStaff_TextChanged(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            string inputText = ctr.Text;
            foreach (char character in inputText)
            {
                if (Char.IsDigit(character))
                {
                    this.errBaoLoi.SetError(ctr, "Họ tên không được chứa số!");
                    return;
                }
            }
            this.errBaoLoi.Clear();
        }

        private void txt_nameGuest_Leave(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            if (ctr.Text.Length == 0)
                this.errBaoLoi.SetError(ctr, "Phải nhập họ tên khách hàng!");
            else
                this.errBaoLoi.Clear();
        }

        private void txt_nameStaff_Leave(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            if (ctr.Text.Length == 0)
                this.errBaoLoi.SetError(ctr, "Phải nhập họ tên nhân viên!");
            else
                this.errBaoLoi.Clear();
        }

        private void txt_countTable_Leave(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            if (ctr.Text.Length == 0 || !checkIsNumber(ctr.Text))
                this.errBaoLoi.SetError(ctr, "Phải nhập số bàn!");
            else
                this.errBaoLoi.Clear();
        }

        private void txtTenMon_TextChanged(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            string inputText = ctr.Text;
            foreach (char character in inputText)
            {
                if (Char.IsDigit(character))
                {
                    this.errBaoLoi.SetError(ctr, "Tên món không được chứa số!");
                    return;
                }
            }
            this.errBaoLoi.Clear();
        }

        private void txtGiaTri_Leave(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            if (ctr.Text.Length == 0 || !checkIsNumber(ctr.Text))
                this.errBaoLoi.SetError(ctr, "Phải nhập giá trị món!");
            else
                this.errBaoLoi.Clear();
        }

        private void txtGiamGia_Leave(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            if (ctr.Text.Length == 0 || !checkIsNumber(ctr.Text))
                this.errBaoLoi.SetError(ctr, "Phải nhập số tiền giảm giá!");
            else
                this.errBaoLoi.Clear();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            frmLogin f = new frmLogin();
            f.Show();
        }

        private void tàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        public void updateComboLoaiMon()
        {
            dataSet = new DataSet();
            string str = "select * from LoaiMonAn";
            adp = new SqlDataAdapter(str, con);
            adp.Fill(dataSet, "LoaiMon");
            cob_loaiMon.DataSource = dataSet.Tables["LoaiMon"];
            cob_loaiMon.DisplayMember = "tenLoaiMonAn";
            cob_loaiMon.ValueMember = "id";
        }

        public void updateComboTenMon()
        {
            dataSet = new DataSet();
            string str = "select ROW_NUMBER() OVER (ORDER BY MA.tenMonAN) AS [STT], MA.tenMonAN as [Name], MA.gia as [Giá] from MonAn as MA where idLoaiMonAn = " + cob_loaiMon.SelectedValue + "";
            adp = new SqlDataAdapter(str, con);
            adp.Fill(dataSet, "TenMon");
            dgv_tenMon.DataSource = dataSet.Tables["TenMon"];
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (count > 1)
            {
                updateComboTenMon();
            }
            count++;
        }

        public void updateGiaTriTenMon()
        {
            string str = "select * from MonAn where tenMonAn = N'" + dgv_tenMon.SelectedRows[0].Cells[1].Value.ToString() + "'";
            cmd = new SqlCommand(str, con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                txtGiaTri.Text = rdr.GetValue(3).ToString();
                txtTongTien.Text = rdr.GetValue(3).ToString();
                nud_soLuong.Value = 1;
            }
            con.Close();
        }

        private void dgv_tenMon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            updateGiaTriTenMon();
        }

        private void pnl_3_Paint(object sender, PaintEventArgs e)
        {

        }

        public int getIdHoaDon(string y)
        {
            int x = 0;
            string str = "select id from HoaDon as HD where HD.idBan = " + y + " and trangThai = N'Chưa thanh toán'";
            cmd = new SqlCommand(str, con); 
            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                x = int.Parse(rdr.GetValue(0).ToString());
            }
            return x;
        }

        public int getIdTenMon(string y)
        {
            int x = 0;
            string str = "select id from MonAn as MA where MA.tenMonAn = N'" + y + "'";
            cmd = new SqlCommand(str, con);
            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                x = int.Parse(rdr.GetValue(0).ToString());
            }
            return x;
        }

        public void loadThongTinHoaDon(string x)
        {
            dataSet = new DataSet();
            string str = "select ROW_NUMBER() OVER (ORDER BY MA.tenMonAN) AS [STT], MA.tenMonAN as [Name], ttHD.count as [Số Lượng], ttHD.count * MA.gia as [Thành tiền] from MonAn as MA, thongTin_HoaDon as ttHD, HoaDon as HD where MA.id = ttHD.idMonAn and ttHD.idHoaDon = " + getIdHoaDon(x) + " and HD.id = ttHD.idHoaDon and HD.trangThai = N'Chưa thanh toán'";
            adp = new SqlDataAdapter(str, con);
            adp.Fill(dataSet, "ThongTinHoaDon");
            dgv_thongTinHoaDon.DataSource = dataSet.Tables["ThongTinHoaDon"];
        }

        public void loadHoaDon()
        {
            double tong = 0;
            foreach (DataGridViewRow i in dgv_thongTinHoaDon.Rows)
            {
                tong += double.Parse(i.Cells[3].Value.ToString());
            }
            txt_TongTienHoaDon.Text = tong.ToString();
            txt_GiamGia.Text = "0";
            txt_thanhTien.Text = tong.ToString();
        }

        public void setColor()
        {
            string str = "select id, trangThai from Ban";
            cmd = new SqlCommand(str, con);
            con.Open();
            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                switch (rdr.GetValue(0).ToString())
                {
                    case "1":
                        {
                            if (rdr.GetValue(1).ToString() == "Đầy")
                                btn_1.BackColor = System.Drawing.Color.Red;
                            else
                                btn_1.BackColor = System.Drawing.Color.Silver;
                            break;
                        }
                    case "2":
                        {
                            if (rdr.GetValue(1).ToString() == "Đầy")
                                btn_2.BackColor = System.Drawing.Color.Red;
                            else
                                btn_2.BackColor = System.Drawing.Color.Silver;
                            break;
                        }
                    case "3":
                        {
                            if (rdr.GetValue(1).ToString() == "Đầy")
                                btn_3.BackColor = System.Drawing.Color.Red;
                            else
                                btn_3.BackColor = System.Drawing.Color.Silver;
                            break;
                        }
                    case "4":
                        {
                            if (rdr.GetValue(1).ToString() == "Đầy")
                                btn_4.BackColor = System.Drawing.Color.Red;
                            else
                                btn_4.BackColor = System.Drawing.Color.Silver;
                            break;
                        }
                    case "5":
                        {
                            if (rdr.GetValue(1).ToString() == "Đầy")
                                btn_5.BackColor = System.Drawing.Color.Red;
                            else
                                btn_5.BackColor = System.Drawing.Color.Silver;
                            break;
                        }
                    case "6":
                        {
                            if (rdr.GetValue(1).ToString() == "Đầy")
                                btn_6.BackColor = System.Drawing.Color.Red;
                            else
                                btn_6.BackColor = System.Drawing.Color.Silver;
                            break;
                        }
                    case "7":
                        {
                            if (rdr.GetValue(1).ToString() == "Đầy")
                                btn_7.BackColor = System.Drawing.Color.Red;
                            else
                                btn_7.BackColor = System.Drawing.Color.Silver;
                            break;
                        }
                    case "8":
                        {
                            if (rdr.GetValue(1).ToString() == "Đầy")
                                btn_8.BackColor = System.Drawing.Color.Red;
                            else
                                btn_8.BackColor = System.Drawing.Color.Silver;
                            break;
                        }
                    case "9":
                        {
                            if (rdr.GetValue(1).ToString() == "Đầy")
                                btn_9.BackColor = System.Drawing.Color.Red;
                            else
                                btn_9.BackColor = System.Drawing.Color.Silver;
                            break;
                        }
                    case "10":
                        {
                            if (rdr.GetValue(1).ToString() == "Đầy")
                                btn_10.BackColor = System.Drawing.Color.Red;
                            else
                                btn_10.BackColor = System.Drawing.Color.Silver;
                            break;
                        }
                    case "11":
                        {
                            if (rdr.GetValue(1).ToString() == "Đầy")
                                btn_11.BackColor = System.Drawing.Color.Red;
                            else
                                btn_11.BackColor = System.Drawing.Color.Silver;
                            break;
                        }
                    case "12":
                        {
                            if (rdr.GetValue(1).ToString() == "Đầy")
                                btn_12.BackColor = System.Drawing.Color.Red;
                            else
                                btn_12.BackColor = System.Drawing.Color.Silver;
                            break;
                        }
                    case "13":
                        {
                            if (rdr.GetValue(1).ToString() == "Đầy")
                                btn_13.BackColor = System.Drawing.Color.Red;
                            else
                                btn_13.BackColor = System.Drawing.Color.Silver;
                            break;
                        }
                    case "14":
                        {
                            if (rdr.GetValue(1).ToString() == "Đầy")
                                btn_14.BackColor = System.Drawing.Color.Red;
                            else
                                btn_14.BackColor = System.Drawing.Color.Silver;
                            break;
                        }
                    case "15":
                        {
                            if (rdr.GetValue(1).ToString() == "Đầy")
                                btn_15.BackColor = System.Drawing.Color.Red;
                            else
                                btn_15.BackColor = System.Drawing.Color.Silver;
                            break;
                        }
                    case "16":
                        {
                            if (rdr.GetValue(1).ToString() == "Đầy")
                                btn_16.BackColor = System.Drawing.Color.Red;
                            else
                                btn_16.BackColor = System.Drawing.Color.Silver;
                            break;
                        }
                }
            }
            con.Close();
        }

        public void testClickBan(Button btn)
        {
            setColor();
            btnSelecting = new Button();
            btnSelecting = btn;
            idBanSelecting = int.Parse(btn.Text);
            btn.BackColor = System.Drawing.Color.Cyan;
            string str = "select * from HoaDon as HD where HD.idBan = " + btn.Text + " and HD.trangThai = N'Chưa thanh toán'";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                txt_countTable.Text = btn.Text;
                txtSoBan.Text = btn.Text;
                txt_nameGuest.Text = rdr.GetValue(1).ToString();
                loadThongTinHoaDon(btn.Text);
                pnl_2.Enabled = pnl_5.Enabled =  pnl_4.Enabled = pnl_1.Enabled = true;
                pnl_1.Enabled = btnXacNhan.Enabled = false;
                loadHoaDon();
            }
            if (!rdr.HasRows)
            {
                txt_countTable.Text = btn.Text;
                txtSoBan.Text = btn.Text;
                txt_nameGuest.Text = "";
                pnl_5.Enabled = pnl_4.Enabled = false;
                pnl_2.Enabled = pnl_1.Enabled = true;
                dgv_thongTinHoaDon.DataSource = null;
                txt_TongTienHoaDon.Clear();
                txt_GiamGia.Clear();
                txt_thanhTien.Clear();
            }
            con.Close();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btn_2_Click(object sender, EventArgs e)
        {
            testClickBan(btn_2);
        }

        private void btn_3_Click(object sender, EventArgs e)
        {
            testClickBan(btn_3);
        }

        private void btn_4_Click(object sender, EventArgs e)
        {
            testClickBan(btn_4);
        }

        private void btn_5_Click(object sender, EventArgs e)
        {
            testClickBan(btn_5);
        }

        private void btn_6_Click(object sender, EventArgs e)
        {
            testClickBan(btn_6);
        }

        private void btn_7_Click(object sender, EventArgs e)
        {
            testClickBan(btn_7);

        }

        private void btn_8_Click(object sender, EventArgs e)
        {
            testClickBan(btn_8);

        }

        private void btn_9_Click(object sender, EventArgs e)
        {
            testClickBan(btn_9);
        }

        private void btn_10_Click(object sender, EventArgs e)
        {
            testClickBan(btn_10);
        }

        private void btn_11_Click(object sender, EventArgs e)
        {
            testClickBan(btn_11);

        }

        private void btn_12_Click(object sender, EventArgs e)
        {
            testClickBan(btn_12);
        }

        private void btn_13_Click(object sender, EventArgs e)
        {
            testClickBan(btn_13);
        }

        private void btn_14_Click(object sender, EventArgs e)
        {
            testClickBan(btn_14);
        }

        private void btn_15_Click(object sender, EventArgs e)
        {
            testClickBan(btn_15);
        }

        private void btn_16_Click(object sender, EventArgs e)
        {
            testClickBan(btn_16);
        }

        private void btn_1_Click(object sender, EventArgs e)
        {
            testClickBan(btn_1);
        }

        private void btn_themMon_Click(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            int x = getIdHoaDon(txtSoBan.Text);
            if (con.State == ConnectionState.Open)
                con.Close();
            if (x != 0)
            {
                try
                {
                    con.Open();
                    string str = "insert into thongTin_HoaDon values (" + x + ", " + getIdTenMon(dgv_tenMon.SelectedRows[0].Cells[1].Value.ToString()) + ", " + nud_soLuong.Value.ToString() + ")";
                    cmd = new SqlCommand(str, con);
                    cmd.ExecuteNonQuery();
                    loadThongTinHoaDon(txtSoBan.Text);
                    loadHoaDon();
                    con.Close();
                }
                catch
                {
                    MessageBox.Show("Không thể thêm món!");
                }
            }
            else
                MessageBox.Show("Không thể thêm món!");
        }

        public void doiMon()
        {
            try
            {
                string str = "update thongTin_HoaDon set idMonAn = " + getIdTenMon(dgv_tenMon.SelectedRows[0].Cells[1].Value.ToString()) + ", count = " + nud_soLuong.Value + " where idHoaDon = " + getIdHoaDon(txtSoBan.Text) + " and idMonAn = " + getIdTenMon(dgv_thongTinHoaDon.SelectedRows[0].Cells[1].Value.ToString()) + "";
                SqlCommand cmd = new SqlCommand(str, con);
                cmd.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("KhÔng thể đổi món!");
            }
        }

        private void btn_doiMon_Click(object sender, EventArgs e)
        {
            con.Open();
            doiMon();
            loadThongTinHoaDon(txtSoBan.Text);
            loadHoaDon();
            con.Close();
        }

        public void xoaMon()
        {
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    string str = "delete from thongTin_HoaDon where idHoaDon = " + getIdHoaDon(txtSoBan.Text) + " and idMonAn = " + getIdTenMon(dgv_thongTinHoaDon.SelectedRows[0].Cells[1].Value.ToString()) + "";
                    SqlCommand cmd = new SqlCommand(str, con);
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    MessageBox.Show("Không thể đổi món!");
                }
            }
        }

        private void btn_huyMon_Click(object sender, EventArgs e)
        {
            con.Open();
            xoaMon();
            loadThongTinHoaDon(txtSoBan.Text);
            loadHoaDon();
            con.Close();
        }

        public void clearData(Panel pnl)
        {
            foreach (Control i in pnl.Controls)
            {
                if (i is TextBox)
                {
                    TextBox txt = (TextBox)i;
                    if(txt.Name != "txt_countTable")
                    {
                        txt.Clear();
                    }   
                }
                else if (i is ComboBox)
                {
                    ComboBox cob = (ComboBox)i;
                    cob.SelectedItem = "";
                }
                else if (i is NumericUpDown)
                {
                    NumericUpDown nup = (NumericUpDown)i;
                    nup.Value = 1;
                }
                else if (i is DataGridView)
                {
                    DataGridView dgv = (DataGridView)i;
                    dgv.DataSource = null;
                }
            }
        }

        public void updateBan()
        {
            try
            {
                string str = "update Ban set trangThai = N'Trống' where id = " + txtSoBan.Text + "";
                SqlCommand cmd = new SqlCommand(str, con);
                cmd.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("KhÔng thể đổi món!");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                string str = "update HoaDon set trangThai = N'Đã thanh toán' where idBan = " + txtSoBan.Text + "";
                SqlCommand cmd = new SqlCommand(str, con);
                con.Open();
                cmd.ExecuteNonQuery();
                updateBan();
                con.Close();
                clearData(pnl_1);
                clearData(pnl_4);
            }
            catch
            {
                MessageBox.Show("KhÔng thể đổi món!");
            }
        }
    }
}