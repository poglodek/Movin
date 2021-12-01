using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Movin.Database.Enum;

namespace Movin.Database.Entity
{
    public class TestResult
    {
        [Key] 
        public int Id { get; set; }
        public Test Test { get; set; }
        public Host Host { get; set; }
        public TestingMethodResult Result { get; set; }
        public DateTime TestDate { get; set; } 
    }
}
