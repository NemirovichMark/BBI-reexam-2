using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace BBI_reexam_2
{
	internal class Task2
	{
		public Task2()
		{
			Car[] cars = new Car[5]
			{
				new Car("Toyota", "Camry", "VIN1234567890", 2020, 10000, "A"),
		new Car("Honda", "Civic", "VIN9876543210", 2018, 5000, "B"),
		new Car("Ford", "Focus", "VIN1111111111", 2022, 1500, "C"),
		new Car("Hyundai", "Elantra", "VIN2222222222", 2019, 2000, "S"),
				new Car("Kia", "Optima", "VIN3333333333", 2021, 7000, "A")
			};

			Truck[] trucks = new Truck[5]
			{
		new Truck("Volvo", "FH16", "VIN4444444444", 2021, 50000, 6),
		new Truck("Mercedes-Benz", "Actros", "VIN5555555555", 2019, 40000, 8),
		new Truck("Scania", "R730", "VIN6666666666", 2020, 60000, 4),
		new Truck("MAN", "TGX", "VIN7777777777", 2018, 30000, 10),
		new Truck("DAF", "XF105", "VIN8888888888", 2022, 70000, 6)
			};

			Motorcycle[] motorcycles = new Motorcycle[5]
			{
		new Motorcycle("Harley-Davidson", "Street Glide", "VIN9999999999", 2020, 20000),
		new Motorcycle("Yamaha", "R1", "VIN0000000000", 2019, 15000),
		new Motorcycle("Honda", "Gold Wing", "VIN1111111111", 2018, 10000),
		new Motorcycle("Ducati", "Panigale V4", "VIN2222222222", 2022, 5000),
		new Motorcycle("BMW", "S 1000 RR", "VIN3333333333", 2021, 25000)
			};
			SortVehiclesByYear(cars);
			SortVehiclesByYear(trucks);
			SortVehiclesByYear(motorcycles);
			PrintVehiclesTable("Автомобили", cars);
			PrintVehiclesTable("Грузовики", trucks);
			PrintVehiclesTable("Мотоциклы", motorcycles);
			Vehicle[] allVehicles = new Vehicle[cars.Length + trucks.Length + motorcycles.Length];
			Array.Copy(cars, allVehicles, cars.Length);
			Array.Copy(trucks, 0, allVehicles, cars.Length, trucks.Length);
			Array.Copy(motorcycles, 0, allVehicles, cars.Length + trucks.Length, motorcycles.Length);
			SortVehiclesByYear(allVehicles);
			PrintVehiclesTable("Все транспортные средства", allVehicles);
		}
		static void SortVehiclesByYear<T>(T[] vehicles) where T : Vehicle
		{
			for (int i = 0; i < vehicles.Length - 1; i++)
			{
				for (int j = i + 1; j < vehicles.Length; j++)
				{
					if (vehicles[i].Year > vehicles[j].Year)
					{

						T temp = vehicles[i];
						vehicles[i] = vehicles[j];
						vehicles[j] = temp;
					}
				}
			}
		}

		static void PrintVehiclesTable(string title, Vehicle[] vehicles)
		{
			Console.WriteLine($"-------------------------------------- {title} --------------------------------------");
			Console.WriteLine("| Марка | Модель | VIN | Год выпуска | Пробег | Информация об использовании |");
			Console.WriteLine("---------------------------------------------------------------------");
			foreach (Vehicle vehicle in vehicles)
			{
				Console.WriteLine($"| {vehicle.Brand} | {vehicle.Model} | {vehicle.VIN} | {vehicle.Year} | {vehicle.Mileage} | {vehicle.GetUsageInfo()} |");
			}
			Console.WriteLine("---------------------------------------------------------------------");
		}
	}
	public abstract class Vehicle
	{
		public string Brand { get; private set; }
		public string Model { get; private set; }
		public string VIN { get; private set; }
		public int Year { get; private set; }
		public int Mileage { get; private set; }

		public Vehicle(string brand, string model, string vIN, int year, int mileage)
		{
			Brand = brand;
			Model = model;
			VIN = vIN;
			Year = year;
			Mileage = mileage;
		}
		public abstract string GetUsageInfo();
	}
	public class Car : Vehicle
	{
		public string Class { get; private set; }

		public Car(string brand, string model, string vIN, int year, int mileage, string carClass) : base(brand, model, vIN, year, mileage)
		{
			Class = carClass;
		}
		public override string GetUsageInfo()
		{
			int years = DateTime.Now.Year - Year;
			if (Mileage / years > 500)
			{
				return $"Рабочая, класс {Class}";
			}
			else if (Mileage / years >= 100 && Mileage / years <= 500)
			{
				return $"Праздничная, класс {Class}";
			}
			else
			{
				return $"Простаивающая, класс {Class}";
			}
		}
	}
	public class Truck : Vehicle
	{
		public int Wheels { get; private set; }

		public Truck(string brand, string model, string vIN, int year, int mileage, int wheels) : base(brand, model, vIN, year, mileage)
		{
			Wheels = wheels;
		}
		public override string GetUsageInfo()
		{
			int years = DateTime.Now.Year - Year;
			if (Mileage / years > 500)
			{
				return $"Грузовой, {Wheels} колес, рабочая";
			}
			else if (Mileage / years >= 100 && Mileage / years <= 500)
			{
				return $"Грузовой, {Wheels} колес, праздничная";
			}
			else
			{
				return $"Грузовой, {Wheels} колес, простаивающая";
			}
		}
	}
	public class Motorcycle : Vehicle
	{
		public Motorcycle(string brand, string model, string vIN, int year, int mileage) : base(brand, model, vIN, year, mileage)
		{
		}

		public override string GetUsageInfo()
		{
			int years = DateTime.Now.Year - Year;
			if (Mileage / years > 500)
			{
				return "Мотоцикл, рабочая";
			}
			else if (Mileage / years >= 100 && Mileage / years <= 500)
			{
				return "Мотоцикл, праздничная";
			}
			else
			{
				return "Мотоцикл, простаивающая";
			}
		}
	}
	internal class Program1
	{
		static void Main(string[] args)
		{
			Task2 task2 = new Task2();
			Console.ReadKey();
		}
	}
}
