using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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

using HorizontalAlignment = iText.Layout.Properties.HorizontalAlignment;
using VerticalAlignment = iText.Layout.Properties.VerticalAlignment;
//using GetHeight = iText.Layout.Style.GetHeight;
using NUnit.Framework;
using iTextSharp.text.pdf;
using iText.Kernel.Colors;
using iText.Layout.Renderer;
using iText.Layout.Layout;

namespace JPEGtoPDF
{
      

    class PDFMaker
    {
        public static void createDocument(List<ImageSelection> listImages,Appearance appearance, PageSize pageSize, string exportFile)
        {
            
            checkSameDocuments(ref exportFile);

            using (PdfWriter writer = new PdfWriter(exportFile))
            {
                using (PdfDocument pdf = new PdfDocument(writer))
                {
                   Document pdoc = new Document(pdf, pageSize);
                    //PdfPage pdfPage = new PdfPage();

                   //pdoc.SetMargins(14.175f, 14.175f, 14.175f, 14.175f);
                    pdoc.SetMargins(14.1665f, 14.1665f, 14.1665f, 14.1665f);
                    //PdfContents pdfContents = new PdfContents(pdoc,pageSize);
                    //pdoc.SetBorder(iText.Layout.Borders.Border.NO_BORDER);



                    /////////////////////////////////////////////////////////////////////////////////



                    /*
                     float[] dim = appearance.getDimensions();
                    Table table = new Table(dim, false).SetHeight(UnitValue.CreatePointValue(pageSize.GetHeight()- 28.333f));//.UseAllAvailableWidth();
                    //table.SetDocument(pdoc);
                    table.SetKeepTogether(true);
                    table.SetExtendBottomRow(false);
                    
                    //Alignment.setAlignment(appearance);
                    
                    for (int  i = 0;  i <appearance.getHeightRatio(); i++)
                    {
                        for (int j = 0; j < appearance.getDimensions().Length; j++)
                        {
                            Cell cell = new Cell();
                            //cell.SetHeight(UnitValue.CreatePointValue((pageSize.GetHeight() - 28.333f - 14.166f) / appearance.getHeightRatio()));
                            cell.SetHeight(table.GetHeight().GetValue()/appearance.getHeightRatio());
                            cellStyle(ref cell);
                            table.AddCell(cell);
                        }
                    }
                    */




                    /////////////////////////////////////////////////////////////////////////////////

                    Table table = tableStyle(appearance, pageSize,pdoc);

                    /*IRenderer tableRenderer = table.CreateRendererSubTree().SetParent(pdoc.GetRenderer());
                    LayoutResult tableLayoutResult =
                            tableRenderer.Layout(new LayoutContext(new LayoutArea(1, new iText.Kernel.Geom.Rectangle(pageSize.GetHeight()-14.1665f, pageSize.GetWidth() - 14.1665f))));

                    pdf.SetDefaultPageSize(pageSize/*new PageSize(550 + 72, tableLayoutResult.GetOccupiedArea().GetBBox().GetHeight() + 72));*/



                    for (int k = 0, i = 0, j = 0; k < /*appearance.getImgNumber()*/listImages.Count; k++, j++)
                    {
                        if (j == appearance.getDimensions().Length) 
                        { j = 0; i++; }
                        if (i == appearance.getHeightRatio())
                        {
                            pdoc.Add(table);
                            table = tableStyle(appearance, pageSize,pdoc);
                            pdoc.Add(new AreaBreak(iText.Layout.Properties.AreaBreakType.NEXT_PAGE));
                            j = i = 0;
                        }
                        //pdoc.Add();
                        Image img = new Image(iText.IO.Image.ImageDataFactory.Create(listImages.ElementAt(k).getPath()));
                        // img = imageRescale(img, pageSize, appearance.getImgNumber());
                        //      Alignment.setImage(ref img, i, j);
                        //MessageBox.Show(i + "  " + j);
                        imgStyle(ref img);


                        /*if(i%appearance.getImgNumber() == 0) 
                        {
                            MessageBox.Show("ijo");
                           pdoc.Add(new Page); 
                           // pdoc.
                            table = new Table(dim, true);
                            table.SetDocument(pdoc);
                        }*/

                        //////////////////////////////////// Cell cell = new Cell();
                        //cell.SetHorizontalAlignment 
                        //cellStyle(ref cell);
                        //////////////////////////////////// cell.SetHeight(UnitValue.CreatePointValue((pageSize.GetHeight()-28.333f- 14.166f) / appearance.getHeightRatio() ));
                        //cell.SetHeight(UnitValue.CreatePointValue((table.GetHeight().GetValue() / appearance.getHeightRatio())));
                        //cell.SetHeight(UnitValue.CreatePointValue(table.GetHeight(). / 2));
                        //MessageBox.Show( table.GetHeight().ToString());
                        //img.SetHorizontalAlignment( iText.Layout.Properties.HorizontalAlignment.RIGHT);
                       // img.SetAutoScale(true);
                        table.GetCell(i,j).Add(img);
                        //cellStyle(ref cell);
                        //table.AddCell(cell);




                    }
                    pdoc.Add(table);
                   // Alignment.setAlignment(ref table);
                   
                    //pdoc.Add(new AreaBreak(iText.Layout.Properties.AreaBreakType.NEXT_PAGE));
                    //pdoc.Add(new Paragraph(""));
                    
                    //pdoc.Add(table);
                   
                    pdoc.Close();


                }
            }

           
        }

        
        static Image imageRescale(Image img, PageSize pageSize, int imgNumber)
            {

                float sizeWidth = pageSize.GetWidth() - 14.175f;
                float sizeHeight = pageSize.GetHeight() - 14.175f;
                



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



            //UnitValue.CreatePointValue(pageSize.GetHeight()/2);

                img.SetHeight(img.GetImageHeight() * imgheight);
                img.SetWidth(img.GetImageWidth() * imgwidth);
            //img.SetHeight(UnitValue.CreatePointValue(pageSize.GetHeight() / 2));

                return img;
            }


          static void cellStyle(ref Cell cell)
        {
            //cell.SetPadding(0);
            //cell.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
            cell.SetHorizontalAlignment( HorizontalAlignment.CENTER);
            cell.SetVerticalAlignment(VerticalAlignment.MIDDLE);
          

        }
        static void imgStyle(ref Image img)
        {
            
            img.SetHorizontalAlignment(HorizontalAlignment.CENTER);
            img.SetAutoScale(true);

        }

        static Table tableStyle(Appearance appearance, PageSize pageSize, Document pdoc)
        {
            float[] dim = appearance.getDimensions();

            Table table = new Table(dim, true);

            table.UseAllAvailableWidth().SetDocument(pdoc);

            table.SetHeight(UnitValue.CreatePointValue(pageSize.GetHeight() - 28.333f));
            //table.SetWidth(UnitValue.CreatePointValue(pageSize.GetWidth() - 28.333f));
            //table.SetKeepTogether(true);
           //table.SetExtendBottomRow(false);
            //MessageBox.Show(pdoc.GetPageEffectiveArea(pageSize).ApplyMargins(14.1665f, 14.1665f, 14.1665f, 14.1665f,false).GetHeight().ToString());
            //float documentHeight = pdoc.GetPageEffectiveArea(pageSize).ApplyMargins(14.1665f, 14.1665f, 14.1665f, 14.1665f, false).GetHeight();
            for (int i = 0; i < appearance.getHeightRatio(); i++)
            {
                for (int j = 0; j < appearance.getDimensions().Length; j++)
                {
                    Cell cell = new Cell();
                   
                    cell.SetHeight(table.GetHeight().GetValue() / appearance.getHeightRatio());
                    cell.SetMinHeight(table.GetHeight().GetValue() / appearance.getHeightRatio());
                    cell.SetMaxHeight(table.GetHeight().GetValue() / appearance.getHeightRatio());
                    //cell.SetHeight(documentHeight / appearance.getHeightRatio());
                    //cell.SetMinHeight(documentHeight / appearance.getHeightRatio());
                    //cell.SetMaxHeight(documentHeight / appearance.getHeightRatio());

                    //MessageBox.Show(cell.GetHeight().GetValue().ToString());
                   /* cell.SetWidth(table.GetWidth().GetValue() / appearance.getDimensions().Length);
                    cell.SetMinWidth(table.GetWidth().GetValue() / appearance.getDimensions().Length);
                    cell.SetMaxWidth(table.GetWidth().GetValue() / appearance.getDimensions().Length);*/
                    cellStyle(ref cell);
                    table.AddCell(cell);
                }
            }
            return table;
        }

        static void checkSameDocuments(ref string exportFile)
        {
            int countFiles = 0;
            while (File.Exists(exportFile.Substring(0, exportFile.Length - 4) + ((countFiles > 0) ? "(" + (countFiles + 1).ToString() + ")" : "") + ".pdf") ) countFiles++;
            exportFile = exportFile.Substring(0,exportFile.Length-4)+ ((countFiles > 0) ? "(" + (countFiles + 1).ToString() + ")" : "")+".pdf"; 
        }
        }
    }

