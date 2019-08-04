using System;

namespace Interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal amountToShop = 400;
            CreditCardFactory.type = CreditCardType.MasterCard;
            ICreditCard MCCreditCard = CreditCardFactory.Create();
            MCCreditCard.Owner = "jhon";
            MCCreditCard.MaxAmount = 5000;

            ShopWithCreditCard(MCCreditCard, amountToShop);

            Console.ReadKey();
            global::System.Console.WriteLine();

            CreditCardFactory.type = CreditCardType.Visa;
            var VCredidCard = CreditCardFactory.Create();
            VCredidCard.Owner = "Peter";
            VCredidCard.MaxAmount = 10000;

            ShopWithCreditCard(VCredidCard, amountToShop);

        }

        private static void ShopWithCreditCard(ICreditCard creditCard, decimal amount)
        {
            Console.WriteLine($"Brand {creditCard.GetBrand()}" );
            var holderInformation = creditCard.GetHolderInformation();
            Console.WriteLine($"information:{holderInformation.Name} {holderInformation.Address}");
            var interest = creditCard.calculateInterest(amount);
            Console.WriteLine($"the interes will be: {interest}$ if you spend {amount}$");
        }
    }
}
