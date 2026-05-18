using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Servicios
{
    public sealed class Bitacora_44MM
    {
        private static readonly object _candado = new object();

        private Bitacora_44MM() { }
        private static Bitacora_44MM _Instancia;

        public static Bitacora_44MM Instancia
        {
            get
            {
                if (_Instancia == null)
                {
                    lock (_candado)
                    {
                        if (_Instancia == null)
                        {
                            _Instancia = new Bitacora_44MM();
                        }
                    }
                }
                return _Instancia;
            }
        }

        private static DAL_Bitacora_44MM _dal = new DAL_Bitacora_44MM();
        public static DAL_Bitacora_44MM Dal
        {
            get { return _dal; }
            set { _dal = value; }
        }

        public static void Registrar_Evento(string login, DateTime fecha, string modulo, string evento, int criticidad)
        {
            Dal.Registrar_Evento(login, fecha, modulo, evento, criticidad);
        }

        private DAL_Bitacora_44MM dal_bitacora = new DAL_Bitacora_44MM();

        public DataTable Gestionar_Bitacora()
        {
            dal_bitacora.Recuperar_Bitacora();
            DataTable tabla_usuarios = dal_bitacora.tabla_datos;

            return tabla_usuarios;
        }

        public (bool, string) Imprimir_Bitacora(DataTable tabla, string ruta)
        {
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

                return (true, "PDF generado exitosamente en: " + ruta);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }
    }
}
