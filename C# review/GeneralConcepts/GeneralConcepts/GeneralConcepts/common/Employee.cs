using System;
using System.Collections.Generic;
using System.Text;

namespace GeneralConcepts
{
    public abstract class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public string GetInfo()
        {
            return $"My name is {Name} and I am {Age}";
        }

        public virtual string Skill()
        {
            return string.Empty;
        }
    }
        
            
}
