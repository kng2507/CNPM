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
using DevExpress.Utils;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;
using System.IO;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraEditors.ViewInfo;
using System.Reflection;
using DevExpress.Utils.Menu;
using GUI.FRM;
using DAO;

namespace GUI.UC
{
    public partial class uc_customer : DevExpress.XtraEditors.XtraUserControl
    {
        private frmMain frm;
        private ImageCollection images = new ImageCollection(); //{ ImageSize=new Size(20, 20) };
        private OpenFileDialog open;
        public uc_customer(frmMain frm)
        {
            InitializeComponent();
            this.frm = frm;

        }

        private void btnDong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm._close();
        }

        private void uc_staff_Load(object sender, EventArgs e)
        {
            CustomerBUS.GetDataGV(gcCustomer);
            gvCustomer.OptionsView.NewItemRowPosition = NewItemRowPosition.Top;
            gvCustomer.IndicatorWidth = 50;
        }
        #region khách hàng
        //xoá khách hàng
        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataRow dr = gvCustomer.GetFocusedDataRow();
            if (dr != null)
            {
                if (XtraMessageBox.Show("Bạn có muốn xoá khách hàng " + dr["name"].ToString() + " ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int i = CustomerBUS.Delete(int.Parse(dr["id"].ToString()));
                    if (i == 1)
                    {
                        XtraMessageBox.Show("Xoá thành công", "Thông báo");
                        CustomerBUS.GetDataGV(gcCustomer);
                    }
                    else
                        XtraMessageBox.Show("Có lỗi xảy ra.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }

        }
        //load hình ảnh
        private void gvCustomer_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
        {
            if (e.Column.FieldName == "image")
            {

                try
                {

                    Image img = Image.FromFile("../../Images/" + gvCustomer.GetDataRow(e.RowHandle)["image"].ToString());
                    images.Images.Clear();
                    images.Images.Add(img);
                }
                catch (Exception ex)
                {

                    Image img = Image.FromFile("../../Images/loadImg.png");
                    images.Images.Clear();
                    //    images.ImageSize = new Size(100, 100);

                    images.Images.Add(img);
                }

                imageCustomer.Images = images;
            }
        }
        //thay đổi hình ảnh khách hàng
        private void imageCustomer_Click(object sender, EventArgs e)
        {
            open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(open.FileName);
                if (!File.Exists("../../Images/" + open.SafeFileName))
                {
                    pictureBox1.Image.Save("../../Images/" + open.SafeFileName);
                }
                try
                {
                    DataRow dr = gvCustomer.GetFocusedDataRow();
                    var model = new Customer
                    {
                        id = int.Parse(dr["id"].ToString().Trim()),
                        name = dr["name"].ToString().Trim(),
                        address = dr["address"].ToString().Trim(),
                        image = open.SafeFileName,
                        phone = dr["phone"].ToString().Trim(),
                    };
                    int i = CustomerBUS.Update(model);
                    if (i == 1)
                        CustomerBUS.GetDataGV(gcCustomer);
                    else
                        XtraMessageBox.Show("Có lỗi xảy ra.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    open = null;
                }
                catch (Exception)
                {

                }
            }
        }
        //phím delete xoá khách hàng
        private void gcCustomer_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && gvCustomer.State != GridState.Editing)
            {
                DataRow dr = gvCustomer.GetFocusedDataRow();
                if (dr != null)
                {
                    if (XtraMessageBox.Show("Bạn có muốn xoá khách hàng " + dr["name"].ToString() + " ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int id = int.Parse(dr["id"].ToString());

                        int i = CustomerBUS.Delete(id);
                        if (i == 1)
                        {
                            XtraMessageBox.Show("Xoá thành công", "Thông báo");
                            CustomerBUS.GetDataGV(gcCustomer);
                        }
                        else
                            XtraMessageBox.Show("Có lỗi xảy ra.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
            }
        }
        //ngăn ko cho chuyển dòng khi sai dữ liệu khách hàng
        private void gvCustomer_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }
        //thêm sửa dữ liệu khách hàng
        private void gvCustomer_ValidateRow(object sender, ValidateRowEventArgs e)
        {
            string sErr = "";
            bool bVali = true;
            if (gvCustomer.GetRowCellValue(e.RowHandle, "name").ToString().Trim() == "")
            {
                bVali = false;
                sErr = "Vui lòng điền tên nhân viên.\n";
            }

            if (gvCustomer.GetRowCellValue(e.RowHandle, "phone").ToString() == "")
            {
                bVali = false;
                sErr += "Vui lòng điền số điện thoại.\n";
            }

            if (gvCustomer.GetRowCellValue(e.RowHandle, "address").ToString() == "")
            {
                bVali = false;
                sErr += "Vui lòng điền địa chỉ.\n";
            }



            if (bVali)
            {
                //thêm mới
                if (e.RowHandle < 0)
                {


                    try
                    {
                        var model = new Customer
                        {
                            name = gvCustomer.GetRowCellValue(e.RowHandle, "name").ToString().Trim(),
                            address = gvCustomer.GetRowCellValue(e.RowHandle, "address").ToString().Trim(),
                            image = open == null || open.SafeFileName == null ? gvCustomer.GetRowCellValue(e.RowHandle, "image").ToString() : open.SafeFileName,
                            phone = gvCustomer.GetRowCellValue(e.RowHandle, "phone").ToString().Trim(),
                        };
                        int i = CustomerBUS.Insert(model);
                        open = null;
                        if (i == 1)
                            XtraMessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        else
                            XtraMessageBox.Show("Có lỗi xảy ra.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    catch (Exception ex)
                    {

                    }
                    CustomerBUS.GetDataGV(gcCustomer);
                }
                //sửa 
                else
                {
                    int i = -1;
                    try
                    {
                        var model = new Customer
                        {
                            id = int.Parse(gvCustomer.GetRowCellValue(e.RowHandle, "id").ToString().Trim()),
                            name = gvCustomer.GetRowCellValue(e.RowHandle, "name").ToString().Trim(),
                            address = gvCustomer.GetRowCellValue(e.RowHandle, "address").ToString().Trim(),
                            image = open == null || open.SafeFileName == null ? gvCustomer.GetRowCellValue(e.RowHandle, "image").ToString() : open.SafeFileName,
                            phone = gvCustomer.GetRowCellValue(e.RowHandle, "phone").ToString().Trim(),
                        };
                        i = CustomerBUS.Update(model);
                        open = null;
                    }
                    catch (Exception)
                    {

                    }
                    if (i == -1)
                        XtraMessageBox.Show("Có lỗi xảy ra.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CustomerBUS.GetDataGV(gcCustomer);

                }
            }
            else
            {

                e.Valid = false;

                XtraMessageBox.Show(sErr, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //đánh số thứ tự bảng khách hàng
        private void gvStaff_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (!e.Info.IsRowIndicator || e.RowHandle < 0)
                return;
            e.Info.DisplayText = (e.RowHandle + 1) + "";
        }
        //xuất ra file excel khách hàng
        private void btnExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "Excel Files (*.xlsx)|*.xls";
            sf.Title = "Xuất ra file excel";
            if (sf.ShowDialog() == DialogResult.OK)
            {
                string str = "khách hàng";
                gvCustomer.ExportToXls(sf.FileName);
                XtraMessageBox.Show("Xuất file excel " + str + " thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
        //xuất ra file word khách hàng
        private void btnWord_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "Word Files (*.docx)|*.docx";
            sf.Title = "Xuất ra file word";
            if (sf.ShowDialog() == DialogResult.OK)
            {
                string str = "khách hàng";
                gvCustomer.ExportToDocx(sf.FileName);

                XtraMessageBox.Show("Xuất file word " + str + " thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
        //xuất ra file Pdf khách hàng
        private void btnPdf_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "Pdf Files (*.pdf)|*.pdf";
            sf.Title = "Xuất ra file pdf";
            if (sf.ShowDialog() == DialogResult.OK)
            {
                string str = "khách hàng";
                gvCustomer.ExportToPdf(sf.FileName);
                XtraMessageBox.Show("Xuất file pdf " + str + " thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        #endregion
    }
}
