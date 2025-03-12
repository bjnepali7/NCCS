
//Write a program to demonstrate single level, multilevel inheritance?

using System;

namespace InheritanceDemo
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Single-Level Inheritance:");
            Car car = new Car();
            car.Start();  // Inherited from Vehicle
            car.Drive();  // Car's own method

            Console.WriteLine("\nMultilevel Inheritance:");
            ElectricCar tesla = new ElectricCar();
            tesla.Start();         // Inherited from Vehicle
            tesla.Drive();         // Inherited from Car
            tesla.ChargeBattery(); // ElectricCar's own method
        }
    }

    // Single-Level Inheritance
    public class Vehicle  // Base class
    {
        public void Start()
        {
            Console.WriteLine("Vehicle is starting");
        }
    }

    public class Car : Vehicle  // Derived class from Vehicle
    {
        public void Drive()
        {
            Console.WriteLine("Car is driving");
        }
    }

    // Multilevel Inheritance
    public class ElectricCar : Car  // Derived class from Car
    {
        public void ChargeBattery()
        {
            Console.WriteLine("Electric Car is charging");
        }
    }
}

