using System;

namespace Kalkuliator
{
    public class InvalidExpressionException : Exception
    {
        public InvalidExpressionException() : base("Wrong input expression format")
        {

        }
    }
}
