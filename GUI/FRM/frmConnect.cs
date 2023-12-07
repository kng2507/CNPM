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
using DAO;

namespace GUI.FRM
{
    public partial class frmConnect : DevExpress.XtraEditors.XtraForm
    {
        private string connectionString;
        private frmSystem frm;
        public frmConnect(frmSystem frm)
        {
            InitializeComponent();
            this.frm = frm;
        }

        private void btnTestconnect_Click(object sender, EventArgs e)
        {
            splashScreenManager1.ShowWaitForm();
            connectionString = String.Format("server={0}; database={1}; Integrated Security = False;uid={2};pwd={3}", cbbServer.Text.Trim(), cbbDatabase.Text, txtUsername.Text, txtPassword.Text);
            if (Support.TestConnection(connectionString))
            {
                splashScreenManager1.CloseWaitForm();
                XtraMessageBox.Show("Kết nối thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                frm.setStatus("Test kết nối thành công.", Color.Yellow);
            }
            else
            {
                splashScreenManager1.CloseWaitForm();

                XtraMessageBox.Show("Kết nối thất bại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                frm.setStatus("Test kết nối thất bại.", Color.Red);
            }


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
        private void cbbDatabase_MouseDown(object sender, MouseEventArgs e)
        {
            if (validateTextBox(txtUsername) || validateTextBox(txtPassword))
                return;
            splashScreenManager1.ShowWaitForm();

            DataTable tb = Support.GetDBName(".", txtUsername.Text.Trim(), txtPassword.Text);
            if (tb.Rows.Count == 0)
                frm.setStatus("Tài khoản mật khẩu không hợp lệ.", Color.Red);
            else
                frm.setStatus("", Color.Red);

            cbbDatabase.Properties.DataSource = tb;
            cbbDatabase.Properties.DisplayMember = "name";
            splashScreenManager1.CloseWaitForm();

        }

        private void cbbServer_MouseDown(object sender, MouseEventArgs e)
        {
            splashScreenManager1.ShowWaitForm();
            cbbServer.Properties.Items.Clear();
            DataTable tb = Support.GetServerName();
            foreach (DataRow r in tb.Rows)
                cbbServer.Properties.Items.Add(r[0].ToString());
            splashScreenManager1.CloseWaitForm();

        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            connectionString = String.Format("server={0}; database={1}; Integrated Security = False;uid={2};pwd={3}", cbbServer.Text.Trim(), cbbDatabase.Text, txtUsername.Text, txtPassword.Text);
            splashScreenManager1.ShowWaitForm();

            if (Support.SaveConnection(connectionString))
            {
                frm.setStatus("Lưu thành công.Vui lòng khởi động lại ứng dụng.", Color.Yellow);
                splashScreenManager1.CloseWaitForm();

                if (XtraMessageBox.Show("Lưu thành công.Vui lòng khởi động lại ứng dụng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) == DialogResult.OK)
                {

                    GUI.Properties.Settings.Default.BKRS = cbbServer.Text.Trim() + "+" + cbbDatabase.Text + "+" + txtUsername.Text + "+" + txtPassword.Text;
                    GUI.Properties.Settings.Default.Save();
                    Application.Restart();
                }
            }
            else
            {
                splashScreenManager1.CloseWaitForm();

                frm.setStatus("Có lỗi xảy ra.", Color.Red);

                XtraMessageBox.Show("Có lỗi xảy ra.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
    }
}