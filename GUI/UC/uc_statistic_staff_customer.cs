using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using GUI.FRM;
using DevExpress.XtraCharts;
using BUS;
using DAO;

namespace GUI.UC
{
    public partial class uc_statistic_staff_customer : DevExpress.XtraEditors.XtraUserControl
    {
        frmMain frm;
        bool checkTypeStatistic;
        public uc_statistic_staff_customer(frmMain frm)
        {
            InitializeComponent();
            this.frm = frm;
            loadDataCBBTypeStatistic(cbbTypeStatistic);
            dateStatistic.DateTime = DateTime.Now;
        }

        private void loadDataCBBTypeStatistic(ComboBoxEdit cbb)
        {
            cbbTypeStatistic.Properties.Items.Add("Chọn loại thống kê");
            cbbTypeStatistic.Properties.Items.Add("Thống kê theo tháng");
            cbbTypeStatistic.Properties.Items.Add("Thống kê theo năm");
            cbbTypeStatistic.SelectedIndex = 0;
        }


        

        private bool validateStatistic()
        {
            if (cbbTypeStatistic.SelectedIndex == 0)
            {
                XtraMessageBox.Show("Chưa chọn loại thống kê.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
            if (dateStatistic.DateTime.CompareTo(DateTime.Now) > 0)
            {
                XtraMessageBox.Show("Ngày chọn không hợp lệ.", "Thông báo");
                return true;
            }
            return false;
        }

        private void loadChartTop(ChartControl chart, string _title, DataTable data)
        {
            chart.Series.Clear();
            chart.Titles.Clear();
            Series _seri = new Series("", ViewType.Bar);
            ChartTitle title = new ChartTitle();
            title.Text = _title;
            _seri.ShowInLegend = true;
            chart.Titles.Add(title);
            chart.Series.Add(_seri);
            foreach (DataRow dr in data.Rows)
                _seri.Points.Add(new SeriesPoint(dr[0].ToString(), dr[1].ToString()));
            if (checkTypeStatistic)
                foreach (Series series in chart.Series)
                {
                    series.CrosshairLabelPattern = "{A}: {V:N0}";
                }
        }

        

       

        private void chartTopCustomer_CustomDrawAxisLabel(object sender, CustomDrawAxisLabelEventArgs e)
        {
            if (checkTypeStatistic)
            {
                try
                {
                    e.Item.Text = Support.convertVND(e.Item.Text);
                }
                catch (Exception ex)
                {

                }
            }
        }

        private void btnStatisticStaff_Click(object sender, EventArgs e)
        {
            if (validateStatistic())
                return;
            splashScreenManager1.ShowWaitForm();
            DataTable tb;
            checkTypeStatistic = false;
            if (cbbTypeStatistic.SelectedIndex == 1)
            {
                tb = ChartTopCustomerStaffBUS.loadTopStaffSell(false, dateStatistic.DateTime);
                loadChartTop(chartTopCustomer, "Top " + tb.Rows.Count + " nhân viên lập hoá đơn tháng "+dateStatistic.DateTime.Month+"/"+dateStatistic.DateTime.Year, tb);
            }
            else
            {
                tb = ChartTopCustomerStaffBUS.loadTopStaffSell(true, dateStatistic.DateTime);
                loadChartTop(chartTopCustomer, "Top " + tb.Rows.Count + " nhân viên lập hoá đơn năm " + dateStatistic.DateTime.Year, tb);
            }
            splashScreenManager1.CloseWaitForm();
        }

        private void btnStatisticalCustomer_Click(object sender, EventArgs e)
        {
            if (validateStatistic())
                return;
            splashScreenManager1.ShowWaitForm();
            DataTable tb;
            checkTypeStatistic = true;
            if (cbbTypeStatistic.SelectedIndex == 1)
            {
                tb = ChartTopCustomerStaffBUS.loadTopCustomerBuy(false, dateStatistic.DateTime);
                loadChartTop(chartTopCustomer, "Top " + tb.Rows.Count + " khách hàng mua tháng "+ dateStatistic.DateTime.Month+"/"+dateStatistic.DateTime.Year, tb);
            }
            else
            {
                tb = ChartTopCustomerStaffBUS.loadTopCustomerBuy(true, dateStatistic.DateTime);
                loadChartTop(chartTopCustomer, "Top " + tb.Rows.Count + " khách hàng mua năm " + dateStatistic.DateTime.Year, tb);
            }
            splashScreenManager1.CloseWaitForm();
        }
    }
}
