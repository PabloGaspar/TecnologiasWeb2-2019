using System;
using System.Collections.Generic;
using System.Text;

namespace AdvancedConcepts
{
    [AttributeUsage(AttributeTargets.Property)]
    public class MaxLengthAttribute : Attribute
    {
        private int _maxLenght;
        public MaxLengthAttribute(int maxLength)
        {
            _maxLenght = maxLength;
        }

        public int getMaxLengt()
        {
            return this._maxLenght;
        }
    }
}
