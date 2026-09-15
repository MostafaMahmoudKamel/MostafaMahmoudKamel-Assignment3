
/*
 * 1)   csproj :
 * that is a file created for each console App , 
 * that contains the information about the project and its dependencies such as framework version
 * 
 * 2) porgram.cs : 
 * file that contains codes to be executed in the console app
 * 
 * 3) obj :
 * folder that contaions output files generated during build project 
 * the files will changed when i making rebuild or clean the project
 * folder that store intermediate files
 * 
 * 4) bin :
 * folder contains final build of project 
 * folder that make cash build files and output files generated during build project,
 * store difference code such as when i add one line to 1000 lines of code the bin folder will store the difference between the two files
 * folder that store the final build of project
 * 
 * ************************************************************************************************
 * <Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net10.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>
* **************************************************************************************************
*  File-scoped namespace applies to the entire file,
*so we don't need curly braces and 
* **************************************************************************************************

</Project>
* **************************************************************************************************
* project use .slnx becouse it display infromation with best format from sln
*
*/

using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace CSharpBasicsAssignment;


class Program
{
    struct Point
    {
        public int X;
        public int Y;
    }
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        RunTypesDemo();
        RunValueVsReferenceDemo();
        ScopeAndOperators();

    }



    static void RunTypesDemo()
    {
        int i = 1;
        long l = 2L;
        double d = 3.7d;
        decimal dec = 4.0m;
        bool b = true;
        char c = 'c';
        string s = "Mostafa Kamel";
        var v = 5;
        Console.WriteLine($"value is :{i} ,type is : {i.GetType().Name}");
        Console.WriteLine($"value is :{l} ,type is : {l.GetType().Name}");
        Console.WriteLine($"value is :{d} ,type is : {d.GetType().Name}");
        Console.WriteLine($"value is :{dec} ,type is : {dec.GetType().Name}");
        Console.WriteLine($"value is :{b} ,type is : {b.GetType().Name}");
        Console.WriteLine($"value is :{c} ,type is : {c.GetType().Name}");
        Console.WriteLine($"value is :{s} ,type is : {s.GetType().Name}");
        Console.WriteLine($"value is :{v} ,type is : {v.GetType().Name}");

        l = i;//implicit conversion from int to long
        Console.WriteLine(l);
        i = c; //implicit conversion from char to int
        Console.WriteLine(i);
        //why no cast is required for the above two conversions?
        //because i cast from smaller data type to larger data type 
        Console.WriteLine("======================================================================================");
        //truncation and rounding
        i = (int)d;
        Console.WriteLine(i);
        i = Convert.ToInt32(d);
        Console.WriteLine(i);
        //  truncation: remove decimal part from double such as 3.7 to 3
        //  rounding: round the double value to nearest integer such as 3.7 to 4
        Console.WriteLine("======================================================================================");
        //compute 5 / 2 as int and 5.0 / 2 as double;
        //because int/int = int ,double/int = double 
        var intResult = 5 / 2;
        var doubleResult = 5.0 / 2;
        Console.WriteLine($"5 / 2 as int: {intResult}");
        Console.WriteLine($"5.0 / 2 as double: {doubleResult}");
        Console.WriteLine("======================================================================================");
        //boxing and unboxing
        var obj = 42; // boxing
        Console.WriteLine($"Boxed value: {obj}");
        var unboxed = (int)obj; // unboxing
        Console.WriteLine($"Unboxed value: {unboxed}");
        Console.WriteLine("======================================================================================");
        //parsing and TryParse
        string str = "42";
        int iValue = int.Parse(str);
        string badString = "abc";
        bool isSuccessed = int.TryParse(badString, out intResult);
        Console.WriteLine($"You entered: {str} , Parsed value: {iValue}, Type: {iValue.GetType().Name}");
        Console.WriteLine($"you entered: {badString} , Parsed value: {intResult}, Type: {intResult.GetType().Name}, Success: {isSuccessed}");
        Console.WriteLine("======================================================================================");
        //
        float fValue = 20.5f;
        decimal dValue = 30.5m;
        fValue = (float)dValue;
        //compiler not allow implicit casting becouse the size of float [4-byte]is smaller than decimal [16-byte] so we need to cast explictly

    }

    static void RunValueVsReferenceDemo()
    {
        //Experiment 1 — struct copy semantics
        Point p1 = new Point { X = 1, Y = 2 };
        Point p2 = p1;
        p2.X = 99;
        Console.WriteLine($"p1: X={p1.X}");
        Console.WriteLine($"p2: X={p2.X}");
        //the value p1.x not equal p1.y because the struct is based on value type
        Console.WriteLine("======================================================================================");
        //Experiment 2 — class reference semantics(Order class)
        Order o1 = new Order
        {
            OrderId = 1,
            CustomerName = "Mostafa",
            Quantity = 5,
            UnitPrice = 100m,
            TotalPrice = 0m,
            IsPaid = false,
            DiscountPercent = 10,
            ShippingCity = "Mansoura",
            Priority = 'H',
            ItemCode = 123456789L
        };
        o1.CalculateTotal();
        Order o2 = o1;
        o2.IsPaid = true;
        Console.WriteLine($"o1: IsPaid={o1.IsPaid}");
        Console.WriteLine($"o2: IsPaid={o2.IsPaid}");
        //the value o1.IsPaid equal o2.IsPaid because the class is based on reference type

        object boxedOrder = o1; // boxing
        Order o3 = (Order)boxedOrder;
        Console.WriteLine(object.ReferenceEquals(o1, o3));

        // It reflects IsPaid = true because o1 and o2 refer to the same object.
        o2.PrintSummary();
        /*
        * Value types store the actual value.
        * Reference types store a reference to an object in the heap.
        * When we assign a value type, the value is copied, so each variable is independent.
        * When we assign a reference type, the reference is copied, so both variables point to the same object.
        * Storing a reference type in an object variable does not create a new object.
      */

    }

    static int feiledScope = 200;
    static void ScopeAndOperators()
    {
        //D1 — Scope
        Console.WriteLine(feiledScope);
        int localVariable = 10;
        {
            int innerVariable = 20;
            Console.WriteLine($"Inner variable: {innerVariable}");
            Console.WriteLine($"Local variable: {localVariable}");
            for (int i = 0; i < 3; i++)
            {
                int x = i * 10;

                Console.WriteLine($"i = {i}, x = {x}");
            }
        }
        Console.WriteLine("================================================================================");

        //D2 — Composite (compound assignment) operators
        int total = 100;
        total += 10;//total = total + 10; is equivalent to total += 10;
        Console.WriteLine($"Total after +=: {total}");

        total -= 10;
        Console.WriteLine($"Total after =: {total}");

        total *= 10;
        Console.WriteLine($"Total after *=: {total}");

        total /= 10;
        Console.WriteLine($"Total after /=: {total}");

        total %= 10;
        Console.WriteLine($"Total after %=: {total}");

        Console.WriteLine("================================================================================");
        //D3 — Bitwise operators(not logical operators)
        int a = 12;//1100 in binrary
        int b = 10;//1010 
        Console.WriteLine(a & b);//1000 in binary = 8
        Console.WriteLine(a | b);//1110 in binary = 14
        Console.WriteLine(a ^ b);//0110 in binary = 6
                                 //& is work all condition  while && is work on first condition if it false it will not check the second condition
        Console.WriteLine("================================================================================");
        //Part E — Draw the Stack & Heap (Markdown)   







    }
}