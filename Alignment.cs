using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iText.Layout.Properties;
using Table = iText.Layout.Element.Table;
using Image = iText.Layout.Element.Image;
using HorizontalAlignment = iText.Layout.Properties.HorizontalAlignment;
using VerticalAlignment = iText.Layout.Properties.VerticalAlignment;
namespace JPEGtoPDF
{


    class Alignment
    {
         static Table tableAl = null;
         static private HorizontalAlignment[,] horizontalAlignments = new HorizontalAlignment[3,3];
         static private VerticalAlignment[,] verticalAlignments = new VerticalAlignment[3,3];
        static public void setAlignment( ref Table table)
        {
            tableAl = table;
            int rows = table.GetNumberOfRows();
            int cols = table.GetNumberOfColumns();
            if (rows == 0 && cols == 0) return;
            if (rows == 2 && cols == 3) alignment_1(2, 3);
            if (rows == 2 && cols == 2) alignment_2(2, 2);
            if (rows == 1 && cols == 3) alignment_3(1, 3);
            if (rows == 3 && cols == 2) alignment_4(3, 2);
            if (rows == 3 && cols == 1) alignment_5(3, 1);

            if (rows == 4 && cols == 1) alignment_6(4, 1);
            if (rows == 6 && cols == 1) alignment_7(6, 1);
            if (rows == 1 && cols == 4) alignment_8(1, 4);
        }
         static public void setAlignment(Appearance appearance)
        {
            tableAl = null;
            int rows = appearance.getHeightRatio();
            int cols = appearance.getDimensions().Length;
            

            if (rows == 2 && cols == 3) alignment_1(2, 3);
            if (rows == 2 && cols == 2) alignment_2(2, 2);
            if (rows == 1 && cols == 3) alignment_3(1, 3);
            if (rows == 3 && cols == 2) alignment_4(3, 2);
            if (rows == 3 && cols == 1) alignment_5(3, 1);

            if (rows == 4 && cols == 1) alignment_6(4, 1);
            if (rows == 6 && cols == 1) alignment_7(6, 1);
            if (rows == 1 && cols == 4) alignment_8(1, 4);
        }

        public  static void alignment_1(int rows, int cols)
        {

            
            /*horizontalAlignments = new HorizontalAlignment[rows, cols];
            verticalAlignments = new VerticalAlignment[rows, cols];*/

            horizontalAlignments[0, 0] = HorizontalAlignment.RIGHT;
            verticalAlignments[0, 0] = VerticalAlignment.BOTTOM;

            horizontalAlignments[0, 1] = HorizontalAlignment.CENTER;
            verticalAlignments[0, 1] = VerticalAlignment.BOTTOM;

            horizontalAlignments[0, 2] = HorizontalAlignment.LEFT;
            verticalAlignments[0, 2] = VerticalAlignment.BOTTOM;

            horizontalAlignments[1, 0] = HorizontalAlignment.RIGHT;
            verticalAlignments[1, 0] = VerticalAlignment.TOP;

            horizontalAlignments[1, 1] = HorizontalAlignment.CENTER;
            verticalAlignments[1, 1] = VerticalAlignment.TOP;

            horizontalAlignments[1, 2] = HorizontalAlignment.LEFT;
            verticalAlignments[1, 2] = VerticalAlignment.TOP;
            if(tableAl!= null) setTable(rows, cols);
        }
        static public void alignment_2(int rows, int cols)
        {
            
            /*horizontalAlignments = new HorizontalAlignment[rows, cols];
            verticalAlignments = new VerticalAlignment[rows, cols];*/

            horizontalAlignments[0, 0] = HorizontalAlignment.RIGHT;
            verticalAlignments[0, 0] = VerticalAlignment.BOTTOM;

            horizontalAlignments[0, 1] = HorizontalAlignment.LEFT;
            verticalAlignments[0, 1] = VerticalAlignment.BOTTOM;

            horizontalAlignments[1, 0] = HorizontalAlignment.RIGHT;
            verticalAlignments[1, 0] = VerticalAlignment.TOP;

            horizontalAlignments[1, 1] = HorizontalAlignment.LEFT;
            verticalAlignments[1, 1] = VerticalAlignment.TOP;

            if (tableAl != null) setTable(rows, cols);

        }
        static public void alignment_3(int rows, int cols)
        {
            
            /*horizontalAlignments = new HorizontalAlignment[rows, cols];
            verticalAlignments = new VerticalAlignment[rows, cols];*/

            horizontalAlignments[0, 0] = HorizontalAlignment.RIGHT;
            verticalAlignments[0, 0] = VerticalAlignment.MIDDLE;

            horizontalAlignments[0, 1] = HorizontalAlignment.CENTER;
            verticalAlignments[0, 1] = VerticalAlignment.MIDDLE;

            horizontalAlignments[0, 2] = HorizontalAlignment.LEFT;
            verticalAlignments[0, 2] = VerticalAlignment.MIDDLE;


            if (tableAl != null) setTable(rows, cols);

        }
        static public void alignment_4(int rows, int cols)
        {
           
            /*horizontalAlignments = new HorizontalAlignment[rows, cols];
            verticalAlignments = new VerticalAlignment[rows, cols];*/

            horizontalAlignments[0, 0] = HorizontalAlignment.RIGHT;
            verticalAlignments[0, 0] = VerticalAlignment.BOTTOM;

            horizontalAlignments[0, 1] = HorizontalAlignment.LEFT;
            verticalAlignments[0, 1] = VerticalAlignment.BOTTOM;

            horizontalAlignments[1, 0] = HorizontalAlignment.RIGHT;
            verticalAlignments[1, 0] = VerticalAlignment.TOP;

            horizontalAlignments[1, 1] = HorizontalAlignment.LEFT;
            verticalAlignments[1, 1] = VerticalAlignment.TOP;

            horizontalAlignments[2, 0] = HorizontalAlignment.RIGHT;
            verticalAlignments[2, 0] = VerticalAlignment.TOP;

            horizontalAlignments[2, 1] = HorizontalAlignment.LEFT;
            verticalAlignments[2, 1] = VerticalAlignment.TOP;

            if (tableAl != null) setTable(rows, cols);
        }
        static public void alignment_5(int rows, int cols)
        {
            
            /*horizontalAlignments = new HorizontalAlignment[rows, cols];
            verticalAlignments = new VerticalAlignment[rows, cols];*/

            horizontalAlignments[0, 0] = HorizontalAlignment.CENTER;
            verticalAlignments[0, 0] = VerticalAlignment.BOTTOM;

            horizontalAlignments[1, 0] = HorizontalAlignment.CENTER;
            verticalAlignments[1, 0] = VerticalAlignment.MIDDLE;

            horizontalAlignments[2, 0] = HorizontalAlignment.CENTER;
            verticalAlignments[2, 0] = VerticalAlignment.TOP;


            if (tableAl != null) setTable(rows, cols);
        }
        static public void alignment_6(int rows, int cols)
        {
            /*horizontalAlignments = new HorizontalAlignment[rows, cols];
            verticalAlignments = new VerticalAlignment[rows, cols];*/

            horizontalAlignments[0, 0] = HorizontalAlignment.CENTER;
            verticalAlignments[0, 0] = VerticalAlignment.BOTTOM;

            horizontalAlignments[1, 0] = HorizontalAlignment.CENTER;
            verticalAlignments[1, 0] = VerticalAlignment.MIDDLE;

            horizontalAlignments[2, 0] = HorizontalAlignment.CENTER;
            verticalAlignments[2, 0] = VerticalAlignment.MIDDLE;

            horizontalAlignments[3, 0] = HorizontalAlignment.CENTER;
            verticalAlignments[3, 0] = VerticalAlignment.TOP;

            

            if (tableAl != null) setTable(rows, cols);
        }
        static public void alignment_7(int rows, int cols)
        {
            /*horizontalAlignments = new HorizontalAlignment[rows, cols];
            verticalAlignments = new VerticalAlignment[rows, cols];*/

            horizontalAlignments[0, 0] = HorizontalAlignment.CENTER;
            verticalAlignments[0, 0] = VerticalAlignment.BOTTOM;

            horizontalAlignments[1, 0] = HorizontalAlignment.CENTER;
            verticalAlignments[1, 0] = VerticalAlignment.MIDDLE;

            horizontalAlignments[2, 0] = HorizontalAlignment.CENTER;
            verticalAlignments[2, 0] = VerticalAlignment.MIDDLE;

            horizontalAlignments[3, 0] = HorizontalAlignment.CENTER;
            verticalAlignments[3, 0] = VerticalAlignment.MIDDLE;

            horizontalAlignments[4, 0] = HorizontalAlignment.CENTER;
            verticalAlignments[4, 0] = VerticalAlignment.MIDDLE;

            horizontalAlignments[5, 0] = HorizontalAlignment.CENTER;
            verticalAlignments[5, 0] = VerticalAlignment.TOP;

            if (tableAl != null) setTable(rows, cols);
        }
        static public void alignment_8(int rows, int cols)
        {

            /*horizontalAlignments = new HorizontalAlignment[rows, cols];
            verticalAlignments = new VerticalAlignment[rows, cols];*/

            horizontalAlignments[0, 0] = HorizontalAlignment.RIGHT;
            verticalAlignments[0, 0] = VerticalAlignment.MIDDLE;

            horizontalAlignments[0, 1] = HorizontalAlignment.CENTER;
            verticalAlignments[0, 1] = VerticalAlignment.MIDDLE;

            horizontalAlignments[0, 2] = HorizontalAlignment.CENTER;
            verticalAlignments[0, 2] = VerticalAlignment.MIDDLE;

            horizontalAlignments[0, 3] = HorizontalAlignment.LEFT;
            verticalAlignments[0, 3] = VerticalAlignment.MIDDLE;

            if (tableAl != null) setTable(rows, cols);

        }

        static void setTable(int rows, int cols)
        {

           // MessageBox.Show(rows.ToString()+ " " + cols.ToString() );
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                {
                    tableAl.GetCell(i, j).SetHorizontalAlignment(horizontalAlignments[i, j]);
                    tableAl.GetCell(i, j).SetVerticalAlignment(verticalAlignments[i, j]);
                    //tableAl.GetCell(1, 0).


                }
        }

        public static void setImage(ref Image img ,int row, int col)
        {
            img.SetHorizontalAlignment(horizontalAlignments[row, col]);
        }
    }
}
