using DAO;
using DevExpress.XtraGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public static class InvoiceBUS
    {
        private static ManagementDrugStoreContextDataContext db = new ManagementDrugStoreContextDataContext();
        public static void ClearCache(this ManagementDrugStoreContextDataContext context)
        {
            const BindingFlags FLAGS = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
            var method = context.GetType().GetMethod("ClearCache", FLAGS);
            method.Invoke(context, null);
        }
        public static void GetDataGV(GridControl gv, bool isPay = true)
        {
            db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues,
                    db.Invoices);
            ClearCache(db);
            List<Invoice> lst;
            if (isPay)
                lst = (from item in db.Invoices select item).ToList();
            else
                lst = (from item in db.Invoices where item.isPay == false select item).ToList();
            gv.DataSource = Support.ToDataTable<Invoice>(lst);
        }
        public static int Insert(Invoice model)
        {
            try
            {
                db.Invoices.InsertOnSubmit(model);
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
                var model = db.Invoices.SingleOrDefault(x => x.id == id);
                db.Invoices.DeleteOnSubmit(model);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                return -1;
            }
            return 1;
        }
        public static int Update(int id,bool isPay)
        {
            try
            {
                var model = db.Invoices.FirstOrDefault(x => x.id == id);
                model.isPay = isPay;                
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                return -1;
            }
            return 1;
        }
        public static Invoice GetLast()
        {
            return db.Invoices.OrderByDescending(x => x.id).FirstOrDefault();
        }
        public static Invoice FindById(int id)
        {
            return db.Invoices.FirstOrDefault(x => x.id == id);
        }
        public static bool IsStaff(int staffId)
        {
            return db.Invoices.FirstOrDefault(x => x.staffId == staffId) != null;
        }
        public static bool IsCustomer(int customerId)
        {
            return db.Invoices.FirstOrDefault(x => x.customerId == customerId) != null;
        }
    }
}
