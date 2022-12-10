using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoObservables.Api.Business.Exceptions
{
    public class GeneralException : Exception 
    {
        public GeneralException() : base("An error has ocurred")
        {

        }

        public GeneralException(Exception ex) : base("An error has ocurred", ex)
        {

        }

        public GeneralException(string message) : base(message)
        {

        }

        public GeneralException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
