// exception c++.cpp: определяет точку входа для консольного приложения.
//

#include "stdafx.h"
#include <Conio.h>
#include<Windows.h>
#include <iostream>
#include <string>


using namespace std;

class engine// двигатель
{
private:
	int *power;// мощность (л.с.)
	string name;// марка двигателя
	double weight;// вес
	int probeg;// пробег
	int resurs;// ресурс двигателя
public:
	engine &operator=(const engine &other)// перегрузка опрератора =
	{
		if (power != nullptr)// проверка на не нулевое значение указателя
			delete power;
		power = new int;
		*this->power = *other.power;
		this->name = other.name;
		this->weight = other.weight;
		this->probeg = other.probeg;
		this->resurs = other.resurs;
		return *this;
	}
	engine(const engine &other)// конструктор с мелким копированием
	{
		this->power = other.power;// мелкое копирование адреса одинаковые
		this->name = other.name;
		this->weight = other.weight;
		this->probeg = other.probeg;
		this->resurs = other.resurs;
	}
	engine(string init_name, double weight, int power, int probeg, int resurs)// конструктор с параметрами
	{
		this->power = new int;
		this->name = init_name;
		this->weight = weight;
		*this->power = power;
		this->probeg = probeg;
		this->resurs = resurs;
	}
	engine(string name)
	{
		this->power = new int;
		this->name = name;
		this->weight = 50;
		*this->power = 100;
		this->probeg = 0;
		this->resurs = 100;
	}
	engine()// конструктор без параметров
	{
		this->power = new int;
		name = "No_Name";
		weight = 10;
		*power = 100;
		probeg = 0;
		resurs = 300;
	}

	// сеттеры и геттеры
	void SetName(string name)
	{
		this->name = name;
	}
	void SetWeight(double weight)
	{
		this->weight = weight;
	}
	void SetPower(int power)
	{
		*this->power = power;
	}
	void SetProbeg(int probeg)
	{
		this->probeg = probeg;
	}
	void SetResurs(int resurs)
	{
		this->resurs = resurs;
	}
	string GetName()
	{
		return name;
	}
	double GetwWight()
	{
		return weight;
	}
	int GetPower()
	{
		return *power;
	}
	int GetProbeg()
	{
		return probeg;
	}
	int GetResurs()
	{
		return resurs;
	}
	void Remont()// ремонт двигателя
	{
		probeg = 0;
	}
	void Read()// ввод данных
	{
		fflush(stdin);
		cout << endl << "Марка двигателя: ";
		getline(cin, name);
		cout << "Вес двигателя: ";
		cin >> weight;
		cout << "Мощность двигателя: ";
		cin >> *power;
		cout << "Пробег двигателя: ";
		cin >> probeg;
		cout << "Ресурс двигателя: ";
		cin >> resurs;
	}
	void Print()// вывод данных
	{
		cout << "Марка двигателя: " << name << endl;
		cout << "Мощность двигателя: " << *power << endl;
		cout << "Пробег двигателя: " << probeg << endl;
		cout << "Ресурс двигателя: " << resurs << endl;
		cout << "Масса двигателя: ";
		printf("%.4lf\n", weight);
	}
	~engine()// деструктор
	{

	}
};
class cars// класс авто
{
public:
	int *year;// год выпуска
	string name;// марка авто
	string color;// цвет авто
	double price;// цена
	engine dvs;// двигатель
public:
	cars(const cars &other)// коннструктор с глубоким копированием
	{
		this->year = new int;
		*this->year = *other.year;
		this->name = other.name;
		this->color = other.color;
		this->price = other.price;
		this->dvs = other.dvs;// перегрузка оператора присваивания

	}
	cars(int year, string name, string color, double price, engine &dvs)// конструктор с параметрами
	{
		this->year = new int;
		this->name = name;
		this->color = color;
		*this->year = year;
		this->price = price;
		this->dvs = dvs;//установка двигателя
	}
	cars(int price)// конструктор с одним параметром
	{
		this->year = new int;
		this->name = "No_Name";
		this->color = "No_Color";
		*(this->year) = 2020;
		this->price = price;
	}
	cars()// конструктор без параметров
	{
		this->year = new int;
		name = "No_Name";
		color = "No_Color";
		*year = 2020;
		price = 1000;

	}
	// сеттеры и геттеры
	void SetName(string name)
	{
		this->name = name;
	}
	void SetColor(string color)
	{
		this->color = color;
	}
	void SetYear(int year)
	{
		*this->year = year;
	}
	void SetPrice(double price)
	{
		this->price = price;
	}
	string GetName()
	{
		return name;
	}
	string GetColor()
	{
		return color;
	}
	int GetYear()
	{
		return *year;
	}
	double GetPrice()
	{
		return price;
	}
	void OutputCars()// функкция вывода данных
	{
		cout << endl << "Марка машины: " << name << endl;
		cout << "Цвет машины: " << color << endl;
		cout << "Год выпуска: " << *year << endl;
		cout << "Цена машины: ";
		printf("%.4lf\n", price);
		dvs.Print();
	}
	void PutCars()// функция ввода данных
	{
		fflush(stdin);
		cout << endl << " Ввод данных" << endl;
		cout << "Марка машины: ";
		getline(cin, name);
		fflush(stdin);
		cout << "Цвет машины: ";
		getline(cin, color);
		cout << "Год выпуска машины: ";
		cin >> *year;
		cout << "Цена: ";
		cin >> price;
		dvs.Read();
	}
	void Modern(double NewWeight, int NewPower, int NewResurs)// модернизация
	{
		dvs.SetWeight(NewWeight);
		dvs.SetPower(NewPower);
		dvs.SetResurs(NewResurs);
		dvs.Remont();
	}
	friend void Drive(cars *avto);// тест-драйв, дружественная функция для класса car
	~cars()
	{
	}
};

void Drive(cars *avto)// возврат значений через указатель
{
	int probeg;
	probeg = avto->dvs.GetProbeg() + 10;
	avto->dvs.SetProbeg(probeg);
}

int _tmain(int argc, _TCHAR* argv[])
{
	SetConsoleCP(1251);// подключение русскоязычного ввода/вывода
	SetConsoleOutputCP(1251);
	system("color F0");
	// Работа со статическими переменными
	engine dvs1("св-01", 10, 100, 0, 400);
	engine dvs2(dvs1);// мелкое копирование
	dvs1.SetPower(500);// при изменении мощности у dvs1, мощность у dvs2 также меняется
	cout << "мощность dvs2: " << dvs2.GetPower() << endl << endl;
	cars avto1(2020, "No_Name", "No_Color", 1000, dvs1);// вызов конструктора со всеми параметрами (статич объект)
	cars avto2(1000); // вызов конструктора с одним параметром (статич объект)
	cars avto3; // вызов конструктора без параметров (статич объект)
	cars *AvtoDin1 = new cars(2020, "No_Name", "No_Color", 5000, dvs1);// вызов конструктора со всеми параметрами (динамич объект)
	cars *AvtoDin2 = new cars(1000);// вызов конструктора с одним параметром (динамич объект)
	cars *AvtoDin3 = new cars();// вызов конструктора без параметров (динамич объект)
	cars avto4 = avto3;// конструктор глубокого копирования
	avto3.SetYear(2015);// при изменении year у avto3, year у avto4 не меняется
	cout << "машина 1:";
	avto4.OutputCars();
	avto4.PutCars();
	printf("\nДанные после ввода:");
	avto4.OutputCars();
	Drive(&avto4);
	printf("\nПосле тест-драйва:");
	avto4.OutputCars();
	avto4.Modern(100, 200, 500);
	printf("\nПосле модернизации:");
	avto4.OutputCars();
	//Работа с массивом
	cars avtoArray[3] = { 1000, 2000, 3000 };
	for (int i = 0; i < 3; i++)
	{
		cout << endl << "Машина " << i + 1;
		avtoArray[i].OutputCars();
	}
	for (int i = 0; i < 3; i++)
	{
		cout << endl << "Машина " << i + 1;
		avtoArray[i].PutCars();
	}
	printf("\nДанные после ввода:\n");
	for (int i = 0; i < 3; i++)
	{
		cout << endl << "Машина " << i + 1;
		avtoArray[i].OutputCars();
	}
	for (int i = 0; i < 3; i++)
	{
		Drive(&avtoArray[i]);
	}
	printf("После тест-драйва:\n");
	for (int i = 0; i < 3; i++)
	{
		cout << endl << "Машина " << i + 1;
		avtoArray[i].OutputCars();
	}
	for (int i = 0; i < 3; i++)
	{
		avtoArray[i].Modern(100, 200, 500);
	}
	printf("После модернизации:\n");
	for (int i = 0; i < 3; i++)
	{
		cout << endl << "Машина " << i + 1;
		avtoArray[i].OutputCars();
	}
	delete AvtoDin1;
	delete AvtoDin2;
	delete AvtoDin3;
	getch();
	return 0;
}

