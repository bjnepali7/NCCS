//Create a class EmployeeDetails having data member empId, empName, empGender, empAddress, and empPosition, constructor to set the details and display method to display the details. Create a subclass SalaryInfo that will inherit EmployeeDetails having own data member salary which will record salary per year, constructor to set the value of salary and method calcTax() that deduct the tax on salary and display the final salary. Tax rate is given as (if salary <= 400000 tax is 1%, salary between 400001 to 800000 tax is 10% and salary > 800000 tax 20%). Now create the object of Salary info and demonstrate the scenario

using System;
class EmployeeDetails
{
    private int empId;
    private string empName;
    private string empGender;
    private string empAddress;
    private string empPosition;

    public EmployeeDetails(int empId, string empName, string empGender, string empAddress, string empPosition)
    {
        this.empId = empId;
        this.empName = empName;
        this.empGender = empGender; // Corrected assignment
        this.empAddress = empAddress; // Corrected assignment
        this.empPosition = empPosition;
    }

    public void displayDetails()
    {
        Console.WriteLine("Employee Id = " + empId);
        Console.WriteLine("Employee Name = " + empName);
        Console.WriteLine("Employee Gender = " + empGender);
        Console.WriteLine("Employee Address = " + empAddress);
        Console.WriteLine("Employee Position = " + empPosition);
    }
}

class SalaryInfo : EmployeeDetails
{
    private double salaryPerYear;

    public SalaryInfo(double salaryPerYear, int empId, string empName, string empGender, string empAddress, string empPosition)
        : base(empId, empName, empGender, empAddress, empPosition)
    {
        this.salaryPerYear = salaryPerYear;
    }

    public void calcTax()
    {
        if (salaryPerYear <= 400000)
        {
            salaryPerYear = salaryPerYear - (0.01 * salaryPerYear);
        }
        else if (salaryPerYear >= 400001 && salaryPerYear <= 800000)
        {
            salaryPerYear = salaryPerYear - (0.1 * salaryPerYear);
        }
        else if (salaryPerYear > 800000)
        {
            salaryPerYear = salaryPerYear - (0.2 * salaryPerYear);
        }
    }

    public void displaySalary()
    {
        Console.WriteLine("Salary after tax = " + salaryPerYear);
    }
}

class Program
{
    static void Main(string[] args)
    {
        SalaryInfo s1 = new SalaryInfo(65000, 09, "Bijay", "Male", "Teku", "App Developer");
        s1.displayDetails();
        s1.calcTax();
        s1.displaySalary();
    }
}