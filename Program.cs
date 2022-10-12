﻿using System.Net.Http.Headers;
using static System.Console;

namespace chap6
{
    internal class Program
    {
     
        public static int Minus(int a, int b)
        {
            return a - b;
        }


        //----
        static int Fibonacci(int n)
        {
            if (n < 2) return n;
            else return Fibonacci(n-1) +Fibonacci(n - 2);
        }
        static void PrintProfile(string name, string phone)
        {
            if(name == "")
            {
                WriteLine("이름을 입력해주세요.");
                return;
            }
            else
            {
                WriteLine($"Name:{name}, Phone:{phone}");
            }
        }

        //----
        public static void Swap(int a, int b)
        {
            int temp = b;
            b = a;
            a = temp;
            WriteLine($"x:{a}, y:{b}");
        }

        //---- ref키워드
        static void Swap(ref int a, ref int b)
        {
            int temp = b;
            b = a;
            a = temp;
        }

        //----
        private int price = 1000;

        public ref int GetPrice()
        {
            return ref price; 
        }
        public void PrintPrice()
        {
            WriteLine($"Price:{price}");
        }

        //----out 대신 ref 사용. -> out은 ref와 다른 안전장치가있음. 해당 매개변수에 결과 저장안하면 컴파일러가 에러메세지를 출력함.  
        static void Divide(int a, int b, out int q, out int r)
        {
            q = a / b;
            r = a % b;
        }

        //----메소드 오버로딩

        static int Plus(int a, int b)
        {
            WriteLine("Calling int Plus(int,int)");
            return a + b;
        }
        static int Plus(int a, int b, int c)
        {
            WriteLine("Calling int Plus(int,int,int)");
            return a + b + c;
        }
        static double Plus(double a, double b)
        {
            WriteLine("Calling double Plus(double,double)");
            return a + b;
        }
        static double Plus(int a, double b)
        {
            WriteLine("Calling double Plus(int,double)");
            return a + b;
        }

        //---- 가변 개수의 인수 params키워드

        static int Sum(params int[] args)
        {
            Write("Summing... ");
            int sum = 0;
            for(int i =0;i< args.Length; i++)
            {
                if (i > 0) Write(",");

                Write(args[i]);
                sum += args[i];
            }
            WriteLine();
            return sum;
        }


        //----명명된 인수
        static void Profile(string name, string phone)
        {
            WriteLine($"Name:{name},Phone:{phone}");
        }

        //----로컬 함수 
        static string ToLowerString(string input) //메소드
        {
            var arr = input.ToCharArray();
            for(int i = 0; i < arr.Length; i++)
            {
                arr[i] = ToLowerChar(i);
            }
            char ToLowerChar(int i) //로컬 함수
            {
                if (arr[i] < 65 || arr[i] > 90) return arr[i];
                else return (char)(arr[i] + 32);
            }
            return new string(arr);
        }

        //연습문제 1 
        static double Square(double arg)
        {
            return arg * arg;
        }


        //메인함수
        static void Main(string[] args)
        {
            int Result = Plus(3, 4);
            WriteLine(Result);

            Result = Minus(5, 2);
            WriteLine(Result);

            WriteLine($"10번째 피보나치 수: {Fibonacci(10)}");

            PrintProfile("", "121-1212");
            PrintProfile("아아아", "010-1111-1234");

            int x = 3;
            int y = 5;
            WriteLine($"x:{x}, y:{y}"); //인수를 매개변수로 넘기는것은 값이 복사되는것이므로, 메모리는 서로 다른공간에 저장되어있음. 
            Swap(x, y);
            WriteLine($"x:{x}, y:{y}");

            x = 10;
            y = 20;

            WriteLine($"x:{x}, y:{y}");
            Swap(ref x, ref y); //ref- 참조에 의한 전달로 원변 변수를 직접 참조함.
            WriteLine($"x:{x}, y:{y}");

            Program carrot = new Program();
            ref int ref_local_price = ref carrot.GetPrice(); 
            int normal_local_price = carrot.GetPrice(); 

            carrot.PrintPrice(); //1000
            WriteLine($"Ref Local Price: {ref_local_price}"); //1000
            WriteLine($"Normal Local Price : {normal_local_price}"); //1000

            ref_local_price = 2000;
            carrot.PrintPrice(); //2000
            WriteLine($"Ref Local Price: {ref_local_price}"); //2000
            WriteLine($"Normal Local Price : {normal_local_price}"); //1000

            int a = 20;
            int b = 3;

            Divide(a,b,out int c, out int d);

            WriteLine($"a:{a}, b:{b}: , a/b:{c}, a%b:{d}");


            WriteLine(Plus(1, 2));
            WriteLine(Plus(1, 2,3));
            WriteLine(Plus(1.2, 2.2));
            WriteLine(Plus(1, 2.5));

            int sum = Sum(3, 4, 5, 6, 7, 8, 9);
            WriteLine($"Sum:{sum}");

            Profile(name: "ㅇㄴㅁㅇㅁㄴ", phone: "11-12312-12213");

            WriteLine(ToLowerString("Hello"));
            WriteLine(ToLowerString("Good Morning ! "));
            WriteLine(ToLowerString("This is C Sharp"));

            Write("수를 입력하세요: ");
            double num = Convert.ToDouble(ReadLine());
            WriteLine($"결과: {Square(num)}");
        }
    }
}