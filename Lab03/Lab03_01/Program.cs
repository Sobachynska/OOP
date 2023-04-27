using System.IO;
using System.Text;
using System;


class Person
{
    public void Greet()
    {
        Console.WriteLine("Hello!");
    }

    public void SetAge(int age)
    {
        this.Age = age;
    }

    public int Age { get; private set; }
}

class Student : Person
{
    public void Study()
    {
        Console.WriteLine("I'm studying");
    }

    public void ShowAge()
    {
        Console.WriteLine("My age is: {0} years old", this.Age);
    }
}

class Professor : Person
{
    public void Explain()
    {
        Console.WriteLine("I'm explaining");
    }

    public void ShowAge()
    {
        Console.WriteLine("My age is: {0} years old", this.Age);
    }
}

class StudentProfessorTest
{
    static void Main(string[] args)
    {
        Person p = new Person();
        p.Greet();

        Student s = new Student();
        s.SetAge(18);
        s.Greet();
        s.Study();
        s.ShowAge();

        Professor prof = new Professor();
        prof.SetAge(38);
        prof.Greet();
        prof.ShowAge();
        prof.Explain();
    }
}
