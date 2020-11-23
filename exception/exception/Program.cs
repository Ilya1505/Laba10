using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exception
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Инициализация:\n");
            engine dvs = new engine("No_Name", 50, 150, 0, 1000);// конструктор со всеми параметрами
            cars avto = new cars("no_name", "no_color", 2020, 1000, dvs);// конструктор со всеми параметрами
            avto.OutputCars();
            avto.PutCars();
            Console.WriteLine("\nДанные после ввода:");
            avto.OutputCars();
            int ProbegFirst = 1;// инициализация переменной для возврата через ref
            avto.Drive(ref ProbegFirst);
            Console.WriteLine("\nПробег после тест-драйва: ");
            Console.WriteLine(ProbegFirst);
            avto.Modern(100, 200, 500);
            Console.WriteLine("\n\nПосле модернизации:");
            avto.OutputCars();
            // объявление и инициализация массива автомобилей
            engine[] arrayE = new engine[2];
            cars[] arrayC = new cars[2];
            for (int i = 0; i < arrayC.Length; i++)
            {
                arrayE[i] = new engine("no_name");
                arrayC[i] = new cars(arrayE[i]);
                Console.WriteLine("\nМашина " + (i + 1));
                arrayC[i].OutputCars();
            }
            Console.WriteLine("\nВвод данных:");
            for (int i = 0; i < arrayC.Length; i++)// заполнение массива
            {
                Console.WriteLine("\nМашина " + (i + 1));
                arrayC[i].PutCars();
            }
            Console.WriteLine("\nДанные после ввода:");
            for (int i = 0; i < arrayC.Length; i++)// заполнение массива
            {
                Console.WriteLine("\nМашина " + (i + 1));
                arrayC[i].OutputCars();
            }
            Console.WriteLine("\nПробег после тест-драйва: ");
            for (int i = 0; i < arrayC.Length; i++)// возвращаемы параметр через out
            {
                int ProbegTwo;
                arrayC[i].DriveTwo(out ProbegTwo);
                Console.WriteLine("\nМашина " + (i + 1) + ": " + ProbegTwo + "КМ");
            }
            Console.WriteLine("\nПосле модернизации: ");
            for (int i = 0; i < arrayC.Length; i++)
            {
                arrayC[i].Modern(100, 200, 500);
                Console.WriteLine("\n");
                arrayC[i].OutputCars();
            }
            Console.ReadLine();
        }
        class engine// двигатель
        {
            private string name;// марка двигателя
            public String Name
            {
                set
                {
                    name = value;
                }
                get
                {
                    return name;
                }
            }
            private Double weight;// вес
            public Double Weight
            {
                set
                {
                    weight = value;
                }
                get
                {
                    return weight;
                }
            }
            private Int32 power;// мощность (л.с.)
            public Int32 Power
            {
                set
                {
                    power = value;
                }
                get
                {
                    return power;
                }
            }
            private Int32 probeg;// пробег
            public Int32 Probeg
            {
                set
                {
                    probeg = value;
                }
                get
                {
                    return probeg;
                }
            }
            private Int32 resurs;// ресурс двигателя
            public Int32 Resurs
            {
                set
                {
                    resurs = value;
                }
                get
                {
                    return resurs;
                }
            }

            public engine(string name, Double weight, Int32 power, Int32 probeg, Int32 resurs)// конструктор со всеми параметрами
            {
                this.name = name;
                this.weight = weight;
                this.power = power;
                this.probeg = probeg;
                this.resurs = resurs;
            }
            public engine(string name)// конструктор с одним параметром
            {
                this.name = name;
                this.weight = 100;
                this.power = 500;
                this.probeg = 0;
                this.resurs = 500;
            }
            public engine()// конструктор без параметров
            {
                this.name = "no_name";
                this.weight = 10;
                this.power = 100;
                this.probeg = 0;
                this.resurs = 500;
            }
            public void Remont()// ремонт двигателя
            {
                this.probeg = 0;
            }
            public void Read()// ввод данных
            {
                Console.WriteLine("Введите марку двигателя: ");
                this.name = Console.ReadLine();
                Console.WriteLine("Введите мощность двигателя: ");
                this.power = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите пробег двигателя: ");
                this.probeg = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите ресурс двигателя: ");
                this.resurs = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите вес двигателя: ");
                this.weight = Convert.ToDouble(Console.ReadLine());
            }
            public void Print()// вывод данных
            {
                Console.WriteLine("Марка двигателя: " + name);
                Console.WriteLine("Мощность двигателя: " + power);
                Console.WriteLine("Пробег двигателя: " + probeg);
                Console.WriteLine("Ресурс двигателя: " + resurs);
                Console.WriteLine("Вес двигателя: " + weight);
            }
        };
        class cars
        {
            private string name;// марка авто
            public string Name// свойство класса
            {
                set
                {
                    if (value != "")
                    {
                        name = value;
                    }
                }
                get
                {
                    return name;
                }
            }
            private string color;// цвет авто
            public string Color
            {
                set
                {
                    if (value != "")
                    { color = value; }
                }
                get
                {
                    return color;
                }
            }
            private Int32 year;// год выпуска
            public Int32 Year
            {
                set
                {
                    year = value;
                }
                get
                {
                    return year;
                }
            }
            private Double price;// цена
            public Double Price
            {
                set
                {
                    price = value;
                }
                get
                {
                    return price;
                }
            }
            private engine dvs;
            public engine Dvs
            {
                set
                {
                    dvs = value;
                }
                get
                {
                    return dvs;
                }
            }

            public cars(string name, string color, Int32 yr, Double pr, engine dvs)// конструктор со всеми параметрами
            {
                this.name = name;
                this.color = color;
                this.year = yr;
                this.price = pr;
                this.dvs = dvs;//установка двигателя
            }
            public cars(engine dvs)// конструктор с одним параметром
            {
                this.name = "No_Name";
                this.color = "No_Color";
                this.year = 2020;
                this.price = 0;
                this.dvs = dvs;//установка двигателя
            }
            public cars()// конструктор без параметров
            {
                name = "no_name";
                color = "no_color";
                year = 2000;
                price = 0;
                this.dvs = new engine();
            }

            public void PutCars()// функкция ввода данных
            {
                Console.WriteLine("Введите марку машины: ");
                name = Console.ReadLine();
                Console.WriteLine("Введите цвет машины: ");
                color = Console.ReadLine();
                Console.WriteLine("Введите год выпуска машины: ");
                year = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите цену машины: ");
                price = Convert.ToDouble(Console.ReadLine());
                dvs.Read();
            }
            public void OutputCars()// функция вывода данных
            {
                Console.WriteLine("Марка машины: " + name);
                Console.WriteLine("Цвет машины: " + color);
                Console.WriteLine("Год выпуска машины: " + year);
                Console.WriteLine("Цена: " + price);
                dvs.Print();
            }
            public void Drive(ref int probeg)// тест-драйв
            {
                probeg = dvs.Probeg + 10;
            }
            public void DriveTwo(out int probeg)// тест-драйв
            {
                probeg = dvs.Probeg + 20;
            }
            public void Modern(Double NewWeight, Int32 NewPower, Int32 NewResurs)// модернизация
            {
                dvs.Weight = NewWeight;
                dvs.Power = NewPower;
                dvs.Resurs = NewResurs;
                dvs.Remont();
            }
        }
    }
}
