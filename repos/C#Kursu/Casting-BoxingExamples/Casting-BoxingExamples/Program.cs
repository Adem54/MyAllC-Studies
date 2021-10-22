using System;

namespace Casting_BoxingExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    class MyClass
    {
        public static void Main()
        {
            // You cannot implicitly convert a double to an integer.
            double d = 3.2;

            // The following line causes compiler error CS0266.
            int i1 = d;

            // However, you can resolve the error by using an explicit conversion.
            int i2 = (int)d;

            // You cannot implicitly convert an object to a class type.
            object obj = new MyClass();

            // The following assignment statement causes error CS0266.
            MyClass myClass = obj;

            // You can resolve the error by using an explicit conversion.
            MyClass c = (MyClass)obj;

            // You cannot implicitly convert a base class object to a derived class type.
            MyClass mc = new MyClass();
            DerivedClass dc = new DerivedClass();

            // The following line causes compiler error CS0266.
            dc = mc;

            // You can resolve the error by using an explicit conversion.
            dc = (DerivedClass)mc;
        }
    }

    class DerivedClass : MyClass
    {
    }
}
