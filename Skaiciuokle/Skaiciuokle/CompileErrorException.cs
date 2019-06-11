using System;

namespace Skaiciuokle
{
    public class CompileErrorException : Exception
    {
        public CompileErrorException() : base("Wrong format")
        {
            
        }
    }
}