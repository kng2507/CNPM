using DAO;
using DevExpress.XtraGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class EntrySlipDetailBUS
    {
        private static ManagementDrugStoreContextDataContext db = new ManagementDrugStoreContextDataContext();
        public static void GetDataGV(GridControl gv, int entrySlipId)
        {
            db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues,
                   db.EntrySlipDetails);
            var lst = (from item in db.EntrySlipDetails where item.entrySlipId == entrySlipId select item).ToList();
            gv.DataSource = Support.ToDataTable<EntrySlipDetail>(lst);
        }
        public static List<EntrySlipDetail> GetDataGV(int entrySlipId)
        {
            db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues,
                   db.EntrySlipDetails);
            return (from item in db.EntrySlipDetails where item.entrySlipId == entrySlipId select item).ToList();

        }
        public static int Insert(EntrySlipDetail model)
        {
            var modelUpdate = db.EntrySlipDetails.FirstOrDefault(x => x.entrySlipId == model.entrySlipId && x.medicineId == model.medicineId);

            if (modelUpdate != null)
            {
                model.quantity += modelUpdate.quantity;
                model.id = modelUpdate.id;
                Update(model);
                return 2;
            }
            else
            {

                db.EntrySlipDetails.InsertOnSubmit(model);
                db.SubmitChanges();
                return 1;

            }
        }
        public static int Update(EntrySlipDetail model)
        {
            if (model.quantity == 0)
            {
                Delete(model.id);
                return 2;
            }
            else
            {

                var modelUpdate = db.EntrySlipDetails.FirstOrDefault(x => x.id == model.id);
                if (modelUpdate == null)
                    return -1;
                modelUpdate.quantity = model.quantity;
                modelUpdate.price = model.price;
                db.SubmitChanges();
                return 1;

            }
        }
        public static int Delete(int id)
        {
            var model = db.EntrySlipDetails.FirstOrDefault(x => x.id == id);
            if (model == null)
                return -1;
            db.EntrySlipDetails.DeleteOnSubmit(model);
            db.SubmitChanges();
            return 1;
        }
        public static bool IsMedicine(int medicineId)
        {
            return db.EntrySlipDetails.FirstOrDefault(x => x.medicineId == medicineId) != null;
        }
    }
}
