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
using MetadataExtractor.Util;
using MetadataExtractor.Formats;
using MetadataExtractor.IO;
using Org.BouncyCastle.Asn1.Cms;
using NPOI.Util;
using MetadataExtractor.Formats.Exif;

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
                   
                    pdoc.SetMargins(14.1665f, 14.1665f, 14.1665f, 14.1665f);
                    



                  

                    Table table = tableStyle(appearance, pageSize,pdoc);

                    



                    for (int k = 0, i = 0, j = 0; k < listImages.Count; k++, j++)
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
                      
                        Image img = new Image(iText.IO.Image.ImageDataFactory.Create(listImages.ElementAt(k).getPath()));
                       
                        imgStyle(ref img, listImages.ElementAt(k));
                        
                       
                        table.GetCell(i,j).Add(img);
                        



                    }
                    pdoc.Add(table);
                   
                   
                    pdoc.Close();


                }
            }

           
        }

        
        


          static void cellStyle(ref Cell cell)
        {
            
            cell.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
            cell.SetHorizontalAlignment( HorizontalAlignment.CENTER);
            cell.SetVerticalAlignment(VerticalAlignment.MIDDLE);
          

        }
        static void imgStyle(ref Image img, ImageSelection image)
        {

        var directories = MetadataExtractor.ImageMetadataReader.ReadMetadata(image.getPath());
            
            

            foreach (var directory in directories)
        {
                foreach (var tag in directory.Tags)
                    if (tag.Name == "Orientation" && directory.Name == "Exif IFD0")
                    {
                        
                        OrientationChecking.rotateChecking(ref img, tag.Description);
                        break;
                    }
            if (directory.HasError)
            {
                    foreach (var error in directory.Errors) 
                    Console.WriteLine($"ERROR: {error}");
            }
        }

           

            img.SetHorizontalAlignment(HorizontalAlignment.CENTER);
           img.SetAutoScale(true);
           
        }

        static Table tableStyle(Appearance appearance, PageSize pageSize, Document pdoc)
        {
            float[] dim = appearance.getDimensions();

            Table table = new Table(dim, true);

            table.UseAllAvailableWidth().SetDocument(pdoc);

            table.SetHeight(UnitValue.CreatePointValue(pageSize.GetHeight() - 28.333f));
           
            for (int i = 0; i < appearance.getHeightRatio()+1; i++)
            {
                for (int j = 0; j < appearance.getDimensions().Length; j++)
                {
                    Cell cell = new Cell();
                   
                    cell.SetHeight(table.GetHeight().GetValue() / appearance.getHeightRatio() -4.666f);
                    
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

