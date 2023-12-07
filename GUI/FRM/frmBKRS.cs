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
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;

namespace GUI.FRM
{
    public partial class frmBKRS : DevExpress.XtraEditors.XtraForm
    {
        public frmBKRS()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 0:backup
        /// 1:restore
        /// </summary>
        /// <param name="check"></param>
        public frmBKRS(string fileName,int check)
        {
            InitializeComponent();
            progressBarControl1.Position =0;

            if (check == 0)
            {
                progressBarControl1.Position = 0;
                string[] strs = Properties.Settings.Default.BKRS.Split('+');
                try
                {
                    Server dbserver = new Server(new ServerConnection(strs[0], strs[2], strs[3]));
                    Backup dbbackup = new Backup() { Action = BackupActionType.Database, Database = strs[1] };
                    dbbackup.Devices.AddDevice(fileName, DeviceType.File);
                    dbbackup.Initialize = true;
                    dbbackup.PercentComplete += Dbbackup_PercentComplete;
                    dbbackup.Complete += Dbbackup_Complete;
                    dbbackup.SqlBackupAsync(dbserver);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("Message",ex.Message);
                }

            }
            else
            {
                progressBarControl1.Position = 0;
                string[] strs = Properties.Settings.Default.BKRS.Split('+');
                try
                {
                    Server dbserver = new Server(new ServerConnection(strs[0], strs[2], strs[3]));
                    Restore dbrestore = new Restore() { Database = strs[1], Action = RestoreActionType.Database, ReplaceDatabase = true, NoRecovery = false };
                    // Kill all processes
                    dbserver.KillAllProcesses(dbrestore.Database);
                    // Set single-user mode
                    Database db = dbserver.Databases[dbrestore.Database];
                    // db.DatabaseOptions.UserAccess=true;
                    db.Alter(TerminationClause.RollbackTransactionsImmediately);
                    // Detach database
                    dbserver.DetachDatabase(dbrestore.Database, false);
                    dbrestore.Devices.AddDevice(fileName, DeviceType.File);
                    
                    dbrestore.PercentComplete += Dbrestore_PercentComplete;
                    dbrestore.Complete += Dbrestore_Complete;
                    dbrestore.SqlRestoreAsync(dbserver);

                    
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("Message",ex.Message);

                }
            }
        }

        private void Dbrestore_Complete(object sender, ServerMessageEventArgs e)
        {
            if (e.Error != null)
            {
                labelControl1.Invoke((MethodInvoker)delegate
                {
                    labelControl1.Text = e.Error.Message;
                });
            }
        }

        private void Dbrestore_PercentComplete(object sender, PercentCompleteEventArgs e)
        {
            progressBarControl1.Invoke((MethodInvoker)delegate
            {
                progressBarControl1.Position = e.Percent;
                progressBarControl1.Update();
            });
        }

        private void Dbbackup_Complete(object sender, ServerMessageEventArgs e)
        {
            if (e.Error != null)
            {
                labelControl1.Invoke((MethodInvoker)delegate
                {
                    labelControl1.Text = e.Error.Message;
                });
            }
        }

        private void Dbbackup_PercentComplete(object sender, PercentCompleteEventArgs e)
        {
            progressBarControl1.Invoke((MethodInvoker)delegate
            {
                progressBarControl1.Position = e.Percent;

                progressBarControl1.Update();
            });
        }

        private void frmBKRS_Load(object sender, EventArgs e)
        {

        }
    }
}