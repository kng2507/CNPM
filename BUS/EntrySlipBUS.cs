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
    public static class EntrySlipBUS
    {
        private static ManagementDrugStoreContextDataContext db = new ManagementDrugStoreContextDataContext();
       
        public static void GetDataGV(GridControl gv, bool isPay = true)
        {
            ClearCache(db);
            List<EntrySlip> lst;
            if (isPay)
                lst = (from item in db.EntrySlips select item).ToList();
            else
                lst = (from item in db.EntrySlips where item.isPay == false select item).ToList();
            gv.DataSource = Support.ToDataTable<EntrySlip>(lst);
        }
        public static void ClearCache(this ManagementDrugStoreContextDataContext context)
        {
            const BindingFlags FLAGS = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
            var method = context.GetType().GetMethod("ClearCache", FLAGS);
            method.Invoke(context, null);
        }
        public static int Insert(EntrySlip model)
        {
            try
            {
                db.EntrySlips.InsertOnSubmit(model);
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
                var model = db.EntrySlips.FirstOrDefault(x => x.id == id);
                db.EntrySlips.DeleteOnSubmit(model);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                return -1;
            }
            return 1;
        }
        public static int Update(int id, bool isPay)
        {
            try
            {
                var nk = db.EntrySlips.FirstOrDefault(x => x.id == id);
                nk.isPay = isPay;
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                return -1;
            }
            return 1;
        }
        public static EntrySlip GetLast()
        {
            return db.EntrySlips.OrderByDescending(x => x.id).FirstOrDefault();
        }
        public static EntrySlip FindById(int id)
        {
            return db.EntrySlips.FirstOrDefault(x => x.id == id);
        }
        public static bool IsStaff(int staffId)
        {
            return db.EntrySlips.FirstOrDefault(x => x.staffId == staffId) != null;
        }
    }
}
