using DinkToPdf;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace PIA_MAD.Clases
{
    public class Utilidades
    {
        public static string GenerarFactura(string formadepago,
            string formadepagodesc,
            string metododepago,
            string metododepagodesc,
            string serie,
            string folio,
            string date,
            string hora,
            string receptornombre,
            string receptorrfc,
            string receptorusocfdicod,
            string receptorusocfdidesc,
            string receptorregimenfiscalcod,
            string receptoregimenfiscaldesc,
            string receptordomicilio,
            string receptorcp,
            string receptorestado,
            string receptorpais,
            List<ConceptoFactura> conceptos,
            string totalletra,
            string subtotal,
            string anticipo,
            string descuentos, 
            string iva, 
            string retisr,
            string retiva, 
            string total,
            string seriecert,
            string foliofiscal,
            string sericertsat,
            string fechacert,
            string seriedigito
            )
        {
            string cadenatimbre = "||1.0|81a313e0-ded9-417d-bd0a-7443aecc1c79|2017-07-08T11:59:19|fG7oFwSA9mIunoO2L6Rn1TexjfJljwuAD1VNq2WY04J85xt/VF1b57BvTAD5C3uI85VVPzFMuFGg8urlDHPWUHHOQ47Q0+wE69+Tf0o4T0baFQTeXH94ntP+0TpqhD7CymLojMyu4T0czYqZK08T+mdokPK9n3+zW4kxhjrtisdMDBp2Lo1QgHBxfi0Qyc9UrUA5GueX+LEUk+bXr2knG+Ho2i31jC2lb3v6oyNkiQ7Y9pG/4KQud3aTM5b/SMwL+ca/MFdLi7fMKS6H6XsB2jTCaFLTItDXUhHYVjI5zXMX41Brtyw4P4sA322x/QSrvuoS3RPdLeTuadWy8whOUw==|00001000000404614920||";
            string selloemisor = "fG7oFwSA9mIunoO2L6Rn1TexjfJljwuAD1VNq2WY04J85xt/VF1b57BvTAD5C3uI85VVPzFMuFGg8urlDHPWUHHOQ47Q0+wE69+Tf0o4T0baFQTeXH94ntP+0TpqhD7CymLojMyu4T0czYqZK08T+mdokPK9n3+zW4kxhjrtisdMDBp2Lo1QgHBxfi0Qyc9UrUA5GueX+LEUk+bXr2knG+Ho2i31jC2lb3v6oyNkiQ7Y9pG/4KQud3aTM5b/SMwL+ca/MFdLi7fMKS6H6XsB2jTCaFLTItDXUhHYVjI5zXMX41Brtyw4P4sA322x/QSrvuoS3RPdLeTuadWy8whOUw==";
            string sellosat = "p7hl2xt2i5M8ZxMuJbiPmX13Ztm0Cn7NzGIz7KHz4eypxHomubDoOIaowTtunleJ5QQQDCZvYoKu6rEFCsszqh9XweR6k6FmDREI9Mvla9TqC8jK/Wnr6RbP3R7A7N8q+Ap1CiCN3awmecGspHyX03bNRxGZLYKibF9CxklFYZfDUdoguv4w2zoADdt97obdiITQ212K1/m+/JyQb+XM+UH7G1YVHLYnsATGIVvOAXYVPYuXWRw91zqTRaPmZGtFEmFuR+wqO9gbCeXT9PooNSokwItYSp+IdR5bMAXi/PM6ssBPBrWsDYHBthHw9p+t4I9+sAgLZMAafUG8La4k2Q==";
            string htmlTemplate = @"
            <!DOCTYPE html>
            <html lang=""es"">
            <head>
                <meta charset=""UTF-8"">
                <style>
                body { font-family: Arial, Helvetica, sans-serif; font-size: 13px; color: #000; margin: 30px; }
                .header { background-color: #56038a; color: white; padding: 10px; }
                .header h2, .header p { margin: 2px 0; }
                .section { margin-top: 10px; }
                .label { font-weight: bold; }
                table { width: 100%; border-collapse: collapse; margin-top: 10px; }
                th, td { border: 1px solid #999; padding: 5px; text-align: left; }
                .right { text-align: right; }
                .summary-box {
                    width: 250px;
                    border: 1px solid #ccc;
                    padding: 5px;
                    margin-top: 10px;
                    margin-left: auto; /* para empujarlo a la derecha */
                }
                .summary-box table { border: none; width: 100%; }
                .summary-box td { border: none; padding: 3px 0; }
                .footer-note { font-size: 10px; margin-top: 30px; }
                .title { font-size: 40px; }
                .second-title {font-size: 20px; margin-top: 0px; margin-bottom: 0px;}
                .resumen-container { display: flex; justify-content: space-between; align-items: flex-start; gap: 20px; }
                .cert-info { flex: 1; max-width: 60%; }
                .summary-box { width: 250px; border: 1px solid #ccc; padding: 5px; margin-top: 10px; }
                </style>
            </head>
            <body>

            <div class=""header"">
                <h2 class=""title"">PIA_MAD</h2>
                <p>RFC: PIA2303159A1</p>
                <p>Tipo de Comprobante: I - Ingreso</p>
                <p>Lugar de Expedición: 77500</p>
                <p>Régimen Fiscal: 601 - General de Ley Personas Morales</p>
            </div>

            <div class=""section"">
                <p><span class=""label"">Forma de pago:</span> %INVOICE_FORMAPAGO% - %INVOICE_FORMAPAGO_DESC%</p>
                <p><span class=""label"">Método de pago:</span> %INVOICE_METODO_PAGO% - %INVOICE_METODO_PAGO_DESC%</p>
                <p><span class=""label"">Moneda:</span> MXN - Peso Mexicano</p>
                <p><span class=""label"">Folio:</span> %INVOICE_SERIE% - %INVOICE_FOLIO%</p>
                <p><span class=""label"">Fecha:</span> %INVOICE_DATE% %INVOICE_HOUR%</p>
            </div>

            <div class=""section"">
                <h4 class=""second-title"">Datos del cliente</h4>
                <p><span class=""label"">Cliente:</span> %RECEPTOR_NOMBRE%</p>
                <p><span class=""label"">RFC:</span> %RECEPTOR_RFC%</p>
                <p><span class=""label"">Uso CFDI:</span> %RECEPTOR_USO_CFDI_COD% - %RECEPTOR_USO_CFDI_DESC%</p>
                <p><span class=""label"">Régimen Fiscal:</span> %RECEPTOR_REGIMEN_FISCAL_COD% - %RECEPTOR_REGIMEN_FISCAL_DESC%</p>
                <p><span class=""label"">Domicilio:</span> %RECEPTOR_DOMICILIO%, C.P. %RECEPTOR_CP%, %RECEPTOR_ESTADO%, %RECEPTOR_PAIS%</p>
            </div>

            <div class=""section"">
                <table>
                    <thead>
                        <tr>
                            <th>Cantidad</th>
                            <th>Unidad</th>
                            <th>Clave Unidad SAT</th>
                            <th>Clave Producto/Servicio</th>
                            <th>Concepto / Descripción</th>
                            <th>Valor Unitario</th>
                            <th>Descuentos</th>
                            <th>Impuestos</th>
                            <th>Importe</th>
                        </tr>
                    </thead>
                    <tbody>
                        %DETALLES_PRODUCTOS%
                    </tbody>
                </table>
            </div>

            <table style=""width: 100%; border: none; border-collapse: collapse;"">
              <tr valign=""top"">
                <td style=""width: 70%; border: none;"">
                  <p><strong>Importe con letra:</strong> %TOTALLETRA%</p>
                  <p><span class=""label"">Serie del Certificado del emisor:</span> %SERIE_CERT%</p>
                  <p><span class=""label"">Folio fiscal:</span> %FOLIO_FISCAL%</p>
                  <p><span class=""label"">No. de serie del Certificado del SAT:</span> %SERIE_CERT_SAT%</p>
                  <p><span class=""label"">Fecha y hora de certificación:</span> %FECHA_CERT%</p>
                  <p class=""footer-note"">Este documento es una representación impresa de un CFDI</p>
                </td>
                <td style=""width: 30%; border: none; text-align: right;"">
              <div style=""display: inline-block; width: 250px; text-align: left;"">
                <table style=""width: 100%; border: none;"">
                      <tr><td style=""border: none;"">Subtotal</td><td style=""text-align:right; border: none;"">%SUBTOTAL%</td></tr>
                      <tr><td style=""border: none;"">Anticipo</td><td style=""text-align:right; border: none;"">%ANTICIPO%</td></tr>
                      <tr><td style=""border: none;"">Descuentos</td><td style=""text-align:right; border: none;"">%DESCUENTOS%</td></tr>
                      <tr><td style=""border: none;"">Impuestos Trasladados</td><td style=""text-align:right; border: none;"">%IVA%</td></tr>
                      <tr><td style=""border: none;"">Retención I.S.R.</td><td style=""text-align:right; border: none;"">%RET_ISR%</td></tr>
                      <tr><td style=""border: none;"">Retención I.V.A.</td><td style=""text-align:right; border: none;"">%RET_IVA%</td></tr>
                      <tr><td style=""border: none;""><strong>Total</strong></td><td style=""text-align:right; border: none;""><strong>%TOTAL%</strong></td></tr>
                    </table>
              </div>
            </td>
              </tr>
            </table>

            <div class=""section"">
              <p><strong>Cadena Original del Timbre:</strong></p>
              <pre style=""white-space: pre-wrap; word-break: break-all; font-family: monospace; font-size: 10px;"">
                %CADENA_TIMBRE%
              </pre>
            </div>

            <div class=""section"">
              <p><strong>Sello Digital del Emisor:</strong></p>
              <pre style=""white-space: pre-wrap; word-break: break-all; font-family: monospace; font-size: 10px;"">
                %SELLO_EMISOR%
              </pre>
            </div>

            <div class=""section"">
              <p><strong>Sello Digital del SAT:</strong></p>
              <pre style=""white-space: pre-wrap; word-break: break-all; font-family: monospace; font-size: 10px;"">
                %SELLO_SAT%
              </pre>
            </div>

            </body>
            </html>
            ";
            string htmlFinal = htmlTemplate;
            string detallesProductos = "";
            foreach (var concepto in conceptos)
            {
                detallesProductos += $@"
        <tr>
            <td>{concepto.Cantidad}</td>
            <td>{concepto.Unidad}</td>
            <td>{concepto.ClaveUnidadSAT}</td>
            <td>{concepto.ClaveProductoServicio}</td>
            <td>{concepto.Descripcion}</td>
            <td>{concepto.ValorUnitario:C}</td>
            <td>{concepto.Descuentos:C}</td>
            <td>{concepto.Impuestos:C}</td>
            <td>{concepto.Importe:C}</td>
        </tr>";
            }

            htmlFinal = htmlFinal.Replace("%INVOICE_FORMAPAGO%", formadepago)
                .Replace("%INVOICE_FORMAPAGO_DESC%", formadepagodesc)
                .Replace("%INVOICE_METODO_PAGO%", metododepago)
                .Replace("%INVOICE_METODO_PAGO_DESC%", metododepagodesc)
                .Replace("%INVOICE_SERIE%", serie)
                .Replace("%INVOICE_FOLIO%", folio)
                .Replace("%INVOICE_DATE%", date)
                .Replace("%INVOICE_HOUR%", hora)
                .Replace("%RECEPTOR_NOMBRE%", receptornombre)
                .Replace("%RECEPTOR_RFC%", receptorrfc)
                .Replace("%RECEPTOR_USO_CFDI_COD%", receptorusocfdicod)
                .Replace("%RECEPTOR_USO_CFDI_DESC%", receptorusocfdidesc)
                .Replace("%RECEPTOR_REGIMEN_FISCAL_COD%", receptorregimenfiscalcod)
                .Replace("%RECEPTOR_REGIMEN_FISCAL_DESC%", receptoregimenfiscaldesc)
                .Replace("%RECEPTOR_DOMICILIO%", receptordomicilio)
                .Replace("%RECEPTOR_CP%", receptorcp)
                .Replace("%RECEPTOR_ESTADO%", receptorestado)
                .Replace("%RECEPTOR_PAIS%", receptorpais)
                .Replace("%DETALLES_PRODUCTOS%", detallesProductos)
                .Replace("%TOTALLETRA%", totalletra)
                .Replace("%SUBTOTAL%", subtotal)
                .Replace("%ANTICIPO%", anticipo)
                .Replace("%DESCUENTOS%", descuentos)
                .Replace("%IVA%", iva)
                .Replace("%RET_ISR%", retisr)
                .Replace("%RET_IVA%", retiva)
                .Replace("%TOTAL%", total)
                .Replace("%SERIE_CERT%", seriecert)
                .Replace("%FOLIO_FISCAL%", foliofiscal)
                .Replace("%SERIE_CERT_SAT%", sericertsat)
                .Replace("%FECHA_CERT%", fechacert)
                .Replace("%CADENA_TIMBRE%", cadenatimbre)
                .Replace("%SELLO_EMISOR%", selloemisor)
                .Replace("%SELLO_SAT%", sellosat);
            try
            {
                var context = new CustomAssemblyLoadContext();
                context.LoadUnmanagedLibrary(Path.Combine(Application.StartupPath, "DinkToPdfLibs", "libwkhtmltox.dll"));

                string outputDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Facturas");
                Directory.CreateDirectory(outputDir);
                string fecha = DateTime.Now.ToString("yyyyMMdd_HHmmss"); 
                string nombreLimpio = $"{fecha}-{receptornombre}-{folio}";
                foreach (char c in Path.GetInvalidFileNameChars())
                {
                    nombreLimpio = nombreLimpio.Replace(c, '_');
                }
                string outputPath = Path.Combine(outputDir, nombreLimpio + ".pdf"); 

                var converter = new SynchronizedConverter(new PdfTools());
                var doc = new HtmlToPdfDocument()
                {
                    GlobalSettings = {
                    PaperSize = DinkToPdf.PaperKind.A4,
                    Orientation = DinkToPdf.Orientation.Portrait,
                    Out = outputPath
                },
                    Objects = {
                        new ObjectSettings() {
                        HtmlContent = htmlFinal
                        }
                    }
                };
                converter.Convert(doc);
                MessageBox.Show("Factura generada con éxito en: " + outputPath);
                return outputPath;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar factura:\n" + ex.Message);
                return null;
            }
        }

        public static string FormatearComoMoneda(decimal numero)
        {
            return numero.ToString("C2", new CultureInfo("es-MX"));
        }

        public static string FormatearTextoComoMoneda(string texto)
        {
 
            string onlyDigits = new string(texto.Where(char.IsDigit).ToArray());

            if (decimal.TryParse(onlyDigits, out decimal value))
            {
                value /= 100; 
                return FormatearComoMoneda(value);
            }

            return texto; 
        }

        private static string ToText(long value)
        {
            if (value == 0) return "cero";

            string[] unidades = { "", "uno", "dos", "tres", "cuatro", "cinco", "seis", "siete", "ocho", "nueve" };
            string[] decenas = { "", "diez", "veinte", "treinta", "cuarenta", "cincuenta", "sesenta", "setenta", "ochenta", "noventa" };
            string[] especiales = { "diez", "once", "doce", "trece", "catorce", "quince", "dieciséis", "diecisiete", "dieciocho", "diecinueve" };
            string[] centenas = { "", "ciento", "doscientos", "trescientos", "cuatrocientos", "quinientos", "seiscientos", "setecientos", "ochocientos", "novecientos" };

            StringBuilder result = new StringBuilder();

            if (value >= 1000000)
            {
                long millones = value / 1000000;
                result.Append(ToText(millones) + " millón" + (millones > 1 ? "es " : " "));
                value %= 1000000;
            }

            if (value >= 1000)
            {
                long miles = value / 1000;
                if (miles == 1)
                    result.Append("mil ");
                else
                    result.Append(ToText(miles) + " mil ");
                value %= 1000;
            }

            if (value >= 100)
            {
                if (value == 100)
                {
                    result.Append("cien");
                    return result.ToString();
                }
                long centenasIndex = value / 100;
                result.Append(centenas[centenasIndex] + " ");
                value %= 100;
            }

            if (value >= 20)
            {
                long decenaIndex = value / 10;
                result.Append(decenas[decenaIndex]);
                long unidadIndex = value % 10;
                if (unidadIndex > 0)
                    result.Append(" y " + unidades[unidadIndex]);
            }
            else if (value >= 10)
            {
                result.Append(especiales[value - 10]);
            }
            else if (value > 0)
            {
                result.Append(unidades[value]);
            }

            return result.ToString();
        }


        public static string NumeroALetras(decimal numero)
        {
            var parteEntera = (long)Math.Floor(numero);
            var centavos = (int)Math.Round((numero - parteEntera) * 100);

            string letras = $"{ToText(parteEntera).Trim()} pesos";

            if (centavos > 0)
                letras += $" con {centavos:00}/100 M.X.N.";
            else
                letras += " 00/100 M.X.N.";

            return letras;
        }


        public static string GenerarUUID() => Guid.NewGuid().ToString().ToUpper();

        public static string GenerarSerieCertificadoEmisor() => "00001000000502128267";

        public static string GenerarSerieCertificadoSAT() => "00001000000403258748";

        public static string GenerarFechaCertificacion() => DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");

        public static string GenerarSelloDigital() => Convert.ToBase64String(Guid.NewGuid().ToByteArray()) + "...";

        public static string GenerarTipoRelacion() => "01 - Nota de crédito de los documentos relacionados";
    }
}
