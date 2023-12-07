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
    public partial class uc_medicine : DevExpress.XtraEditors.XtraUserControl
    {
        private frmMain frm;
        private ImageCollection images = new ImageCollection(); //{ ImageSize=new Size(20, 20) };
        private OpenFileDialog open;
        public uc_medicine(frmMain frm)
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
            MedicineBUS.GetDataGV(gcMedicine);
            TypeOfMedicineBUS.GetDataLk(lkTypeOfMedicine);
            ManufacturerBUS.GetDataLk(lkManufacturer);
            SupplierBUS.GetDataLk(lkSupplier);
            ManufacturerBUS.GetDataGV(gcManufacturer);
            TypeOfMedicineBUS.GetDataGV(gcTypeOfMedicine);
            SupplierBUS.GetDataGV(gcSupplier);
            gvManufacturer.OptionsView.NewItemRowPosition = NewItemRowPosition.Top;
            gvManufacturer.IndicatorWidth = 50;
            gvTypeOfMedicine.OptionsView.NewItemRowPosition = NewItemRowPosition.Top;
            gvTypeOfMedicine.IndicatorWidth = 50;
            gvMedicine.OptionsView.NewItemRowPosition = NewItemRowPosition.Top;
            gvMedicine.IndicatorWidth = 50;
            gvSupplier.OptionsView.NewItemRowPosition = NewItemRowPosition.Top;
            gvSupplier.IndicatorWidth = 50;
        }
        #region thuốc      
        //load hình ảnh
        private void gvMedicine_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
        {
            if (e.Column.FieldName == "image")
            {

                try
                {

                    Image img = Image.FromFile("../../Images/" + gvMedicine.GetDataRow(e.RowHandle)["image"].ToString());
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

                imageMedicine.Images = images;
            }
        }
        //thay đổi hình ảnh thuốc
        private void imageMedicine_Click(object sender, EventArgs e)
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
                    DataRow dr = gvMedicine.GetFocusedDataRow();
                    var model = new Medicine
                    {
                        id = int.Parse(dr["id"].ToString().Trim()),
                        name = dr["name"].ToString().Trim(),
                        note = dr["note"].ToString().Trim(),
                        uses = dr["uses"].ToString().Trim(),
                        image = open.SafeFileName,
                        price = double.Parse(dr["price"].ToString().Trim()),
                        manufacturerId = int.Parse(dr["manufacturerId"].ToString().Trim()),
                        supplierId = int.Parse(dr["supplierId"].ToString().Trim()),
                        typeOfMedicineId = int.Parse(dr["typeOfMedicineId"].ToString().Trim()),
                    };
                    int i = MedicineBUS.Update(model);
                    if (i == 1)
                        MedicineBUS.GetDataGV(gcMedicine);
                    else
                        XtraMessageBox.Show("Có lỗi xảy ra.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    open = null;
                }
                catch (Exception)
                {

                }
            }
        }
        //phím delete xoá thuốc
        private void gcMedicine_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && gvMedicine.State != GridState.Editing)
            {
                DataRow dr = gvMedicine.GetFocusedDataRow();
                if (dr != null)
                {
                    if (XtraMessageBox.Show("Bạn có muốn xoá thuốc " + dr["name"].ToString() + " ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int id = int.Parse(dr["id"].ToString());
                        int i = MedicineBUS.Delete(id);
                        if (i == 1)
                        {
                            XtraMessageBox.Show("Xoá thành công", "Thông báo");
                            MedicineBUS.GetDataGV(gcMedicine);
                        }
                        else
                            XtraMessageBox.Show("Có lỗi xảy ra.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
            }
        }
        //ngăn ko cho chuyển dòng khi sai dữ liệu thuốc
        private void gvMedicine_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;

        }
        //thêm sửa dữ liệu thuốc
        private void gvMedicine_ValidateRow(object sender, ValidateRowEventArgs e)
        {
            string sErr = "";
            bool bVali = true;
            if (gvMedicine.GetRowCellValue(e.RowHandle, "name").ToString().Trim() == "")
            {
                bVali = false;
                sErr = "Vui lòng điền tên thuốc.\n";
            }

            if (gvMedicine.GetRowCellValue(e.RowHandle, "typeOfMedicineId").ToString() == "")
            {
                bVali = false;
                sErr += "Vui lòng chọn loại thuốc.";
            }
            if (gvMedicine.GetRowCellValue(e.RowHandle, "manufacturerId").ToString() == "")
            {
                bVali = false;
                sErr += "Vui lòng chọn hãng sản xuất.";
            }
            if (gvMedicine.GetRowCellValue(e.RowHandle, "supplierId").ToString() == "")
            {
                bVali = false;
                sErr += "Vui lòng chọn nhà cung cấp.";
            }
            if (gvMedicine.GetRowCellValue(e.RowHandle, "price").ToString().Trim() == "")
            {
                bVali = false;
                sErr = "Vui lòng điền giá.\n";
            }
            if (gvMedicine.GetRowCellValue(e.RowHandle, "uses").ToString().Trim() == "")
            {
                bVali = false;
                sErr = "Vui lòng điền công dụng.\n";
            }
            if (bVali)
            {

                //thêm mới
                if (e.RowHandle < 0)
                {
                    try
                    {
                        var model = new Medicine
                        {
                            name = gvMedicine.GetRowCellValue(e.RowHandle, "name").ToString().Trim(),
                            note = gvMedicine.GetRowCellValue(e.RowHandle, "note").ToString().Trim(),
                            uses = gvMedicine.GetRowCellValue(e.RowHandle, "uses").ToString().Trim(),
                            price = double.Parse(gvMedicine.GetRowCellValue(e.RowHandle, "price").ToString().Trim()),
                            image = open == null || open.SafeFileName == null ? gvMedicine.GetRowCellValue(e.RowHandle, "image").ToString() : open.SafeFileName,
                            manufacturerId = int.Parse(gvMedicine.GetRowCellValue(e.RowHandle, "manufacturerId").ToString().Trim()),
                            supplierId = int.Parse(gvMedicine.GetRowCellValue(e.RowHandle, "supplierId").ToString().Trim()),
                            typeOfMedicineId = int.Parse(gvMedicine.GetRowCellValue(e.RowHandle, "typeOfMedicineId").ToString().Trim()),
                        };
                        int i = MedicineBUS.Insert(model);
                        open = null;
                        if (i == 1)
                            XtraMessageBox.Show("Thêm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        else if (i == 0)
                            XtraMessageBox.Show("Trùng tên thuốc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        else
                            XtraMessageBox.Show("Có lỗi xảy ra.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    catch (Exception ex)
                    {

                    }
                    MedicineBUS.GetDataGV(gcMedicine);
                }
                //sửa 
                else
                {
                    int i = -1;
                    try
                    {
                        var model = new Medicine
                        {
                            id = int.Parse(gvMedicine.GetRowCellValue(e.RowHandle, "id").ToString().Trim()),
                            name = gvMedicine.GetRowCellValue(e.RowHandle, "name").ToString().Trim(),
                            price = double.Parse(gvMedicine.GetRowCellValue(e.RowHandle, "price").ToString().Trim()),
                            note = gvMedicine.GetRowCellValue(e.RowHandle, "note").ToString().Trim(),
                            uses = gvMedicine.GetRowCellValue(e.RowHandle, "uses").ToString().Trim(),
                            image = open == null || open.SafeFileName == null ? gvMedicine.GetRowCellValue(e.RowHandle, "image").ToString() : open.SafeFileName,
                            manufacturerId = int.Parse(gvMedicine.GetRowCellValue(e.RowHandle, "manufacturerId").ToString().Trim()),
                            supplierId = int.Parse(gvMedicine.GetRowCellValue(e.RowHandle, "supplierId").ToString().Trim()),
                            typeOfMedicineId = int.Parse(gvMedicine.GetRowCellValue(e.RowHandle, "typeOfMedicineId").ToString().Trim()),
                        };
                        i = MedicineBUS.Update(model);
                        open = null;
                    }
                    catch (Exception)
                    {

                    }
                    if (i == -1)
                        XtraMessageBox.Show("Có lỗi xảy ra.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else if (i == 0)
                        XtraMessageBox.Show("Trùng tên thuốc.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    MedicineBUS.GetDataGV(gcMedicine);
                }
            }
            else
            {

                e.Valid = false;

                XtraMessageBox.Show(sErr, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //đánh số thứ tự bảng thuốc
        private void gvMedicine_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (!e.Info.IsRowIndicator || e.RowHandle < 0)
                return;
            e.Info.DisplayText = (e.RowHandle + 1) + "";
        }
        #endregion    
        #region loại thuốc
        //phím delete xoá loại thuốc
        private void gcTypeOfMedicine_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && gvTypeOfMedicine.State != GridState.Editing)
            {
                DataRow dr = gvTypeOfMedicine.GetFocusedDataRow();
                if (dr != null)
                {
                    if (XtraMessageBox.Show("Bạn có muốn xoá loại thuốc " + dr["name"].ToString() + " ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int id = int.Parse(dr["id"].ToString());
                        int i = TypeOfMedicineBUS.Delete(id);
                        if (i == 1)
                        {
                            XtraMessageBox.Show("Xoá thành công", "Thông báo");
                            TypeOfMedicineBUS.GetDataGV(gcTypeOfMedicine);
                        }
                        else
                            XtraMessageBox.Show("Có lỗi xảy ra.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
            }
        }
        //đánh số thứ tự bảng loại thuốc
        private void gvTypeOfMedicine_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (!e.Info.IsRowIndicator || e.RowHandle < 0)
                return;
            e.Info.DisplayText = (e.RowHandle + 1) + "";
        }
        //thêm sửa loại thuốc
        private void gvTypeOfMedicine_ValidateRow(object sender, ValidateRowEventArgs e)
        {
            string sErr = "";
            bool bVali = true;
            if (gvTypeOfMedicine.GetRowCellValue(e.RowHandle, "name").ToString().Trim() == "")
            {
                bVali = false;
                sErr = "Vui lòng điền tên loại thuốc.\n";
            }

            if (bVali)
            {

                //thêm mới
                if (e.RowHandle < 0)
                {
                    try
                    {
                        var model = new TypeOfMedicine
                        {
                            name = gvTypeOfMedicine.GetRowCellValue(e.RowHandle, "name").ToString().Trim(),
                            note = gvTypeOfMedicine.GetRowCellValue(e.RowHandle, "note").ToString().Trim(),
                        };
                        int i = TypeOfMedicineBUS.Insert(model);
                        open = null;
                        if (i == 1)
                            XtraMessageBox.Show("Thêm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        else if (i == 0)
                            XtraMessageBox.Show("Trùng tên loại thuốc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        else
                            XtraMessageBox.Show("Có lỗi xảy ra.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    catch (Exception ex)
                    {

                    }
                    TypeOfMedicineBUS.GetDataGV(gcTypeOfMedicine);
                }
                //sửa 
                else
                {
                    int i = -1;
                    try
                    {
                        var model = new TypeOfMedicine
                        {
                            id = int.Parse(gvTypeOfMedicine.GetRowCellValue(e.RowHandle, "id").ToString().Trim()),
                            name = gvTypeOfMedicine.GetRowCellValue(e.RowHandle, "name").ToString().Trim(),
                            note = gvTypeOfMedicine.GetRowCellValue(e.RowHandle, "note").ToString().Trim(),

                        };
                        i = TypeOfMedicineBUS.Update(model);
                        open = null;
                    }
                    catch (Exception)
                    {

                    }
                    if (i == -1)
                        XtraMessageBox.Show("Có lỗi xảy ra.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else if (i == 0)
                        XtraMessageBox.Show("Trùng tên loại thuốc.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    TypeOfMedicineBUS.GetDataGV(gcTypeOfMedicine);
                }
            }
            else
            {

                e.Valid = false;

                XtraMessageBox.Show(sErr, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //ngăn ko cho chuyển dòng khi sai dữ liệu loại thuốc   
        private void gvTypeOfMedicine_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }
        #endregion
        #region hãng sản xuất
        //phím delete xoá hãng sản xuất
        private void gcManufacturer_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && gvManufacturer.State != GridState.Editing)
            {
                DataRow dr = gvManufacturer.GetFocusedDataRow();
                if (dr != null)
                {
                    if (XtraMessageBox.Show("Bạn có muốn xoá hãng sản xuất " + dr["name"].ToString() + " ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int id = int.Parse(dr["id"].ToString());
                        int i = ManufacturerBUS.Delete(id);
                        if (i == 1)
                        {
                            XtraMessageBox.Show("Xoá thành công", "Thông báo");
                            ManufacturerBUS.GetDataGV(gcManufacturer);
                        }
                        else
                            XtraMessageBox.Show("Có lỗi xảy ra.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
            }
        }
        //đánh số thứ tự bảng hãng sản xuất
        private void gvManufacturer_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (!e.Info.IsRowIndicator || e.RowHandle < 0)
                return;
            e.Info.DisplayText = (e.RowHandle + 1) + "";
        }
        //ngăn không cho chuyển dòng khi sai dữ liệu bảng hãng sản xuất
        private void gvManufacturer_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }
        //thêm sửa bảng hãng sản xuất
        private void gvManufacturer_ValidateRow(object sender, ValidateRowEventArgs e)
        {
            string sErr = "";
            bool bVali = true;
            if (gvManufacturer.GetRowCellValue(e.RowHandle, "name").ToString().Trim() == "")
            {
                bVali = false;
                sErr = "Vui lòng điền tên hãng sản xuất.\n";
            }
            if (gvManufacturer.GetRowCellValue(e.RowHandle, "country").ToString().Trim() == "")
            {
                bVali = false;
                sErr = "Vui lòng điền tên quốc gia.\n";
            }
            if (bVali)
            {

                //thêm mới
                if (e.RowHandle < 0)
                {
                    try
                    {
                        var model = new Manufacturer
                        {
                            name = gvManufacturer.GetRowCellValue(e.RowHandle, "name").ToString().Trim(),
                            country = gvManufacturer.GetRowCellValue(e.RowHandle, "country").ToString().Trim(),
                        };
                        int i = ManufacturerBUS.Insert(model);
                        open = null;
                        if (i == 1)
                            XtraMessageBox.Show("Thêm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        else if (i == 0)
                            XtraMessageBox.Show("Trùng tên hãng sản xuất", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        else
                            XtraMessageBox.Show("Có lỗi xảy ra.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    catch (Exception ex)
                    {

                    }
                    ManufacturerBUS.GetDataGV(gcManufacturer);
                }
                //sửa 
                else
                {
                    int i = -1;
                    try
                    {
                        var model = new Manufacturer
                        {
                            id = int.Parse(gvManufacturer.GetRowCellValue(e.RowHandle, "id").ToString().Trim()),
                            name = gvManufacturer.GetRowCellValue(e.RowHandle, "name").ToString().Trim(),
                            country = gvManufacturer.GetRowCellValue(e.RowHandle, "country").ToString().Trim(),

                        };
                        i = ManufacturerBUS.Update(model);
                        open = null;
                    }
                    catch (Exception)
                    {

                    }
                    if (i == -1)
                        XtraMessageBox.Show("Có lỗi xảy ra.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else if (i == 0)
                        XtraMessageBox.Show("Trùng tên hãng sản xuất.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ManufacturerBUS.GetDataGV(gcManufacturer);
                }
            }
            else
            {

                e.Valid = false;

                XtraMessageBox.Show(sErr, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        #region nhà cung cấp
        //phím delete xoá nhà cung cấp
        private void gcSupplier_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && gvSupplier.State != GridState.Editing)
            {
                DataRow dr = gvSupplier.GetFocusedDataRow();
                if (dr != null)
                {
                    if (XtraMessageBox.Show("Bạn có muốn xoá nhà cung cấp " + dr["name"].ToString() + " ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int id = int.Parse(dr["id"].ToString());
                        int i = SupplierBUS.Delete(id);
                        if (i == 1)
                        {
                            XtraMessageBox.Show("Xoá thành công", "Thông báo");
                            SupplierBUS.GetDataGV(gcSupplier);
                        }
                        else
                            XtraMessageBox.Show("Có lỗi xảy ra.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
            }
        }
        //đánh số thứ tự bảng nhà cung cấp
        private void gvSupplier_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (!e.Info.IsRowIndicator || e.RowHandle < 0)
                return;
            e.Info.DisplayText = (e.RowHandle + 1) + "";
        }
        //ngăn không cho chuyển dòng khi nhà cung cấp sai dữ liệu
        private void gvSupplier_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }
        //thêm sửa bảng nhà cung cấp
        private void gvSupplier_ValidateRow(object sender, ValidateRowEventArgs e)
        {
            string sErr = "";
            bool bVali = true;
            if (gvSupplier.GetRowCellValue(e.RowHandle, "name").ToString().Trim() == "")
            {
                bVali = false;
                sErr = "Vui lòng điền tên nhà cung cấp.\n";
            }
            if (gvSupplier.GetRowCellValue(e.RowHandle, "address").ToString().Trim() == "")
            {
                bVali = false;
                sErr = "Vui lòng điền địa chỉ.\n";
            }
            if (bVali)
            {

                //thêm mới
                if (e.RowHandle < 0)
                {
                    try
                    {
                        var model = new Supplier
                        {
                            name = gvSupplier.GetRowCellValue(e.RowHandle, "name").ToString().Trim(),
                            address = gvSupplier.GetRowCellValue(e.RowHandle, "address").ToString().Trim(),
                        };
                        int i = SupplierBUS.Insert(model);
                        open = null;
                        if (i == 1)
                            XtraMessageBox.Show("Thêm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        else if (i == 0)
                            XtraMessageBox.Show("Trùng tên nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        else
                            XtraMessageBox.Show("Có lỗi xảy ra.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    catch (Exception ex)
                    {

                    }
                    SupplierBUS.GetDataGV(gcSupplier);
                }
                //sửa 
                else
                {
                    int i = -1;
                    try
                    {
                        var model = new Supplier
                        {
                            id = int.Parse(gvSupplier.GetRowCellValue(e.RowHandle, "id").ToString().Trim()),
                            name = gvSupplier.GetRowCellValue(e.RowHandle, "name").ToString().Trim(),
                            address = gvSupplier.GetRowCellValue(e.RowHandle, "address").ToString().Trim(),

                        };
                        i = SupplierBUS.Update(model);
                        open = null;
                    }
                    catch (Exception)
                    {

                    }
                    if (i == -1)
                        XtraMessageBox.Show("Có lỗi xảy ra.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else if (i == 0)
                        XtraMessageBox.Show("Trùng tên nhà cung cấp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    SupplierBUS.GetDataGV(gcSupplier);
                }
            }
            else
            {

                e.Valid = false;

                XtraMessageBox.Show(sErr, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        #region thuốc, loại thuốc, hãng sản xuất, nhà cung cấp
        //xoá thuốc, loại thuốc, hãng sản xuất, nhà cung cấp
        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (xtraTabControl1.SelectedTabPageIndex == 0)
            {
                DataRow dr = gvMedicine.GetFocusedDataRow();
                if (dr != null)
                {
                    if (XtraMessageBox.Show("Bạn có muốn xoá thuốc " + dr["name"].ToString() + " ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int i = MedicineBUS.Delete(int.Parse(dr["id"].ToString()));
                        if (i == 1)
                        {
                            XtraMessageBox.Show("Xoá thành công", "Thông báo");
                            MedicineBUS.GetDataGV(gcMedicine);
                        }
                        else
                            XtraMessageBox.Show("Có lỗi xảy ra.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
            }
            else if (xtraTabControl1.SelectedTabPageIndex == 1)
            {
                DataRow dr = gvTypeOfMedicine.GetFocusedDataRow();
                if (dr != null)
                {
                    if (XtraMessageBox.Show("Bạn có muốn xoá loại thuốc " + dr["name"].ToString() + " ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int i = TypeOfMedicineBUS.Delete(int.Parse(dr["id"].ToString()));
                        if (i == 1)
                        {
                            XtraMessageBox.Show("Xoá thành công", "Thông báo");
                            TypeOfMedicineBUS.GetDataGV(gcTypeOfMedicine);
                        }
                        else
                            XtraMessageBox.Show("Có lỗi xảy ra.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
            }
            else if (xtraTabControl1.SelectedTabPageIndex == 2)
            {
                DataRow dr = gvManufacturer.GetFocusedDataRow();
                if (dr != null)
                {
                    if (XtraMessageBox.Show("Bạn có muốn xoá hãng sản xuất " + dr["name"].ToString() + " ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int i = ManufacturerBUS.Delete(int.Parse(dr["id"].ToString()));
                        if (i == 1)
                        {
                            XtraMessageBox.Show("Xoá thành công", "Thông báo");
                            ManufacturerBUS.GetDataGV(gcManufacturer);
                        }
                        else
                            XtraMessageBox.Show("Có lỗi xảy ra.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
            }
            else
            {
                DataRow dr = gvSupplier.GetFocusedDataRow();
                if (dr != null)
                {
                    if (XtraMessageBox.Show("Bạn có muốn xoá hãng sản xuất " + dr["name"].ToString() + " ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int i = SupplierBUS.Delete(int.Parse(dr["id"].ToString()));
                        if (i == 1)
                        {
                            XtraMessageBox.Show("Xoá thành công", "Thông báo");
                            SupplierBUS.GetDataGV(gcSupplier);
                        }
                        else
                            XtraMessageBox.Show("Có lỗi xảy ra.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
            }

        }
        //xuất excel thuốc, loại thuốc, hãng sản xuất, nhà cung cấp
        private void btnExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "Excel Files (*.xlsx)|*.xls";
            sf.Title = "Xuất ra file excel";
            if (sf.ShowDialog() == DialogResult.OK)
            {
                string str = "thuốc";
                if (xtraTabControl1.SelectedTabPageIndex == 0)
                    gvMedicine.ExportToXls(sf.FileName);
                else if (xtraTabControl1.SelectedTabPageIndex == 1)
                {
                    gvTypeOfMedicine.ExportToXls(sf.FileName);
                    str = "loại thuốc";
                }
                else if (xtraTabControl1.SelectedTabPageIndex == 2)
                {
                    gvManufacturer.ExportToXls(sf.FileName);
                    str = "hãng sản xuất";
                }
                else
                {
                    gvSupplier.ExportToXls(sf.FileName);
                    str = "nhà cung cấp";
                }
                XtraMessageBox.Show("Xuất file excel " + str + " thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
        //xuất word thuốc, loại thuốc, hãng sản xuất, nhà cung cấp
        private void btnWord_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "Word Files (*.docx)|*.docx";
            sf.Title = "Xuất ra file word";
            if (sf.ShowDialog() == DialogResult.OK)
            {
                string str = "thuốc";
                if (xtraTabControl1.SelectedTabPageIndex == 0)
                    gvMedicine.ExportToDocx(sf.FileName);
                else if (xtraTabControl1.SelectedTabPageIndex == 1)
                {
                    gvTypeOfMedicine.ExportToDocx(sf.FileName);
                    str = "loại thuốc";
                }
                else if (xtraTabControl1.SelectedTabPageIndex == 2)
                {
                    gvManufacturer.ExportToDocx(sf.FileName);
                    str = "hãng sản xuất";
                }
                else
                {
                    gvSupplier.ExportToDocx(sf.FileName);
                    str = "nhà cung cấp";
                }
                XtraMessageBox.Show("Xuất file word " + str + " thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
        //xuất pdf thuốc, loại thuốc, hãng sản xuất, nhà cung cấp
        private void btnPdf_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "Pdf Files (*.pdf)|*.pdf";
            sf.Title = "Xuất ra file pdf";
            if (sf.ShowDialog() == DialogResult.OK)
            {
                string str = "thuốc";
                if (xtraTabControl1.SelectedTabPageIndex == 0)
                    gvMedicine.ExportToPdf(sf.FileName);
                else if (xtraTabControl1.SelectedTabPageIndex == 1)
                {
                    gvTypeOfMedicine.ExportToPdf(sf.FileName);
                    str = "loại thuốc";
                }
                else if (xtraTabControl1.SelectedTabPageIndex == 2)
                {
                    gvManufacturer.ExportToPdf(sf.FileName);
                    str = "hãng sản xuất";
                }
                else
                {
                    gvSupplier.ExportToPdf(sf.FileName);
                    str = "nhà cung cấp";
                }
                XtraMessageBox.Show("Xuất file pdf " + str + " thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
        #endregion


    }
}
