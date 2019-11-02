using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPEGtoPDF
{
    enum AppearanceType { Portrait, Landscape, Magic }
    class Appearance
    {
        private AppearanceType type { get; set; }

        private Format format { get; set; }


        private float[] dimensions;

        
        private int imgNumber { get; set; }
        private int heightRatio { get; set; }

        public Appearance(AppearanceType appearanceType, Format format, int imgNumber)
        {
            this.type = appearanceType;
            this.imgNumber = imgNumber;
            this.format = format;

            init(type, this.imgNumber);
        }


        public float [] getDimensions()
        {
            return dimensions;
        }

        public int getImgNumber()
        {
            return imgNumber;
        }

        public int getHeightRatio()
        {
            return heightRatio;
        }

        public void init(AppearanceType appearanceType, int imgNumber)
        {
            if(imgNumber == 4 && ((appearanceType==AppearanceType.Landscape)||(appearanceType == AppearanceType.Portrait)))
            {
                this.dimensions = new float[] { 1, 1 };
                this.heightRatio = 2;
                return;
            }

            if(appearanceType == AppearanceType.Portrait && imgNumber == 6)
            {
                this.dimensions = new float[] { 1, 1, 1 };
                this.heightRatio = 2;
                return;
            }
            if (appearanceType == AppearanceType.Portrait && imgNumber == 3)
            {
                this.dimensions = new float[] { 1, 1, 1 };
                this.heightRatio = 1;
                return;
            }

            if (appearanceType == AppearanceType.Landscape && imgNumber == 6)
            {
                this.dimensions = new float[] {1, 1};
                this.heightRatio = 3;
                return;
            }

            if (appearanceType == AppearanceType.Landscape && imgNumber == 3)
            {
                this.dimensions = new float[] {1};
                this.heightRatio = 3;
                return;
            }

            if (appearanceType == AppearanceType.Magic && imgNumber == 4 && format.formatValue=="21x30 (cm)")
            {
                this.dimensions = new float[] { 1 };
                this.heightRatio = 4;
                return;
            }

            if (appearanceType == AppearanceType.Magic && imgNumber == 6 && format.formatValue == "21x30 (cm)")
            {
                this.dimensions = new float[] { 1 };
                this.heightRatio = 6;
                return;
            }

            if (appearanceType == AppearanceType.Magic && format.formatValue == "21x15 (cm)")
            {
                this.dimensions = new float[] {1, 1, 1, 1};
                this.heightRatio = 1;
                return;
            }
        }

    }
}
