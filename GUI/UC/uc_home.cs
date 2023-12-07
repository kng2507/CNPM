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
using System.Data;
using System.Globalization;
using DAO;

namespace GUI.UC
{
    public partial class uc_home : DevExpress.XtraEditors.XtraUserControl
    {
        frmMain frm;
        public uc_home(frmMain frm)
        {
            InitializeComponent();
            this.frm = frm;
        }

        private void uc_home_Load(object sender, EventArgs e)
        {
            //load biểu đồ doanh thu năm hiện tại
            loadStatisticalYear();
            //load biểu đồ lượng nhập vào bán ra tháng hiện tại
            loadQuantityImportAndOrder();
            //load biểu đồ top sản phẩm bán chạy (số lượng bán >=30)
            loadTopProductSelling();
            //load biểu đồ các sản phẩm hết hàng
            loadProductsNotStock();
        }

        private void loadProductsNotStock()
        {
            Series _seri = new Series("Thuốc", ViewType.Area);
            ChartTitle title = new ChartTitle();
            title.Text = "Các thuốc sắp hoặc đã hết hàng";
            chartNotStock.Titles.Add(title);
            chartNotStock.Series.Add(_seri);
            foreach (DataRow dr in ChartBUS.loadProductNotStock().Rows)
                _seri.Points.Add(new SeriesPoint(dr[0].ToString(), dr[1].ToString()));
        }

        private void loadTopProductSelling()
        {
            Series _seri = new Series("Thuốc", ViewType.Bar);
            ChartTitle title = new ChartTitle();
            title.Text = "Top thuốc bán chạy tháng " + DateTime.Now.Month + "/" + DateTime.Now.Year;
            _seri.ShowInLegend = true;
            chartTopSelling.Titles.Add(title);
            chartTopSelling.Series.Add(_seri);
            foreach (DataRow dr in ChartBUS.loadTopSelling().Rows)
                _seri.Points.Add(new SeriesPoint(dr[0].ToString(), dr[1].ToString()));
        }

        private void loadQuantityImportAndOrder()
        {
            Series _seri = new Series("Hoá đơn, phiếu nhập", ViewType.Doughnut);
            ChartTitle title = new ChartTitle();
            title.Text = "Hoá đơn, phiếu nhập tháng " + DateTime.Now.Month + "/" + DateTime.Now.Year;
            chartQuantityImportOrder.Titles.Add(title);
            chartQuantityImportOrder.Series.Add(_seri);
            foreach (DataRow dr in ChartBUS.loadInvoiceAndEntrySlipMonthNow().Rows)
            {
                _seri.Points.Add(new SeriesPoint(dr[0].ToString(), dr[1].ToString().Equals("") ? "0" : dr[1].ToString()));
            }
            _seri.Label.TextPattern = "{A}: {V}";
        }

        private void loadStatisticalYear()
        {
            Series _seri = new Series("Doanh thu", ViewType.Pie);
            ChartTitle title = new ChartTitle();
            title.Text = "Doanh thu năm " + DateTime.Now.Year;
            chartStatistical.Titles.Add(title);
            foreach (DataRow dr in ChartBUS.loadStatisticalYear().Rows)
            _seri.Points.Add(new SeriesPoint(dr[0].ToString(), dr[1].ToString().Equals("")?"0": dr[1].ToString()));
            _seri.ShowInLegend = true;
            _seri.Label.TextPattern = "{A}: {V: N0}";
            chartStatistical.Series.Add(_seri);
        }
    }
}
