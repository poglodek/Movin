using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movin.Exception
{
    public class WrongTypeTestException : System.Exception
    {
        public WrongTypeTestException(string msg) : base(msg)
        {
                
        }
    }
}
