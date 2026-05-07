using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public sealed class DataTable_Filter_44MM
    {
        private DataTable_Filter_44MM() { }

        private static DataTable_Filter_44MM _Instancia;

        public static DataTable_Filter_44MM Instancia
        {
            get
            {
                if (_Instancia == null)
                {
                    _Instancia = new DataTable_Filter_44MM();
                }
                return _Instancia;
            }
        }


        public static DataTable Filtrar_Tabla(DataTable tabla_original, string propiedad, string valor)
        {
            DataTable dt = new DataTable();
            foreach (DataColumn column in tabla_original.Columns)
            {
                dt.Columns.Add(column.ColumnName);
                dt.Columns[column.ColumnName].DataType = column.DataType;
            }

            foreach (DataRow row in tabla_original.Rows)
            {
                if (row[propiedad].ToString() == valor)
                {
                    DataRow new_row = dt.NewRow();
                    foreach (DataColumn column in tabla_original.Columns)
                    {
                        new_row[column.ColumnName] = row[column.ColumnName];
                    }
                    dt.Rows.Add(new_row);

                }
            }
            return dt;
        }

        public static DataTable Filtrar_Entre_Fechas(DataTable tabla_original, string propiedad, DateTime fecha_inicial, DateTime fecha_final)
        {
            DataTable dt = new DataTable();
            foreach (DataColumn column in tabla_original.Columns)
            {
                dt.Columns.Add(column.ColumnName);
                dt.Columns[column.ColumnName].DataType = column.DataType;
            }

            foreach (DataRow row in tabla_original.Rows)
            {
                DateTime fecha = (DateTime)row[propiedad];
                TimeSpan diferencia_inicial = fecha - fecha_inicial;
                TimeSpan diferencia_final = fecha_final - fecha;

                if (diferencia_inicial.TotalDays <= 1 && diferencia_final.TotalDays <= 1 && fecha.Date >= fecha_inicial.Date && fecha.Date <= fecha_final.Date)
                {
                    DataRow new_row = dt.NewRow();
                    foreach (DataColumn column in tabla_original.Columns)
                    {
                        new_row[column.ColumnName] = row[column.ColumnName];
                    }
                    dt.Rows.Add(new_row);

                }
            }
            return dt;
        }
    }
}