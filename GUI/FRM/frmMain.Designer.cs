namespace GUI.FRM
{
    partial class frmMain
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.mainContainer = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer();
            this.accordionControl1 = new DevExpress.XtraBars.Navigation.AccordionControl();
            this.btnHome = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.btnManagerment = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.btnProduct = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.btnNhanVien = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.btnKhachHang = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.btnReceipt = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.btnOrder = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.btnStaffCustomer = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.btnBanHang = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.btnNhapHang = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.btnCustomerOfStaff = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.btnStatistical = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.btnTurnover = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.btnInventory = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.btnTopStaffCustomer = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.fluentDesignFormControl1 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl();
            this.lbTieuDe = new DevExpress.XtraBars.BarHeaderItem();
            this.fluentFormDefaultManager1 = new DevExpress.XtraBars.FluentDesignSystem.FluentFormDefaultManager(this.components);
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.btnChangePass = new DevExpress.XtraBars.BarButtonItem();
            this.btnBackup = new DevExpress.XtraBars.BarButtonItem();
            this.btnRestore = new DevExpress.XtraBars.BarButtonItem();
            this.btnLogout = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.lbAccount = new DevExpress.XtraBars.BarHeaderItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barHeaderItem1 = new DevExpress.XtraBars.BarHeaderItem();
            this.repositoryItemPictureEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.repositoryItemImageEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageEdit();
            this.repositoryItemPictureEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.repositoryItemPictureEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::GUI.FRM.WaitForm1), true, true);
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentFormDefaultManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit3)).BeginInit();
            this.SuspendLayout();
            // 
            // mainContainer
            // 
            this.mainContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainContainer.Location = new System.Drawing.Point(375, 78);
            this.mainContainer.Name = "mainContainer";
            this.mainContainer.Size = new System.Drawing.Size(673, 586);
            this.mainContainer.TabIndex = 0;
            // 
            // accordionControl1
            // 
            this.accordionControl1.Appearance.AccordionControl.BackColor = System.Drawing.Color.White;
            this.accordionControl1.Appearance.AccordionControl.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accordionControl1.Appearance.AccordionControl.Options.UseBackColor = true;
            this.accordionControl1.Appearance.AccordionControl.Options.UseFont = true;
            this.accordionControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.accordionControl1.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.btnHome,
            this.btnManagerment,
            this.btnStaffCustomer,
            this.btnStatistical});
            this.accordionControl1.Location = new System.Drawing.Point(0, 78);
            this.accordionControl1.Name = "accordionControl1";
            this.accordionControl1.OptionsHamburgerMenu.DisplayMode = DevExpress.XtraBars.Navigation.AccordionControlDisplayMode.Overlay;
            this.accordionControl1.ScrollBarMode = DevExpress.XtraBars.Navigation.ScrollBarMode.Touch;
            this.accordionControl1.Size = new System.Drawing.Size(375, 586);
            this.accordionControl1.TabIndex = 1;
            this.accordionControl1.ViewType = DevExpress.XtraBars.Navigation.AccordionControlViewType.HamburgerMenu;
            // 
            // btnHome
            // 
            this.btnHome.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnHome.ImageOptions.Image")));
            this.btnHome.Name = "btnHome";
            this.btnHome.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.btnHome.Text = "Trang chủ";
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // btnManagerment
            // 
            this.btnManagerment.Appearance.Disabled.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(236)))), ((int)(((byte)(254)))));
            this.btnManagerment.Appearance.Disabled.Options.UseBackColor = true;
            this.btnManagerment.Appearance.Hovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(236)))), ((int)(((byte)(254)))));
            this.btnManagerment.Appearance.Hovered.Options.UseBackColor = true;
            this.btnManagerment.Appearance.Normal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(236)))), ((int)(((byte)(254)))));
            this.btnManagerment.Appearance.Normal.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnManagerment.Appearance.Normal.Options.UseBackColor = true;
            this.btnManagerment.Appearance.Pressed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(236)))), ((int)(((byte)(254)))));
            this.btnManagerment.Appearance.Pressed.Options.UseBackColor = true;
            this.btnManagerment.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.btnProduct,
            this.btnNhanVien,
            this.btnKhachHang,
            this.btnReceipt,
            this.btnOrder});
            this.btnManagerment.Expanded = true;
            this.btnManagerment.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnManagerment.ImageOptions.Image")));
            this.btnManagerment.Name = "btnManagerment";
            this.btnManagerment.Tag = "";
            this.btnManagerment.Text = "Quản lý";
            // 
            // btnProduct
            // 
            this.btnProduct.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnProduct.ImageOptions.Image")));
            this.btnProduct.Name = "btnProduct";
            this.btnProduct.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.btnProduct.Text = "Thuốc";
            this.btnProduct.Click += new System.EventHandler(this.btnProduct_Click);
            // 
            // btnNhanVien
            // 
            this.btnNhanVien.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnNhanVien.ImageOptions.Image")));
            this.btnNhanVien.Name = "btnNhanVien";
            this.btnNhanVien.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.btnNhanVien.Text = "Nhân viên";
            this.btnNhanVien.Click += new System.EventHandler(this.btnNhanVien_Click);
            // 
            // btnKhachHang
            // 
            this.btnKhachHang.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnKhachHang.ImageOptions.Image")));
            this.btnKhachHang.Name = "btnKhachHang";
            this.btnKhachHang.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.btnKhachHang.Text = "Khách hàng";
            this.btnKhachHang.Click += new System.EventHandler(this.btnKhachHang_Click);
            // 
            // btnReceipt
            // 
            this.btnReceipt.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnReceipt.ImageOptions.Image")));
            this.btnReceipt.Name = "btnReceipt";
            this.btnReceipt.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.btnReceipt.Text = "Phiếu nhập";
            this.btnReceipt.Click += new System.EventHandler(this.btnReceipt_Click);
            // 
            // btnOrder
            // 
            this.btnOrder.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnOrder.ImageOptions.Image")));
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.btnOrder.Text = "Hoá đơn";
            this.btnOrder.Click += new System.EventHandler(this.btnOrder_Click);
            // 
            // btnStaffCustomer
            // 
            this.btnStaffCustomer.Appearance.Disabled.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(236)))), ((int)(((byte)(254)))));
            this.btnStaffCustomer.Appearance.Disabled.Options.UseBackColor = true;
            this.btnStaffCustomer.Appearance.Hovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(236)))), ((int)(((byte)(254)))));
            this.btnStaffCustomer.Appearance.Hovered.Options.UseBackColor = true;
            this.btnStaffCustomer.Appearance.Normal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(236)))), ((int)(((byte)(254)))));
            this.btnStaffCustomer.Appearance.Normal.Options.UseBackColor = true;
            this.btnStaffCustomer.Appearance.Pressed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(236)))), ((int)(((byte)(254)))));
            this.btnStaffCustomer.Appearance.Pressed.Options.UseBackColor = true;
            this.btnStaffCustomer.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.btnBanHang,
            this.btnNhapHang,
            this.btnCustomerOfStaff});
            this.btnStaffCustomer.Expanded = true;
            this.btnStaffCustomer.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnStaffCustomer.ImageOptions.Image")));
            this.btnStaffCustomer.Name = "btnStaffCustomer";
            this.btnStaffCustomer.Text = "Khách hàng";
            // 
            // btnBanHang
            // 
            this.btnBanHang.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnBanHang.ImageOptions.Image")));
            this.btnBanHang.Name = "btnBanHang";
            this.btnBanHang.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.btnBanHang.Text = "Bán thuốc";
            this.btnBanHang.Click += new System.EventHandler(this.btnBanHang_Click);
            // 
            // btnNhapHang
            // 
            this.btnNhapHang.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnNhapHang.ImageOptions.Image")));
            this.btnNhapHang.Name = "btnNhapHang";
            this.btnNhapHang.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.btnNhapHang.Text = "Nhập thuốc";
            this.btnNhapHang.Click += new System.EventHandler(this.btnNhapHang_Click);
            // 
            // btnCustomerOfStaff
            // 
            this.btnCustomerOfStaff.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCustomerOfStaff.ImageOptions.Image")));
            this.btnCustomerOfStaff.Name = "btnCustomerOfStaff";
            this.btnCustomerOfStaff.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.btnCustomerOfStaff.Text = "Quản lý khách hàng";
            this.btnCustomerOfStaff.Click += new System.EventHandler(this.btnCustomerOfStaff_Click);
            // 
            // btnStatistical
            // 
            this.btnStatistical.Appearance.Disabled.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(236)))), ((int)(((byte)(254)))));
            this.btnStatistical.Appearance.Disabled.Options.UseBackColor = true;
            this.btnStatistical.Appearance.Hovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(236)))), ((int)(((byte)(254)))));
            this.btnStatistical.Appearance.Hovered.Options.UseBackColor = true;
            this.btnStatistical.Appearance.Normal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(236)))), ((int)(((byte)(254)))));
            this.btnStatistical.Appearance.Normal.Options.UseBackColor = true;
            this.btnStatistical.Appearance.Pressed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(236)))), ((int)(((byte)(254)))));
            this.btnStatistical.Appearance.Pressed.Options.UseBackColor = true;
            this.btnStatistical.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.btnTurnover,
            this.btnInventory,
            this.btnTopStaffCustomer});
            this.btnStatistical.Expanded = true;
            this.btnStatistical.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnStatistical.ImageOptions.Image")));
            this.btnStatistical.Name = "btnStatistical";
            this.btnStatistical.Text = "Thống kê - Dự đoán";
            // 
            // btnTurnover
            // 
            this.btnTurnover.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnTurnover.ImageOptions.Image")));
            this.btnTurnover.Name = "btnTurnover";
            this.btnTurnover.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.btnTurnover.Text = "Doanh thu";
            this.btnTurnover.Click += new System.EventHandler(this.btnTurnover_Click);
            // 
            // btnInventory
            // 
            this.btnInventory.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnInventory.ImageOptions.Image")));
            this.btnInventory.Name = "btnInventory";
            this.btnInventory.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.btnInventory.Text = "Tồn kho";
            this.btnInventory.Click += new System.EventHandler(this.btnInventory_Click);
            // 
            // btnTopStaffCustomer
            // 
            this.btnTopStaffCustomer.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnTopStaffCustomer.ImageOptions.Image")));
            this.btnTopStaffCustomer.Name = "btnTopStaffCustomer";
            this.btnTopStaffCustomer.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.btnTopStaffCustomer.Text = "Top khách hàng, nhân viên";
            this.btnTopStaffCustomer.Click += new System.EventHandler(this.btnTopStaffCustomer_Click);
            // 
            // fluentDesignFormControl1
            // 
            this.fluentDesignFormControl1.FluentDesignForm = this;
            this.fluentDesignFormControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.lbTieuDe});
            this.fluentDesignFormControl1.Location = new System.Drawing.Point(0, 0);
            this.fluentDesignFormControl1.Manager = this.fluentFormDefaultManager1;
            this.fluentDesignFormControl1.Name = "fluentDesignFormControl1";
            this.fluentDesignFormControl1.Size = new System.Drawing.Size(1048, 42);
            this.fluentDesignFormControl1.TabIndex = 2;
            this.fluentDesignFormControl1.TabStop = false;
            this.fluentDesignFormControl1.TitleItemLinks.Add(this.lbTieuDe);
            // 
            // lbTieuDe
            // 
            this.lbTieuDe.Id = 0;
            this.lbTieuDe.Name = "lbTieuDe";
            // 
            // fluentFormDefaultManager1
            // 
            this.fluentFormDefaultManager1.DockingEnabled = false;
            this.fluentFormDefaultManager1.Form = this;
            this.fluentFormDefaultManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.lbTieuDe});
            this.fluentFormDefaultManager1.MaxItemId = 1;
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1,
            this.bar3});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnChangePass,
            this.btnBackup,
            this.btnRestore,
            this.btnLogout,
            this.barHeaderItem1,
            this.lbAccount});
            this.barManager1.MaxItemId = 16;
            this.barManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemPictureEdit1,
            this.repositoryItemImageEdit1,
            this.repositoryItemPictureEdit2,
            this.repositoryItemPictureEdit3});
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.FloatLocation = new System.Drawing.Point(362, 237);
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnChangePass, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnBackup, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnRestore, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnLogout, true)});
            this.bar1.Text = "Tools";
            // 
            // btnChangePass
            // 
            this.btnChangePass.Caption = "Đổi mật khẩu";
            this.btnChangePass.Id = 7;
            this.btnChangePass.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnChangePass.ImageOptions.Image")));
            this.btnChangePass.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnChangePass.ImageOptions.LargeImage")));
            this.btnChangePass.Name = "btnChangePass";
            this.btnChangePass.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnChangePass.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnChangePass_ItemClick);
            // 
            // btnBackup
            // 
            this.btnBackup.Caption = "Backup";
            this.btnBackup.Id = 8;
            this.btnBackup.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnBackup.ImageOptions.Image")));
            this.btnBackup.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnBackup.ImageOptions.LargeImage")));
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnBackup.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnBackup_ItemClick);
            // 
            // btnRestore
            // 
            this.btnRestore.Caption = "Restore";
            this.btnRestore.Id = 9;
            this.btnRestore.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnRestore.ImageOptions.Image")));
            this.btnRestore.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnRestore.ImageOptions.LargeImage")));
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnRestore.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRestore_ItemClick);
            // 
            // btnLogout
            // 
            this.btnLogout.Caption = "Đăng xuất";
            this.btnLogout.Id = 10;
            this.btnLogout.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnLogout.ImageOptions.Image")));
            this.btnLogout.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnLogout.ImageOptions.LargeImage")));
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnLogout.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLogout_ItemClick);
            // 
            // bar3
            // 
            this.bar3.BarName = "Custom 3";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.lbAccount)});
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Custom 3";
            // 
            // lbAccount
            // 
            this.lbAccount.Caption = "NV";
            this.lbAccount.Id = 15;
            this.lbAccount.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("lbAccount.ImageOptions.Image")));
            this.lbAccount.Name = "lbAccount";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 42);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1048, 36);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 664);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1048, 39);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 78);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 586);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1048, 78);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 586);
            // 
            // barHeaderItem1
            // 
            this.barHeaderItem1.Caption = "Trạng thái";
            this.barHeaderItem1.Id = 11;
            this.barHeaderItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barHeaderItem1.ImageOptions.Image")));
            this.barHeaderItem1.Name = "barHeaderItem1";
            this.barHeaderItem1.ShowItemShortcut = DevExpress.Utils.DefaultBoolean.True;
            // 
            // repositoryItemPictureEdit1
            // 
            this.repositoryItemPictureEdit1.Name = "repositoryItemPictureEdit1";
            // 
            // repositoryItemImageEdit1
            // 
            this.repositoryItemImageEdit1.AutoHeight = false;
            this.repositoryItemImageEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageEdit1.Name = "repositoryItemImageEdit1";
            // 
            // repositoryItemPictureEdit2
            // 
            this.repositoryItemPictureEdit2.Name = "repositoryItemPictureEdit2";
            // 
            // repositoryItemPictureEdit3
            // 
            this.repositoryItemPictureEdit3.InitialImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("repositoryItemPictureEdit3.InitialImageOptions.Image")));
            this.repositoryItemPictureEdit3.Name = "repositoryItemPictureEdit3";
            // 
            // bar2
            // 
            this.bar2.BarName = "Custom 4";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 1;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.Text = "Custom 4";
            // 
            // splashScreenManager1
            // 
            this.splashScreenManager1.ClosingDelay = 500;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1048, 703);
            this.ControlContainer = this.mainContainer;
            this.Controls.Add(this.mainContainer);
            this.Controls.Add(this.accordionControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Controls.Add(this.fluentDesignFormControl1);
            this.FluentDesignFormControl = this.fluentDesignFormControl1;
            this.Name = "frmMain";
            this.NavigationControl = this.accordionControl1;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phần mềm quản lý nhà thuốc";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentFormDefaultManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer mainContainer;
        private DevExpress.XtraBars.Navigation.AccordionControl accordionControl1;
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl fluentDesignFormControl1;
        private DevExpress.XtraBars.FluentDesignSystem.FluentFormDefaultManager fluentFormDefaultManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemPictureEdit1;
        private DevExpress.XtraBars.BarButtonItem btnChangePass;
        private DevExpress.XtraBars.BarButtonItem btnBackup;
        private DevExpress.XtraBars.BarButtonItem btnRestore;
        private DevExpress.XtraBars.BarButtonItem btnLogout;
        private DevExpress.XtraBars.Navigation.AccordionControlElement btnProduct;
        private DevExpress.XtraBars.Navigation.AccordionControlElement btnNhanVien;
        private DevExpress.XtraBars.Navigation.AccordionControlElement btnKhachHang;
        private DevExpress.XtraBars.Navigation.AccordionControlElement btnReceipt;
        private DevExpress.XtraBars.Navigation.AccordionControlElement btnOrder;
        private DevExpress.XtraBars.Navigation.AccordionControlElement btnStaffCustomer;
        private DevExpress.XtraBars.Navigation.AccordionControlElement btnBanHang;
        private DevExpress.XtraBars.Navigation.AccordionControlElement btnNhapHang;
        private DevExpress.XtraBars.Navigation.AccordionControlElement btnStatistical;
        private DevExpress.XtraBars.Navigation.AccordionControlElement btnTurnover;
        private DevExpress.XtraBars.BarHeaderItem barHeaderItem1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarHeaderItem lbTieuDe;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemPictureEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageEdit repositoryItemImageEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemPictureEdit3;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarHeaderItem lbAccount;
        private DevExpress.XtraBars.Navigation.AccordionControlElement btnInventory;
        private DevExpress.XtraBars.Navigation.AccordionControlElement btnHome;
        private DevExpress.XtraBars.Navigation.AccordionControlElement btnManagerment;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement btnCustomerOfStaff;
        private DevExpress.XtraBars.Navigation.AccordionControlElement btnTopStaffCustomer;
    }
}