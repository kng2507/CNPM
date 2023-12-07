using DAO;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using GUI.UC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GUI.FRM
{
    public partial class frmMain : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        UserControl uc;
        public Staff staff;
        frmSystem frm;
        bool checkClose;
        
        public frmMain(frmSystem frm, Staff staff)
        {
            InitializeComponent();

            this.staff = staff;
            this.frm = frm;
            lbAccount.Caption = "Nhân viên: " + staff.name;
            openUC(typeof(uc_home));
            checkClose = true;
            if (!staff.Role.name.ToLower().Equals("admin"))
                btnManagerment.Visible = btnStatistical.Visible = btnRestore.Enabled = btnBackup.Enabled = false;
            else
                btnCustomerOfStaff.Visible = false;
        }
        public void _close()
        {
            mainContainer.Controls.Remove(uc);
            mainContainer.BringToFront();
        }

        private void openUC(Type typeUC)
        {
            splashScreenManager1.ShowWaitForm();
            bool check = false;
            foreach (UserControl _uc in mainContainer.Controls)
            {

                if (_uc.GetType() == typeUC)
                {
                    _uc.BringToFront();
                    lbTieuDe.Caption = _uc.Tag.ToString();
                    check = true;
                    continue;
                }
                mainContainer.Controls.Remove(_uc);

            }
            if (!check)
            {
                uc = (UserControl)Activator.CreateInstance(typeUC, this);
                uc.Dock = DockStyle.Fill;
                mainContainer.Controls.Add(uc);
                uc.BringToFront();
                lbTieuDe.Caption = uc.Tag.ToString();
            }
            splashScreenManager1.CloseWaitForm();
        }
        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            openUC(typeof(uc_customer));
        }
        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            openUC(typeof(uc_staff));
        }
        private void btnProduct_Click(object sender, EventArgs e)
        {
            openUC(typeof(uc_medicine));
        }
        private void btnBanHang_Click(object sender, EventArgs e)
        {
            openUC(typeof(uc_invoice));

        }
        private void btnNhapHang_Click(object sender, EventArgs e)
        {
            openUC(typeof(uc_entrySlip));
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            openUC(typeof(uc_order));

        }

        private void btnReceipt_Click(object sender, EventArgs e)
        {
            openUC(typeof(uc_import));

        }
        private void btnBackup_ItemClick(object sender, ItemClickEventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "SQL Backup (*.bak)|*.bak";
            sf.Title = "Backup database";
            if (sf.ShowDialog() == DialogResult.OK)
            {
                new frmBKRS(sf.FileName, 0).ShowDialog();
            }
        }

        private void btnRestore_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "SQL Backup (*.bak)|*.bak";
            op.Title = "Restore database";
            if (op.ShowDialog() == DialogResult.OK)
            {
                new frmBKRS(op.FileName, 1).ShowDialog();

            }
        }
        public void logout(int check = 0)
        {
            checkClose = false;
            if (check == 0)
            {
                if (XtraMessageBox.Show("Bạn chắc chắn muốn đăng xuất?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    Close();
                    frm._show();
                }
            }
            else
            {
                Close();

                frm._show();
            }
            checkClose = true;

        }
        private void btnLogout_ItemClick(object sender, ItemClickEventArgs e)
        {
            logout();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(checkClose)
            e.Cancel = true;
        }

        private void btnChangePass_ItemClick(object sender, ItemClickEventArgs e)
        {
            new frmChangePass(this, staff).ShowDialog();
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            openUC(typeof(uc_inventory));

        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            openUC(typeof(uc_home));

        }

        private void btnTurnover_Click(object sender, EventArgs e)
        {
            openUC(typeof(uc_statistical));
        }

        private void btnCustomerOfStaff_Click(object sender, EventArgs e)
        {
            openUC(typeof(uc_customer));
        }


        private void btnTopStaffCustomer_Click(object sender, EventArgs e)
        {
            openUC(typeof(uc_statistic_staff_customer));

        }
    }
}
