using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movin.Exception
{
    public class InCorrectIpAddress : System.Exception
    {
        public InCorrectIpAddress(string message) : base(message)
        {
                
        }
    }
}
