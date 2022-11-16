using static System.Console;
using System;

using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Net.Security;
using System.Net.Cache;
using System.Threading.Tasks.Dataflow;

namespace chap7
{
    class Cat
    {
        public string name;
        public string color;

        public void Meow()
        {
            WriteLine($"{name}: 야옹");
        }

    }

    //----
    class Dog
    {
        public string Name; //필드선언
        public string Color;

        public Dog() // 기본 생성자
        {
            Name = "";
            Color = "";
        }

        public Dog(string _Name, string _Color) //생성자 오버로딩
        {
            Name = _Name;
            Color = _Color;
        }

        ~Dog()
        {
            WriteLine($"{Name} 잘가");
        }

        public void Bark()
        {
            WriteLine($"{Name} : 멍멍");
        }

    }

    //----
    class Global
    {
        public static int CNT = 0; //클래스에 소속된 필드
    }

    class A
    {
        public A()
        {
            Global.CNT++;
        }
    }
    class B
    {
        public B()
        {
            Global.CNT++;
        }
    }

    //----깊은 복사 얕은 복사
    class MyClass
    {
        public int field1;
        public int field2;

        public MyClass DeepCopy()
        {
            MyClass newCopy = new MyClass();
            newCopy.field1 = this.field1;
            newCopy.field2 = this.field2;

            return newCopy;
        }

    }

    //---- this
    class Employee
    {
        private string name;
        private string position;

        public void SetName(string name)
        {
            this.name = name;
        }
        public string GetName()
        {
            return name;
        }
       
        public void SetPosition(string position)
        {
            this.position = position;
        }
        public string GetPosition()
        {
            return this.position;
        }
    }

    //---this() 생성자 
    class aa
    {
        int a, b, c;

        public aa()
        {
            this.a = 5425;
            WriteLine("aa()");
        }
        public aa(int b): this()
        {
            this.b = b;
            WriteLine($"aa({b})");
        }
        public aa(int b, int c) : this(b)
        {
            this.c = c;
            WriteLine($"aa({b},{c})");
        }
        public void printfield()
        {
            WriteLine($"a:{a}b:{b},c:{c}");
        }
    }

    //---- 접근 한정자
    class WaterHeater
    {
        protected int temp;

        public void settemp(int temp)
        {
            if (temp < -5 || temp > 42)
            {
                throw new Exception("Out of Range");
            }

            this.temp = temp; // temp는 외부에서 접근이 불가능하니 public 메소드 통해 접근해야함.
        }
        internal void TurnOnWater()
        {
            WriteLine($"Turn on water : {temp}");
        }

    }

    //상속으로 코드 재활용하기
    class Base
    {
        protected string name;
        public Base(string name)
        {
            this.name = name;
            WriteLine($"{this.name}.Base()");
        }
        ~Base()
        {
            WriteLine($"{this.name}.~Base()");
        }
        public void BaseMethod()
        {
            WriteLine($"{name}.BaseMethod()");
        }
    }

    class Derived : Base
    {
        public Derived(string name) : base(name)
        {
            WriteLine($"{this.name}.Derived()");
        }
        ~Derived()
        {
            WriteLine($"{this.name}.~Derived()");
        }
        public void DerivedMethod()
        {
            WriteLine($"{name}.DerivedMethod()");
        }
    }


    //----기반클래스, 파생클래스 형식변환
    // is = 객체가 해당형식에 해당하는지 검사하고 bool로 반환함
    // as = 형식 변환 연산자, 형식변환 연산자가 변환에 실패하는 경우 예외를 던지는 반면, as는 객체 참조를 null로 만듬
    class Mammal2
    {
        public void Nurse()
        {
            WriteLine("Nurse()");
        }
    }
    class Dog2: Mammal2
    {
        public void Bark()
        {
            WriteLine("Bark()");
        }
    }
    class Cat2 : Mammal2
    {
        public void Meow()
        {
            WriteLine("Meow()");
        }
    }

    //오버로이딩과 다형성 
    class ArmorSuite
    {
        public virtual void Initialize()
        {
            WriteLine("Armor");
        }
    }
    class Ironman : ArmorSuite
    {
        public override void Initialize()
        {
            base.Initialize();
            WriteLine("Repulsor Rays Armed");
        }
    }
    class WarMachine : ArmorSuite
    {
        public override void Initialize()
        {
            base.Initialize();
            WriteLine("Double-Barrel Cannons Armed");
            WriteLine("Micro-Rocket Launcher Armed");
        }
    }

    //메소드 숨기기
    class BBase
    {
        public void MyMethod()
        {
            WriteLine("Base.MyMethod()");
        }
    }
    class DDerived : BBase
    {
        public new void MyMethod() //여기서 new 는 메소드 숨기기 위한것임 . 알던 new가 아님 .
        {
            WriteLine("Derived.MyMethod()");
        }
    }

    //오버라이딩 봉인하기
    class BBBase
    {
        public virtual void SealMe()
        {
        }
    }
    class DDDerived : BBBase{
        public sealed override void SealMe()
        {
        }
    }
    //class WantToOverride : DDDerived
    //{
    //    public override void SealMe() //DDDerived.Sealme는 봉인되어있어 재정의할 수 없습니다 Error
    //    {
    //    }
    //}

    
    //읽기전용 필드
    class Configuration
    {
        private readonly int min;
        private readonly int max; 

        public Configuration(int v1, int v2)
        {
            min = v1;
            max = v2;
            WriteLine($"{min},{max}");
        }
        public void ChangeMax(int newMax)
        {
           // max = newMax; --읽기 전용이라 다른 곳에서 값 수정하려하면 컴파일 에러 발생. 
        }
    }

    //중첩 클래스
    class Conf
    {
        List<ItemValue> listconfig = new List<ItemValue>();

        public void SetConfig(string item, string value)
        {
            ItemValue iv = new ItemValue();
            iv.SetValue(this,item, value);
        }

        public string GetConfig(string item)
        {
            foreach(ItemValue iv in listconfig)
            {
                if (iv.GetItem() == item) return iv.GetValue();
            }
            return "";
        }

        private class ItemValue
        {
            private string item;
            private string value;

            public void SetValue(Conf config, string item, string value)
            {
                this.item = item;
                this.value = value;

                bool found = false;

                for(int i = 0; i < config.listconfig.Count; i++)
                {
                    if (config.listconfig[i].item == item)
                    {
                        config.listconfig[i] = this;
                        found = true;
                        break;
                    }
                }
                if (found == false)
                {
                    config.listconfig.Add(this);
                }
            }
            public string GetItem()
            {
                return item;
            }
            public string GetValue()
            {
                return value;
            }
        }
    }

    //분할 클래스
    partial class Mclass
    {
        public void Method1()
        {
            WriteLine("Method1");
        }
        public void Method2()
        {
            WriteLine("Method2");
        }
    }
    partial class Mclass
    {
        public void Method3()
        {
            WriteLine("Method3");
        }
        public void Method4()
        {
            WriteLine("Method4");
        }
    }

    //확장 메소드 - 기존 클래스의 기능을 확장하는 기법.
    public static class IntegerExtension {
        public static int Square(this int myInt)
        {
            return myInt * myInt;
        }
        public static int Power(this int myInt, int exponent)
        {
            int result = myInt;
            for(int i = 1; i < exponent; i++)
            {
                result *= myInt;
            }
            return result;
        }
      
    }

    //구조체
    struct point3D
    {
        public int x;
        public int y;
        public int z;

        public point3D(int x, int y , int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public override string ToString()
        {
            return String.Format($"{x}, {y}, {z}");
        }
    }

    //변경 불가능한 구조체
    readonly struct RGBColor
    {
        public readonly byte R;
        public readonly byte G;
        public readonly byte B;

        public RGBColor(byte r, byte g, byte b)
        {
            R = r;
            G = g;
            B = b;
        }
    }

    
    internal class Program
    {
        

        static void Main(string[] args)
        {
            Cat kitty = new Cat();
            kitty.color = "하얀색";
            kitty.name = "키티";
            kitty.Meow();
            WriteLine($"{kitty.name}:{kitty.color}");

            Cat nero = new Cat();
            nero.color = "검정색";
            nero.name = "네로";
            nero.Meow();
            WriteLine($"{nero.name}:{nero.color}");

            Dog happy = new Dog("해피","검정색");
            happy.Bark();
            WriteLine($"{happy.Name}:{happy.Color}");

            Dog tutu = new Dog("투투", "흰색");
            tutu.Bark();
            WriteLine($"{tutu.Name}: {tutu.Color}");

            WriteLine($"Global.count == {Global.CNT}");

            new A();
            new A();
            new B();
            new B();

            WriteLine($"Global.count == {Global.CNT}");

            WriteLine("얕은 복사");
            {
                MyClass source = new MyClass();
                source.field1 = 10;
                source.field2 = 20;

                MyClass target = source;
                target.field2 = 30;

                WriteLine($"{source.field1},{source.field2}");
                WriteLine($"{target.field1},{target.field2}");
            }
            WriteLine("깊은 복사");

            {
                MyClass source = new MyClass();
                source.field1 = 10;
                source.field2 = 20;

                MyClass target = source.DeepCopy();
                target.field2 = 30;

                WriteLine($"{source.field1},{source.field2}");
                WriteLine($"{target.field1},{target.field2}");
            }

            Employee pooh = new Employee();
            pooh.SetName("푸우");
            pooh.SetPosition("Waiter");
            WriteLine($"{pooh.GetName()} : {pooh.GetPosition()}");

            Employee yj = new Employee();
            yj.SetName("유정");
            yj.SetPosition("공뭔");
            WriteLine($"{yj.GetName()} : {yj.GetPosition()}");

            aa a0 = new aa();
            a0.printfield();
            WriteLine();

            aa b0 = new aa(1);
            b0.printfield();
            WriteLine();

            aa c0 = new aa(1,2);
            c0.printfield();
            WriteLine();

            try
            {
                WaterHeater heater = new WaterHeater();
                heater.settemp(20);
                heater.TurnOnWater();

                heater.settemp(-2);
                heater.TurnOnWater();

                heater.settemp(50);
                heater.TurnOnWater();
            }

            catch(Exception e)
            {
                WriteLine(e.Message);
            }

            //----
            Base a = new Base("a");
            a.BaseMethod();
            Derived b = new Derived("b");
            b.BaseMethod();
            b.DerivedMethod();

            //----
            Mammal2 mammal2 = new Dog2();
            Dog2 dog2;
            if(mammal2 is Dog2)
            {
                dog2 = (Dog2)mammal2;
                dog2.Bark();
            }

            Mammal2 mammal3 = new Cat2();
            Cat2 cat2 = mammal3 as Cat2;
            if(cat2 != null)
            {
                cat2.Meow();
            }
            Cat2 cat3 = mammal2 as Cat2;
            if(cat3 != null)
            {
                cat3.Meow();
            }
            else
            {
                WriteLine("cat3 is not a Cat");
            }


            //====
            WriteLine("----");
            WriteLine("Creating ArmorSuite ~~");
            ArmorSuite as1 = new ArmorSuite();
            as1.Initialize();

            WriteLine("\n Creating IronMan ~~");
            ArmorSuite ironman = new Ironman();
            ironman.Initialize();

            WriteLine("\n Creating WarMachine ~~");
            ArmorSuite warmachine = new WarMachine();
            warmachine.Initialize();


            //----
            WriteLine("--메소드 숨기기--");
            BBase baseobj = new BBase();
            baseobj.MyMethod();

            DDerived dd = new DDerived();
            dd.MyMethod();

            BBase bb = new DDerived(); //객체를 생성하면 다시 숨긴 메소드를 실행시킴. 
            bb.MyMethod();

            //-- readonly --
            WriteLine("----");
            Configuration cof = new Configuration(10, 100);

            // -- 중첩클래스 -- 
            WriteLine("-- 중첩클래스 --");
            Conf config = new Conf();
            config.SetConfig("VERSION", "V 5.0");
            config.SetConfig("SIZE", "655,324 KB");

            
            WriteLine(config.GetConfig("VERSION"));
            WriteLine(config.GetConfig("SIZE"));

            config.SetConfig("VERSION", "V 5.0.1");
            WriteLine(config.GetConfig("VERSION"));


            //--분할 클래스
            WriteLine("-- 분할 클래스 --");
            Mclass obj = new Mclass();
            obj.Method1();
            obj.Method2();
            obj.Method3();
            obj.Method4();

            //-- 확장 메소드 --
            WriteLine($"3^2 = {3.Square()}");
            WriteLine($"3^4 = {3.Power(4)}");
            WriteLine($"2^10 =  {2.Power(10)}");

            //--구조체
            WriteLine("-- 구조체 --");
            point3D p3d1;
            p3d1.x = 10;
            p3d1.y = 20;
            p3d1.z = 30;

            WriteLine(p3d1.ToString());

            point3D p3d2 = new point3D(100, 200, 300);
            point3D p3d3 = p3d2;
            p3d2.z = 55;

            WriteLine(p3d2.ToString());
            WriteLine(p3d3.ToString());

            // 변할수 없는 구조체
            WriteLine("-- 변할 수 없는 구조체 --");

            RGBColor Red = new RGBColor(255, 0, 0);
            //Red.G = 100; - 읽기 전용 필드이므로 수정하려하면 컴파일 에러 발생.

            //튜플
            var t1 = ("슈퍼맨", 9999);
            WriteLine($"{t1.Item1}, {t1.Item2}");

            var t2 = (Name: "박상현", Age: 17);
            WriteLine($"{t2.Name},{t2.Age}");

            //튜플분해
            var (Name, Age) = t2;
            WriteLine($"{Name},{Age}");

            var (Name2, Age2) = ("박지성", 13);
            WriteLine($"{Name2},{Age2}");

            t2 = t1;
            WriteLine($"{t2.Name},{t2.Age}");
        
        }
        
    }
}