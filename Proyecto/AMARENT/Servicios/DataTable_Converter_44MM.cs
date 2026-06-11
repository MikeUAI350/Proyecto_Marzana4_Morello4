using BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class DataTable_Converter_44MM<T>
    {
        public List<T> DataTable_Class(DataTable tabla, Type tipo)
        {
            List<T> list = new List<T>();
            foreach (DataRow row in tabla.Rows)
            {
                T be = (T)Activator.CreateInstance(tipo, row);
                list.Add(be);
            }
            return list;
        }

        public DataTable Class_DataTable(List<T> lista, Type tipo)
        {
            DataTable tabla = new DataTable();
            foreach (var item in lista)
            {
                if (tabla.Columns.Count == 0)
                {
                    foreach (PropertyInfo prop in tipo.GetProperties())
                    {
                        tabla.Columns.Add(prop.Name);
                    }
                }
                DataRow row = tabla.NewRow();
                foreach (PropertyInfo prop in tipo.GetProperties())
                {
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                }
                tabla.Rows.Add(row);
            }
            return tabla;
        }
    }
}