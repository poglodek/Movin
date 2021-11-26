using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movin.Database.Entity
{
    public class Port
    {
        [Key]
        public int Key { get; set; }
        public int PortNumber { get; set; }
        public string PortName { get; set; }
        public List<Host> Hosts;
    }
}
