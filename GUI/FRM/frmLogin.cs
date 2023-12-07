using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BUS;
using DAO;
using DevExpress.XtraSplashScreen;

namespace GUI.FRM
{
    public partial class frmLogin : DevExpress.XtraEditors.XtraForm
    {
        private frmSystem frm;
        public frmLogin(frmSystem frm)
        {
            InitializeComponent();
            this.frm = frm;
        }
        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtUsername.Focus();
            if (!string.IsNullOrEmpty(Properties.Settings.Default.Remember))
            {
                string[] arrStr = Properties.Settings.Default.Remember.Split('-');
                txtUsername.Text = arrStr[0];
                txtPassword.Text = arrStr[1];
                ckbRemember.Checked = true;
            }
            else
                ckbRemember.Checked = false;
        }
        private bool validateTextBox(TextEdit txt)
        {
            if (txt.Text.Trim().Length == 0)
            {
                XtraMessageBox.Show(txt.Tag + " không được rỗng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt.Focus();
                return true;
            }
            return false;
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {

            if (validateTextBox(txtUsername) || validateTextBox(txtPassword))
                return;
            splashScreenManager1.ShowWaitForm();
            int errorCode = 0;
            Staff staff = StaffBUS.Login(txtUsername.Text, txtPassword.Text, ref errorCode);
            if (errorCode.ToString().Equals("-2146232060"))
            {
                splashScreenManager1.CloseWaitForm();

                XtraMessageBox.Show("Lỗi kết nối server.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                frm.setStatus("Lỗi kết nối server.", Color.Red);
            }
            else
        if (staff == null)
            {
                splashScreenManager1.CloseWaitForm();
                XtraMessageBox.Show("Sai tài khoản hoặc mật khẩu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                frm.setStatus("Sai tài khoản hoặc mật khẩu", Color.Red);
            }
            else

            {
                if (ckbRemember.Checked)
                    Properties.Settings.Default.Remember = txtUsername.Text.Trim() + "-" + txtPassword.Text.Trim();
                else
                    Properties.Settings.Default.Remember = "";
                Properties.Settings.Default.Save();
                frm.Hide();
                splashScreenManager1.CloseWaitForm();
                new frmMain(frm, staff).Show();
            }

        }


    }
}