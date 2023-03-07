using System.Buffers.Text;
using System;
using System.Drawing;
using System.Numerics;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Reflection.Metadata;
using System.Diagnostics.Metrics;

public class Task
{
    private static double sqrt(double x)
    {
        return Math.Sqrt(x);
    }
    public static double Get_solution(ref double a, ref double b)
    {
        return (a * a - b * b) / (a * b) + Math.Sqrt(a / b) * Math.Log(a + b);
    }
    public static double Get_function_value(double x)
    {
        if (x > 5)
            return 5 * Math.Sqrt(x);
        else if (1 < x && x < 5)
            return 1 / x;
        else if (-5 < x && x <= 1)
            return x * x;
        else if (x < -5)
            return 10 * x;
        throw new("X must be greter or less than 5.");
    }
    public static double GetSeries(int n, double x)
    {
        if(x == -1.0)
        {
            throw new DivideByZeroException();
        }
        double res = 0;
        for (int i = 0; i <= n; i++)
        {
            res += (Math.Pow(x - 1, 2 * i + 1)) / ((2 * i + 1) * (Math.Pow(x + 1, 2 * i + 1)));
        }
        return res;
    }
    public static double[] Get_median_of_triangle(double AB, double AC, double BC)
    {
        if (AB + AC <= BC || AB + BC <= AC || BC + AC <= AB)
        {
            return new double[] {-1.0, -1.0, -1.0 };
        }
        // median from vertex A
        double median_a_length = sqrt((2*AB*AB + 2*AC*AC - BC*BC) / 4);
        // median from vertex B
        double median_b_length = sqrt(((2*BC*BC + 2*AB*AB - AC*AC) / 4));
        // median from vertex C
        double median_c_length = sqrt(((2*AC*AC + 2*BC*BC - AB*AB)/ 4));
        return new double[] { median_a_length, median_b_length, median_c_length };
    }
    private static void Task1()
    {
        Console.WriteLine("Name: Roma Vasich,\nAge: 16,\nGroup: IPZ-11,\nYear of study: 1, \nEmail:roma_vasich@knu.ua");
        double []side = new double[] { 0,0,0};
        Console.WriteLine("Input the sides of the trianlge ABC: ");
        try
        {
            Console.Write("Side AB: ");
            side[0] = Convert.ToDouble(Console.ReadLine());
            Console.Write("Side AC: ");
            side[1] = Convert.ToDouble(Console.ReadLine());
            Console.Write("Side BC: ");
            side[2] = Convert.ToDouble(Console.ReadLine());
        }
        catch (FormatException e) 
        {
            Console.WriteLine(e.Message);
        }
        double[] tringle = Get_median_of_triangle(side[0],side[1],side[2]);
        Console.WriteLine($"Median of vertex A: {tringle[0]}\nMedian of vertex B: {tringle[1]}\nMedian of vertex C: {tringle[2]}");
    }
    private static void Task2()
    {
        double a = 0; 
        double b = 0;
        try
        {
            Console.WriteLine("Input a: ");
            a = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Input b: ");
            b = Convert.ToDouble(Console.ReadLine());
        }
        catch(FormatException e)
        {
            Console.WriteLine(e.Message);
        }
        Console.WriteLine($"Resulst: {Get_solution(ref a, ref b)}");
        //return Get_solution(ref a, ref b);
    }
    private static void Task3()
    {
        Console.WriteLine("Input x: ");
        double x = 0;
        try
        {
            x = Convert.ToDouble(Console.ReadLine());
        }
        catch(FormatException e)
        {
            Console.WriteLine(e.Message);
        }
        Console.WriteLine($"f(x) = {Get_function_value(x)}");
        //return Get_function_value(x);
    }
    private static void Task4()
    {
        var disciplines = new List<string>() { "Mathematics", "Computer Science", "Physics", "Biology", "Chemistry" };
        var studentPreferences = new List<int>() { 0, 0, 0, 0, 0};
        Console.WriteLine("Input Student`s preferences from 1 to 5 in : ");
        try
        {
            Console.Write($"{disciplines[0]}: ");
            studentPreferences[0] = Convert.ToInt32(Console.ReadLine());
            if(studentPreferences[0] > 5 || studentPreferences[0] < 1)
            {
                throw new FormatException();
            }
            Console.Write($"{disciplines[1]}: ");
            studentPreferences[1] = Convert.ToInt32(Console.ReadLine());
            if (studentPreferences[1] > 5 || studentPreferences[1] < 1)
            {
                throw new FormatException();
            }
            Console.Write($"{disciplines[2]}: ");
            studentPreferences[2] = Convert.ToInt32(Console.ReadLine());
            if (studentPreferences[2] > 5 || studentPreferences[2] < 1)
            {
                throw new FormatException();
            }
            Console.Write($"{disciplines[3]}: ");
            studentPreferences[3] = Convert.ToInt32(Console.ReadLine());
            if (studentPreferences[3] > 5 || studentPreferences[3] < 1)
            {
                throw new FormatException();
            }
            Console.Write($"{disciplines[4]}: ");
            studentPreferences[4] = Convert.ToInt32(Console.ReadLine());
            if (studentPreferences[4] > 5 || studentPreferences[4] < 1)
            {
                throw new FormatException();
            }
        }
        catch(FormatException e)
        {
            Console.WriteLine(e.Message);
        }
        int op = (Math.Max(studentPreferences[0],Math.Max(studentPreferences[1], Math.Max(studentPreferences[2], Math.Max(studentPreferences[3], studentPreferences[4])))));
        if(studentPreferences.Where(x => x.Equals(op)).Count() == 1){
            Console.Write("Prefered discipline is: \n");
        }
        else
        {
            Console.Write("Prefered discipline are: \n");
        }
        for(int i = 0; i < studentPreferences.Count; i++){
            if(studentPreferences[i] == op)
                switch (i)
                {
                    case 0: Console.WriteLine(disciplines[0]);break;
                    case 1: Console.WriteLine(disciplines[1]);break;
                    case 2: Console.WriteLine(disciplines[2]);break;
                    case 3: Console.WriteLine(disciplines[3]);break;
                    case 4: Console.WriteLine(disciplines[4]);break;
                }
        }
        //Console.WriteLine(Math.Max(studentPreferences[0], Math.Max(studentPreferences[1], Math.Max(studentPreferences[2], Math.Max(studentPreferences[3], studentPreferences[4])))));
    }
    private static void Task5()
    {
        int n = 0;
        double x = 0;
        try
        {
            Console.WriteLine("Input n: ");
            n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Input x(x > 0): ");
            x = Convert.ToDouble(Console.ReadLine());
        }
        catch(FormatException e)
        {
            Console.WriteLine(e.Message);
        }
        if(x <= 0)
        {
            throw new FormatException();
        }
        Console.WriteLine($"Result is: {GetSeries(n,x)}");
    }
    public static void Run()
    {
        int option = 0;
        Console.WriteLine("Choose a task(1-5): ");
        try
        {
            option = Convert.ToInt32(Console.ReadLine());
        }
        catch(FormatException e) { Console.WriteLine(e.Message); }
        switch (option)
        {
            case 1: Console.WriteLine("TASK1\n"); Task1(); break;
            case 2: Console.WriteLine("TASK2\n"); Task2(); break;
            case 3: Console.WriteLine("TASK3\n"); Task3(); break;
            case 4: Console.WriteLine("TASK4\n"); Task4(); break;
            case 5: Console.WriteLine("TASK5\n"); Task5(); break;
            default: throw new FormatException("Wrong Input.");
        }
    }
}