using System;

namespace Exercise02
{
    public class Circle : Shape
    {
        public Circle(double radius)
        {
            Height = Width = radius * 2;
        }

        public override double Area => Math.Round(Math.PI * Math.Pow(Height / 2, 2), 1);
    }
}