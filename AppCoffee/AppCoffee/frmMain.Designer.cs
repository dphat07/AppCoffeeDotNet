using System.Windows.Forms;
namespace AppCoffee
{
    partial class mainApp
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainApp));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tàiKhoảnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thôngTinCáNhânToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đăngXuấtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýKhoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_thanhToan = new System.Windows.Forms.Button();
            this.pnl_1 = new System.Windows.Forms.Panel();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btnXacNhan = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_countTable = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_nameGuest = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_nameStaff = new System.Windows.Forms.TextBox();
            this.pnl_5 = new System.Windows.Forms.Panel();
            this.btn_themMon = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.txt_timKiemMon = new System.Windows.Forms.TextBox();
            this.dgv_tenMon = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip3 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.đổiMónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cob_loaiMon = new System.Windows.Forms.ComboBox();
            this.nud_soLuong = new System.Windows.Forms.NumericUpDown();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtGiaTri = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.xóaMónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label6 = new System.Windows.Forms.Label();
            this.pnl_3 = new System.Windows.Forms.Panel();
            this.flp_Ban = new System.Windows.Forms.FlowLayoutPanel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmi_doiban = new System.Windows.Forms.ToolStripMenuItem();
            this.hủyBànToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnl_4 = new System.Windows.Forms.Panel();
            this.btnInHoaDon = new System.Windows.Forms.Button();
            this.dgv_thongTinHoaDon = new System.Windows.Forms.DataGridView();
            this.txt_TongTienHoaDon = new System.Windows.Forms.TextBox();
            this.txt_GiamGia = new System.Windows.Forms.TextBox();
            this.txt_thanhTien = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtSoBan = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.errBaoLoi = new System.Windows.Forms.ErrorProvider(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label15 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.pnl_1.SuspendLayout();
            this.pnl_5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_tenMon)).BeginInit();
            this.contextMenuStrip3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_soLuong)).BeginInit();
            this.contextMenuStrip2.SuspendLayout();
            this.pnl_3.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.pnl_4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_thongTinHoaDon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errBaoLoi)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tàiKhoảnToolStripMenuItem,
            this.quảnLýToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1554, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tàiKhoảnToolStripMenuItem
            // 
            this.tàiKhoảnToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thôngTinCáNhânToolStripMenuItem,
            this.đăngXuấtToolStripMenuItem});
            this.tàiKhoảnToolStripMenuItem.Name = "tàiKhoảnToolStripMenuItem";
            this.tàiKhoảnToolStripMenuItem.Size = new System.Drawing.Size(85, 24);
            this.tàiKhoảnToolStripMenuItem.Text = "Tài khoản";
            // 
            // thôngTinCáNhânToolStripMenuItem
            // 
            this.thôngTinCáNhânToolStripMenuItem.Name = "thôngTinCáNhânToolStripMenuItem";
            this.thôngTinCáNhânToolStripMenuItem.Size = new System.Drawing.Size(210, 26);
            this.thôngTinCáNhânToolStripMenuItem.Text = "Thông tin cá nhân";
            this.thôngTinCáNhânToolStripMenuItem.Click += new System.EventHandler(this.thôngTinCáNhânToolStripMenuItem_Click);
            // 
            // đăngXuấtToolStripMenuItem
            // 
            this.đăngXuấtToolStripMenuItem.Name = "đăngXuấtToolStripMenuItem";
            this.đăngXuấtToolStripMenuItem.Size = new System.Drawing.Size(210, 26);
            this.đăngXuấtToolStripMenuItem.Text = "Đăng xuất";
            this.đăngXuấtToolStripMenuItem.Click += new System.EventHandler(this.đăngXuấtToolStripMenuItem_Click);
            // 
            // quảnLýToolStripMenuItem
            // 
            this.quảnLýToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quảnLýKhoToolStripMenuItem});
            this.quảnLýToolStripMenuItem.Name = "quảnLýToolStripMenuItem";
            this.quảnLýToolStripMenuItem.Size = new System.Drawing.Size(73, 24);
            this.quảnLýToolStripMenuItem.Text = "Quản lý";
            // 
            // quảnLýKhoToolStripMenuItem
            // 
            this.quảnLýKhoToolStripMenuItem.Name = "quảnLýKhoToolStripMenuItem";
            this.quảnLýKhoToolStripMenuItem.Size = new System.Drawing.Size(170, 26);
            this.quảnLýKhoToolStripMenuItem.Text = "Quản lý kho";
            this.quảnLýKhoToolStripMenuItem.Click += new System.EventHandler(this.quảnLýKhoToolStripMenuItem_Click);
            // 
            // btn_thanhToan
            // 
            this.btn_thanhToan.Enabled = false;
            this.btn_thanhToan.Location = new System.Drawing.Point(19, 573);
            this.btn_thanhToan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_thanhToan.Name = "btn_thanhToan";
            this.btn_thanhToan.Size = new System.Drawing.Size(225, 66);
            this.btn_thanhToan.TabIndex = 4;
            this.btn_thanhToan.Text = "Thanh toán";
            this.btn_thanhToan.UseVisualStyleBackColor = true;
            this.btn_thanhToan.Click += new System.EventHandler(this.button5_Click);
            // 
            // pnl_1
            // 
            this.pnl_1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pnl_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_1.Controls.Add(this.dateTimePicker1);
            this.pnl_1.Controls.Add(this.btnXacNhan);
            this.pnl_1.Controls.Add(this.label10);
            this.pnl_1.Controls.Add(this.txt_countTable);
            this.pnl_1.Controls.Add(this.label7);
            this.pnl_1.Controls.Add(this.txt_nameGuest);
            this.pnl_1.Controls.Add(this.label8);
            this.pnl_1.Controls.Add(this.label9);
            this.pnl_1.Controls.Add(this.txt_nameStaff);
            this.pnl_1.Location = new System.Drawing.Point(11, 103);
            this.pnl_1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnl_1.Name = "pnl_1";
            this.pnl_1.Size = new System.Drawing.Size(507, 264);
            this.pnl_1.TabIndex = 2;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(149, 14);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(336, 22);
            this.dateTimePicker1.TabIndex = 19;
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.btnXacNhan.Enabled = false;
            this.btnXacNhan.Location = new System.Drawing.Point(32, 196);
            this.btnXacNhan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(456, 52);
            this.btnXacNhan.TabIndex = 5;
            this.btnXacNhan.Text = "Xác nhận";
            this.btnXacNhan.UseVisualStyleBackColor = false;
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(28, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(73, 16);
            this.label10.TabIndex = 11;
            this.label10.Text = "Ngày nhập";
            // 
            // txt_countTable
            // 
            this.txt_countTable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_countTable.Location = new System.Drawing.Point(149, 101);
            this.txt_countTable.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_countTable.Name = "txt_countTable";
            this.txt_countTable.Size = new System.Drawing.Size(337, 22);
            this.txt_countTable.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(27, 145);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 16);
            this.label7.TabIndex = 16;
            this.label7.Text = "Tên nhân viên";
            // 
            // txt_nameGuest
            // 
            this.txt_nameGuest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_nameGuest.Location = new System.Drawing.Point(149, 57);
            this.txt_nameGuest.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_nameGuest.Name = "txt_nameGuest";
            this.txt_nameGuest.Size = new System.Drawing.Size(337, 22);
            this.txt_nameGuest.TabIndex = 18;
            this.txt_nameGuest.TextChanged += new System.EventHandler(this.txt_nameGuest_TextChanged);
            this.txt_nameGuest.Leave += new System.EventHandler(this.txt_nameGuest_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(27, 102);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 16);
            this.label8.TabIndex = 14;
            this.label8.Text = "Số bàn";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(27, 59);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(103, 16);
            this.label9.TabIndex = 13;
            this.label9.Text = "Tên khách hàng";
            // 
            // txt_nameStaff
            // 
            this.txt_nameStaff.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_nameStaff.Enabled = false;
            this.txt_nameStaff.Location = new System.Drawing.Point(149, 145);
            this.txt_nameStaff.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_nameStaff.Name = "txt_nameStaff";
            this.txt_nameStaff.Size = new System.Drawing.Size(337, 22);
            this.txt_nameStaff.TabIndex = 17;
            // 
            // pnl_5
            // 
            this.pnl_5.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pnl_5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_5.Controls.Add(this.btn_themMon);
            this.pnl_5.Controls.Add(this.label16);
            this.pnl_5.Controls.Add(this.txt_timKiemMon);
            this.pnl_5.Controls.Add(this.dgv_tenMon);
            this.pnl_5.Controls.Add(this.cob_loaiMon);
            this.pnl_5.Controls.Add(this.nud_soLuong);
            this.pnl_5.Controls.Add(this.txtTongTien);
            this.pnl_5.Controls.Add(this.label5);
            this.pnl_5.Controls.Add(this.label1);
            this.pnl_5.Controls.Add(this.label4);
            this.pnl_5.Controls.Add(this.txtGiaTri);
            this.pnl_5.Controls.Add(this.label2);
            this.pnl_5.Location = new System.Drawing.Point(1037, 103);
            this.pnl_5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnl_5.Name = "pnl_5";
            this.pnl_5.Size = new System.Drawing.Size(507, 653);
            this.pnl_5.TabIndex = 3;
            // 
            // btn_themMon
            // 
            this.btn_themMon.Location = new System.Drawing.Point(161, 587);
            this.btn_themMon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_themMon.Name = "btn_themMon";
            this.btn_themMon.Size = new System.Drawing.Size(201, 52);
            this.btn_themMon.TabIndex = 5;
            this.btn_themMon.Text = "Thêm món";
            this.btn_themMon.UseVisualStyleBackColor = true;
            this.btn_themMon.Click += new System.EventHandler(this.btn_themMon_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(27, 59);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(62, 16);
            this.label16.TabIndex = 17;
            this.label16.Text = "Tìm kiếm";
            // 
            // txt_timKiemMon
            // 
            this.txt_timKiemMon.Location = new System.Drawing.Point(113, 56);
            this.txt_timKiemMon.Name = "txt_timKiemMon";
            this.txt_timKiemMon.Size = new System.Drawing.Size(361, 22);
            this.txt_timKiemMon.TabIndex = 16;
            this.txt_timKiemMon.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // dgv_tenMon
            // 
            this.dgv_tenMon.AllowUserToAddRows = false;
            this.dgv_tenMon.AllowUserToDeleteRows = false;
            this.dgv_tenMon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_tenMon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_tenMon.ContextMenuStrip = this.contextMenuStrip3;
            this.dgv_tenMon.Location = new System.Drawing.Point(28, 101);
            this.dgv_tenMon.Name = "dgv_tenMon";
            this.dgv_tenMon.ReadOnly = true;
            this.dgv_tenMon.RowHeadersWidth = 51;
            this.dgv_tenMon.RowTemplate.Height = 24;
            this.dgv_tenMon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_tenMon.Size = new System.Drawing.Size(446, 306);
            this.dgv_tenMon.TabIndex = 15;
            // 
            // contextMenuStrip3
            // 
            this.contextMenuStrip3.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.đổiMónToolStripMenuItem});
            this.contextMenuStrip3.Name = "contextMenuStrip3";
            this.contextMenuStrip3.Size = new System.Drawing.Size(137, 28);
            // 
            // đổiMónToolStripMenuItem
            // 
            this.đổiMónToolStripMenuItem.Name = "đổiMónToolStripMenuItem";
            this.đổiMónToolStripMenuItem.Size = new System.Drawing.Size(136, 24);
            this.đổiMónToolStripMenuItem.Text = "Đổi món";
            this.đổiMónToolStripMenuItem.Click += new System.EventHandler(this.đổiMónToolStripMenuItem_Click_1);
            // 
            // cob_loaiMon
            // 
            this.cob_loaiMon.FormattingEnabled = true;
            this.cob_loaiMon.Location = new System.Drawing.Point(113, 13);
            this.cob_loaiMon.Name = "cob_loaiMon";
            this.cob_loaiMon.Size = new System.Drawing.Size(361, 24);
            this.cob_loaiMon.TabIndex = 12;
            this.cob_loaiMon.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // nud_soLuong
            // 
            this.nud_soLuong.Location = new System.Drawing.Point(126, 480);
            this.nud_soLuong.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nud_soLuong.Name = "nud_soLuong";
            this.nud_soLuong.Size = new System.Drawing.Size(137, 22);
            this.nud_soLuong.TabIndex = 11;
            this.nud_soLuong.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txtTongTien
            // 
            this.txtTongTien.Location = new System.Drawing.Point(125, 532);
            this.txtTongTien.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.Size = new System.Drawing.Size(349, 22);
            this.txtTongTien.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(40, 485);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "Số lượng";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Loại món";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 536);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Tổng tiền";
            // 
            // txtGiaTri
            // 
            this.txtGiaTri.Location = new System.Drawing.Point(126, 437);
            this.txtGiaTri.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtGiaTri.Name = "txtGiaTri";
            this.txtGiaTri.Size = new System.Drawing.Size(348, 22);
            this.txtGiaTri.TabIndex = 8;
            this.txtGiaTri.TextChanged += new System.EventHandler(this.txtGiaTri_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 440);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Giá trị";
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xóaMónToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(139, 28);
            // 
            // xóaMónToolStripMenuItem
            // 
            this.xóaMónToolStripMenuItem.Name = "xóaMónToolStripMenuItem";
            this.xóaMónToolStripMenuItem.Size = new System.Drawing.Size(138, 24);
            this.xóaMónToolStripMenuItem.Text = "Xóa món";
            this.xóaMónToolStripMenuItem.Click += new System.EventHandler(this.xóaMónToolStripMenuItem_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(196, 2);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 33);
            this.label6.TabIndex = 0;
            this.label6.Text = "Hóa đơn";
            // 
            // pnl_3
            // 
            this.pnl_3.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pnl_3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_3.Controls.Add(this.flp_Ban);
            this.pnl_3.Location = new System.Drawing.Point(11, 372);
            this.pnl_3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnl_3.Name = "pnl_3";
            this.pnl_3.Size = new System.Drawing.Size(507, 384);
            this.pnl_3.TabIndex = 2;
            // 
            // flp_Ban
            // 
            this.flp_Ban.AutoScroll = true;
            this.flp_Ban.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flp_Ban.Location = new System.Drawing.Point(3, 2);
            this.flp_Ban.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flp_Ban.Name = "flp_Ban";
            this.flp_Ban.Size = new System.Drawing.Size(503, 378);
            this.flp_Ban.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_doiban,
            this.hủyBànToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(134, 52);
            // 
            // tsmi_doiban
            // 
            this.tsmi_doiban.Name = "tsmi_doiban";
            this.tsmi_doiban.Size = new System.Drawing.Size(133, 24);
            this.tsmi_doiban.Text = "Đổi bàn";
            this.tsmi_doiban.Click += new System.EventHandler(this.đổiBànToolStripMenuItem_Click);
            // 
            // hủyBànToolStripMenuItem
            // 
            this.hủyBànToolStripMenuItem.Name = "hủyBànToolStripMenuItem";
            this.hủyBànToolStripMenuItem.Size = new System.Drawing.Size(133, 24);
            this.hủyBànToolStripMenuItem.Text = "Hủy bàn";
            this.hủyBànToolStripMenuItem.Click += new System.EventHandler(this.hủyBànToolStripMenuItem_Click);
            // 
            // pnl_4
            // 
            this.pnl_4.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pnl_4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_4.Controls.Add(this.btnInHoaDon);
            this.pnl_4.Controls.Add(this.btn_thanhToan);
            this.pnl_4.Controls.Add(this.dgv_thongTinHoaDon);
            this.pnl_4.Controls.Add(this.txt_TongTienHoaDon);
            this.pnl_4.Controls.Add(this.txt_GiamGia);
            this.pnl_4.Controls.Add(this.txt_thanhTien);
            this.pnl_4.Controls.Add(this.label14);
            this.pnl_4.Controls.Add(this.label13);
            this.pnl_4.Controls.Add(this.label12);
            this.pnl_4.Controls.Add(this.txtSoBan);
            this.pnl_4.Controls.Add(this.label11);
            this.pnl_4.Controls.Add(this.label6);
            this.pnl_4.Location = new System.Drawing.Point(524, 103);
            this.pnl_4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnl_4.Name = "pnl_4";
            this.pnl_4.Size = new System.Drawing.Size(507, 653);
            this.pnl_4.TabIndex = 4;
            // 
            // btnInHoaDon
            // 
            this.btnInHoaDon.Location = new System.Drawing.Point(275, 573);
            this.btnInHoaDon.Name = "btnInHoaDon";
            this.btnInHoaDon.Size = new System.Drawing.Size(207, 66);
            this.btnInHoaDon.TabIndex = 17;
            this.btnInHoaDon.Text = "In Hóa Đơn";
            this.btnInHoaDon.UseVisualStyleBackColor = true;
            this.btnInHoaDon.Click += new System.EventHandler(this.btnInHoaDon_Click);
            // 
            // dgv_thongTinHoaDon
            // 
            this.dgv_thongTinHoaDon.AllowUserToAddRows = false;
            this.dgv_thongTinHoaDon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_thongTinHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_thongTinHoaDon.ContextMenuStrip = this.contextMenuStrip2;
            this.dgv_thongTinHoaDon.Location = new System.Drawing.Point(30, 82);
            this.dgv_thongTinHoaDon.Name = "dgv_thongTinHoaDon";
            this.dgv_thongTinHoaDon.RowHeadersWidth = 51;
            this.dgv_thongTinHoaDon.RowTemplate.Height = 24;
            this.dgv_thongTinHoaDon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_thongTinHoaDon.Size = new System.Drawing.Size(454, 374);
            this.dgv_thongTinHoaDon.TabIndex = 16;
            // 
            // txt_TongTienHoaDon
            // 
            this.txt_TongTienHoaDon.Location = new System.Drawing.Point(121, 471);
            this.txt_TongTienHoaDon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_TongTienHoaDon.Name = "txt_TongTienHoaDon";
            this.txt_TongTienHoaDon.Size = new System.Drawing.Size(361, 22);
            this.txt_TongTienHoaDon.TabIndex = 12;
            // 
            // txt_GiamGia
            // 
            this.txt_GiamGia.Location = new System.Drawing.Point(121, 503);
            this.txt_GiamGia.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_GiamGia.Name = "txt_GiamGia";
            this.txt_GiamGia.Size = new System.Drawing.Size(361, 22);
            this.txt_GiamGia.TabIndex = 13;
            // 
            // txt_thanhTien
            // 
            this.txt_thanhTien.Location = new System.Drawing.Point(121, 533);
            this.txt_thanhTien.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_thanhTien.Name = "txt_thanhTien";
            this.txt_thanhTien.Size = new System.Drawing.Size(361, 22);
            this.txt_thanhTien.TabIndex = 14;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(25, 536);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(72, 16);
            this.label14.TabIndex = 15;
            this.label14.Text = "Thành tiền:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(25, 506);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(64, 16);
            this.label13.TabIndex = 14;
            this.label13.Text = "Giảm giá:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(25, 474);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(66, 16);
            this.label12.TabIndex = 13;
            this.label12.Text = "Tổng tiền:";
            // 
            // txtSoBan
            // 
            this.txtSoBan.Location = new System.Drawing.Point(67, 46);
            this.txtSoBan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSoBan.Name = "txtSoBan";
            this.txtSoBan.Size = new System.Drawing.Size(35, 22);
            this.txtSoBan.TabIndex = 12;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(23, 48);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(37, 16);
            this.label11.TabIndex = 12;
            this.label11.Text = "Bàn: ";
            // 
            // errBaoLoi
            // 
            this.errBaoLoi.ContainerControl = this;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "100-1000536_coffee-cup-icon-cup-of-coffee-icon-png.png");
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Red;
            this.label15.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label15.ImageIndex = 0;
            this.label15.Location = new System.Drawing.Point(481, 44);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(692, 39);
            this.label15.TabIndex = 5;
            this.label15.Text = "PHẦN MỀM QUẢN LÝ QUÁN CAFE";
            // 
            // mainApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1554, 759);
            this.Controls.Add(this.pnl_1);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.pnl_4);
            this.Controls.Add(this.pnl_3);
            this.Controls.Add(this.pnl_5);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "mainApp";
            this.Text = " Giao diện chính";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form_quanlyquancafe_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pnl_1.ResumeLayout(false);
            this.pnl_1.PerformLayout();
            this.pnl_5.ResumeLayout(false);
            this.pnl_5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_tenMon)).EndInit();
            this.contextMenuStrip3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nud_soLuong)).EndInit();
            this.contextMenuStrip2.ResumeLayout(false);
            this.pnl_3.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.pnl_4.ResumeLayout(false);
            this.pnl_4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_thongTinHoaDon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errBaoLoi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem tàiKhoảnToolStripMenuItem;
        private ToolStripMenuItem thôngTinCáNhânToolStripMenuItem;
        private ToolStripMenuItem đăngXuấtToolStripMenuItem;
        private ToolStripMenuItem quảnLýToolStripMenuItem;
        private Button btn_thanhToan;
        private Panel pnl_1;
        private Panel pnl_5;
        private Label label5;
        private TextBox txtGiaTri;
        private TextBox txtTongTien;
        private Label label4;
        private Label label2;
        private Label label1;
        private Panel pnl_3;
        private Panel pnl_4;
        private FlowLayoutPanel flp_Ban;
        private Label label10;
        private TextBox txt_countTable;
        private Label label7;
        private TextBox txt_nameGuest;
        private Label label8;
        private Label label9;
        private TextBox txt_nameStaff;
        private DateTimePicker dateTimePicker1;
        private Button btnXacNhan;
        private Label label6;
        private NumericUpDown nud_soLuong;
        private TextBox txtSoBan;
        private Label label11;
        private Label label14;
        private Label label13;
        private Label label12;
        private TextBox txt_thanhTien;
        private TextBox txt_GiamGia;
        private TextBox txt_TongTienHoaDon;
        private ErrorProvider errBaoLoi;
        private Label label15;
        private ImageList imageList1;
        private DataGridView dgv_thongTinHoaDon;
        private ComboBox cob_loaiMon;
        private DataGridView dgv_tenMon;
        private Label label16;
        private TextBox txt_timKiemMon;
        private Button btn_themMon;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem tsmi_doiban;
        private ToolStripMenuItem hủyBànToolStripMenuItem;
        private ContextMenuStrip contextMenuStrip2;
        private ToolStripMenuItem xóaMónToolStripMenuItem;
        private ContextMenuStrip contextMenuStrip3;
        private ToolStripMenuItem đổiMónToolStripMenuItem;
        private Button btnInHoaDon;
        private ToolStripMenuItem quảnLýKhoToolStripMenuItem;
    }
}