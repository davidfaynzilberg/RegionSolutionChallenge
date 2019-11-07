using System;
using System.Collections.Generic;
using System.Text;

namespace RegionSolution
{
    public class SubRegion : List<Tuple<int, int>>
    {
        private RegionHelper _regionHelper;
        public SubRegion(RegionHelper regionHelper) : base() {
            _regionHelper = regionHelper;
        }

        // Function Determine and return the Center Of Mass
        public Tuple<Double, Double> CenterOfMass()
        {
            Double sumOfX = 0;
            Double sumOfY = 0;
            Double sumOfValues = 0;

            foreach (var tuple in this)
            {
                sumOfValues += _regionHelper.InputRegion[tuple.Item2, tuple.Item1];
            }
            // Console.Write("\n\t111111111111111111111 {0}", sumOfValues);

            foreach (var tuple in this)
            {
                Double tempValue = _regionHelper.InputRegion[tuple.Item2, tuple.Item1];
                sumOfX += (Double)tuple.Item1 * tempValue / sumOfValues;
                sumOfY += (Double)tuple.Item2 * tempValue / sumOfValues;
                // Console.Write("\n\t{0} {1} {2} {3}", sumOfX, sumOfY, tempValue, sumOfValues);
            }

            return new Tuple<double, double>(sumOfX, sumOfY);
            // return new Tuple<double, double>(sumOfX / this.Count * sumOfValues, sumOfY / this.Count * sumOfValues);
        }
    }
}
