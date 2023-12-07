using DAO;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class CustomerBUS
    {
        private static ManagementDrugStoreContextDataContext db = new ManagementDrugStoreContextDataContext();
        public static void GetDataLk(LookUpEdit lk)
        {
            lk.Properties.DataSource = from item in db.Customers select item;
            lk.Properties.DisplayMember = "name";
            lk.Properties.ValueMember = "id";
        }
        public static void GetDataLk(RepositoryItemLookUpEdit lk)
        {
            lk.DataSource = from item in db.Customers select item;
            lk.DisplayMember = "name";
            lk.ValueMember = "id";
        }
        public static void GetDataGV(GridControl gv)
        {
            var lst = (from item in db.Customers select item).ToList();
            gv.DataSource = Support.ToDataTable<Customer>(lst);
        }
        public static int Insert(Customer model)
        {            
            try
            {
                db.Customers.InsertOnSubmit(model);
                db.SubmitChanges();
                return 1;
            }
            catch (Exception ex)
            {

                return -1;
            }

        }
        public static int Update(Customer model)
        {
          
            var modelUpdate = db.Customers.FirstOrDefault(x => x.id == model.id);
            try
            {
                if (modelUpdate == null)
                    return -1;
                modelUpdate.name = model.name;                
                modelUpdate.image = model.image;
                modelUpdate.address = model.address;
                modelUpdate.phone = model.phone;
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
                var model = db.Customers.FirstOrDefault(x => x.id == id);
                if (model == null)
                    return -1;
                db.Customers.DeleteOnSubmit(model);
                db.SubmitChanges();
                return 1;
            }
            catch (Exception ex)
            {

                return -1;
            }

        }
        public static Customer FindById(int id)
        {
            return db.Customers.SingleOrDefault(x => x.id == id);
        }
    }
}
