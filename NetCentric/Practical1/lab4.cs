//4.	Create a class Number having instance variable x and y both in integer, default constructor that set the value of x and y to 0, parameterized constructor that sets the value of x and y, method findOdd() that calculates the even no. occurring between x and y and display the result, findEven() that calculates the odd no. occurring between x and y and display the results. Now, create some instance of Number and invoke all the methods. 

using System;
class Number
{
    private int x;
    private int y;
    public Number()
    {
        x = 0;
        y = 0;
    }
    public Number(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
    public void findOdd()
    {
        Console.WriteLine("The Odd Numbers are:");
        for (int i = x; i <= y; i++)
        {
            if (i % 2 != 0)
            { 
                Console.WriteLine(i);
            }
        }
    }
    public void findEven()
    {
        Console.WriteLine("The Even Numbers are:");
        for (int i = x; i <= y; i++)
        {
            if (i % 2 == 0)
            {
                Console.WriteLine(i);
            }
        }
    }
}
class Program
{
    static void Main(string[] args)
    {
        Number n1 = new Number();
        Number n2 = new Number(9, 18);
        n2.findOdd();
        n2.findEven();
    }
}