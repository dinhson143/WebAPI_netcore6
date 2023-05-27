using System;

namespace WebAPI.Model.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException():base()
        {}
        
        public NotFoundException(string message) : base(message)
        {
        }

    }
}