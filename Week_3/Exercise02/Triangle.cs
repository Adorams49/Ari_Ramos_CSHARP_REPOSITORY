using System;

namespace Exercise02
{
    public class Triangle : Shape
    {
        public Triangle(double height, double width)
        {
            Height = height;
            Width = width;
        }

        public override double Area => 0.5 * Height * Width;
    }
}