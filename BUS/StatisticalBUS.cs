using DAO;
using DevExpress.XtraGrid;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public static class StatisticalBUS
    {
        private static ManagementDrugStoreContextDataContext db = new ManagementDrugStoreContextDataContext();
        public static void ClearCache(this ManagementDrugStoreContextDataContext context)
        {
            const BindingFlags FLAGS = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
            var method = context.GetType().GetMethod("ClearCache", FLAGS);
            method.Invoke(context, null);
        }
        public static double TotalEntrySlip(DateTime dateTimeFrom, DateTime dateTimeTo)
        {
            ClearCache(db);
            double sumMoney = db.EntrySlips.Where(x => x.isPay == true && x.createDate.Value.CompareTo(dateTimeFrom) >= 0 && x.createDate.Value.CompareTo(dateTimeTo) <= 0).ToList().Sum(x => x.total);
            return sumMoney;
        }

        public static double TotalInvoice(DateTime dateTimeFrom, DateTime dateTimeTo)
        {
            ClearCache(db);
            double sumMoney = db.Invoices.Where(x => x.isPay == true && x.createDate.Value.CompareTo(dateTimeFrom) >= 0 && x.createDate.Value.CompareTo(dateTimeTo) <= 0).ToList().Sum(x => x.total);
            return sumMoney;
        }
        public static DataTable loadDetailStatistical(GridControl gc, DateTime dateTimeFrom, DateTime dateTimeTo)
        {
            ClearCache(db);
            DataTable tb = new DataTable();
            tb.Columns.Add("date");
            tb.Columns.Add("invoice");
            tb.Columns.Add("entrySlip");
            tb.Columns.Add("profit");
            var lstOrder = db.Invoices.Where(x => x.isPay == true && x.createDate.Value.CompareTo(dateTimeFrom) >= 0 && x.createDate.Value.CompareTo(dateTimeTo) <= 0).ToList();
            var lstImport = db.EntrySlips.Where(x => x.isPay == true && x.createDate.Value.CompareTo(dateTimeFrom) >= 0 && x.createDate.Value.CompareTo(dateTimeTo) <= 0).ToList();
            for (DateTime date = dateTimeFrom; date.CompareTo(dateTimeTo) <= 0; date = date.AddDays(1))
            {
                var lstOrderTemp = lstOrder.Where(x => DateTime.Parse(x.createDate.Value.ToShortDateString()).CompareTo(DateTime.Parse(date.ToShortDateString())) == 0).ToList();
                var lstImportTemp = lstImport.Where(x => DateTime.Parse(x.createDate.Value.ToShortDateString()).CompareTo(DateTime.Parse(date.ToShortDateString())) == 0).ToList();
                if (lstOrderTemp.Count != 0 || lstImportTemp.Count != 0)
                {
                    DataRow dr = tb.NewRow();
                    var sumOrder = lstOrderTemp.Sum(x => x.total);
                    var sumImport = lstImportTemp.Sum(x => x.total);
                    dr[0] = date.ToShortDateString();
                    dr[1] = Support.convertVND(sumOrder.ToString());
                    dr[2] = Support.convertVND(sumImport.ToString());
                    dr[3] = Support.convertVND((sumOrder - sumImport).ToString());
                    tb.Rows.Add(dr);
                }
            }
            gc.DataSource = tb;
            return tb;
        }

    }
}
