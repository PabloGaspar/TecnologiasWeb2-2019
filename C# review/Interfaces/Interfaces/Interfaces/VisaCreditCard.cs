using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public class VisaCreditCard : ICreditCard
    {
        private string owner;
        private decimal maxAmount;
        private const string brand = "Visa";


        public string Owner
        {
            get { return owner; }
            set { owner = value; }
        }

        public decimal MaxAmount
        {
            get { return maxAmount; }
            set { maxAmount = value; }
        }

        public decimal calculateInterest(decimal amount)
        {
            return amount * 0.5m;
        }

        public string GetBrand()
        {
            return $"Im the best Brand: {brand}";
        }

        public CardHolderInfo GetHolderInformation()
        {
            return new CardHolderInfo()
            {
                Name = owner
            };
        }
    }
}
