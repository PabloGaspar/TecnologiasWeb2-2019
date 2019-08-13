using System;
using System.Collections.Generic;
using System.Text;

namespace AdvancedConcepts.common
{
    class Car
    {
        public string Brand { get; set; }
        [MaxLength(12)]
        public string CarName { get; set; }
    }
}
