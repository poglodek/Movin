using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Movin.Database.Enum;

namespace Movin.Dto.TestResult
{
    public class TestResultDto
    {
        public int TestId { get; set; }
        public int HostId { get; set; }
        public TestingMethodResult Result { get; set; }
        public DateTime TestDate { get; set; }
    }
}
