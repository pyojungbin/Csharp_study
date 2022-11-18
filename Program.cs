using static System.Console;

namespace chap8
{
    interface ILogger //ILogger 인터페이스는 상속받는 클래스가 반드시 WirteLog() 메서드를 구현하도록 강제합니다.
    {
        void WriteLog(string message);
    }

    class ConsoleLogger : ILogger
    {
        public void WriteLog(string message)
        {
            Console.WriteLine($"{DateTime.Now.ToLocalTime()} , {message}");
        }
    }

    class FileLogger : ILogger
    {
        private StreamWriter writer;

        public FileLogger(string path)
        {
            writer = File.CreateText(path);
            writer.AutoFlush = true;
        }
        public void WriteLog(string message)
        {
            writer.WriteLine($"{DateTime.Now.ToShortTimeString()},{message}");
        }
    }

    class ClimateMonitor
    {
        private ILogger logger;
        public ClimateMonitor(ILogger logger)
        {
            this.logger = logger;
        }
        public void start()
        {
            while (true)
            {
                Console.Write("온도를 입력해주세요: ");
                string temp = ReadLine();
                if (temp == "")
                {
                    break;
                }
                logger.WriteLog("현재 온도 : " + temp);
            }
        }
    }

    //인터페이스 상속
    interface ILogger2
    {
        void WriteLog(string message);
    }
    interface IFormattableLogger : ILogger2 // IFormattableLogger 는 ILoggers를 상속함.
    {
        void WriteLog(string format, params object[] args);
    }
    class ConsoleLogger2 : IFormattableLogger
    {
        public void WriteLog(string message)
        {
            WriteLine($"{DateTime.Now.ToLocalTime()} , {message}");
        }
        public void WriteLog(string format, params object[] args)
        {
            String message = String.Format(format, args);
            WriteLine($"{DateTime.Now.ToLocalTime()}, {message}");
        }
    }

    //인터페이스 다중상속
    interface IRunnerable
    {
        void Run();
    }
    interface IFlyable
    {
        void Fly();
    }
    class FlyingCar : IRunnerable, IFlyable
    {
        public void Run()
        {
            WriteLine("Run! Run!");
        }
        public void Fly()
        {
            WriteLine("FLY! FLY!");
        }
    }

    //인터페이스 기본 구현메소드
    interface ILogger3
    {
        void WriteLog(string message);

        void WriteError(string error)
        {
            WriteLine($"Error:{error}");
        }
    }
    class ConsoleLogger3 : ILogger3
    {
        public void WriteLog(string message)
        {
            WriteLine($"{DateTime.Now.ToLocalTime()},{message}");
        }
    }

    //추상클래스
    abstract class AbstractBase
    {
        protected void PrivateMethodA()
        {
            WriteLine("AbastractBase.PrivateMethodA()");
        }
        public void PublicMethodA()
        {
            WriteLine("AbstractBase.PublicMethodA()");
        }
        public abstract void AbstractMethodA();
    }
    class Derived: AbstractBase
    {
        public override void AbstractMethodA()
        {
            WriteLine("Derived.AbastractMethodA()");
            PrivateMethodA();
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            ClimateMonitor monitor = new ClimateMonitor(new ConsoleLogger());

            monitor.start();

            //--인터페이스 상속--
            WriteLine("-- 인터페이스 상속--");
            IFormattableLogger logger = new ConsoleLogger2();
            logger.WriteLog("The world is not flat");
            logger.WriteLog("{0}+{1} = {2}",1,1,2);


            //인터페이스 다중상속
            WriteLine("-- 인터페이스 다중상속 --");
            FlyingCar car = new FlyingCar();
            car.Run();
            car.Fly();

            IRunnerable runnable = car;
            runnable.Run();

            IFlyable flyable = car;
            flyable.Fly();

            //인터페이스 기본 구현 메소드
            ILogger3 logger3 = new ConsoleLogger3();
            logger3.WriteLog("System Up");
            logger3.WriteError("System Fail");

            ConsoleLogger3 clogger = new ConsoleLogger3();
            clogger.WriteLog("System Up");
            //clogger.writeError("asdasd"); --컴파일 에러 . consolelogger가 error 메소드를 오버라이딩하지않아서.


            //추상클래스 
            WriteLine("-- 추상클래스 --");
            AbstractBase obj = new Derived();
            obj.AbstractMethodA();
            obj.PublicMethodA();

        }
    }
}