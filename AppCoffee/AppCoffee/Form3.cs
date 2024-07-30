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
    public partial class BaoCaoDoanhThu : Form
    {
        public BaoCaoDoanhThu()
        {
            InitializeComponent();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            var series = new System.Windows.Forms.DataVisualization.Charting.Series
            {
                Name = "Tổng tiền", // Tên của chuỗi dữ liệu
                ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column // Loại biểu đồ (line chart, column chart, bar chart, etc.)
            };
            series.Points.AddXY("tháng 1", 1000000);
            series.Points.AddXY("tháng 2", 2000000);
            series.Points.AddXY("tháng 3", 3000000);
            series.Points.AddXY("tháng 4", 4000000);
            series.Points.AddXY("tháng 5", 5000000);
            series.Points.AddXY("tháng 6", 6000000);
            series.Points.AddXY("tháng 7", 7000000);
            series.Points.AddXY("tháng 8", 8000000);
            series.Points.AddXY("tháng 9", 9000000);
            series.Points.AddXY("tháng 10", 10000000);
            series.Points.AddXY("tháng 11", 11000000);
            series.Points.AddXY("tháng 12", 12000000);
            // Thêm nhiều điểm dữ liệu khác nếu cần

            // Thêm chuỗi dữ liệu vào biểu đồ
            chartdoanhthu.Series.Add(series);
        }
    }
}
