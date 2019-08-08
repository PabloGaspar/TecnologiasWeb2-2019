using System;
using System.Collections.Generic;
using System.Text;
using GeneralConcepts;

namespace GeneralConcepts.Generics
{


    //    Generics can be applied to the following:

    //Interface
    //Abstract class
    //Class
    //Method
    //Static method
    //Property
    //Event
    //Delegates
    //Operator

    public class MyGenericArray<T> //where T : Employee   //-> constrains
    {
        private T[] array;

        public MyGenericArray(int size)
        {
            array = new T[size + 1];
        }
        public T getItem(int index)
        {
            return array[index];
        }
        public void setItem(int index, T value)
        {
            array[index] = value;
            //value.Skill();
        }
    }
    public static class Tester
    {
        public static void Test()
        {

            //declaring an int array
            MyGenericArray<int> intArray = new MyGenericArray<int>(5);

            //setting values
            for (int c = 0; c < 5; c++)
            {
                intArray.setItem(c, c * 5);
            }

            //retrieving the values
            for (int c = 0; c < 5; c++)
            {
                Console.Write(intArray.getItem(c) + " ");
            }

            Console.WriteLine();

            //generic class of Dev

            var devArray = new MyGenericArray<Developer>(2);

            devArray.setItem(0, new Developer() {
                Name = "Pepe",
                Age = 55
            });

            devArray.setItem(1, new Developer()
            {
                Name = "Alam",
                Age = 11
            });

            for (int i = 0; i < 2; i++)
            {
                var dev = devArray.getItem(i);

                Console.WriteLine(dev.GetInfo());
                Console.WriteLine(dev.Skill());
            }

            Console.ReadKey();

            //generic method 
            int a = 1;
            int b = 2;

            Swap<int>(ref a, ref b);
            System.Console.WriteLine(a + " " + b);

            //inference 
            Swap(ref a, ref b);
        }

        static void Swap<T>(ref T lhs, ref T rhs)
        {
            T temp;
            temp = lhs;
            lhs = rhs;
            rhs = temp;
        }

    }
}
