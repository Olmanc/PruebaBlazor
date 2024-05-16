using System.Data;
using System.Dynamic;
using System.Reflection;

namespace PruebaPracticaGISSA.Data
{
    public static class GeneralUtils
    {
        public static List<object> ConvertDataTableToObjectsV2(this DataTable table)
        {
            return table.AsEnumerable().Select(row => {
                var obj = new ExpandoObject() as IDictionary<string, object>;
                foreach (var column in table.Columns.Cast<DataColumn>())
                {
                    obj[column.ColumnName.Trim()] = row[column].ToString().Trim();
                }
                return (object)obj;
            }).ToList();
        }

        public static List<object> ConvertDataTableToObjectsParallel(this DataTable table)
        {
            // Se asume que el entorno puede beneficiarse del procesamiento paralelo
            return table.AsEnumerable().AsParallel().Select(row =>
            {
                var obj = new ExpandoObject() as IDictionary<string, object>;
                foreach (var column in table.Columns.Cast<DataColumn>())
                {
                    obj[column.ColumnName.Trim()] = row[column]?.ToString().Trim();
                }
                return (object)obj;
            }).ToList();
        }


        public static List<object> ConvertDataTableToObjects(this DataTable table)
        {
            string a = "";
            var list = new List<object>();

            foreach (DataRow row in table.Rows)
            {
                var obj = new ExpandoObject() as IDictionary<string, object>;

                foreach (DataColumn column in table.Columns)
                {
                    obj.Add(column.ColumnName.ToString().TrimEnd().TrimStart(), row[column].ToString().TrimEnd().TrimStart());
                }

                list.Add(obj);
            }

            return list;
        }

        public static List<T> ConvertDataTable<T>(this DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }
        private static T GetItemString<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                        pro.SetValue(obj, dr[column.ColumnName].ToString().Trim(), null);
                    else
                        continue;
                }
            }
            return obj;
        }

        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);

            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    else
                        continue;
                }
            }
            return obj;
        }
    }
}
