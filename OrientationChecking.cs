using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


using Image = iText.Layout.Element.Image;
using System.Windows.Forms;
//using iText.Layout.Element.Ima;
namespace JPEGtoPDF
{
    class OrientationChecking
    {
        static double degree = 0;

        public static void rotateChecking(ref Image img, string orientationTag)
        {

            Regex rx = new Regex(@"rotate\s+[0-9]{1,3}(cw|ccw|\s){0,1}", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            Regex rx2 = new Regex(@"(cw|ccw)", RegexOptions.Compiled | RegexOptions.IgnoreCase);

            Regex rx3 = new Regex(@"cw", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            if (rx.IsMatch(orientationTag))
            {
                Match matchDegree = Regex.Match(orientationTag, @"[0-9]{1,3}");
                Match matchType = rx2.Match(orientationTag);
                degree = double.Parse(matchDegree.Value.ToString());
                

                if (!rx3.IsMatch(matchType.Value)) degree = -degree;
                //Console.WriteLine(degree);
                switch (degree)
                {
                    case 90:    img.SetRotationAngle(-Math.PI / 2); break;
                    case 180:   img.SetRotationAngle(-Math.PI); break;
                    case 270:   img.SetRotationAngle(-Math.PI * 3 / 2); break;

                    case -90:   img.SetRotationAngle(Math.PI / 2); break;
                    case -180:  img.SetRotationAngle(Math.PI); break;
                    case -270:  img.SetRotationAngle(Math.PI * 3 / 2); break;

                }
                //img.SetRotationAngle(-Math.PI/2);

                
            }



            


        }


        /*public static void rotateCheckingPreview( ref System.Drawing.Image imgPreview, string path)
        {

            var directories = MetadataExtractor.ImageMetadataReader.ReadMetadata(path);

            string orientationTag = "";

            foreach (var directory in directories)
            {
                foreach (var tag in directory.Tags)
                    if (tag.Name == "Orientation" && directory.Name == "Exif IFD0")
                    {
                        orientationTag = tag.Description;
                        break;
                    }
                if (directory.HasError)
                {
                    foreach (var error in directory.Errors)
                        Console.WriteLine($"ERROR: {error}");
                }
            }
            //Console.WriteLine("hgjkhl");

            Console.WriteLine(orientationTag);
            Regex rx = new Regex(@"rotate\s+[0-9]{1,3}\s+(cw|ccw|\s){0,1}", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            Regex rx2 = new Regex(@"(cw|ccw)", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            Regex rx3 = new Regex(@"cw", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            if (rx.IsMatch(orientationTag))
            {
                Console.WriteLine("I'm in");

                Match matchDegree = Regex.Match(orientationTag, @"[0-9]{1,3}");
                Match matchType = rx2.Match(orientationTag);
                degree = double.Parse(matchDegree.Value.ToString());
                Console.WriteLine(degree);
                if (rx3.IsMatch(matchType.Value)) degree = -degree;





                switch (degree)
                {
                    case 90: imgPreview.RotateFlip(System.Drawing.RotateFlipType.Rotate90FlipNone); break;
                    case 180: imgPreview.RotateFlip(System.Drawing.RotateFlipType.Rotate180FlipNone); break;           
                    case 270: imgPreview.RotateFlip(System.Drawing.RotateFlipType.Rotate270FlipNone);break;

                    case -90: imgPreview.RotateFlip(System.Drawing.RotateFlipType.Rotate270FlipNone); break;
                    case -180: imgPreview.RotateFlip(System.Drawing.RotateFlipType.Rotate180FlipNone); break;
                    case -270: imgPreview.RotateFlip(System.Drawing.RotateFlipType.Rotate90FlipNone); break;
                        

                }
                //img.SetRotationAngle(-Math.PI/2);

                
            }

            

        }*/
    }
}