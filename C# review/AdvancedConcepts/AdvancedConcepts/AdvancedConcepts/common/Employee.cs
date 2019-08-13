using System;
using System.Collections.Generic;
using System.Text;

namespace AdvancedConcepts.common
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        private string hobby;

        public string GetInfo()
        {
            return $"My name is {Name} and I am {Age}";
        }

        public virtual string Skill()
        {
            return string.Empty;
        }

        public int DoMath(int a, int b)
        {
            return a + b;
        }
    }
}
