using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;

using Image = iText.Layout.Element.Image;
using PageSize = iText.Kernel.Geom.PageSize;
using System.Drawing.Imaging;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text;

namespace JPEGtoPDF
{
    

    public partial class FormImageToPDF : Form
    {
        
        public string saveLocation = Environment.CurrentDirectory;
        
        int imgNumber = 4;

        List<ImageSelection> listImages = new List<ImageSelection>();

        public FormImageToPDF()
        {
            InitializeComponent();
            textBoxOutputPath.Text = saveLocation;
            pictureBoxPreview.SizeMode = PictureBoxSizeMode.Zoom;
            populateComboBox();
        }

        void populateComboBox()
        {
            List<Format> formats = new List<Format>() 
            { 
                new Format()
                {
                    id = "01",
                    formatValue = "20x20 (cm)",
                    numberFormats =new List<PicturesPerPage>
                    {
                        new PicturesPerPage("01","3"),
                        new PicturesPerPage("01","4")
                    }
                },
                new Format()
                {
                    id = "02",
                    formatValue = "21x30 (cm)",
                    numberFormats = new List<PicturesPerPage>
                    {
                        new PicturesPerPage("02","4"),
                        new PicturesPerPage("02","6")
                    }
                },
                new Format()
                {
                    id = "03",
                    formatValue = "21x15 (cm)",
                    numberFormats = new List<PicturesPerPage>
                    {
                        new PicturesPerPage("03","4")
                    }
                }
            };

            
            comboBoxFormat.DataSource = formats;
            comboBoxFormat.ValueMember = "id";
            comboBoxFormat.DisplayMember = "formatValue";

            comboBoxPages.DataSource = comboBoxFormat.DataSource;


            
            comboBoxPages.DisplayMember = "numberFormats.numberPages";
            comboBoxFormat.SelectedIndex = 0;
            comboBoxAppearance.SelectedIndex = 0;
        }

        private void addFiles_Click(object sender, EventArgs e)
        {
            string[] pathToImages = null;
            string[] fileNames = null;

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "Image file| " + " *.png; *.jpg; *.jpeg; *.jfif; *.bmp; *.tif; *.tiff; *.gif";
            
            
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pathToImages = openFileDialog.FileNames.ToArray();
                fileNames = openFileDialog.SafeFileNames.ToArray();
            }
            for (int i = 0; i < fileNames.Length; i++)
                if (checkingDuplicates(fileNames.ElementAt(i)))
                {
                    listImages.Add(new ImageSelection(fileNames.ElementAt(i), pathToImages.ElementAt(i)));
                    listBoxImageFile.Items.Add(listImages.Last());
                }
                else MessageBox.Show("An image with this name already exists. Please rename or choose another image !");

        }

        bool checkingDuplicates(string fileName)
        {
            foreach (ImageSelection image in listImages)
                if (image.ToString() == fileName) return false;

            return true;
        }

        private void removeSelected_Click(object sender, EventArgs e)
        {


            List<ImageSelection> imagesToDelete = new List<ImageSelection>();

            foreach (ImageSelection garbage in listBoxImageFile.SelectedItems)
                imagesToDelete.Add(garbage);

            foreach (ImageSelection imageToDelete in imagesToDelete)
            {
                listBoxImageFile.Items.Remove(imageToDelete);

                foreach (ImageSelection image in listImages)
                {
                    if (image.ToString() == imageToDelete.ToString())
                    {
                        listImages.Remove(image);
                        break;
                    }
                }
            }


        }


        private void ButtonOutputPath_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    textBoxOutputPath.Text = fbd.SelectedPath;


                }
            }
        }

        private void SavePDF_Click(object sender, EventArgs e)
        {
            string pdfName ;
            PageSize pageSize =  new PageSize(567f, 567f);

            pdfName = textBoxPDFName.Text;
            if (!(textBoxPDFName.Text.EndsWith(".pdf"))) pdfName+=".pdf";
           


           
            string exportFile = Path.Combine(textBoxOutputPath.Text, pdfName);
           

            
                switch (comboBoxFormat.Text)
                {
                    case "20x20 (cm)": pageSize = new PageSize(567f, 567f);       break;
                    case "21x30 (cm)": pageSize = new PageSize(595.35f, 850.5f);  break;
                    case "21x15 (cm)": pageSize = new PageSize(595.35f, 425.25f); break;
                }
                switch (comboBoxPages.Text)
                {
                    case "3": imgNumber = 3;  break;
                    case "4": imgNumber = 4;  break;
                    case "6": imgNumber = 6;  break;
                }


            PDFMaker.createDocument(listImages, pageSize, imgNumber, exportFile);

            }
        

        private void listBoxImageFile_MouseClick(object sender, MouseEventArgs e)
        {
            int count = 0;

            foreach (ImageSelection img in listBoxImageFile.SelectedItems) count++;
            if (count == 1)
            {
                foreach (ImageSelection img in listImages)
                    if (img.ToString() == listBoxImageFile.SelectedItem.ToString())
                    {
                        pictureBoxPreview.Image = System.Drawing.Image.FromFile(img.getPath()); break;
                    }
            }

            else { pictureBoxPreview.Image = null; }
        }

        private void comboBoxFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((comboBoxFormat.Text == "21x30 (cm)" || comboBoxFormat.Text == "21x15 (cm)"))
                if (!comboBoxAppearance.Items.Contains("Magic Appearance")) comboBoxAppearance.Items.Add("Magic Appearance");
                else return;
            else comboBoxAppearance.Items.Remove("Magic Appearance");
                
        }

        private void button1_Click(object sender, EventArgs e)
        {
            formatInformation formatInformation = new formatInformation();
            formatInformation.Show();
        }
    }
    }

