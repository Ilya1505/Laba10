package com.company;
import java.util.Scanner;
public class Main {
    public static void main(String[] args)
    {
        engine dvs1 = new engine("no_name", 10, 100, 0, 1000);// конструктор со всеми параметрами
        cars avto1 = new cars("no_name", "no_color", 2020, 1000, dvs1);// конструктор со всеми параметрами
        engine dvs2 = new engine("no_name");// конструктор с одним параметром
        cars avto2 = new cars(dvs2);// конструктор с одним параметром
        cars avto3 = new cars();// конструктор без параметров
        AfterDrive rezult = new AfterDrive();// объект вспомогательного класса
        int probeg;
        avto1.OutputCars();
        avto1.PutCars();
        System.out.println(System.lineSeparator()+"Данные после ввода: ");
        avto1.OutputCars();
        avto1.Drive(rezult);
        probeg=rezult.km;
        System.out.println(System.lineSeparator()+"Пробег после тест-драйва: ");
        System.out.println(probeg+" КМ"+System.lineSeparator());
        avto1.Modern(100, 200, 500);
        System.out.println("После модернизации: ");
        avto1.OutputCars();
        // массив объектов
        engine []arrayE = new engine[2];
        for(int i=0;i<arrayE.length;i++)
        {
            arrayE[i] = new engine("no_name");// массив объектов созданных через конструктор с одним параметром
        }
        cars []arrayC = new cars[2];
        for(int i=0; i<arrayC.length;i++)
        {
            arrayC[i]=new cars(arrayE[i]);// массив объектов созданных через конструктор с одним параметром
        }
        for(int i=0; i<arrayC.length;i++)
        {
            System.out.println(System.lineSeparator()+"машина "+(i+1));
            arrayC[i].OutputCars();
        }
        for(int i=0; i<arrayC.length;i++)
        {	System.out.println(System.lineSeparator()+"машина "+(i+1));
            arrayC[i].PutCars();
        }
        System.out.println(System.lineSeparator()+"Данные после ввода: ");
        for(int i=0; i<arrayC.length;i++)
        {	System.out.println(System.lineSeparator()+"машина "+(i+1));
            arrayC[i].OutputCars();
        }
        System.out.println(System.lineSeparator()+"Пробег после тест-драйва: ");
        for(int i=0; i<arrayC.length;i++)
        {	arrayC[i].Drive(rezult);
            probeg=rezult.km;
            System.out.println(System.lineSeparator()+"машина "+(i+1));
            System.out.println(probeg+" КМ");
        }
        for(int i=0; i<arrayC.length;i++)
        {
            arrayC[i].Modern(100, 200, 500);
        }
        System.out.println(System.lineSeparator()+"После модернизации: ");
        for(int i=0; i<arrayC.length;i++)
        {	System.out.println(System.lineSeparator()+"машина "+(i+1));
            arrayC[i].OutputCars();
        }
    }
};

class AfterDrive// вспомогательный класс
{
    public int km;
}

class engine// двигатель
{
    private String name=new String();// марка двигателя
    private double weight;// вес
    private int power;// мощность (л.с.)
    private int probeg;// пробег
    private int resurs;// ресурс двигателя

    public engine(String name, double weight, int power, int probeg, int resurs)// конструктор со всеми параметрами
    {
        this.name=name;
        this.weight = weight;
        this.power = power;
        this.probeg = probeg;
        this.resurs = resurs;
    }
    public engine(String name)// конструктор с одним параметром
    {
        this.name=name;
        this.weight = 10;
        this.power = 100;
        this.probeg = 0;
        this.resurs = 1000;
    }
    public engine()// конструктор без параметров
    {
        name="no_name";
        weight = 10;
        power = 100;
        probeg = 0;
        resurs = 1000;
    }
    // сеттеры и геттеры
    public void SetName(String name)
    {
        this.name=name;
    }
    public void SetWeight(double weight)
    {
        this.weight = weight;
    }
    public void SetPower(int power)
    {
        this.power = power;
    }
    public void SetProbeg(int probeg)
    {
        this.probeg = probeg;
    }
    public void SetResurs(int resurs)
    {
        this.resurs = resurs;
    }
    public String GetName()
    {
        return name;
    }
    public double GetwWight()
    {
        return weight;
    }
    public int GetPower()
    {
        return power;
    }
    public int GetProbeg()
    {
        return probeg;
    }
    public int GetResurs()
    {
        return resurs;
    }
    public void Remont()// ремонт двигателя
    {
        probeg = 0;
    }
    public void Read()// ввод данных
    {
        Scanner read = new Scanner(System.in);
        System.out.println("Введите марку двигателя: ");
        name=read.nextLine();
        System.out.println("Введите мощность двигателя: ");
        power=read.nextInt();
        System.out.println("Введите пробег двигателя: ");
        probeg=read.nextInt();
        System.out.println("Введите ресурс двигателя: ");
        resurs=read.nextInt();
        System.out.println("Введите вес двигателя: ");
        weight=read.nextDouble();
    }
    public void Print()// вывод данных
    {
        System.out.println("Марка двигателя: " + name);
        System.out.println("Мощность двигателя: " + power);
        System.out.println("Пробег двигателя: " + probeg);
        System.out.println("Ресурс двигателя: " + resurs);
        System.out.println("Вес двигателя: " + weight);
    }
};

class cars// класс авто
{
    private String name=new String();// марка авто
    private String color=new String();// цвет авто
    private int year;// год выпуска
    private double price;// цена
    private engine dvs;// двигатель
    public cars(String name, String color, int yr, double pr, engine dvs)// конструктор со всеми параметрами
    {
        this.name=name;
        this.color=color;
        this.year = yr;
        this.price = pr;
        this.dvs = dvs;//установка двигателя
    }
    public cars(engine dvs)// конструктор с одним параметром
    {
        this.name="no_name";
        this.color="no_color";
        this.year = 2020;
        this.price = 10000;
        this.dvs=dvs;
    }
    public cars()// конструктор без параметров
    {
        this.dvs = new engine();
        name="no_name";
        color="no_color";
        year = 2000;
        price = 0;
    }
    // сеттеры и геттеры
    public void SetName(String name)
    {
        this.name=name;
    }
    public void SetYear(int year)
    {
        this.year = year;
    }
    public void SetPrice(double price)
    {
        this.price = price;
    }
    public String GetName()
    {
        return name;
    }
    public String GetColor()
    {
        return color;
    }
    public int GetYear()
    {
        return year;
    }
    public double GetPrice()
    {
        return price;
    }
    public void PutCars()// функкция ввода данных
    {
        Scanner read = new Scanner(System.in);
        System.out.println("Введите марку машины: ");
        name=read.nextLine();
        System.out.println("Введите цвет машины: ");
        color=read.nextLine();
        System.out.println("Введите год выпуска машины: ");
        year=read.nextInt();
        System.out.println("Введите цену машины: ");
        price=read.nextDouble();
        dvs.Read();
    }
    public void OutputCars()// функция вывода данных
    {
        System.out.println("Марка машины: " + name);
        System.out.println("Цвет машины: " + color);
        System.out.println("Год выпуска машины: " + year);
        System.out.println("Цена: " + price);
        dvs.Print();
    }
    public void Drive(AfterDrive rezult)// тест-драйв
    {
        rezult.km = dvs.GetProbeg() + 10;
    }
    public void Modern(double NewWeight, int NewPower, int NewResurs)// модернизация
    {
        dvs.SetWeight(NewWeight);
        dvs.SetPower(NewPower);
        dvs.SetResurs(NewResurs);
        dvs.Remont();
    }
};
