using DAO;
using DevExpress.XtraGrid;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class InvoiceDetailBUS
    {
        private static ManagementDrugStoreContextDataContext db = new ManagementDrugStoreContextDataContext();
        public static void GetDataGV(GridControl gv, int invoiceId)
        {
            db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues,
                   db.InvoiceDetails);
            var lst = (from item in db.InvoiceDetails where item.invoiceId == invoiceId select item).ToList();
            gv.DataSource = Support.ToDataTable<InvoiceDetail>(lst);
        }
        public static List<InvoiceDetail> GetDataGV(int invoiceId)
        {
            db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues,
                   db.InvoiceDetails);
            return (from item in db.InvoiceDetails where item.invoiceId == invoiceId select item).ToList();
        }
        public static int Insert(InvoiceDetail model)
        {
            var modelUpdate = db.InvoiceDetails.FirstOrDefault(x => x.invoiceId == model.invoiceId && x.medicineId == model.medicineId);
            if (modelUpdate != null)
            {
                model.id = modelUpdate.id;
                model.quantity += modelUpdate.quantity;
                Update(model);
                return 2;
            }
            else
            {

                db.InvoiceDetails.InsertOnSubmit(model);
                db.SubmitChanges();
                return 1;

            }
        }
        public static int Update(InvoiceDetail model)
        {
            if (model.quantity == 0)
            {
                Delete(model.id);
                return 2;
            }
            else
            {

                var modelUpdate = db.InvoiceDetails.FirstOrDefault(x => x.invoiceId == model.invoiceId && x.medicineId == model.medicineId);
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
            var model = db.InvoiceDetails.FirstOrDefault(x => x.id==id);
            if (model == null)
                return -1;
            db.InvoiceDetails.DeleteOnSubmit(model);
            db.SubmitChanges();
            return 1;

        }
        public static InvoiceDetail FindByID(int id)
        {
            return db.InvoiceDetails.SingleOrDefault(x => x.id==id);
        }
        public static bool IsMedicine(int medicineId)
        {
            return db.InvoiceDetails.FirstOrDefault(x => x.medicineId == medicineId) != null;
        }
    }
}
