using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TelephoneDirectory.CustomException
{
    public class DepartmanException : ApplicationException
    {
        public DepartmanException() : base()
        {

        }

        public DepartmanException(String message) : base(message)
        {

        }

    }
}