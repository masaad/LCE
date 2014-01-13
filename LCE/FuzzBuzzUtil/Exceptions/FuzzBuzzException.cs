using System;

namespace FuzzBuzzUtil.Exceptions
{
    public class FuzzBuzzException : Exception
    {
        public FuzzBuzzException()
        {            
        }

        public FuzzBuzzException(string message) 
            : base(message)
        {            
        }

        public FuzzBuzzException(string message, Exception inner) 
            : base(message, inner)
        {            
        }
    }
}
