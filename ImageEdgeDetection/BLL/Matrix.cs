/*
 * The Following Code was developed by Dewald Esterhuizen
 * View Documentation at: http://softwarebydefault.com
 * Licensed under Ms-PL 
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImageEdgeDetection
{
    public static class Matrix
    {
        public static List<double[,]> AllMatrix
        {
            get
            {

                double[,] laplacian5x5 = { { -1, -1, -1, -1, -1, },
                                           { -1, -1, -1, -1, -1, },
                                           { -1, -1, 24, -1, -1, },
                                           { -1, -1, -1, -1, -1, },
                                           { -1, -1, -1, -1, -1  }, };

                double[,] sobel3x3Horizontal = { { -1,  0,  1, },
                                                 { -2,  0,  2, },
                                                 { -1,  0,  1, }, };

                double[,] prewitt3x3Vertical = { {  1,  1,  1, },
                                                 {  0,  0,  0, },
                                                 { -1, -1, -1, }, };

                List<double[,]> allMatrix = new List<double[,]>();
                allMatrix.Add(laplacian5x5);
                allMatrix.Add(sobel3x3Horizontal);
                allMatrix.Add(prewitt3x3Vertical);

                return allMatrix;
            }

        }
    }
}
