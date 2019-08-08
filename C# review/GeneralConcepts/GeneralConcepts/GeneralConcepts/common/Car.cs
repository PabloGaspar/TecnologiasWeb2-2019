using System;
using System.Collections.Generic;
using System.Text;

namespace GeneralConcepts
{
    public enum CarType
    {
        Ferrary,
        Beetle
    }

    public class Car
    {
        public string OwnerName { get; set; }
        public int OwnerAge { get; set; }
        public CarType type { get; set; }
    }
}
