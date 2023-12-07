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
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraEditors.Controls;
using System.Globalization;
using GUI.FRM;

namespace GUI.UC
{
    public partial class uc_invoice : DevExpress.XtraEditors.XtraUserControl
    {
        frmMain frm;
        public uc_invoice(frmMain frm)
        {
            InitializeComponent();
            this.frm = frm;
        }
        //load form khi chạy lần đầu
        private void uc_order_employee_Load(object sender, EventArgs e)
        {
            //lấy danh sách khách hàng
            CustomerBUS.GetDataLk(cbbCustomer);
            //load danh sách hoá đơn chưa thanh toán
            InvoiceBUS.GetDataGV(gcOrder, false);
            MedicineBUS.GetDataLk(lkMedicine);
            gvOrderDetail.OptionsView.NewItemRowPosition = NewItemRowPosition.Top;
            gvOrder.IndicatorWidth = 50;
            gvOrderDetail.IndicatorWidth = 50;
        }
        //xoá data gridview chi tiết hoá đơn
        void clearDataGVOrderDetail()
        {
            gcOrderDetail.DataSource = null;
            layoutGroupOrderDetail.Enabled = txtTienKhachDua.Enabled = false;
            txtTienKhachDua.Text = txtTienThua.Text = txtTienPhaiTra.Text = "";

        }
        //đóng user control bán hàng
        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm._close();
        }
        //gọi các chi tiết của 1 hoá đơn có mã hoá đơn truyền vào
        private void callDataGVOrderDetail(int mahd)
        {
            InvoiceDetailBUS.GetDataGV(gcOrderDetail, mahd);
            MedicineBUS.GetDataLk(lkMedicine);
            layoutGroupOrderDetail.Enabled = txtTienKhachDua.Enabled = true;
            layoutGroupOrderDetail.Text = "Chi tiết hoá đơn " + mahd;
            txtTienPhaiTra.Text = Support.convertVND(gvOrder.GetRowCellValue(gvOrder.FocusedRowHandle, "total").ToString());
        }
        //click 1 dòng trong gridview hoá đơn
        private void gvOrder_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.RowHandle > -1)
                callDataGVOrderDetail(int.Parse(gvOrder.GetRowCellValue(e.RowHandle, "id").ToString()));
        }
        //tạo 1 hoá đơn mới cho khách hàng       
        private void btnCreateOrder_Click(object sender, EventArgs e)
        {
            var customerId = cbbCustomer.GetColumnValue("id");
            if (customerId == null)
                XtraMessageBox.Show("Vui lòng chọn khách hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                var model = new Invoice
                {
                    customerId = int.Parse(customerId.ToString()),
                    createDate = DateTime.Now,
                    isPay = false,
                    staffId = frm.staff.id,
                };
                int i = InvoiceBUS.Insert(model);
                if (i != -1)
                {
                    XtraMessageBox.Show("Tạo hoá đơn thành công.", "Thông báo");
                    InvoiceBUS.GetDataGV(gcOrder, false);
                    gvOrder.FocusedRowHandle = gvOrder.RowCount - 1;
                    callDataGVOrderDetail(InvoiceBUS.GetLast().id);
                }
            }
        }
        //huỷ 1 hoá đơn trong gridview hoá đơn
        private void destroyOrder()
        {
            var invoiceId = gvOrder.GetRowCellValue(gvOrder.FocusedRowHandle, "id");
            if (invoiceId != null)
            {
                if (XtraMessageBox.Show("Bạn chắc chắn huỷ hoá đơn " + invoiceId.ToString() + "?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    int i = InvoiceBUS.Delete(int.Parse(invoiceId.ToString()));
                    if (i != -1)
                    {
                        XtraMessageBox.Show("Huỷ hoá đơn thành công " + invoiceId.ToString() + ".", "Thông báo");
                        InvoiceBUS.GetDataGV(gcOrder, false);
                        clearDataGVOrderDetail();
                    }
                    else
                        XtraMessageBox.Show("Có lỗi xảy ra.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        //sự kiện gọi hàm huỷ hoá đơn
        private void btnDestroy_Click(object sender, EventArgs e)
        {
            destroyOrder();
        }
        //click nút delete xoá 1 dòng trong chi tiết hoá đơn
        private void gcOrderDetail_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && gvOrderDetail.State != GridState.Editing)
            {
                var invoiceId = gvOrderDetail.GetRowCellValue(gvOrderDetail.FocusedRowHandle, "invoiceId");
                var medicineId = gvOrderDetail.GetRowCellValue(gvOrderDetail.FocusedRowHandle, "medicineId");
                if (invoiceId != null)
                {
                    if (XtraMessageBox.Show("Bạn chắc chắn xoá thuốc " + MedicineBUS.FindById(int.Parse(medicineId.ToString())).name + "?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        int i = InvoiceDetailBUS.Delete(int.Parse(gvOrderDetail.GetRowCellValue(gvOrderDetail.FocusedRowHandle, "id").ToString()));
                        if (i != -1)
                        {
                            XtraMessageBox.Show("Xoá thành công.", "Thông báo");
                            InvoiceDetailBUS.GetDataGV(gcOrderDetail, int.Parse(invoiceId.ToString()));
                            InvoiceBUS.GetDataGV(gcOrder, false);
                            MedicineBUS.GetDataLk(lkMedicine);
                            callDataGVOrderDetail(int.Parse(invoiceId.ToString()));
                        }
                        else
                            XtraMessageBox.Show("Có lỗi xảy ra.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        //ngăn không cho thao tác khi thêm sửa 1 dòng trong bảng cthd khi dữ liệu sai
        private void gvOrderDetail_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }
        //thêm sửa 1 dòng trong bảng chi tiết hoá đơn
        private void gvOrderDetail_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            string sErr = "";
            bool bVali = true;
            if (gvOrderDetail.GetRowCellValue(e.RowHandle, "medicineId").ToString().Trim() == "")
            {
                bVali = false;
                sErr = "Vui lòng chọn thuốc.\n";
            }
            if (gvOrderDetail.GetRowCellValue(e.RowHandle, "quantity").ToString().Trim() == "")
            {
                bVali = false;
                sErr += "Vui lòng điền số lượng.\n";
            }
            if (bVali)
            {
                int quantity = int.Parse(gvOrderDetail.GetRowCellValue(e.RowHandle, "quantity").ToString().Trim());
                Medicine medicine = MedicineBUS.FindById(int.Parse(gvOrderDetail.GetRowCellValue(e.RowHandle, "medicineId").ToString().Trim()));
                if (quantity <= 0)
                {
                    bVali = false;
                    sErr += "Số lượng phải lớn hơn 0.\n";
                }
                //thêm mới
                if (e.RowHandle < 0)
                {
                    if (quantity > medicine.quantity)
                    {
                        bVali = false;
                        sErr += "Không đủ thuốc.\n";
                    }
                    if (!bVali)
                    {
                        e.Valid = false;
                        XtraMessageBox.Show(sErr, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    var model = new InvoiceDetail
                    {
                        invoiceId = int.Parse(gvOrder.GetRowCellValue(gvOrder.FocusedRowHandle, "id").ToString()),
                        medicineId = int.Parse(gvOrderDetail.GetRowCellValue(e.RowHandle, "medicineId").ToString().Trim()),
                        quantity = int.Parse(gvOrderDetail.GetRowCellValue(e.RowHandle, "quantity").ToString().Trim()),
                        price = MedicineBUS.FindById(int.Parse(gvOrderDetail.GetRowCellValue(e.RowHandle, "medicineId").ToString().Trim())).price,
                    };
                    int i = InvoiceDetailBUS.Insert(model);
                    if (i != -1)
                        XtraMessageBox.Show("Thêm thành công", "Thông báo", DevExpress.Utils.DefaultBoolean.True);
                    int row = gvOrder.FocusedRowHandle;
                    int invoiceId = int.Parse(gvOrder.GetRowCellValue(row, "id").ToString());
                    InvoiceBUS.GetDataGV(gcOrder, false);
                    gvOrder.FocusedRowHandle = row;
                    callDataGVOrderDetail(invoiceId);
                }
                //sửa 
                else
                {
                    InvoiceDetail invoidDetail = InvoiceDetailBUS.FindByID(int.Parse(gvOrderDetail.GetRowCellValue(gvOrder.FocusedRowHandle, "id").ToString()));
                    int quantityRemain = invoidDetail.quantity.Value + medicine.quantity;
                    if (quantity > quantityRemain)
                    {
                        bVali = false;
                        sErr += "Không đủ thuốc.\n";
                    }
                    if (!bVali)
                    {
                        e.Valid = false;
                        XtraMessageBox.Show(sErr, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    var model = new InvoiceDetail
                    {
                        id = int.Parse(gvOrderDetail.GetRowCellValue(gvOrderDetail.FocusedRowHandle, "id").ToString()),
                        invoiceId = int.Parse(gvOrder.GetRowCellValue(gvOrder.FocusedRowHandle, "id").ToString()),
                        medicineId = int.Parse(gvOrderDetail.GetRowCellValue(e.RowHandle, "medicineId").ToString().Trim()),
                        quantity = int.Parse(gvOrderDetail.GetRowCellValue(e.RowHandle, "quantity").ToString().Trim()),
                        price = MedicineBUS.FindById(int.Parse(gvOrderDetail.GetRowCellValue(e.RowHandle, "medicineId").ToString().Trim())).price,
                    };
                    InvoiceDetailBUS.Update(model);
                    int row = gvOrder.FocusedRowHandle;
                    int invoiceId = int.Parse(gvOrder.GetRowCellValue(row, "id").ToString());
                    InvoiceBUS.GetDataGV(gcOrder, false);
                    gvOrder.FocusedRowHandle = row;
                    callDataGVOrderDetail(invoiceId);
                }
            }
            else
            {
                e.Valid = false;
                XtraMessageBox.Show(sErr, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //thanh toán 1 hoá đơn
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (txtTienPhaiTra.Text.Trim().Length == 0)
            {
                XtraMessageBox.Show("Mời bạn chọn hoá đơn muốn thanh toán.", "Thông báo");
                return;
            }
            double tienPhaiTra = double.Parse(gvOrder.GetRowCellValue(gvOrder.FocusedRowHandle, "total").ToString());

            if (tienPhaiTra == 0)
            {
                XtraMessageBox.Show("Hoá đơn chưa có sản phẩm không cần thanh toán.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtTienKhachDua.Text.Trim().Length == 0)
            {
                XtraMessageBox.Show("Khách chưa đưa tiền.", "Thông báo");
                return;
            }
            double tienKhachDua = double.Parse(txtTienKhachDua.Text.Trim());

            if (tienPhaiTra > tienKhachDua)
            {
                XtraMessageBox.Show("Khách đưa không đủ tiền.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int i = InvoiceBUS.Update(int.Parse(gvOrder.GetRowCellValue(gvOrder.FocusedRowHandle, "id").ToString()), true);
            if (i != -1)
            {
                XtraMessageBox.Show("Thanh toán thành công.", "Thông báo");
                txtTienThua.Text = Support.convertVND((tienKhachDua - tienPhaiTra).ToString());
                InvoiceBUS.GetDataGV(gcOrder, false);
                clearDataGVOrderDetail();
            }

        }
        //chuyển về kiểu tiền tệ khi nhập tiền vào textbox
        private void txtTienKhachDua_KeyUp(object sender, KeyEventArgs e)
        {
            CultureInfo culture = new CultureInfo("en-US");
            decimal value;
            try
            {
                value = decimal.Parse(txtTienKhachDua.Text, NumberStyles.AllowThousands);

            }
            catch (Exception ex)
            {
                value = 0;
            }
            txtTienKhachDua.Text = String.Format(culture, "{0:N0}", value);
            txtTienKhachDua.Select(txtTienKhachDua.Text.Length, 0);
            decimal tienPhaiTra = decimal.Parse(gvOrder.GetRowCellValue(gvOrder.FocusedRowHandle, "total").ToString());
            txtTienThua.Text = Support.convertVND((value - tienPhaiTra).ToString());
        }
        //không cho nhập chữ vào ô textbox
        private void txtTienKhachDua_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }
        //xoá 1 hoá đơn bằng nút delete
        private void gcOrder_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            destroyOrder();
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
