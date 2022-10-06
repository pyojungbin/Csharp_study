using System.Collections;
using static System.Console;

namespace CHAP4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ArrayList a = null;
            a?.Add("야구");
            a?.Add("농구");

            WriteLine($"count:{a?.Count}");
            WriteLine($"{a?[0]}");
            WriteLine($"{a?[1]}");

            a = new ArrayList(); //a는 더이상 null이 아님. 
            a?.Add("축구");
            a?.Add("농구");
            WriteLine($"Count: {a?.Count}");
            WriteLine($"{a?[0]}");
            WriteLine($"{a?[1]}");


            //----
            int b = 100;
            WriteLine($"b = 100 : {b}");

            b += 90;
            WriteLine($"b +=90 : {b}");

            b -= 80;
            WriteLine($"b -=80 : {b}");

            b |= 30;
            WriteLine($"b |=30 : {b}");

            b ^= 20;
            WriteLine($"b^=20 : {b}");

            //----
            int? num = null;
            WriteLine($"{(num ?? 0)}"); // ?? :  null일경우 우측 반환 , null이 아닐 경우 좌측 반환

            num = 99;
            WriteLine($"{(num ?? 0)}");

            string str = null;
            WriteLine($"{(str ?? "default")}");

            str = "asd";
            WriteLine($"{(str ?? "default")}");
        }
    }
}