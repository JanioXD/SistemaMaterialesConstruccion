using iTextSharp.text;
using iTextSharp.text.pdf;
using SistemaMaterialesConstruccion.Entidades;
using System.Diagnostics;
using System.IO;

namespace SistemaMaterialesConstruccion.Utilidades
{
    public class GeneradorPDF
    {
        public static void GenerarFacturaPDF(Venta objVenta)
        {
            string ruta = "Factura_" + objVenta.NumeroFactura + ".pdf";

            // 1. Tipografías y Paleta de Colores Elegante (Gris Grafito)
            BaseColor grisEleganteCorp = new BaseColor(44, 62, 80);
            BaseColor colorTextoGris = new BaseColor(80, 80, 80);
            BaseColor colorLineas = new BaseColor(220, 225, 230);
            BaseColor fondoCliente = new BaseColor(248, 249, 250);

            Font fuenteBarraLateral = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 38, BaseColor.WHITE);
            Font fuenteCompania = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 15, grisEleganteCorp);
            Font fuenteTituloFactura = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18, grisEleganteCorp);
            Font fuenteSeccion = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 9, grisEleganteCorp);
            Font fuenteTexto = FontFactory.GetFont(FontFactory.HELVETICA, 9, colorTextoGris);
            Font fuenteNegrita = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 9, new BaseColor(50, 50, 50));
            Font fuenteBlanca = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 9, BaseColor.WHITE);

            // Márgenes en cero para la barra perimetral izquierda
            Document documento = new Document(PageSize.A4, 0, 0, 0, 0);

            using (FileStream fs = new FileStream(ruta, FileMode.Create))
            {
                using (PdfWriter writer = PdfWriter.GetInstance(documento, fs))
                {
                    documento.Open();

                    // ============================================================================
                    // CONTENEDOR PRINCIPAL: Tabla de 2 columnas (Barra Lateral vs Contenido Derecho)
                    // ============================================================================
                    PdfPTable contenedorPrincipal = new PdfPTable(2);
                    contenedorPrincipal.WidthPercentage = 100;
                    contenedorPrincipal.SetWidths(new float[] { 18f, 82f });

                    // ------------------------------------------------------------------------
                    // COLUMNA IZQUIERDA: Barra con texto vertical
                    // ------------------------------------------------------------------------
                    PdfPCell celdaBarraLateral = new PdfPCell();
                    celdaBarraLateral.BackgroundColor = grisEleganteCorp;
                    celdaBarraLateral.Border = PdfPCell.NO_BORDER;
                    celdaBarraLateral.FixedHeight = PageSize.A4.Height;

                    BarraLateralEvento eventoTexto = new BarraLateralEvento("CONSTRUYE MAS", fuenteBarraLateral);
                    celdaBarraLateral.CellEvent = eventoTexto;
                    contenedorPrincipal.AddCell(celdaBarraLateral);

                    // ------------------------------------------------------------------------
                    // COLUMNA DERECHA: Todo el cuerpo de la factura
                    // ------------------------------------------------------------------------
                    PdfPCell celdaCuerpo = new PdfPCell();
                    celdaCuerpo.Border = PdfPCell.NO_BORDER;
                    celdaCuerpo.Padding = 35f;

                    // --- ENCABEZADO SUPERIOR DERECHO ---
                    PdfPTable tablaEncabezado = new PdfPTable(2);
                    tablaEncabezado.WidthPercentage = 100;
                    tablaEncabezado.SetWidths(new float[] { 55f, 45f });

                    PdfPCell celdaEmpresa = new PdfPCell() { Border = PdfPCell.NO_BORDER };
                    celdaEmpresa.AddElement(new Paragraph("FERRETERÍA CONSTRUYE MÁS S.A.", fuenteCompania));
                    celdaEmpresa.AddElement(new Paragraph("RUC: 1792345678001\nAv. De la Prensa N32-12 y Matilde Alvarez\nTeléfono: (02) 2999-888\nEmail: contacto@construyemas.com", fuenteTexto));
                    tablaEncabezado.AddCell(celdaEmpresa);

                    PdfPCell celdaFacturaInfo = new PdfPCell() { Border = PdfPCell.NO_BORDER };
                    Paragraph pTipo = new Paragraph("FACTURA", fuenteTituloFactura) { Alignment = Element.ALIGN_RIGHT };
                    Paragraph pNum = new Paragraph($"FACTURA NO: {objVenta.NumeroFactura}", fuenteNegrita) { Alignment = Element.ALIGN_RIGHT };
                    Paragraph pFecha = new Paragraph($"FECHA EMISIÓN: {objVenta.Fecha:dd/MM/yyyy}", fuenteTexto) { Alignment = Element.ALIGN_RIGHT };
                    celdaFacturaInfo.AddElement(pTipo);
                    celdaFacturaInfo.AddElement(pNum);
                    celdaFacturaInfo.AddElement(pFecha);
                    tablaEncabezado.AddCell(celdaFacturaInfo);
                    celdaCuerpo.AddElement(tablaEncabezado);

                    celdaCuerpo.AddElement(new Paragraph(" "));

                    // --- BLOQUES EN PARALELO: CLIENTE Y PAGO ---
                    PdfPTable tablaBloquesInformativos = new PdfPTable(2);
                    tablaBloquesInformativos.WidthPercentage = 100;
                    tablaBloquesInformativos.SetWidths(new float[] { 50f, 50f });

                    // Bloque Cliente
                    PdfPCell bloqueCliente = new PdfPCell() { Border = PdfPCell.NO_BORDER };
                    bloqueCliente.AddElement(new Paragraph("FACTURAR A:", fuenteSeccion));
                    bloqueCliente.AddElement(new Paragraph($"Nombre: {objVenta.ObjCliente.Nombre}\nIdentificación: {objVenta.ObjCliente.Identificacion}\nDirección: Av. Juan Tanca Marengo Km 4.5\nTeléfono: 0999999999", fuenteTexto));
                    tablaBloquesInformativos.AddCell(bloqueCliente);

                    // Bloque Información Bancaria de la Empresa
                    PdfPCell bloquePago = new PdfPCell() { Border = PdfPCell.NO_BORDER };
                    bloquePago.AddElement(new Paragraph("MÉTODO DE PAGO:", fuenteSeccion));
                    bloquePago.AddElement(new Paragraph("Banco: Banco Pichincha\nCuenta Cte: 2100456789\nA Nombre de: Construye Más S.A.\nTipo de Pago: Transferencia / Efectivo", fuenteTexto));
                    tablaBloquesInformativos.AddCell(bloquePago);

                    celdaCuerpo.AddElement(tablaBloquesInformativos);
                    celdaCuerpo.AddElement(new Paragraph(" \n"));

                    // --- TABLA PRINCIPAL DE PRODUCTOS ---
                    PdfPTable tablaItems = new PdfPTable(new float[] { 52f, 13f, 15f, 20f });
                    tablaItems.WidthPercentage = 100;

                    string[] headers = { "DESCRIPCIÓN DEL PRODUCTO", "CANT.", "PRECIO", "TOTAL" };
                    foreach (string header in headers)
                    {
                        PdfPCell cHeader = new PdfPCell(new Phrase(header, fuenteBlanca));
                        cHeader.BackgroundColor = grisEleganteCorp;
                        cHeader.Padding = 6f;
                        cHeader.Border = PdfPCell.NO_BORDER;
                        cHeader.HorizontalAlignment = (header.StartsWith("DESCRIPCIÓN")) ? Element.ALIGN_LEFT :
                                                      (header == "CANT.") ? Element.ALIGN_CENTER : Element.ALIGN_RIGHT;
                        tablaItems.AddCell(cHeader);
                    }

                    bool filaPar = false;
                    foreach (DetalleVenta item in objVenta.ListaDetalleVenta)
                    {
                        BaseColor fondoFila = filaPar ? fondoCliente : BaseColor.WHITE;

                        tablaItems.AddCell(CrearCeldaLimpia(item.ObjProducto.Nombre, fuenteTexto, Element.ALIGN_LEFT, fondoFila, colorLineas));
                        tablaItems.AddCell(CrearCeldaLimpia(item.Cantidad.ToString(), fuenteTexto, Element.ALIGN_CENTER, fondoFila, colorLineas));
                        tablaItems.AddCell(CrearCeldaLimpia($"$ {item.PrecioUnitario:N2}", fuenteTexto, Element.ALIGN_RIGHT, fondoFila, colorLineas));
                        tablaItems.AddCell(CrearCeldaLimpia($"$ {item.Subtotal:N2}", fuenteTexto, Element.ALIGN_RIGHT, fondoFila, colorLineas));

                        filaPar = !filaPar;
                    }
                    celdaCuerpo.AddElement(tablaItems);
                    celdaCuerpo.AddElement(new Paragraph(" "));

                    // --- SECCIÓN INFERIOR: TÉRMINOS Y TOTALES ---
                    PdfPTable tablaInferiorTotales = new PdfPTable(2);
                    tablaInferiorTotales.WidthPercentage = 100;
                    tablaInferiorTotales.SetWidths(new float[] { 55f, 45f });

                    // Términos y condiciones (Izquierda)
                    PdfPCell celdaTerminos = new PdfPCell() { Border = PdfPCell.NO_BORDER };
                    celdaTerminos.AddElement(new Paragraph("Términos y Condiciones:", fuenteSeccion));
                    celdaTerminos.AddElement(new Paragraph("1. Los materiales como cemento o hierro no aplican a devoluciones.\n2. Todo cambio se realizará dentro de las 48 horas laborables.\n3. El pago tardío genera un recargo del 2% de interés.", fuenteTexto));
                    tablaInferiorTotales.AddCell(celdaTerminos);

                    // Tabla de Totales (Derecha)
                    PdfPCell celdaTotalesBloque = new PdfPCell() { Border = PdfPCell.NO_BORDER };
                    PdfPTable subTablaTotales = new PdfPTable(2);
                    subTablaTotales.WidthPercentage = 100;

                    InyectarFilaFinTotales(subTablaTotales, "SUB TOTAL", $"$ {objVenta.Subtotal:N2}", fuenteTexto, false, grisEleganteCorp);
                    InyectarFilaFinTotales(subTablaTotales, "IVA (15%)", $"$ {objVenta.IVA:N2}", fuenteTexto, false, grisEleganteCorp);
                    InyectarFilaFinTotales(subTablaTotales, "TOTAL", $"$ {objVenta.Total:N2}", fuenteBlanca, true, grisEleganteCorp);

                    celdaTotalesBloque.AddElement(subTablaTotales);
                    tablaInferiorTotales.AddCell(celdaTotalesBloque);

                    celdaCuerpo.AddElement(tablaInferiorTotales);

                    contenedorPrincipal.AddCell(celdaCuerpo);
                    documento.Add(contenedorPrincipal);
                    documento.Close();
                }
            }

            Process.Start(new ProcessStartInfo { FileName = ruta, UseShellExecute = true });
        }

        private static PdfPCell CrearCeldaLimpia(string texto, Font fuente, int alinear, BaseColor fondo, BaseColor colorBorde)
        {
            return new PdfPCell(new Phrase(texto, fuente))
            {
                HorizontalAlignment = alinear,
                Padding = 7f,
                BackgroundColor = fondo,
                Border = PdfPCell.BOTTOM_BORDER,
                BorderColor = colorBorde,
                BorderWidth = 0.5f
            };
        }

        private static void InyectarFilaFinTotales(PdfPTable tabla, string lbl, string val, Font font, bool esTotal, BaseColor colorFondoTotal)
        {
            PdfPCell cLbl = new PdfPCell(new Phrase(lbl, font));
            PdfPCell cVal = new PdfPCell(new Phrase(val, font));

            if (esTotal)
            {
                cLbl.BackgroundColor = colorFondoTotal;
                cVal.BackgroundColor = colorFondoTotal;
                cLbl.Border = PdfPCell.NO_BORDER;
                cVal.Border = PdfPCell.NO_BORDER;
            }
            else
            {
                cLbl.Border = PdfPCell.BOTTOM_BORDER;
                cVal.Border = PdfPCell.BOTTOM_BORDER;
                cLbl.BorderColor = new BaseColor(230, 230, 230);
                cVal.BorderColor = new BaseColor(230, 230, 230);
            }

            cLbl.Padding = 6f; cLbl.HorizontalAlignment = Element.ALIGN_LEFT;
            cVal.Padding = 6f; cVal.HorizontalAlignment = Element.ALIGN_RIGHT;
            tabla.AddCell(cLbl);
            tabla.AddCell(cVal);
        }
    }
    public class BarraLateralEvento : IPdfPCellEvent
    {
        private string texto;
        private Font fuente;

        public BarraLateralEvento(string texto, Font fuente)
        {
            this.texto = texto;
            this.fuente = fuente;
        }

        public void CellLayout(PdfPCell cell, Rectangle position, PdfContentByte[] canvases)
        {
            PdfContentByte cb = canvases[PdfPTable.TEXTCANVAS];
            cb.SaveState();

            cb.BeginText();
            cb.SetFontAndSize(fuente.BaseFont, fuente.Size);
            cb.SetColorFill(fuente.Color);

            // Centramos horizontalmente la letra dentro del ancho de la barra
            float x = position.Left + (position.Width / 2) - (fuente.Size / 3);
            float y = position.Top - 50f;
            cb.ShowTextAligned(Element.ALIGN_RIGHT, texto, x, y, 90f);

            cb.EndText();
            cb.RestoreState();
        }
    }
}
