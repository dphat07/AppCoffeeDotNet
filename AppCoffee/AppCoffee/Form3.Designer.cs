
namespace AppCoffee
{
    partial class BaoCaoDoanhThu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.label1 = new System.Windows.Forms.Label();
            this.chartdoanhthu = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chartdoanhthu)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(254, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(605, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "BÁO CÁO DOANH THU CÁC THÁNG";
            // 
            // chartdoanhthu
            // 
            chartArea2.Name = "ChartArea1";
            this.chartdoanhthu.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartdoanhthu.Legends.Add(legend2);
            this.chartdoanhthu.Location = new System.Drawing.Point(38, 89);
            this.chartdoanhthu.Name = "chartdoanhthu";
            this.chartdoanhthu.Size = new System.Drawing.Size(1059, 539);
            this.chartdoanhthu.TabIndex = 1;
            title2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title2.Name = "Title1";
            title2.Text = "Biểu đồ doanh thu các tháng";
            this.chartdoanhthu.Titles.Add(title2);
            this.chartdoanhthu.Click += new System.EventHandler(this.chart1_Click);
            // 
            // BaoCaoDoanhThu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1123, 669);
            this.Controls.Add(this.chartdoanhthu);
            this.Controls.Add(this.label1);
            this.Name = "BaoCaoDoanhThu";
            this.Text = "Báo Cáo Doanh Thu";
            this.Load += new System.EventHandler(this.Form3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartdoanhthu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartdoanhthu;
    }
}