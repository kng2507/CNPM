using DAO;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class StaffBUS
    {
        private static ManagementDrugStoreContextDataContext db = new ManagementDrugStoreContextDataContext();

        public static void GetDataLk(RepositoryItemLookUpEdit lk)
        {
            lk.DataSource = from item in db.Staffs select item;
            lk.DisplayMember = "name";
            lk.ValueMember = "id";
        }
        public static void GetDataGV(GridControl gv)
        {
            var lst = (from item in db.Staffs select item).ToList();
            gv.DataSource = Support.ToDataTable<Staff>(lst);
        }
        public static int Insert(Staff model)
        {
            if (db.Staffs.FirstOrDefault(x => x.username.ToLower().Equals(model.username.ToLower())) != null)
                return 0;
            try
            {
                db.Staffs.InsertOnSubmit(model);
                db.SubmitChanges();
                return 1;
            }
            catch (Exception ex)
            {

                return -1;
            }

        }
        public static int Update(Staff model)
        {
            var modelUpdate = db.Staffs.FirstOrDefault(x => x.id == model.id);
            try
            {
                if (modelUpdate == null)
                    return -1;
                modelUpdate.name = model.name;                
                modelUpdate.image = model.image;
                modelUpdate.dateOfBirth = model.dateOfBirth;
                modelUpdate.phone = model.phone;
                modelUpdate.Role = db.Roles.SingleOrDefault(x => x.id == model.roleId);
                modelUpdate.roleId = model.roleId;
                modelUpdate.address = model.address;
                db.SubmitChanges();
                return 1;
            }
            catch (Exception ex)
            {

                return -1;
            }

        }
        public static int Delete(int id)
        {
            try
            {
                var model = db.Staffs.FirstOrDefault(x => x.id == id);
                if (model == null)
                    return -1;
                db.Staffs.DeleteOnSubmit(model);
                db.SubmitChanges();
                return 1;
            }
            catch (Exception ex)
            {

                return -1;
            }

        }
        public static int ResetPassword(int id)
        {
         
            var modelUpdate = db.Staffs.FirstOrDefault(x => x.id == id);
            try
            {
                if (modelUpdate == null)
                    return -1;
                modelUpdate.password = Support.EndCodeMD5("12345");
                db.SubmitChanges();
                return 1;
            }
            catch (Exception ex)
            {

                return -1;
            }

        }
        public static int ChangePassword(int id,string oldPass,string newPass)
        {
            oldPass = Support.EndCodeMD5(oldPass);
            newPass = Support.EndCodeMD5(newPass);
            var modelUpdate = db.Staffs.SingleOrDefault(x => x.id == id && x.password.Equals(oldPass));
            try
            {
                if (modelUpdate == null)
                    return -1;
                modelUpdate.password = newPass;
                db.SubmitChanges();
                return 1;
            }
            catch (Exception ex)
            {

                return -1;
            }

        }
        public static Staff Login(string username, string password, ref int errorCode)
        {
            password = Support.EndCodeMD5(password.Trim());
            Staff staff = null;
            try
            {
                staff = db.Staffs.SingleOrDefault(x => x.username.Trim().Equals(username.Trim()) && x.password.Equals(password));
            }
            catch (SqlException ex)
            {
                errorCode = ex.ErrorCode;
            }

            return staff;
        }
    }
}
