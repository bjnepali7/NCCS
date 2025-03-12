//Write a program to demonstrate class, constructor, properties and method

using System;

class Example
{
    private int num; // Field should be declared at the class level.

    public Example()
    {
        Console.WriteLine("This is default constructor");
    }

    public int Number
    {
        get { return num; }
        set { num = value; }
    }

    public void display()
    {
        Console.WriteLine($"My number is {num}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Example d1 = new Example();
        d1.Number= 7;
        d1.display();
    }
}
