namespace GUI.UC
{
    partial class uc_statistic_staff_customer
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::GUI.FRM.WaitForm1), true, true, typeof(System.Windows.Forms.UserControl));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btnStatisticStaff = new DevExpress.XtraEditors.SimpleButton();
            this.btnStatisticalCustomer = new DevExpress.XtraEditors.SimpleButton();
            this.dateStatistic = new DevExpress.XtraEditors.DateEdit();
            this.cbbTypeStatistic = new DevExpress.XtraEditors.ComboBoxEdit();
            this.chartTopCustomer = new DevExpress.XtraCharts.ChartControl();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateStatistic.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateStatistic.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbTypeStatistic.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTopCustomer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            this.SuspendLayout();
            // 
            // splashScreenManager1
            // 
            this.splashScreenManager1.ClosingDelay = 500;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.btnStatisticStaff);
            this.layoutControl1.Controls.Add(this.btnStatisticalCustomer);
            this.layoutControl1.Controls.Add(this.dateStatistic);
            this.layoutControl1.Controls.Add(this.cbbTypeStatistic);
            this.layoutControl1.Controls.Add(this.chartTopCustomer);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(794, 437);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // btnStatisticStaff
            // 
            this.btnStatisticStaff.Location = new System.Drawing.Point(24, 154);
            this.btnStatisticStaff.Name = "btnStatisticStaff";
            this.btnStatisticStaff.Size = new System.Drawing.Size(359, 32);
            this.btnStatisticStaff.StyleController = this.layoutControl1;
            this.btnStatisticStaff.TabIndex = 8;
            this.btnStatisticStaff.Text = "Thống kê nhân viên";
            this.btnStatisticStaff.Click += new System.EventHandler(this.btnStatisticStaff_Click);
            // 
            // btnStatisticalCustomer
            // 
            this.btnStatisticalCustomer.Location = new System.Drawing.Point(24, 118);
            this.btnStatisticalCustomer.Name = "btnStatisticalCustomer";
            this.btnStatisticalCustomer.Size = new System.Drawing.Size(359, 32);
            this.btnStatisticalCustomer.StyleController = this.layoutControl1;
            this.btnStatisticalCustomer.TabIndex = 7;
            this.btnStatisticalCustomer.Text = "Thống kê khách hàng";
            this.btnStatisticalCustomer.Click += new System.EventHandler(this.btnStatisticalCustomer_Click);
            // 
            // dateStatistic
            // 
            this.dateStatistic.EditValue = null;
            this.dateStatistic.Location = new System.Drawing.Point(159, 86);
            this.dateStatistic.Name = "dateStatistic";
            this.dateStatistic.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateStatistic.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateStatistic.Size = new System.Drawing.Size(224, 28);
            this.dateStatistic.StyleController = this.layoutControl1;
            this.dateStatistic.TabIndex = 6;
            // 
            // cbbTypeStatistic
            // 
            this.cbbTypeStatistic.Location = new System.Drawing.Point(159, 54);
            this.cbbTypeStatistic.Name = "cbbTypeStatistic";
            this.cbbTypeStatistic.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbbTypeStatistic.Size = new System.Drawing.Size(224, 28);
            this.cbbTypeStatistic.StyleController = this.layoutControl1;
            this.cbbTypeStatistic.TabIndex = 5;
            // 
            // chartTopCustomer
            // 
            this.chartTopCustomer.Legend.Name = "Default Legend";
            this.chartTopCustomer.Location = new System.Drawing.Point(399, 12);
            this.chartTopCustomer.Name = "chartTopCustomer";
            this.chartTopCustomer.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            this.chartTopCustomer.Size = new System.Drawing.Size(383, 413);
            this.chartTopCustomer.TabIndex = 4;
            this.chartTopCustomer.CustomDrawAxisLabel += new DevExpress.XtraCharts.CustomDrawAxisLabelEventHandler(this.chartTopCustomer_CustomDrawAxisLabel);
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlGroup1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(794, 437);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.chartTopCustomer;
            this.layoutControlItem1.Location = new System.Drawing.Point(387, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(387, 417);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(387, 417);
            this.layoutControlGroup1.Text = "Bảng điều khiển";
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.cbbTypeStatistic;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(363, 32);
            this.layoutControlItem2.Text = "Chọn loại thống kê";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(132, 20);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.dateStatistic;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 32);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(363, 32);
            this.layoutControlItem3.Text = "Chọn tháng,năm";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(132, 20);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.btnStatisticalCustomer;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 64);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(363, 36);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.btnStatisticStaff;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 100);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(363, 263);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // uc_statistic_staff_customer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Name = "uc_statistic_staff_customer";
            this.Size = new System.Drawing.Size(794, 437);
            this.Tag = "Thống kê top nhân viên,khách hàng";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dateStatistic.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateStatistic.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbTypeStatistic.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTopCustomer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraCharts.ChartControl chartTopCustomer;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.ComboBoxEdit cbbTypeStatistic;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.DateEdit dateStatistic;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.SimpleButton btnStatisticStaff;
        private DevExpress.XtraEditors.SimpleButton btnStatisticalCustomer;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
    }
}
