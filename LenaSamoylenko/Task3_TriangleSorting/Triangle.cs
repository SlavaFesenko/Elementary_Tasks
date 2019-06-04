using System;
using System.Collections.Generic;

namespace Task3_TriangleSorting
{
    internal class Triangle
    {
        private double firstSide;
        private int measureForFirstSide;
        private double secondSide;
        private int measureForSecondSide;
        private double thirtSide;
        private int measureForThirdSide;
        private int perimeterMeasure;
        private string name;

        public double FirstSide { get => firstSide; }
        public double SecondSide { get => secondSide; }
        public double ThirtSide { get => thirtSide; }
        public string Name { get => name; private set => name = value; }
        public int PerimeterMeasure
        {
            get => perimeterMeasure;
            private set => perimeterMeasure = value;
        }

        public Dictionary<string, int> Measure = new Dictionary<string, int>
        {
            ["mm"] = -3,
            ["sm"] = -2,
            ["dm"] = -1,
            ["m"] = 0,
            ["km"] = 1
        };

        public double HalfPerimeter { get => Perimeter / 2.0; }
        public double Perimeter { get => (FirstSide + SecondSide + ThirtSide); }
        public double Square
        {
            get => Math.Sqrt(HalfPerimeter * (HalfPerimeter - FirstSide)
                * (HalfPerimeter - SecondSide) * (HalfPerimeter - ThirtSide));
        }

        public Triangle(string name, double firstSide, double secondSide, double thirtSide, string measure1, string measure2, string measure3)
        {
            this.firstSide = firstSide;
            this.secondSide = secondSide;
            this.thirtSide = thirtSide;
            this.name = name;

            this.measureForFirstSide = Measure[measure1];
            this.measureForSecondSide = Measure[measure2];
            this.measureForThirdSide = Measure[measure3];

            SideAfterConvert();
        }

        private void SideAfterConvert()
        {

            if (measureForFirstSide == measureForSecondSide 
                && measureForSecondSide == measureForThirdSide&&measureForFirstSide==measureForThirdSide)
            {
                perimeterMeasure = measureForFirstSide;
            }
            else
            {
                //int maxMeasure = Math.Max
                //    (Math.Max(measureForFirstSide, measureForSecondSide), measureForThirdSide);
                //PerimeterMeasure = maxMeasure;

                firstSide = firstSide * Math.Pow(10, measureForFirstSide);
                secondSide = secondSide * Math.Pow(10, measureForSecondSide);
                thirtSide = thirtSide * Math.Pow(10, measureForThirdSide);

                perimeterMeasure = measureForFirstSide = measureForSecondSide
                    = measureForThirdSide = Measure["m"];
            }

        }

        private bool ConvertMeasureTypeToInt(string measureUnit, out int measureUnitInt)
        {
            bool result = false;
            measureUnitInt = 0;

            try
            {
                measureUnitInt = Measure[measureUnit];
                result = true;
            }
            catch
            {
                //add logging
            }

            return result;
        }

    }
}