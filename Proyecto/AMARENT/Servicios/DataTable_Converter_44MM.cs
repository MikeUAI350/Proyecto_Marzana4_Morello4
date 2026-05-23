using BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class DataTable_Converter_44MM <T>
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
    }
}