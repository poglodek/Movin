using Movin.Database.Enum;
using System.ComponentModel.DataAnnotations;

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
