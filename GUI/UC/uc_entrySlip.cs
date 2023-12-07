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
using DAO;
using DevExpress.XtraEditors.Controls;
using GUI.FRM;
using DevExpress.XtraEditors.Repository;

namespace GUI.UC
{
    public partial class uc_entrySlip : DevExpress.XtraEditors.XtraUserControl
    {
        frmMain frm;
        public uc_entrySlip(frmMain frm)
        {
            InitializeComponent();
            this.frm = frm;
        }
        //load data khi form khởi chạy
        private void uc_import_employee_Load(object sender, EventArgs e)
        {
            //load danh sách hoá đơn chưa thanh toán
            EntrySlipBUS.GetDataGV(gcImport, false);
            SupplierBUS.GetDataLk(lkSupplier);
            gvImportDetail.OptionsView.NewItemRowPosition = NewItemRowPosition.Top;
            gvImport.IndicatorWidth = 50;
            gvImportDetail.IndicatorWidth = 50;
        }
        //xoá data gridview chi tiết nhập kho
        void clearDataGVImportDetail()
        {
            gcImportDetail.DataSource = null;
            layoutGroupImportDetail.Enabled = false;
            txtTienPhaiTra.Text = "";

        }
        //đóng form nhập hàng
        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm._close();
        }
        //gọi các chi tiết của 1 phiếu nhập có mã phiếu nhập truyền vào
        private void callDataGVImportDetail(int entrySlipId, int supplierId)
        {
            EntrySlipDetailBUS.GetDataGV(gcImportDetail, entrySlipId);
            MedicineBUS.GetDataLk(lkMedicine, supplierId);
            layoutGroupImportDetail.Enabled = true;
            layoutGroupImportDetail.Text = "Chi tiết phiếu nhập " + entrySlipId;
            txtTienPhaiTra.Text = Support.convertVND(gvImport.GetRowCellValue(gvImport.FocusedRowHandle, "total").ToString());
        }
        //click 1 dòng trong gridview nhập kho
        private void gvImport_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            var entrySlipId = int.Parse(gvImport.GetRowCellValue(e.RowHandle, "id").ToString());
            var supplierId = int.Parse(gvImport.GetRowCellValue(e.RowHandle, "supplierId").ToString());
            if (e.RowHandle > -1)
                callDataGVImportDetail(entrySlipId, supplierId);
        }
        //tạo 1 hoá đơn mới cho khách hàng       
        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                var supplierId = int.Parse(lkSupplier.EditValue.ToString());
                var model = new EntrySlip
                {
                    staffId = frm.staff.id,
                    createDate = DateTime.Now,
                    isPay = false,
                    supplierId = supplierId,
                };
                int i = EntrySlipBUS.Insert(model);
                if (i != -1)
                {
                    XtraMessageBox.Show("Tạo phiếu nhập thành công.", "Thông báo");
                    EntrySlipBUS.GetDataGV(gcImport, false);
                    gvImport.FocusedRowHandle = gvImport.RowCount - 1;
                    callDataGVImportDetail(EntrySlipBUS.GetLast().id, supplierId);
                }
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show("Bạn chưa chọn nhà cung cấp", "Thông báo");
            }
           
        }
        //huỷ 1 phiếu trong gridview nhập kho
        private void destroyImport()
        {
            var entrySlipId = gvImport.GetRowCellValue(gvImport.FocusedRowHandle, "id");
            var supplierId = gvImport.GetRowCellValue(gvImport.FocusedRowHandle, "supplierId");
            if (entrySlipId != null)
            {
                if (XtraMessageBox.Show("Bạn chắc chắn huỷ phiếu nhập " + entrySlipId.ToString() + "?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    int i = EntrySlipBUS.Delete(int.Parse(entrySlipId.ToString()));
                    if (i != -1)
                    {
                        XtraMessageBox.Show("Huỷ phiếu nhập thành công " + entrySlipId + ".", "Thông báo");
                        EntrySlipBUS.GetDataGV(gcImport, false);
                        clearDataGVImportDetail();
                    }
                    else
                        XtraMessageBox.Show("Có lỗi xảy ra.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        //sự kiện gọi hàm huỷ phiếu nhập
        private void btnDestroy_Click(object sender, EventArgs e)
        {
            destroyImport();
        }
        //click nút delete xoá 1 dòng trong chi tiết hoá đơn
        private void gcImportDetail_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && gvImportDetail.State != GridState.Editing)
            {
                var entrySlipId = gvImportDetail.GetRowCellValue(gvImportDetail.FocusedRowHandle, "entrySlipId");
                var supplierId = gvImport.GetRowCellValue(gvImportDetail.FocusedRowHandle, "supplierId");
                var medicineId = gvImportDetail.GetRowCellValue(gvImportDetail.FocusedRowHandle, "medicineId");
                if (entrySlipId != null)
                {
                    if (XtraMessageBox.Show("Bạn chắc chắn xoá thuốc " + MedicineBUS.FindById(int.Parse(medicineId.ToString())).name + "?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        int i = EntrySlipDetailBUS.Delete(int.Parse(gvImportDetail.GetRowCellValue(gvImportDetail.FocusedRowHandle, "id").ToString()));
                        if (i != -1)
                        {
                            XtraMessageBox.Show("Xoá thành công.", "Thông báo");
                            EntrySlipDetailBUS.GetDataGV(gcImportDetail, int.Parse(entrySlipId.ToString()));
                            EntrySlipBUS.GetDataGV(gcImport, false);
                            callDataGVImportDetail(int.Parse(entrySlipId.ToString()), int.Parse(supplierId.ToString()));

                        }
                        else
                            XtraMessageBox.Show("Có lỗi xảy ra.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        //ngăn không cho thao tác khi thêm sửa 1 dòng trong bảng ctnk khi dữ liệu sai
        private void gvImportDetail_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }
        //thêm sửa 1 dòng trong bảng chi tiết nhập kho
        private void gvImportDetail_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            string sErr = "";
            bool bVali = true;
            if (gvImportDetail.GetRowCellValue(e.RowHandle, "medicineId").ToString().Trim() == "")
            {
                bVali = false;
                sErr = "Vui lòng chọn thuốc.\n";
            }
            if (gvImportDetail.GetRowCellValue(e.RowHandle, "quantity").ToString().Trim() == "")
            {
                bVali = false;
                sErr += "Vui lòng điền số lượng.\n";
            }
            if (gvImportDetail.GetRowCellValue(e.RowHandle, "price").ToString().Trim() == "")
            {
                bVali = false;
                sErr += "Vui lòng điền đơn giá.\n";

            }
            else
              if (int.Parse(gvImportDetail.GetRowCellValue(e.RowHandle, "price").ToString().Trim()) <= 0)
            {
                bVali = false;
                sErr += "Đơn giá phải lớn hơn 0.\n";
            }

            if (bVali)
            {
                //thêm mới
                if (e.RowHandle < 0)
                {

                    if (int.Parse(gvImportDetail.GetRowCellValue(e.RowHandle, "quantity").ToString().Trim()) <= 0)
                    {
                        bVali = false;
                        sErr += "Số lượng phải lớn hơn 0.\n";
                    }

                    if (!bVali)
                    {
                        e.Valid = false;
                        XtraMessageBox.Show(sErr, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    var model = new EntrySlipDetail
                    {
                        entrySlipId = int.Parse(gvImport.GetRowCellValue(gvImport.FocusedRowHandle, "id").ToString()),
                        medicineId = int.Parse(gvImportDetail.GetRowCellValue(e.RowHandle, "medicineId").ToString().Trim()),
                        quantity = int.Parse(gvImportDetail.GetRowCellValue(e.RowHandle, "quantity").ToString().Trim()),
                        price = double.Parse(gvImportDetail.GetRowCellValue(e.RowHandle, "price").ToString().Trim())
                    };
                    int i = EntrySlipDetailBUS.Insert(model);
                    if (i != -1)
                        XtraMessageBox.Show("Thêm thành công", "Thông báo", DevExpress.Utils.DefaultBoolean.True);
                    int row = gvImport.FocusedRowHandle;
                    int entrySlipId = int.Parse(gvImport.GetRowCellValue(row, "id").ToString());
                    int supplierId = int.Parse(gvImport.GetRowCellValue(row, "supplierId").ToString());
                    gvImport.FocusedRowHandle = row;
                    EntrySlipBUS.GetDataGV(gcImport, false);
                    callDataGVImportDetail(entrySlipId, supplierId);
                }
                //sửa 
                else
                {
                    var model = new EntrySlipDetail
                    {
                        id = int.Parse(gvImportDetail.GetRowCellValue(e.RowHandle, "id").ToString().Trim()),
                        entrySlipId = int.Parse(gvImport.GetRowCellValue(gvImport.FocusedRowHandle, "id").ToString()),
                        medicineId = int.Parse(gvImportDetail.GetRowCellValue(e.RowHandle, "medicineId").ToString().Trim()),
                        quantity = int.Parse(gvImportDetail.GetRowCellValue(e.RowHandle, "quantity").ToString().Trim()),
                        price = double.Parse(gvImportDetail.GetRowCellValue(e.RowHandle, "price").ToString().Trim())
                    };
                    EntrySlipDetailBUS.Update(model);
                    int row = gvImport.FocusedRowHandle;
                    int entrySlipId = int.Parse(gvImport.GetRowCellValue(row, "id").ToString());
                    int supplierId = int.Parse(gvImport.GetRowCellValue(row, "supplierId").ToString());
                    EntrySlipBUS.GetDataGV(gcImport, false);
                    gvImport.FocusedRowHandle = row;
                    callDataGVImportDetail(entrySlipId, supplierId);

                }
            }
            else
            {
                e.Valid = false;
                XtraMessageBox.Show(sErr, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //thanh toán 1 phiếu nhập
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (txtTienPhaiTra.Text.Trim().Length == 0)
            {
                XtraMessageBox.Show("Mời bạn chọn phiếu nhập muốn thanh toán.", "Thông báo");
                return;
            }
            double tienPhaiTra = double.Parse(gvImport.GetRowCellValue(gvImport.FocusedRowHandle, "total").ToString());

            if (tienPhaiTra == 0)
            {
                XtraMessageBox.Show("Phiếu nhập chưa có sản phẩm không cần thanh toán.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int i = EntrySlipBUS.Update(int.Parse(gvImport.GetRowCellValue(gvImport.FocusedRowHandle, "id").ToString()), true);
            if (i != -1)
            {
                XtraMessageBox.Show("Thanh toán thành công.", "Thông báo");
                EntrySlipBUS.GetDataGV(gcImport, false);
                clearDataGVImportDetail();
            }
        }
        //xoá 1 phiếu nhập bằng nút delete
        private void gcImport_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            destroyImport();
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
