using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public enum CreditCardType
    {
        MasterCard,
        Visa
    }

    public static class CreditCardFactory
    {

        public static CreditCardType type;
        public static ICreditCard Create()
        {
            switch (type)
            {
                case CreditCardType.MasterCard:
                    return new MasterCradCreditCard();
                case CreditCardType.Visa:
                    return new VisaCreditCard();
                default:
                    return null;
            }
        }
    }
}
