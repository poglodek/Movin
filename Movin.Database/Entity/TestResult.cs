using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movin.Database.Entity
{
    public class TestResult
    {
        [Key] 
        public int Id { get; set; }
        public Test Test { get; set; }
        private bool Result { get; set; }
        private DateTime TestDate { get; set; } 
    }
}
