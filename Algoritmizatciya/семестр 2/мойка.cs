using System;
using System.Collections.Generic;

namespace C_
{delegate void CarWashDelegate(Garage name);
    internal class Program
    {
        static void Main(string[] args)
        {
            CarWashDelegate delegat = new CarWash().Wash;
            Garage garage = new Garage(){};
            garage.AddCar(new Car("Car 1"));
            garage.AddCar(new Car("Car 2"));
            delegat(garage);
        }
    }
    class Car
    {
        public string Name { get; set; }
        public Car(string name) { Name = name; }

    }
    class Garage
    {
        List<Car> cars = new List<Car>();
        public void AddCar(Car car)
        {
            cars.Add(car);
        }
        public void WashCars()
        {
            foreach (Car car in cars)
            {
                Console.WriteLine($"Машина {car.Name} вымыта");
            }
        }
        
    }
    class CarWash
    {
        public void Wash(Garage garage)
        {
            garage.WashCars();
        }
    }
}
