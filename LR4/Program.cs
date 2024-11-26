using System;
using System.Reflection;

public class Person
{
    public string Name { get; set; } 
    private int age;                 
    protected string Gender;         
    internal double Height;          
    private protected string Nationality; 

    public Person(string name, int age, string gender, double height, string nationality)
    {
        Name = name;
        this.age = age;
        Gender = gender;
        Height = height;
        Nationality = nationality;
    }

    public void SayHello() => Console.WriteLine($"Hello, my name is {Name}!");

    private int GetAge() => age;

    protected void DisplayGender() => Console.WriteLine($"Gender: {Gender}");
}

class Program
{
    static void Main(string[] args)
    {
        Type personType = typeof(Person);
        Console.WriteLine($"Type: {personType.Name}");
        Console.WriteLine($"Namespace: {personType.Namespace}");
        Console.WriteLine($"Is Class: {personType.IsClass}");

        MemberInfo[] members = personType.GetMembers();
        Console.WriteLine("\nMembers:");
        foreach (var member in members)
        {
            Console.WriteLine($"{member.MemberType}: {member.Name}");
        }

        Console.WriteLine("\nFields:");
        FieldInfo[] fields = personType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
        foreach (var field in fields)
        {
            Console.WriteLine($"{field.Name} (Type: {field.FieldType.Name})");
        }

        Console.WriteLine("\nMethods:");
        MethodInfo[] methods = personType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
        foreach (var method in methods)
        {
            Console.WriteLine($"{method.Name} (Return Type: {method.ReturnType.Name})");
        }

        Console.WriteLine("\nInvoke Method:");
        Person person = new Person("John", 30, "Male", 180.5, "American");
        MethodInfo sayHelloMethod = personType.GetMethod("SayHello");
        sayHelloMethod.Invoke(person, null);

        MethodInfo getAgeMethod = personType.GetMethod("GetAge", BindingFlags.NonPublic | BindingFlags.Instance);
        int age = (int)getAgeMethod.Invoke(person, null);
        Console.WriteLine($"Age: {age}");
        Console.ReadLine();
    }
}
