using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Type        Byte(s) of memory    Min                          Max");
        Console.WriteLine("--------------------------------------------------------------------------");

        Console.WriteLine($"sbyte       {sizeof(sbyte),-18} {sbyte.MinValue, -27} {sbyte.MaxValue}");
        Console.WriteLine($"byte        {sizeof(byte),-18} {byte.MinValue, -27} {byte.MaxValue}");
        Console.WriteLine($"short       {sizeof(short),-18} {short.MinValue, -27} {short.MaxValue}");
        Console.WriteLine($"ushort      {sizeof(ushort),-18} {ushort.MinValue, -27} {ushort.MaxValue}");
        Console.WriteLine($"int         {sizeof(int),-18} {int.MinValue, -27} {int.MaxValue}");
        Console.WriteLine($"uint        {sizeof(uint),-18} {uint.MinValue, -27} {uint.MaxValue}");
        Console.WriteLine($"long        {sizeof(long),-18} {long.MinValue, -27} {long.MaxValue}");
        Console.WriteLine($"ulong       {sizeof(ulong),-18} {ulong.MinValue, -27} {ulong.MaxValue}");
        Console.WriteLine($"float       {sizeof(float),-18} {float.MinValue, -27:E} {float.MaxValue:E}");
        Console.WriteLine($"double      {sizeof(double),-18} {double.MinValue, -27:E} {double.MaxValue:E}");
        Console.WriteLine($"decimal     {sizeof(decimal),-18} {decimal.MinValue, -27} {decimal.MaxValue}");
    }
}
