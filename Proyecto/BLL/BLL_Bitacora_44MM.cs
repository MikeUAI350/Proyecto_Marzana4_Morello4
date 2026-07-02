using BE;
using DAL;
using Digito_Verificador_IS;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Servicios;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BLL
{
    public class BLL_Bitacora_44MM
    {
        private DAL_Bitacora_44MM dal_bitacora = new DAL_Bitacora_44MM();
        private BLL_Digito_Verificador_44MM bll_dv = new BLL_Digito_Verificador_44MM();
        private DataTable_Converter_44MM<BE_Bitacora_44MM> datatable_converter = new DataTable_Converter_44MM<BE_Bitacora_44MM>();

        public void Registrar_Evento(string login, DateTime fecha, string modulo, string evento, int criticidad)
        {
            dal_bitacora.Registrar_Evento(login, fecha, modulo, evento, criticidad);
            //Digito verificador
            bll_dv.Guardar_Calculo();
        }

        public List<BE_Bitacora_44MM> Gestionar_Bitacora()
        {
            dal_bitacora.Recuperar_Bitacora();
            DataTable tabla_usuarios = dal_bitacora.tabla_datos;

            List<BE_Bitacora_44MM> lista_usuarios = datatable_converter.DataTable_Class(tabla_usuarios, typeof(BE_Bitacora_44MM));

            return lista_usuarios;
        }

        public DataRow Obtener_Login(string login)
        {
            DataTable dt = dal_bitacora.Obtener_Login(login);
            if (dt.Rows.Count != 1)
            {
                return null;
            }
            else
            {
                return dt.Rows[0];
            }
        }

        public (bool, string) Imprimir_Bitacora(List<BE_Bitacora_44MM> lista, string ruta)
        {
            DataTable tabla = datatable_converter.Class_DataTable(lista, typeof(BE_Bitacora_44MM));
            // Crear documento
            Document documento = new Document(PageSize.A4.Rotate(), 10f, 10f, 10f, 10f);

            try
            {
                PdfWriter.GetInstance(documento, new FileStream(ruta, FileMode.Create));
                documento.Open();

                // Crear tabla PDF
                PdfPTable tablaPDF = new PdfPTable(tabla.Columns.Count);
                tablaPDF.WidthPercentage = 100;

                // Fuente
                Font fuenteCabecera = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16);
                Font fuenteDatos = FontFactory.GetFont(FontFactory.HELVETICA, 12);

                // Encabezados
                foreach (DataColumn columna in tabla.Columns)
                {
                    PdfPCell celda = new PdfPCell(new Phrase(columna.ColumnName, fuenteCabecera));
                    celda.HorizontalAlignment = Element.ALIGN_CENTER;
                    celda.BackgroundColor = BaseColor.LIGHT_GRAY;

                    tablaPDF.AddCell(celda);
                }

                // Datos
                foreach (DataRow fila in tabla.Rows)
                {
                    foreach (object valor in fila.ItemArray)
                    {
                        PdfPCell celda = new PdfPCell(new Phrase(valor.ToString(), fuenteDatos));
                        celda.HorizontalAlignment = Element.ALIGN_LEFT;

                        tablaPDF.AddCell(celda);
                    }
                }

                documento.Add(tablaPDF);
                documento.Close();

                return (true, "PDFGeneradoExitosamenteEn");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }
    }
}
