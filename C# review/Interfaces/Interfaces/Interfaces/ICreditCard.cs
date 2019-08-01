using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public interface ICreditCard
    {
        string Owner { get; set; }
        decimal MaxAmount { get; set; }

        string GetBrand(); 
        CardHolderInfo GetHolderInformation();
        decimal calculateInterest(decimal amount);
    }
}
