using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Exceptions
{
    public class NotFoundItemException : Exception
    {
        public NotFoundItemException(string message)
            :base(message)
        {

        }
    }
}
