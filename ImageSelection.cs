using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPEGtoPDF
{
    class ImageSelection
    {

        
        private string name { get; set; }
        private string path;
        private int index { get; set; }

      
        public ImageSelection (string name, string path)
        {
            this.name = name;
            this.path = path;
            

        }

        public override string ToString()
        {
            return name;
        }

        public string getPath()
        {
            return path;
        }

    }
}
