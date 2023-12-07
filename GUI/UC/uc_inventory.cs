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
using BUS;
using DAO;
using GUI.FRM;
using GUI.Report;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.Parameters;
namespace GUI.UC
{
    public partial class uc_inventory : DevExpress.XtraEditors.XtraUserControl
    {
        DataTable tb;
        frmMain frm;
        public uc_inventory(frmMain frm)
        {
            InitializeComponent();
            this.frm = frm;
            gvInventory.IndicatorWidth = 50;
            dateFrom.DateTime = DateTime.Now;
            dateTo.DateTime = DateTime.Now;
        }

        private void btnDong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm._close();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            if(DateTime.Parse(dateFrom.DateTime.ToShortDateString()).CompareTo(DateTime.Parse(dateTo.DateTime.ToShortDateString())) >0)
            {
                XtraMessageBox.Show("Ngày tìm không hợp lệ.", "Thông báo");
                return;
            }
            var quantityEntrySlip = InventoryBUS.QuantityEntrySlip(dateFrom.DateTime, dateTo.DateTime);
            var quantityInvoice = InventoryBUS.QuantityInvoice(dateFrom.DateTime, dateTo.DateTime);
            txtLuongNhap.Text = Support.convertVND(quantityEntrySlip.ToString());
            txtLuongBan.Text = Support.convertVND(quantityInvoice.ToString());
            tb= InventoryBUS.loadDetailInventory(gcInventory, dateFrom.DateTime, dateTo.DateTime);

        }

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (tb == null || tb.Rows.Count == 0)
                return;
            var rp = new rpInventory();
            rp.DataSource = tb;
            rp.lbNguoiLap.Value =frm.staff.name;
            rp.ShowPreviewDialog();
        }

        private void gvInventory_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (!e.Info.IsRowIndicator || e.RowHandle < 0)
                return;
            e.Info.DisplayText = (e.RowHandle + 1) + "";
        }
    }
}
