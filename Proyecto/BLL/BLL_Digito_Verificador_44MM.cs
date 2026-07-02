using DAL;
using Servicios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digito_Verificador_IS
{
    public class BLL_Digito_Verificador_44MM
    {
        private DAL_Digito_Verificador_44MM dal_dv = new DAL_Digito_Verificador_44MM();

        public (bool, List<string>) Recalcular_Todo()
        {
            bool exito = true;
            List<string> nombres_tablas = new List<string>();

            DataSet tables = dal_dv.Recuperar_Tablas();
            foreach (DataTable table in tables.Tables)
            {
                string v = Calcular_Vertical(table);
                string h = Calcular_Horizontal(table);

                DataRow row = dal_dv.tabla_datos.Rows.Find(table.TableName);
                if (row != null)
                {
                    if ((string)row["Calculo_Vertical"] != v || (string)row["Calculo_Horizontal"] != h)
                    {
                        exito = false;
                        nombres_tablas.Add(table.TableName);
                    }
                }
            }
            return (exito, nombres_tablas);
        }

        public bool Recalcular()
        {
            bool exito = true;

            DataSet tables = dal_dv.Recuperar_Tablas();
            foreach (DataTable table in tables.Tables)
            {
                string v = Calcular_Vertical(table);
                string h = Calcular_Horizontal(table);

                DataRow row = dal_dv.tabla_datos.Rows.Find(table.TableName);
                if (row != null)
                {
                    if ((string)row["Calculo_Vertical"] != v || (string)row["Calculo_Horizontal"] != h)
                    {
                        exito = false;
                    }
                }
            }
            return exito;
        }

        public void Guardar_Calculo()
        {
            DataSet tables = dal_dv.Recuperar_Tablas();
            foreach (DataTable table in tables.Tables)
            {
                string v = Calcular_Vertical(table);
                string h = Calcular_Horizontal(table);

                dal_dv.Guardar_Calculo(table.TableName, v, h);
            }
        }

        #region Calculos
        private string Calcular_Vertical(DataTable table)
        {
            string total = string.Empty;
            foreach (DataRow row in table.Rows)
            {
                string total_row = string.Empty;
                for (int x = 0; x < table.Columns.Count; x++)
                {
                    total_row += row[x].ToString();
                }
                string total_row_enc = Encriptador_44MM.Instancia.Computar(total_row);
                total += total_row_enc;
            }
            string total_enc = Encriptador_44MM.Instancia.Computar(total);
            //int total_size = total_enc.Count();
            return total_enc;
        }

        private string Calcular_Horizontal(DataTable table)
        {
            string total = string.Empty;
            foreach (DataColumn column in table.Columns)
            {
                string total_column = string.Empty;
                for (int x = 0; x < table.Rows.Count; x++)
                {
                    total_column += table.Rows[x].ToString();
                }
                string total_column_enc = Encriptador_44MM.Instancia.Computar(total_column);
                total += total_column_enc;
            }
            string total_enc = Encriptador_44MM.Instancia.Computar(total);
            //int total_size = total_enc.Count();
            return total_enc;
        }
        #endregion
    }
}