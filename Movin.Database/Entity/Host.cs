using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movin.Database.Entity
{
    public class Host
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string HostName { get; set; }
        [Required]
        public string Ip { get; set; }
        public List<Test> Tests { get; set; }
        public List<Port> Ports { get; set; }
    }
    
}
