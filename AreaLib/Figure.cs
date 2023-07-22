using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreaLib
{
    interface Figures
    {
        double Area();
    }

    class Circle : Figures
    {
        double _radius;
        public Circle(double radius)
        {
            _radius = radius;
        }

        public double Area()
        {
            if (_radius <= 0)
            {
                throw new ArgumentException("Такого круга не существует!");
            }
            return Math.PI * _radius * _radius;
        }
    }

    class Triangle : Figures
    {
        double sideA, sideB, sideC;
        public Triangle(double a, double b, double c)
        {
            sideA = a;
            sideB = b;
            sideC = c;
        }

        public double Area()
        {
            //условие того, что треугольник прямоугольный
            bool isRectangular = (sideA + sideB + sideC) / 3 == sideA;
            bool isTriangleCorrect = sideA + sideB > sideC && sideB + sideC > sideA && sideA + sideC > sideB;
            if (sideA <= 0 || sideB <= 0 || sideC <= 0)
            {
                throw new ArgumentException("Такого треугольника не существует!");
            }
            if (!isTriangleCorrect)
            {
                throw new ArgumentException("Такого треугольника не существует!");
            }
            double p = (sideA + sideB + sideC) / 2;
            double area = Math.Sqrt(p * ((p - sideA) * (p - sideB) * (p - sideC)));
            Console.ForegroundColor = ConsoleColor.Cyan;
            if (isRectangular)
            {
                Console.WriteLine("Треугольник прямоугольный");
            }
            else
            {
                Console.WriteLine("Треугольник не прямоугольный");
            }
            Console.ForegroundColor = ConsoleColor.White;
            return area;
        }
    }

    class Square : Figures
    {
        double sideA, sideB;
        public Square(double a, double b)
        {
            sideA = a;
            sideB = b;
        }

        public double Area()
        {
            if (sideA <= 0 || sideB <= 0)
            {
                throw new ArgumentException("Фигура не является квадратом!");
            }
            return sideA * sideB;
        }
    }

    public class Figure
    {
        Figures Fig;

        public Figure(double radius)
        {
            Fig = new Circle(radius);
        }

        public Figure(double a, double b)
        {
            Fig = new Square(a, b);
        }

        public Figure(double a, double b, double c)
        {
            Fig = new Triangle(a, b, c);
        }
        /// <summary>
        /// возвращает площадь заданной фигуры
        /// </summary>
        /// <returns>площадь заданной фигуры</returns>
        public double GetArea()
        {
            return Fig.Area();
        }
    }
}
