using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp25
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Car[] cars = new Car[5]
			{
				new Car("Toyota", "Camry", "VIN1234567890", 2020, 10000),
				new Car("Honda", "Civic", "VIN9876543210", 2018, 5000),
				new Car("Ford", "Focus", "VIN1111111111", 2022, 1500),
				new Car("Hyundai", "Elantra", "VIN2222222222", 2019, 2000),
				new Car("Kia", "Optima", "VIN3333333333", 2021, 7000)
			};
			for (int i = 0; i < cars.Length - 1; i++)
			{
				for (int j = i + 1; j < cars.Length; j++)
				{
					if (cars[i].Mileage > cars[j].Mileage)
					{
						Car temp = cars[i];
						cars[i] = cars[j];
						cars[j] = temp;
					}
				}
			}
			Console.WriteLine("---------------------------------------------------------------------");
			Console.WriteLine("| Марка | Модель | VIN | Год выпуска | Пробег | Характеристика |");
			Console.WriteLine("---------------------------------------------------------------------");
			foreach (Car car in cars)
			{
				Console.WriteLine($"| {car.Brand} | {car.Model} | {car.VIN} | {car.Year} | {car.Mileage} | {car.GetCarCharacteristics()} |");
			}
			Console.WriteLine("---------------------------------------------------------------------");
			Console.ReadKey();
		}
	}
	public class Car
	{
		public string Brand { get; private set; }
		public string Model { get; private set; }
		public string VIN { get; private set; }
		public int Year { get; private set; }
		public int Mileage { get; private set; }
		public Car(string brand, string model, string vIN, int year, int mileage)
		{
			Brand = brand;
			Model = model;
			VIN = vIN;
			Year = year;
			Mileage = mileage;
		}
		public void PrintInfo()
		{
			Console.WriteLine($"Марка: {Brand}");
			Console.WriteLine($"Модель: {Model}");
			Console.WriteLine($"VIN: {VIN}");
			Console.WriteLine($"Год выпуска: {Year}");
			Console.WriteLine($"Пробег: {Mileage}");
			Console.WriteLine($"Характеристика: {GetCarCharacteristics()}");
		}
		public string GetCarCharacteristics()
		{
			int years = DateTime.Now.Year - Year;
			if (Mileage / years > 500)
			{
				return "Рабочая";
			}
			else if (Mileage / years >= 100 && Mileage / years <= 500)
			{
				return "Праздничная";
			}
			else
			{
				return "Простаивающая";
			}
		}
	}
}
