using System;
using System.IO;
using System.Text;

class User
{
    protected string name;
    protected int age;

    public void setName(string name)
    {
        this.name = name;
    }

    public string getName()
    {
        return name;
    }

    public void setAge(int age)
    {
        this.age = age;
    }

    public int getAge()
    {
        return age;
    }
}

class Worker : User
{
    private double salary;

    public void setSalary(double salary)
    {
        this.salary = salary;
    }

    public double getSalary()
    {
        return salary;
    }
}

class Student : User
{
    private double scholarship;
    private int course;

    public void setScholarship(double scholarship)
    {
        this.scholarship = scholarship;
    }

    public double getScholarship()
    {
        return scholarship;
    }

    public void setCourse(int course)
    {
        this.course = course;
    }

    public int getCourse()
    {
        return course;
    }
}

class Driver : Worker
{
    private int drivingExperience;
    private string drivingCategory;

    public void setDrivingExperience(int experience)
    {
        this.drivingExperience = experience;
    }

    public int getDrivingExperience()
    {
        return drivingExperience;
    }

    public void setDrivingCategory(string category)
    {
        this.drivingCategory = category;
    }

    public string getDrivingCategory()
    {
        return drivingCategory;
    }
}


class Program
{
    static void Main(string[] args)
    {
        Worker ivan = new Worker();
        ivan.setName("Іван");
        ivan.setAge(25);
        ivan.setSalary(1000);

        Worker vasya = new Worker();
        vasya.setName("Вася");
        vasya.setAge(26);
        vasya.setSalary(2000);

        double totalSalary = ivan.getSalary() + vasya.getSalary();
        Console.OutputEncoding = UTF8Encoding.UTF8;
        Console.WriteLine("Сума зарплат Івана та Васі: " + totalSalary);
    }
}