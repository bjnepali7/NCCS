//2.	Write a program to demonstrate method overloading?
using System;

class Calculator
{
    public void sum(int x, int y)
    {
        Console.WriteLine("The sum is " + (x + y));
    }

    public void sum(int x, int y, int z)
    {
        Console.WriteLine("The sum is " + (x + y + z));
    }
}

class Program
{
    static void Main(string[] args)
    {
        Calculator calc = new Calculator();
        calc.sum(8, 2);
        calc.sum(6, 3, 3);
    }
}
