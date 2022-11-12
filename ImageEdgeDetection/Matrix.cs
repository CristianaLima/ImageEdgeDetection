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
                double[,] laplacian3x3 = { { -1, -1, -1,  },
                                           { -1,  8, -1,  },
                                           { -1, -1, -1,  }, };

                double[,] laplacian5x5 = { { -1, -1, -1, -1, -1, },
                                           { -1, -1, -1, -1, -1, },
                                           { -1, -1, 24, -1, -1, },
                                           { -1, -1, -1, -1, -1, },
                                           { -1, -1, -1, -1, -1  }, };

                double[,] sobel3x3Horizontal = { { -1,  0,  1, },
                                                 { -2,  0,  2, },
                                                 { -1,  0,  1, }, };

                double[,] sobel3x3Vertical = { {  1,  2,  1, },
                                               {  0,  0,  0, },
                                               { -1, -2, -1, }, };

                double[,] prewitt3x3Horizontal = { { -1,  0,  1, },
                                                   { -1,  0,  1, },
                                                   { -1,  0,  1, }, };

                double[,] prewitt3x3Vertical = { {  1,  1,  1, },
                                                 {  0,  0,  0, },
                                                 { -1, -1, -1, }, };

                double[,] kirsch3x3Horizontal = { {  5,  5,  5, },
                                                  { -3,  0, -3, },
                                                  { -3, -3, -3, }, };

                double[,] kirsch3x3Vertical = { {  5, -3, -3, },
                                                {  5,  0, -3, },
                                                {  5, -3, -3, }, };

                List<double[,]> allMatrix = new List<double[,]>();
                allMatrix.Add(laplacian3x3);
                allMatrix.Add(laplacian5x5);
                allMatrix.Add(sobel3x3Horizontal);
                allMatrix.Add(sobel3x3Vertical);
                allMatrix.Add(prewitt3x3Horizontal);
                allMatrix.Add(prewitt3x3Vertical);
                allMatrix.Add(kirsch3x3Horizontal);
                allMatrix.Add(kirsch3x3Vertical);

                return allMatrix;
            }

        }
    }
}
