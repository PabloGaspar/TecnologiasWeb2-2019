using System;
using System.Collections.Generic;
using System.Text;
using GeneralConcepts.Generics;

namespace GeneralConcepts.DelegatesAndLambdas
{
    public static class Tester
    {
        public static void Test()
        {
            var qa = new QA();
            // action for void functions
            Action<Employee, string, int> action = populateEmployee;
            populateEmployee(qa, "Peter", 22);

            // func for return methods
            Func<Employee, string, int, string> func = populateAndShowEmployee;
             var info = func(qa, "Tony", 23);

            ////Lambda expresion
            //(input - parameters) => expression

            Action<Employee, string, int> lambdaAction = (employee, name, age) => {
                employee.Name = name;
                employee.Age = age;
            };

            Func<Employee, string, int, string> lambdaFunc = (employee, name, age) => {
                employee.Name = name;
                employee.Age = age;
                return $"{employee.GetInfo()} and {employee.Skill()}";
            };

            var dev = new Developer();
            lambdaAction(dev, "Stan", 65);

            var devInfo = lambdaFunc(dev, "Stan", 65);
        }

        public static string populateAndShowEmployee(Employee employee, string name, int age)
        {
            employee.Name = name;
            employee.Age = age;
            return $"{employee.GetInfo()} and {employee.Skill()}";
        }

        public static void populateEmployee(Employee employee, string name, int age)
        {
            employee.Name = name;
            employee.Age = age;
        }

    }

    
}
