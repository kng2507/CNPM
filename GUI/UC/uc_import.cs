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
    public partial class uc_import : DevExpress.XtraEditors.XtraUserControl
    {
        frmMain frm;
        List<EntrySlipDetail> lstDetailImport;

        public uc_import(frmMain frm)
        {
            InitializeComponent();
            this.frm = frm;
        }
        //load data khi form khởi chạy
        private void uc_import_Load(object sender, EventArgs e)
        {
            EntrySlipBUS.GetDataGV(gcImport, true);
            gvImport.IndicatorWidth = 50;
            gvImportDetail.IndicatorWidth = 50;
        }
        //đóng form
        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm._close();
        }

        private void gvImport_MasterRowEmpty(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowEmptyEventArgs e)
        {
            var id = gvImport.GetRowCellValue(e.RowHandle, "id");
            if (id != null)
                e.IsEmpty = EntrySlipDetailBUS.GetDataGV(int.Parse(id.ToString())).Count == 0;
        }

        private void gvImport_MasterRowGetChildList(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowGetChildListEventArgs e)
        {
            var id = gvImport.GetRowCellValue(e.RowHandle, "id");
            if (id != null)
            {
                e.ChildList = EntrySlipDetailBUS.GetDataGV(int.Parse(id.ToString()));
                gvImportDetail.ViewCaption = "Chi tiết phiếu nhập " + id;
            }
        }

        private void gvImport_MasterRowGetRelationCount(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationCountEventArgs e)
        {
            e.RelationCount = 1;
        }

        private void gvImport_MasterRowGetRelationName(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationNameEventArgs e)
        {
            e.RelationName = "Chi tiết phiếu nhập";
        }


        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int row = gvImport.FocusedRowHandle;
            if (row >= 0)
            {
                int entrySlipId = int.Parse(gvImport.GetRowCellValue(row, "id").ToString());
                lstDetailImport = EntrySlipDetailBUS.GetDataGV(entrySlipId);
                EntrySlip es =EntrySlipBUS.FindById(entrySlipId);
                var rp = new rpImport();
                rp.DataSource = lstDetailImport;
                rp.lbNguoiLap.Value = frm.staff.name;
                rp.lbCodeImport.Value = "BÁO CÁO PHIẾU NHẬP " + entrySlipId;
                rp.lbDate.Value = es.createDate;
                rp.lbStaff.Value = es.Staff.name;
                rp.lbSupplier.Value = es.Supplier.name;
                rp.ShowPreviewDialog();
            }
        }

        private void gvImport_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (!e.Info.IsRowIndicator || e.RowHandle < 0)
                return;
            e.Info.DisplayText = (e.RowHandle + 1) + "";
        }

        private void gvImportDetail_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {

            if (!e.Info.IsRowIndicator || e.RowHandle < 0)
                return;
            e.Info.DisplayText = (e.RowHandle + 1) + "";
        }
    }
}
