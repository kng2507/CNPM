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
using DevExpress.XtraGrid.Views.Grid;
using GUI.FRM;
using DAO;
using GUI.Report;
using DevExpress.XtraReports.UI;

namespace GUI.UC
{
    public partial class uc_order : DevExpress.XtraEditors.XtraUserControl
    {
        List<InvoiceDetail> lstDetailOrder;
        frmMain frm;
        public uc_order(frmMain frm)
        {
            InitializeComponent();
            this.frm = frm;
        }
        //load data khi form khởi chạy
        private void uc_order_Load(object sender, EventArgs e)
        {
            InvoiceBUS.GetDataGV(gcOrder, true);
            gvOrder.IndicatorWidth = 50;
            gvOrderDetail.IndicatorWidth = 50;
        }
        //đóng form hoá đơn
        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm._close();
        }

        private void gvOrder_MasterRowEmpty(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowEmptyEventArgs e)
        {
            var invoidId = gvOrder.GetRowCellValue(e.RowHandle, "invoidId");
            if (invoidId != null)
                e.IsEmpty = InvoiceDetailBUS.GetDataGV(int.Parse(invoidId.ToString())).Count == 0;
        }

        private void gvOrder_MasterRowGetChildList(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowGetChildListEventArgs e)
        {
            var invoiceId = gvOrder.GetRowCellValue(e.RowHandle, "id");
            if (invoiceId != null)
            {
                e.ChildList = InvoiceDetailBUS.GetDataGV(int.Parse(invoiceId.ToString()));

                gvOrderDetail.ViewCaption = "Chi tiết hoá đơn " + invoiceId.ToString();

            }
        }

        private void gvOrder_MasterRowGetRelationCount(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationCountEventArgs e)
        {
            e.RelationCount = 1;
        }

        private void gvOrder_MasterRowGetRelationName(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationNameEventArgs e)
        {
            e.RelationName = "Chi tiết hoá đơn";
        }
      
        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int row = gvOrder.FocusedRowHandle;
            if (row >= 0)
            {
                int invoiceId = int.Parse(gvOrder.GetRowCellValue(row, "id").ToString());
                lstDetailOrder = InvoiceDetailBUS.GetDataGV(invoiceId);
                Invoice invoice = InvoiceBUS.FindById(invoiceId);
                var rp = new rpOrder();
                rp.DataSource = lstDetailOrder;
                rp.lbNguoiLap.Value = frm.staff.name;
                rp.lbCodeOrder.Value = "BÁO CÁO HOÁ ĐƠN " + invoiceId;
                rp.lbCustomer.Value = invoice.Customer.name;
                rp.lbDate.Value = invoice.createDate;
                rp.lbStaff.Value = invoice.Staff.name;
                rp.lbTienPhaiTra.Value = invoice.total;
                rp.ShowPreviewDialog();

            }
        }

        private void gvOrder_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (!e.Info.IsRowIndicator || e.RowHandle < 0)
                return;
            e.Info.DisplayText = (e.RowHandle + 1) + "";
        }

        private void gvOrderDetail_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (!e.Info.IsRowIndicator || e.RowHandle < 0)
                return;
            e.Info.DisplayText = (e.RowHandle + 1) + "";
        }
    }
}
