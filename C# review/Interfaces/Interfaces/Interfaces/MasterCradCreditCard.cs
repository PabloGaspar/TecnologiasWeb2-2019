using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public class MasterCradCreditCard : ICreditCard
    {

        private string owner;
        private decimal maxAmount;
        private const string brand = "Master Card";


        public string Owner {
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
            decimal interestFactor;

            if (maxAmount > 1000)
            {
                interestFactor = 0.10m;
            }
            else
            {
                interestFactor = 0.5m;
            }

            return amount * interestFactor;
        }

        public string GetBrand()
        {
            return $"The brand is: {brand}";
        }

        public CardHolderInfo GetHolderInformation()
        {
            return new CardHolderInfo()
            {
                Name = $"Owner: {owner}",
                Address = "no Adress"
            };
        }
    }
}
