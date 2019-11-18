using System;
using System.Collections.Generic;

namespace RegionSolution
{
    class Program
    {
        static void Main(string[] args)
        {
            // Introduction
            Console.WriteLine("Welcome to Region Center Calculation App");
            Console.WriteLine("\nExample Input:\n");
            Console.WriteLine("(1) 6 6 - Two-Dimenstion Array Dimensions");
            Console.WriteLine("\n(2) Array Lines:");
            Console.WriteLine(" 0, 80, 45, 95, 170, 145 - Two Dimenstion Array Input");
            Console.WriteLine(" 115, 210, 60, 5, 230, 220 ");
            Console.WriteLine(" 5, 0, 145, 250, 245, 140 ");
            Console.WriteLine(" 15, 5, 175, 250, 185, 160 ");
            Console.WriteLine(" 5, 0, 25, 5, 145, 250 ");
            Console.WriteLine("\n(3) 200 - Threshold Input");
            Console.WriteLine("");
            Console.WriteLine("---------- OR ----------");
            Console.WriteLine("\ntype: 'load test data'");
            Console.WriteLine("\n");

            InputCommands inputCommands = new InputCommands();

            while (!inputCommands.InputsCompleated)
            {
                // Adding Inputs
                inputCommands.AddInput(Console.ReadLine());
            }

            // setting the Threshold
            int threshold = inputCommands.Threshold;
            Console.WriteLine("\nThreshold Is Set to: {0}", threshold.ToString());

            // Allocating the arrays Dimensions
            // int[,] inputRegion = new int[inputCommands.lengthX, inputCommands.lengthY];
            // Console.WriteLine("\nDimensions Is Set to: {0}x{1}", inputCommands.lengthX.ToString(), inputCommands.lengthY.ToString());

            // getting the mass values from inputs
            int[,] inputRegion = inputCommands.inputArray;

            // Printing inputed mass
            Console.WriteLine("\nMass Is Set to:");
            for (int y = 0; y < inputRegion.GetLength(0); y++)
            {
                for (int x = 0; x < inputRegion.GetLength(1); x++)
                {
                    Console.Write("\t{0}", inputRegion[y, x]);
                }
                Console.WriteLine("");
            }

            RegionHelper regionHelper = new RegionHelper(inputRegion);
            List<Tuple<Double, Double>> results = regionHelper.process(threshold);

            int cntr = 1;
            foreach (var result in results)
                Console.Write("\n\tCenter of The Mass {2} X:<{0}> Y:<{1}> average position\n\n", result.Item1.ToString(), result.Item2.ToString(), cntr++);
        }
    }
}
