﻿namespace Chap2_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            byte a = 240;
            Console.WriteLine(a);

            byte b = 0b1111_0000;
            Console.WriteLine(b);

            byte c = 0xF0;
            Console.WriteLine(c);

            uint d = 0X1234_abcd;
            Console.WriteLine(d);


            uint aa = uint.MaxValue;
            Console.WriteLine(aa);

            aa = aa + 1;
            Console.WriteLine(aa);

            int bb = int.MaxValue;
            Console.WriteLine(bb);

            bb = bb + 1;
            Console.WriteLine(bb);
        }
    }
}