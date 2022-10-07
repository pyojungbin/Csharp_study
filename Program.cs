using static System.Console;

namespace chap5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Write("숫자를 입력: ");
            string input = ReadLine();
            //int num = Convert.ToInt32(input);
            int num = Int32.Parse(input);

            if (num < 0)
            {
                WriteLine("음수");
            }
            else if (num > 0)
            {
                if (num % 2 == 0)
                {
                    WriteLine("짝수");
                }
                else
                {
                    WriteLine("홀수");
                }
            }
            else
                WriteLine("0");


            //----
            Write("요일 입력: ");
            string day = ReadLine();

            switch (day)
            {
                case "월":WriteLine("월요일"); break;
                case "화": WriteLine("화요일"); break;
                case "수": WriteLine("수요일"); break;
                case "목": WriteLine("목요일"); break;
                case "금": WriteLine("금요일"); break;
                case "토": WriteLine("토요일"); break;
                case "일": WriteLine("일요일"); break;
                default: WriteLine("없는 날짜입니다."); break;
            }


            //---- switch 문
            object obj = null;
            string s= ReadLine();
            if (int.TryParse(s, out int out_i)) obj = out_i;
            else if (float.TryParse(s, out float out_f)) obj = out_f;
            else obj = s;

            switch (obj)
            {
                case int i: WriteLine("int형식");break;
                case float f: WriteLine("float형식");break;
                default:WriteLine("모르는형식");break;
            }


            //---- switch 식. 
            Write("점수를 입력: ");
            int score = int.Parse(ReadLine());

            WriteLine("재수강 여부(y/n):");
            string recourse = ReadLine();
            bool repeated = recourse == "y" ? true : false;

            string grade = (int)(Math.Truncate(score / 10.0) * 10) switch
            {
                90 when repeated == true => "B+",
                90 => "A",
                80 => "B",
                70 => "C",
                60 => "D",
                _ => "F"
            };
            WriteLine($"학점: {grade}");

            //----

            int i2 = 10;

            while (i2 > 0)
            {
                i2--;
                WriteLine($"i2:{i2}");
            }

            //----do while

            int c = 10;
            do
            {
                WriteLine($"c:{c--}");
            } while (c>0);

            int d = 10;
            do
            {
                WriteLine($"d:{d--}");
            } while (d > 10);


            //----foreach - 배열또는 컬렉션 순환하며 요소에 차례대로 접근.
            int[] arr= new int[]{ 0, 1, 2, 3, 4 };
            foreach(int a in arr){
                WriteLine(a);
            }


            while (true)
            {
                Write("계속할까요?0,1 : ");
                string answer = ReadLine();
                if (answer == "0") break;
            }

            //---- continue문
            for (int j = 0; j < 10; j++)
            {
                if(j%2 == 0)
                {
                    continue;//짝수이면 해당 반복문을 건너뛰고 반복문 초기로 다시돌아감.
                }
                WriteLine($"{j}");
            }

            //----goto 문 . 양날의 검

            Console.Write("종료 숫자 입력: ");
            int number = Convert.ToInt32(ReadLine());
            int exit_num = 0;
            for(int ii = 0; ii < 3; ii++)
            {
                for(int jj = 0; jj < 3; jj++)
                {
                    for(int kk=0; kk<3; kk++)
                    {
                        if(exit_num++ == number)
                        {
                            goto EXIT_FOR;
                        }
                        WriteLine($"{exit_num}");
                    }
                }
            }
            goto EXIT_PROGRAM;

            EXIT_FOR: WriteLine("\n Exit nested for");
            EXIT_PROGRAM: WriteLine("\n EXIT PROGRAM");

            //----연습문제
            for(int aa = 0; aa < 5; aa++)
            {
                for(int bb = 0; bb <= aa; bb++)
                {
                    Write("*");
                }
                WriteLine();
            }

            //연습문제2

            for(int xx = 5; xx > 0; xx--)
            {
                for(int yy = 0; yy <= xx; yy++)
                {
                    Write("*");
                }
                WriteLine();
            }

            //연습문제3
            int cnt = 0;

            while (cnt<5)
            {
                cnt++;

                for (int pp=0; pp < cnt; pp++)
                {
                    Write("*");
                }

                WriteLine();

            }

            //연습문제4
            int cnt2 = 0;
            do {
                cnt2++;

                for (int pp = 0; pp < cnt2; pp++)
                {
                    Write("*");
                }

                WriteLine();
            } while (cnt2<5);

            //연습문제5

            while (true)
            {
                WriteLine("반복 횟수 입력: ");
                int repeat = Convert.ToInt32(ReadLine());

                if (repeat < 0)
                {
                    WriteLine("0보다 작은 수 입니다. "); continue;
                }

                for(int a1 =0; a1 < repeat; a1++)
                {
                    for(int a2=0; a2 <= a1; a2++)
                    {
                        Write("*");
                    }
                    WriteLine();
                }

                Write("종료하시겠습니까? y/n  :");
                string ans = ReadLine();
                if (ans == "y") break;
                
            }
        }
    }
}