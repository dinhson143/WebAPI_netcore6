using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Model.Exceptions
{
   public class AuthorizedException : Exception
    {
        public AuthorizedException(string message) : base(message)
        {
        }
        public AuthorizedException():base()
        {
        }
    }
}