using System;

namespace Exercise02
{
    public class Square : Shape
    {
        public Square(double side)
        {
            Height = Width = side;
        }

        public override double Area => Height * Width;
    }
}