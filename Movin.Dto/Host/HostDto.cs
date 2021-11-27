using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Movin.Database.Entity;

namespace Movin.Dto.Host
{
    public class HostDto
    {
        public string HostName { get; set; }
        public string Ip { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int Port { get; set; }
    }
}
