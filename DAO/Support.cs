using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.Sql;

namespace DAO
{
    public static class Support
    {
        public static string EndCodeMD5(string input)
        {
            MD5 md5Hasher = MD5.Create();
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }
        public static DataTable ToDataTable<T>(this IList<T> data)
        {
            PropertyDescriptorCollection properties =
                TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }
        public static bool SaveConnection(string connectionString)
        {
            if (TestConnection(connectionString))
            {
                try
                {
                    Properties.Settings.Default.ManagementDrugstoreConnectionString = connectionString;
                    Properties.Settings.Default.Save();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            return false;
        }
        public static bool TestConnection(string connectionString)
        {
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                con.Open();
                con.Close();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
        public static DataTable GetServerName()
        {
            DataTable dt = new DataTable();
            dt = SqlDataSourceEnumerator.Instance.GetDataSources();
            if (dt.Rows.Count == 0)
            {
                dt = new DataTable();
                dt.Columns.Add("ServerName");
                DataRow r = dt.NewRow();
                r[0] = ".";
                dt.Rows.Add(r);
            }
            return dt;
        }
        public static string convertVND(string money)
        {
              var format = System.Globalization.CultureInfo.GetCultureInfo("en-US");
              string value = String.Format(format, "{0:N0}", Convert.ToDouble(money));
              return value;
        }
        public static DataTable GetDBName(string pServer, string pUser, string pPass)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                da = new SqlDataAdapter("select name from sys.Databases",
                    "Data Source=" + pServer + ";Initial Catalog=master;User ID=" + pUser + ";pwd = " +
                    pPass + "");
                da.Fill(dt);
            }
            catch (Exception)
            {

            }

            return dt;
        }
    }
}
