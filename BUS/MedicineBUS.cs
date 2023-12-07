using DAO;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public static class  MedicineBUS
    {

        private static ManagementDrugStoreContextDataContext db = new ManagementDrugStoreContextDataContext();
        public static void GetDataLk(RepositoryItemLookUpEdit lk, int supplierId = 0)
        {
            ClearCache(db);
            if (supplierId == 0)
                lk.DataSource = from item in db.Medicines select item;
            else
                lk.DataSource = from item in db.Medicines where item.supplierId == supplierId select item;
            lk.DisplayMember = "name";
            lk.ValueMember = "id";
        }
        public static void ClearCache(this ManagementDrugStoreContextDataContext context)
        {
            const BindingFlags FLAGS = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
            var method = context.GetType().GetMethod("ClearCache", FLAGS);
            method.Invoke(context, null);
        }
        public static void GetDataGV(GridControl gv)
        {
            ClearCache(db);
            var lst = (from item in db.Medicines select item).ToList();
            gv.DataSource = Support.ToDataTable<Medicine>(lst);
        }
        public static int Insert(Medicine model)
        {
            try
            {
                db.Medicines.InsertOnSubmit(model);
                db.SubmitChanges();
                return 1;
            }
            catch (Exception ex)
            {

                return -1;
            }

        }
        public static int Update(Medicine model)
        {
            var modelUpdate = db.Medicines.SingleOrDefault(x => x.id == model.id);
            try
            {
                if (modelUpdate == null)
                    return -1;
                modelUpdate.name = model.name;
                modelUpdate.note = model.note;
                modelUpdate.uses = model.uses;
                modelUpdate.image = model.image;
                modelUpdate.price = model.price;
                modelUpdate.Supplier = db.Suppliers.SingleOrDefault(x => x.id == model.supplierId);
                modelUpdate.supplierId = model.supplierId;
                modelUpdate.Manufacturer = db.Manufacturers.SingleOrDefault(x => x.id == model.manufacturerId);
                modelUpdate.manufacturerId = model.manufacturerId;
                modelUpdate.TypeOfMedicine = db.TypeOfMedicines.SingleOrDefault(x => x.id == model.typeOfMedicineId);
                modelUpdate.typeOfMedicineId = model.typeOfMedicineId;
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
                var model = db.Medicines.SingleOrDefault(x => x.id == id);
                if (model == null)
                    return -1;
                db.Medicines.DeleteOnSubmit(model);
                db.SubmitChanges();
                return 1;
            }
            catch (Exception ex)
            {

                return -1;
            }

        }
        public static Medicine FindById(int id)
        {
            ClearCache(db);
            return db.Medicines.SingleOrDefault(x => x.id == id);
        }

    }
}
