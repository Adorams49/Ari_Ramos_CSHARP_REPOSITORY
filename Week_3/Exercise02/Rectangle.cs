using System;

namespace Exercise02
{
    public class Rectangle : Shape
    {
        public Rectangle(double height, double width)
        {
            Height = height;
            Width = width;
        }

        public override double Area => Height * Width;
    }
}