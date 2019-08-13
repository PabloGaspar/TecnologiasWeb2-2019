using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using AdvancedConcepts.common;

namespace AdvancedConcepts
{
    public static class ReflectionDemo
    {
        public static void Test()
        {
            Employee employeePeter = new Developer()
            {
                Age = 42,
                Id = 33,
                Name = "Peter"
            };

            bool isDeveloperType = employeePeter is Developer;

            bool isCarType = employeePeter is Car;

            Developer developerPeter = employeePeter as Developer;
            Developer developerPete2 = (Developer)employeePeter;

            // Using GetType to obtain type information:  
            int i = 42;
            System.Type type = i.GetType();
            System.Console.WriteLine(type);

            // Using Reflection to get information of an Assembly:  
            System.Reflection.Assembly info = typeof(System.Int32).Assembly;
            System.Console.WriteLine(info);

            //Get Type
            Type developerType = developerPeter.GetType();
            Console.WriteLine(developerType.FullName);

            //Typeof same
            Type developerType2 = typeof(Developer);
            Console.WriteLine(developerType2.FullName);

            GetTypeProperties(developerType);
            GetMethods(developerType);
        }

        public static void GetTypeProperties(Type t)
        {
            StringBuilder OutputText = new StringBuilder();

            //properties retrieve the strings   
            OutputText.AppendLine("Analysis of type " + t.Name);
            OutputText.AppendLine("Type Name: " + t.Name);
            OutputText.AppendLine("Full Name: " + t.FullName);
            OutputText.AppendLine("Namespace: " + t.Namespace);

            //properties retrieve references          
            Type tBase = t.BaseType;

            if (tBase != null)
            {
                OutputText.AppendLine("Base Type: " + tBase.Name);
            }
            
            //properties retrieve boolean          
            OutputText.AppendLine("Is Abstract Class: " + t.IsAbstract);
            OutputText.AppendLine("Is an Arry: " + t.IsArray);
            OutputText.AppendLine("Is a Class: " + t.IsClass);
            OutputText.AppendLine("Is a COM Object : " + t.IsCOMObject);

            OutputText.AppendLine("\nPUBLIC MEMBERS:");
            MemberInfo[] Members = t.GetMembers();

            foreach (MemberInfo NextMember in Members)
            {
                OutputText.AppendLine(NextMember.DeclaringType + " " +
                NextMember.MemberType + "  " + NextMember.Name);
            }
            Console.WriteLine(OutputText);


        }

        public static void TestAttributes()
        {
            var car = new Car()
            {
                Brand = "Nissan",
                CarName = "The fasstest car you have evern seen"
            };


            var carType = car.GetType();
            var properties = carType.GetProperties();
            foreach (var property in properties)
            {
                Console.WriteLine($"Poperty Name: {property.Name}");
                var propertyAttributes = property.GetCustomAttributes();
                foreach (var attribute in propertyAttributes)
                {
                    Console.WriteLine($"Attribute Name: {attribute.GetType().Name}");

                    if (attribute is MaxLengthAttribute)
                    {
                        var maxLengAttribute = attribute as MaxLengthAttribute;

                        var maxLenght = maxLengAttribute.getMaxLengt();
                        var propertyValue = property.GetValue(car) as string;
                        if (propertyValue.Length > maxLenght)
                        {
                            throw new Exception("Too long");
                        }
                        else
                        {
                            Console.WriteLine("everything is fine");
                        }
                    }
                }
            }
        }

        public static void GetMethods(Type t)
        {
            Console.WriteLine("***** Methods *****");
            //MethodInfo[] mi = t.GetMethods();
            List<MethodInfo> mi = new List<MethodInfo>();
            mi.Add(t.GetMethod("DoMath"));
            mi.Add(t.GetMethod("Skill"));

            foreach (MethodInfo m in mi)
            {
                Console.WriteLine("->{0}", m.Name);
                Console.WriteLine($"return type: { m.ReturnType.Name}");
                foreach (var param in m.GetParameters()) 
                {
                    Console.WriteLine($"Param Type:{param.ParameterType} - Param Name: {param.Name} ");
                }
            }
            Console.WriteLine("");
        }

    }
}
