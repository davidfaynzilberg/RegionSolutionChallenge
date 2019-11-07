using System;
using System.Collections.Generic;
using System.Text;

namespace RegionSolution
{
    class InputCommands
    {
        private int x = 0;
        private int y = 0;
        private int _lengthX = 0;
        private int _lengthY = 0;
        private List<string> listOfInputStrings;
        public int[,] inputArray = null;
        public int Threshold { get; set; }
        public int lengthX {
            get => _lengthX;
            set
            {
                _lengthX = value;
            }
        }
        public int lengthY
        {
            get => _lengthY;
            set
            {
                _lengthY = value;
            }
        }

        public InputCommands()
        {
            listOfInputStrings = new List<string>();
        }

        public void AddInput(string inputValues)
        {
            if (!InputsCompleated)
            {
                if (listOfInputStrings.Count == 0) // first Two Dimenstion Array Dimensions "5 6"
                {
                    if (inputValues.Contains("load test data"))
                    {
                        // Loading Test Data
                        // Creating region map testing data
                        inputArray = new int[,] {
                                                { 0, 80, 45, 95, 170, 145 },
                                                { 115, 210, 60, 5, 230, 220 },
                                                { 5, 0, 145, 250, 245, 140 },
                                                { 15, 5, 175, 250, 185, 160 },
                                                { 0, 5, 95, 115, 165, 250 },
                                                { 5, 0, 25, 5, 145, 250 },
                                                // { 115, 210, 60, 5, 230, 220 }
                        };

                        this.Threshold = 200;
                        lengthX = -1;
                    }
                    else if (inputValues.Contains(" "))
                    {
                        var arrDimenstions = inputValues.Split(" ");
                        if(arrDimenstions.Length > 0)
                            lengthX = Convert.ToInt32(arrDimenstions[0]);
                        if(arrDimenstions.Length > 1)
                            lengthY = Convert.ToInt32(arrDimenstions[1]);
                    }
                }
                else if (listOfInputStrings.Count == lengthX + 1) // Last Item Threshold
                {
                    this.Threshold = Convert.ToInt32(inputValues);
                }
                else
                {
                    if(inputArray==null) // Create the array if does not exists
                       inputArray = new int[lengthX, lengthY];

                    y = 0;
                    foreach (string tempValue in inputValues.Split(" "))
                    {
                        inputArray[x, y++] = Convert.ToInt32(tempValue);
                    }

                    x++;
                }

                listOfInputStrings.Add(inputValues);
            }
        }

        public bool InputsCompleated
        {
            get
            {
                return listOfInputStrings.Count == lengthX + 2;
            }
        }
    }
}
