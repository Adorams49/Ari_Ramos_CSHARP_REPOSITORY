using System;

namespace Exercise02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---------------------------------------");

            var r = new Rectangle(3, 4.5);
            Console.WriteLine($"1. Rectangle H: {r.Height}, W: {r.Width}, Area: {r.Area}");

            var s = new Square(5);
            Console.WriteLine($"2. Square    H: {s.Height}, W: {s.Width}, Area: {s.Area}");

            var c = new Circle(2.5);
            Console.WriteLine($"3. Circle    H: {c.Height}, W: {c.Width}, Area: {c.Area}");

            var t = new Triangle(4, 6);
            Console.WriteLine($"4. Triangle  H: {t.Height}, W: {t.Width}, Area: {t.Area}");

            Console.WriteLine("---------------------------------------");
        }
    }
}
