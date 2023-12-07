using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;

namespace GUI.FRM
{
    public partial class frmSystem : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmSystem()
        {
            InitializeComponent();
            lbStatus.Caption = "";
        }
        void openForm(Type typeForm)
        {
            foreach (Form frm in MdiChildren)
            {

                if (frm.GetType() == typeForm)
                {
                    frm.Activate();

                    return;
                }
            }
            Form f = (Form)Activator.CreateInstance(typeForm, this);
            f.MdiParent = this;

            f.Show();
        }
        public void setStatus(string status, Color cl)
        {
            lbStatus.Caption = status;
            lbStatus.ItemAppearance.Normal.ForeColor = cl;
        }

        private void btnConnect_ItemClick(object sender, ItemClickEventArgs e)
        {
            openForm(typeof(frmConnect));

        }

        private void btnLogin_ItemClick(object sender, ItemClickEventArgs e)
        {
            openForm(typeof(frmLogin));

        }

        private void frmSystem_Load(object sender, EventArgs e)
        {
            openForm(typeof(frmLogin));

        }
        public void _show()
        {
            this.Show();

            foreach (Form frm in MdiChildren)
            {

                if (frm.GetType() == typeof(frmLogin))
                {
                    frm.Close();

                    return;
                }
            }

        }
    }
}