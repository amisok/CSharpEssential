using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Input;

namespace Cars
{
    public class Engine : IEngine
    {
        private bool isOn = false;
        private double power;
        public bool Start()
        {
            isOn = true;
            return true;
        }

        public bool Work
        {
            get { return isOn; }
        }

        public double Power
        {
            get { return power; }

            set
            {
                if (value > 0 && value <= 1550)
                {
                    power = value;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }
    }

    public class Wheel : IWheel
    {
        private string tread;
        private string disk;
        private DiskType dType;

        public string Tread
        {
            get
            {
                return tread;
            }
            set
            {
                if (value.Length <= 10 && value.Length > 0)
                {
                    tread = value;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }

        public string Disk
        {
            get
            {
                return disk;
            }
            set
            {
                if (value.Length <= 15 && value.Length > 0)
                {
                    disk = value;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }

            }
        }
        public DiskType DType
        {
            get
            {
                return dType;
            }
            set
            {
                if (value == DiskType.Stamped || value == DiskType.Cast || value == DiskType.Wrought)
                {
                    dType = value;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }
    }
    public class Car : ICar
    {
        public int currentPath = 0;
        public Wheel wheel = new Wheel();
        public Engine engine = new Engine();
        private CarBody body;
        private double mas;
        private double speed;


        public CarBody Body
        {
            get
            {
                return body;
            }

            set
            {
                if (value == CarBody.Steel || value == CarBody.Titanium || value == CarBody.Carbon || value == CarBody.Aluminium)
                {
                    body = value;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }

        public double Mas
        {
            get
            {
                return mas;
            }

            set
            {
                if (value > 0)
                {
                    mas = value;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }

        public double Speed
        {
            get { return speed; }
            set { speed = value;}
        }

        public void Move(int time)
        {
            engine.Start();
            if (engine.Work)
            {
                currentPath += Convert.ToInt32(Speed) * time;
            }
        }
    }

    public class Humer : Car
    {
        public Humer(double enginePower, double massa, CarBody material, string tread, string diskSize, DiskType typeOfDisk)
        {
            engine.Power = enginePower;
            Mas = massa;
            Body = material;
            Speed = engine.Power * 1000 / (Mas * 9.8);
            wheel.Tread = tread;
            wheel.Disk = diskSize;
            wheel.DType = typeOfDisk;
        }
    }

    public class Man : Car
    {
        public Man(double enginePower, double massa, CarBody material, string tread, string diskSize, DiskType typeOfDisk)
        {
            engine.Power = enginePower;
            Mas = massa;
            Body = material;
            Speed = engine.Power * 1000 / (Mas * 9.8);
            wheel.Tread = tread;
            wheel.Disk = diskSize;
            wheel.DType = typeOfDisk;
        }
    }

    class Program
    {

        static void showFrame(Man man, Humer humer, int finish)
        {
            Console.Clear();
            Console.WriteLine("----");
            Console.WriteLine(" S |");
            Console.Write(" t |");

            int lenPathInConsole = (Console.WindowWidth - 4) * humer.currentPath / finish;
            for (int i = 0; i < lenPathInConsole - 1; i++)
            {
                Console.Write("=");
            }
            Console.WriteLine("H");

            Console.WriteLine(" a |");
            Console.Write(" r |");

            lenPathInConsole = (Console.WindowWidth - 4) * man.currentPath / finish;
            for (int i = 0; i < lenPathInConsole - 1; i++)
            {
                Console.Write("=");
            }
            Console.WriteLine("M");
            Console.WriteLine(" t |");
            Console.WriteLine("----");
        }

        static void showFinishFrame(string winner)
        {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("!!! {0} is WINNER !!!", winner);
        }


        static void Main(string[] args)
        {
            int finish = 7000; /*m*/
            try
            {
                Man man = new Man(1000, 1000, CarBody.Aluminium, "10", "15", DiskType.Wrought);
                Humer humer = new Humer(700, 1200, CarBody.Steel, "10", "15", DiskType.Stamped);

                showFrame(man, humer, finish);
                
                while (humer.currentPath < finish  && man.currentPath < finish)
                {
                    if (Console.ReadKey().Key == ConsoleKey.RightArrow)
                    {
                        humer.Move(1);
                        man.Move(1);

                        showFrame(man, humer, finish);
                    }
                }

                showFinishFrame(humer.currentPath >= finish ? "Hummer" : "MAN");

                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
