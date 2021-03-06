﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exception
{
    class Program
    {
        static Exception ex;// исключение класса ex
        static void Main(string[] args)
        {
            Console.WriteLine("Инициализация:\n");
            engine dvs = new engine("No_Name", 50, 150, 0, 1000);// конструктор со всеми параметрами
            cars avto = new cars("no_name", "no_color", 2020, 1000, dvs);// конструктор со всеми параметрами
            avto.OutputCars();
            bool f;
            do
            {
                f = false;
                try { avto.PutCars(); }
                catch (FormatException ex)// обработка программного исключения
                {
                    f = true;
                    Console.WriteLine("Ошибка: " + ex.Message);
                    Console.WriteLine("Введите данные еще раз");
                }
                catch(Exception ex)// обработка пользовательского исключения
                {
                    f = true;
                    Console.WriteLine("Ошибка: " + ex.Message);
                    Console.WriteLine("Введите данные еще раз");
                }
            } while (f);
            Console.WriteLine("\nДанные после ввода:");
            avto.OutputCars();
            int probegAfterDrive=0;
            try { probegAfterDrive = avto.Drive(10); }
            catch (Exception ex)// обработка пользовательского исключения
            {
                Console.WriteLine("Ошибка: " + ex.Message);
                Console.WriteLine("Завершение работы программы");
                Environment.Exit(1);
            }
            Console.Write("\nПробег после тест-драйва: ");
            Console.WriteLine(probegAfterDrive);
            try { avto.Modern(100, 200, 500); }
            catch (Exception ex)// обработка пользовательского исключения
            {
                Console.WriteLine("Ошибка: " + ex.Message);
                Console.WriteLine("Завершение работы программы");
                Environment.Exit(1);
            }
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
                do
                {
                    f = false;
                    try { arrayC[i].PutCars(); }
                    catch (FormatException ex)
                    {
                        f = true;
                        Console.WriteLine("Ошибка: " + ex.Message);
                        Console.WriteLine("Введите данные еще раз");
                    }
                    catch (Exception ex)
                    {
                        f = true;
                        Console.WriteLine("Ошибка: " + ex.Message);
                        Console.WriteLine("Введите данные еще раз");
                    }
                } while (f);
            }
            Console.WriteLine("\nДанные после ввода:");
            for (int i = 0; i < arrayC.Length; i++)// заполнение массива
            {
                Console.WriteLine("\nМашина " + (i + 1));
                arrayC[i].OutputCars();
            }
            for (int i = 0; i < arrayC.Length; i++)
            {
                try { probegAfterDrive = arrayC[i].Drive(10); }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка: " + ex.Message);
                    Console.WriteLine("Завершение работы программы");
                    Environment.Exit(1);
                }
            }
            Console.WriteLine("\nПробег после тест-драйва: ");
            for (int i = 0; i < arrayC.Length; i++)// возвращаемы параметр через out
            {
                Console.WriteLine("\nМашина " + (i + 1) + ": " + probegAfterDrive + "КМ");
            }
            for (int i = 0; i < arrayC.Length; i++)
            {
                try { arrayC[i].Modern(100, 200, 500); }
                catch(Exception ex)
                {
                    Console.WriteLine("Ошибка: " + ex.Message);
                    Console.WriteLine("Завершение работы программы");
                    Environment.Exit(1);
                }
            }
            Console.WriteLine("\nПосле модернизации: ");
            for (int i = 0; i < arrayC.Length; i++)
            {
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
                if (name.Length == 0) throw ex = new Exception("пустая марка двигателя");// создание объекта класса Exception
                Console.WriteLine("Введите мощность двигателя: ");
                this.power = Convert.ToInt32(Console.ReadLine());
                if (power<0||power>100000) throw ex = new Exception("некорректная мощность двигателя");
                Console.WriteLine("Введите пробег двигателя: ");
                this.probeg = Convert.ToInt32(Console.ReadLine());
                if (probeg < 0 || power > 1000000) throw ex = new Exception("некорректный пробег");
                Console.WriteLine("Введите ресурс двигателя: ");
                this.resurs = Convert.ToInt32(Console.ReadLine());
                if (resurs < 0 || power > 1000000) throw ex = new Exception("некорректный двигателя");
                Console.WriteLine("Введите вес двигателя: ");
                this.weight = Convert.ToDouble(Console.ReadLine());
                if (weight< 0 || weight > 1000000) throw ex = new Exception("некорректный вес двигателя");
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
                if (name.Length == 0) throw ex = new Exception("пустая строка марки авто");
                Console.WriteLine("Введите цвет машины: ");
                color = Console.ReadLine();
                if (color.Length == 0) throw ex = new Exception("пустая строка цвета авто");
                Console.WriteLine("Введите год выпуска машины: ");
                year = Convert.ToInt32(Console.ReadLine());
                if (year<2000||year>2020) throw ex = new Exception("неккоректный год выпуска авто");
                Console.WriteLine("Введите цену машины: ");
                price = Convert.ToDouble(Console.ReadLine());
                if (price < 1 || price > 10000000) throw ex = new Exception("неккоректная цена авто");
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
            public int Drive(int km)// тест-драйв
            {
                if (km < 0 || km > 100) throw ex = new Exception("некорректное расстояние тест-драйва");
                return dvs.Probeg = dvs.Probeg + km;
            }
            public void Modern(Double NewWeight, Int32 NewPower, Int32 NewResurs)// модернизация
            {
                if (NewWeight < 0 || NewWeight > 15000 ||
                    NewPower < 0 || NewPower > 15000 || NewResurs < 0 || NewResurs > 1000000)
                {
                    ex = new Exception("некорректные данные модернизации");
                }
                dvs.Weight = NewWeight;
                dvs.Power = NewPower;
                dvs.Resurs = NewResurs;
                dvs.Remont();
            }
        }
    }
}
