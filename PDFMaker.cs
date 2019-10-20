using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.ComponentModel;
using System.Data;
using System.Drawing;


using System.Windows.Forms;

using iText.Layout;
using iText.Layout.Element;
using Image = iText.Layout.Element.Image;
using PageSize = iText.Kernel.Geom.PageSize;
using PdfWriter = iText.Kernel.Pdf.PdfWriter;
using PdfDocument = iText.Kernel.Pdf.PdfDocument;
using UnitValue = iText.Layout.Properties.UnitValue;
//using GetHeight = iText.Layout.Style.GetHeight;
using NUnit.Framework;
using iTextSharp.text.pdf;
using iText.Kernel.Colors;

namespace JPEGtoPDF
{
    class PDFMaker
    {
        public static void createDocument(List<ImageSelection> listImages, PageSize pageSize, int imgNumber, string exportFile)
        {
            using (PdfWriter writer = new PdfWriter(exportFile))
            {
                using (PdfDocument pdf = new PdfDocument(writer))
                {
                   Document pdoc = new Document(pdf, pageSize);


                    pdoc.SetMargins(14.175f, 14.175f, 14.175f, 14.175f);
                    //pdoc.SetMargins(0,0,0,0);
                    //pdoc.
                    //MessageBox.Show(pdoc.GetPageEffectiveArea(pageSize).ToString());


                    Table table = new Table(2);
                    //table.SetBorder(iText.Layout.Borders.Border.NO_BORDER);

                    table.SetDocument(pdoc);
                   // table.SetMaxWidth(Docume)
                    //table.seth
                    //table.SetMargins(14.175f, 14.175f, 14.175f, 14.175f);
                    
                    //table.SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER);
                    //table.SetVerticalAlignment(iText.Layout.Properties.VerticalAlignment.MIDDLE);
                    for (int i = 0; i < 4/*listImages.Count*/; i++)
                    {
                        Image img = new Image(iText.IO.Image.ImageDataFactory.Create(listImages.ElementAt(i).getPath()));
                        img.SetAutoScale(true);
                        
                        Cell cell = new Cell();
                        //img.SetHeight(cell.GetHeight());
                        //img.SetWidth(cell.GetWidth());

                        //img.ScaleToFit(iText.Layout.Style.GetHeight.cell(), cell.GetHeight(UnitValue.POINT));
                        //cell.SetHeight(0.5f);
                        //cell.SetBackgroundColor(ColorConstants.BLACK);
                        cell.Add(img);
                        //img = imageRescale(img, pageSize, imgNumber);
                        
                        //MessageBox.Show(i.ToString());
                        //if (i % 2 == 0) table.StartNewRow();
                        table.AddCell(cell);




                    }

                    pdoc.Add(table);

                    pdoc.Close();


                }
            }

           // CreatePdf(exportFile, pageSize)
        }

        /*public  static void CreatePdf(String filename, PageSize pageSize)
        {
            // step 1
            using (PdfWriter writer = new PdfWriter(exportFile))
            {
                using (PdfDocument pdf = new PdfDocument(writer))
                {
                    Document pdoc = new Document(pdf, pageSize);

                    Document.Add(createFirstTable());

                }
            }
        }*/

        /**
         * Creates our first table
         * @return our first table
         */
        /*public static PdfPTable createFirstTable()
        {
            // a table with three columns
            iTextSharp.text.pdf.PdfPTable table = new iTextSharp.text.pdf.PdfPTable(3);
            // the cell object
            PdfPCell cell;
            // we add a cell with colspan 3
            cell = new PdfPCell(new iTextSharp.text.Phrase("Cell with colspan 3"));
            //cell.setColspan(3);
            cell.Colspan = 3;
            table.AddCell(cell);
            // now we add a cell with rowspan 2
            cell = new PdfPCell(new iTextSharp.text.Phrase("Cell with rowspan 2"));
            //cell.setRowspan(2);
            cell.Rowspan = 2;
            table.AddCell(cell);
            // we add the four remaining cells with addCell()
            table.AddCell("row 1; cell 1");
            table.AddCell("row 1; cell 2");
            table.AddCell("row 2; cell 1");
            table.AddCell("row 2; cell 2");
            return table;
        }
        */
        /*static Image imageRescale(Image img, PageSize pageSize, int imgNumber)
            {

                float sizeWidth = pageSize.GetWidth() - 28.35f;
                float sizeHeight = pageSize.GetHeight() - 28.35f;
                //float sizeWidth= pageSize.GetWidth();
                //float sizeHeight= pageSize.GetHeight();



                switch (imgNumber)
                {
                    case 1:
                        sizeWidth = sizeWidth / img.GetImageWidth();

                        sizeHeight = sizeHeight / img.GetImageHeight();
                        break;
                    case 2:

                        sizeWidth = sizeWidth / img.GetImageWidth();

                        sizeHeight = sizeHeight / img.GetImageHeight() / 2;
                        break;
                    case 4:

                        sizeWidth = sizeWidth / img.GetImageWidth() / 2;
                        sizeHeight = sizeHeight / img.GetImageHeight() / 2; break;

                    case 6:

                        sizeWidth = sizeWidth / img.GetImageWidth() / 2;
                        sizeHeight = sizeHeight / img.GetImageHeight() / 3;
                        break;


                }

                float imgwidth = sizeWidth;
                float imgheight = sizeHeight;

                if (imgwidth >= imgheight)
                    imgwidth = imgheight;
                else imgheight = imgwidth;





                img.SetHeight(img.GetImageHeight() * imgheight);
                img.SetWidth(img.GetImageWidth() * imgwidth);

                return img;
            }



        }*/
    }
}
