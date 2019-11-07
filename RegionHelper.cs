using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RegionSolution
{
    public class RegionHelper
    {
        public RegionHelper(int[,] inputRegion)
        {
            InputRegion = inputRegion;
            yDimentionSize = inputRegion.GetLength(0);
            xDimentionSize = inputRegion.GetLength(1);
        }

        List<Tuple<Double, Double>> centerOfSubRegionsList = null;
        List<SubRegion> subRegionsList = null;

        private int xDimentionSize { get; set; }
        private int yDimentionSize { get; set; }

        public int[,] InputRegion { get; set; }
        private bool[,] InputRegionProcessedFlags { get; set; }

        private int Threshold { get; set; }

        public List<Tuple<Double, Double>> process(int threshold)
        {
            Threshold = threshold;
            centerOfSubRegionsList = new List<Tuple<Double, Double>>();
            subRegionsList = new List<SubRegion>();

            // creating the array with same size 
            // to keep the processing status for each cell
            InputRegionProcessedFlags = new bool[yDimentionSize, xDimentionSize];

            for (int y = 0; y < InputRegion.GetLength(0); y++)
            {
                for (int x = 0; x < InputRegion.GetLength(1); x++)
                {
                    if (!InputRegionProcessedFlags[y, x])
                        matchCellToRegion(x, y);
                }
            }

            foreach (var subRegion in subRegionsList)
            {
                centerOfSubRegionsList.Add(subRegion.CenterOfMass());
                //foreach (var t in subRegion)
                //    Console.Write("\n\t{0}", t.ToString());
            }

            return centerOfSubRegionsList;
        }

        private void matchCellToRegion(int x, int y, SubRegion subRegion = null)
        {
            // checking if cell is checked
            if (InputRegionProcessedFlags[y, x] == true)
                return;

            InputRegionProcessedFlags[y, x] = true;

            // Console.Write("\n\tIF {0}:{1} with Threshold {2} {3}", y, x, Threshold, InputRegion[y, x]);
            if (InputRegion[y, x] > Threshold)
            {
                if (subRegion == null)
                {
                    subRegion = new SubRegion(this);
                    subRegionsList.Add(subRegion);
                }

                subRegion.Add(new Tuple<int, int>(x, y));

                // Check neighbors
                    for (int yn = y - 1; yn <= y + 1 && yn > -1 && yn < yDimentionSize; yn++)
                    {
                        for (int xn = x - 1; xn <= x + 1 && xn > -1 && xn < xDimentionSize; xn++)
                        {
                            // Console.Write("\n\tChecking {0}:{1} with value {2}", xn, yn, InputRegion[yn, xn]);

                            if (!InputRegionProcessedFlags[yn, xn])
                            {
                                // Console.Write("\n\tChecking {0}:{1} with value {2}", yn, xn, InputRegion[yn, xn]);
                                matchCellToRegion(xn, yn, subRegion);
                            }
                            //else
                            //{
                            //    Console.Write("\n\tNOT Checking {0}:{1} with value {2}", yn, xn, InputRegion[yn, xn]);
                            //}
                        }
                    }
            }
        }
    }

}
