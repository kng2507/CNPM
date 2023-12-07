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
using BUS;

namespace GUI.FRM
{
    public partial class frmChangePass : DevExpress.XtraEditors.XtraForm
    {
        Staff staff;
        frmMain frm;
        public frmChangePass(frmMain frm,Staff staff)
        {
            InitializeComponent();
            this.staff = staff;
            this.frm = frm;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        bool validateTextBox(TextEdit txt)
        {
            if (txt.Text.Trim().Length == 0)
            {
                XtraMessageBox.Show(txt.Tag + " không được rỗng.", "Thông báo");
                txt.Focus();
                return true;
            }
            return false;
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (validateTextBox(txtOldPass) || validateTextBox(txtNewPass))
                return;
            if (txtNewPass.Text.Length < 5)
            {
                XtraMessageBox.Show("Mật khẩu từ 5 kí tự trở lên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNewPass.Focus();
                return;
            }
            if(!txtNewPass.Text.Equals(txtConfirmPass.Text))
            {
                XtraMessageBox.Show("Xác nhận mật khẩu không giống nhau.", "Thông báo",MessageBoxButtons.OK ,MessageBoxIcon.Error);
                txtConfirmPass.Focus();
                return;
            }
            int i =StaffBUS.ChangePassword(staff.id, txtOldPass.Text, txtNewPass.Text);
            if (i == -1)
            { 
                XtraMessageBox.Show("Mật khẩu cũ không chính xác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtOldPass.Focus();
            }
            else
            {
                XtraMessageBox.Show("Đổi mật khẩu thành công.Vui lòng đăng nhập lại", "Thông báo");
                frm.logout(1);
            }
        }
    }
}