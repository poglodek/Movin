using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movin.Exception
{
    public class InCorrectQueryParseException : System.Exception
    {
        public InCorrectQueryParseException(string message) : base(message)
        {
            
        }
    }
}
