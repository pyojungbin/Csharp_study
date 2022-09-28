﻿using System.Globalization;
using static System.Console;

namespace chap3
{
    internal class Program
    {
        enum dialogResult { YES,NO,CANCEL,CONFIRM,OK}
        enum dialogResult2 { YES=10,NO,CANCEL,CONFIRM=50,OK}


        static void Main(string[] args)
        {
            //----
            bool a = true;
            bool b = false;

            WriteLine(a);
            WriteLine(b);

            //object 형은 모든 형식의 조상이다. 
            object c = 12;
            object d = "asd";
            object e = 's';
            object f = 12.31441;

            WriteLine(c);
            WriteLine(d);
            WriteLine(e);
            WriteLine(f);



            //----
            int aa = 123;
            object bb = (object)aa; //aa를 object형으로 박싱하여 힙에 저장 . 
            int cc = (int)bb; // bb를 int형으로 언박싱하여 stack에 저장 .

            WriteLine(aa);
            WriteLine(bb);
            WriteLine(cc);

            double x = 3.12412;
            object y = x; // x를 박싱하여 힙에 저장
            double z = (double)y; // y를 언박싱하여 stack에 저장.

            WriteLine(x);
            WriteLine(y);
            WriteLine(z);



            //----
            sbyte aaa = 127;
            WriteLine(aaa);

            int bbb = (int)aaa;
            WriteLine(bbb);

            int ccc = 128;
            WriteLine(ccc);

            sbyte ddd = (sbyte)ccc; //sbyte 범위는 -128~127인데 128인경우 OVERFLOW 발생
            WriteLine(ddd);


            //----
            float q = 69.6875f;
            WriteLine("q:{0}", q);

            double w = (double)q;
            WriteLine("w:{0}", w);
            WriteLine("69.6875 == w : {0}", 69.6875 == w);

            float t = 0.1f;
            WriteLine(t);

            double tt = (double)t;
            WriteLine(tt);
            WriteLine("tt == 0.1 : {0}", 0.1 == tt);



            //----
            int a1 = 123;
            string b1 = a1.ToString();
            WriteLine(b1);

            float c1 = 3.14f;
            string d1 = c1.ToString();
            WriteLine(d1);

            string e1 = "123456";
            int f1 = Convert.ToInt32(e1);
            WriteLine(f1);

            string g1 = "12.123";
            float h1 = Convert.ToSingle(g1);
            WriteLine(h1);



            //----
            WriteLine((int)dialogResult.OK);
            WriteLine((int)dialogResult.NO);
            WriteLine((int)dialogResult.CANCEL);
            WriteLine((int)dialogResult.YES);
            WriteLine((int)dialogResult.CONFIRM);


            dialogResult result = dialogResult.YES;
            WriteLine(result == dialogResult.YES);

            WriteLine((int)dialogResult2.OK);
            WriteLine((int)dialogResult2.NO);
            WriteLine((int)dialogResult2.CANCEL);
            WriteLine((int)dialogResult2.YES);
            WriteLine((int)dialogResult2.CONFIRM);




            int? pa = null;
            WriteLine(pa.HasValue);
            pa = 33;
            if (pa.HasValue == true)
                WriteLine(pa.Value);
            else
                WriteLine(pa.HasValue);


            //----
            var v1 = 20;
            WriteLine(v1.GetType());

            var v2 = "asdasd";
            WriteLine(v2.GetType());

            var v3 = 12.21f;
            WriteLine(v3.GetType());

            var v4 = 'a';
            WriteLine(v4.GetType());


            //----
            string greeting = "Good Morning";

            WriteLine(greeting.IndexOf("Good"));
            WriteLine(greeting.IndexOf('o'));

            WriteLine(greeting.LastIndexOf("Good"));
            WriteLine(greeting.LastIndexOf('o'));

            WriteLine(greeting.StartsWith("Good"));
            WriteLine(greeting.EndsWith("Morning"));

            WriteLine(greeting.Contains("Morning"));
            WriteLine(greeting.Replace("Morning", "Evening"));


            //----
            WriteLine("{0}", "ABC".ToLower());
            WriteLine("{0}", "abc".ToUpper());
            WriteLine("{0}", "Happy Birthday".Insert(5, "your"));
            WriteLine("{0}", "I dont love you".Remove(2, 6));
            WriteLine("{0}", " NO SPACES ".Trim());
            WriteLine("{0}", " NO SPACES ".TrimStart());
            WriteLine("{0}", " NO SPACES ".TrimEnd());

            //----
            string gr = "Good Morning.";
            WriteLine(gr.Substring(0, 5)); //  Good
            WriteLine(gr.Substring(5));// Morning.

            string[] arr = greeting.Split(new string[] {" "}, StringSplitOptions.None);// Good , Morning
            WriteLine("Word Count:{0}", arr.Length); //2 

            foreach (string element in arr)
            {
                WriteLine("{0}", element); // Good, Morning
            }


            //----
            string fmt = "{0,-20}{1,-15}{2,30}";
            WriteLine(fmt, "Publisher", "Author", "Title");
            WriteLine(fmt, "Marvel", "Stan LEE", "Iron Man");
            WriteLine(fmt, "Hanbit", "Sanghyun Park", "This is C#");
            WriteLine(fmt, "pretice hall", "jungbin", "the c programming language");


            //----
            WriteLine("{0:D}", 123);
            WriteLine("{0:D5}", 123);

            WriteLine("0x{0:X}", 0xff1234);
            WriteLine("0x{0:X8}", 0xff1234);

            WriteLine("{0:N}", 123456789);
            WriteLine("{0:N0}", 123456789);

            WriteLine("{0:F}", 132.456);
            WriteLine("{0:F5}", 132.456);

            WriteLine("{0:E}", 123.456789);


            //----
            DateTime dt = new DateTime(2022, 09, 28, 23, 18, 22);
            CultureInfo ciKo = new CultureInfo("ko-KR");


            //----
            string name = "김김김";
            int age = 25;
            WriteLine($"{name,-10},{age:D3}");

            name = "박박박";
            age = 21;
            WriteLine($"{name},{age,-10:D3}");

            name = "이이이";
            age = 33;
            WriteLine($"{name},{(age > 19 ? "성인":"미성년자")}");
            WriteLine();
            WriteLine();


            //연습문제 1
            WriteLine("사각형의 너비를 입력하시오: ");
            string width = ReadLine();

            WriteLine("사각형의 높이를 입력하시오: ");
            string height = ReadLine();

            int area = Convert.ToInt32(width) * Convert.ToInt32(height);

            WriteLine($"사각형의 넓이는 : {area}");
            

            //연습문제3
            /*
             값형식 : }를 만나면 메모리가 비워짐
             참조 형식: }를 만나면 메모리는 남지만 가비지 컬렉터가 쓰레기값 수거해감. 
             */


            //연습문제4
            /*
            박싱 : 박싱을 수행하여 해당 값을 힙에 할당. 
            언박싱 : 박싱된 값을 꺼내 값 형식 변수(스택)에 저장하는 과정. 
             */
        }
    }
}