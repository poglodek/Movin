using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Movin.Database.Entity;
using Movin.Database.Enum;
using Movin.Dto.Host;

namespace Movin.Dto.Test
{
    public class TestDto
    {
        public TestType TestType { get; set; }
        public string TestName { get; set; }
        public bool TestEnable { get; set; }
        public int TestIntervalInSeconds { get; set; }
        public bool SaveTestToDatabase { get; set; } = true;
        public bool LogTestToFile { get; set; } = false;
        public string TestFileName { get; set; }
        public string TestFilePath { get; set; }
        public bool SendEmailWhenTestFailure { get; set; } = false;
        public List<HostDto> Hosts { get; set; }
        public List<TestResult> TestResults { get; set; }
    }
}
