using System;
using System.Collections.Generic;
using System.Text;

namespace Figures
{
    public static class FigureOperator
    {
        public static double AveragePerimeter(Figure[] figures)
        {
            double averagePerimeter = 0;
            for(int i = 0; i<figures.Length; i++)
            {
                averagePerimeter = averagePerimeter + figures[i].Perimeter();
            }
            return averagePerimeter/figures.Length;
        }

        public static double SquareSumm(Figure[] figures)
        {
            double squareSumm = 0;
            for (int i = 0; i < figures.Length; i++)
            {
                squareSumm = squareSumm + figures[i].Square();
            }
            return squareSumm;
        }

        public static Figure MaxSquareFigure(Figure[] figures)
        {
            Figure maxSquareFigure = figures[0];
            double maxSquare = figures[0].Square();
            for (int i = 1; i < figures.Length; i++)
            {
                if(maxSquare < figures[i].Square())
                {
                    maxSquare = figures[i].Square();
                    maxSquareFigure = figures[i];
                }
            }
            return maxSquareFigure;
        }

        public static string MaxPerimeterFigureType(Figure[] figures)
        {
            string figureType =figures[0].GetType().ToString();
            List<double> maxPerimeterPerType = new List<double>();
            List<Type> typeList = new List<Type>();
            int elementIndex = 0;
            for (int i=0; i<figures.Length;i++)
            {
                if(typeList.FindIndex(x => x == figures[i].GetType())<0)
                {
                    typeList.Add(figures[i].GetType());
                    maxPerimeterPerType.Add(figures[i].Perimeter());
                }
                else
                {
                    elementIndex = typeList.FindIndex(x => x == figures[i].GetType());
                    if (maxPerimeterPerType[elementIndex]<figures[i].Perimeter())
                    {
                        maxPerimeterPerType[elementIndex] = figures[i].Perimeter();
                    }
                }
            }
            elementIndex = 0;
            foreach (double perimeter in maxPerimeterPerType)
            {
                if(perimeter > maxPerimeterPerType[elementIndex])
                {
                    elementIndex = maxPerimeterPerType.FindIndex(x => x == perimeter);
                }
            }
            figureType = typeList[elementIndex].Name.ToString();
            return figureType;
        }
    }
}
