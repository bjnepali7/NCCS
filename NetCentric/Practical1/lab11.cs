//Write a program to demonstrate abstract class

using System;

public abstract class Animal  // Abstract class
{
    public abstract void Speak();  // Abstract method, must be implemented by derived class

    public void Eat()  // Concrete method
    {
        Console.WriteLine("Animal is eating");
    }
}

public class Cat: Animal  // Derived class
{
    public override void Speak()  // Implementing the abstract method
    {
        Console.WriteLine("cat is mewoing");
    }
}

class Program
{
    static void Main()
    {
       Cat c = new Cat();
        c.Speak();  // Output: Dog is barking
        c.Eat();    // Output: Animal is eating
    }
}