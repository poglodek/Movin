using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Movin.Database.Enum;

namespace Movin.Dto.Test
{
    public class TestListDto
    {
        public int Id { get; set; }
        public TestType TestType { get; set; }
        public string TestName { get; set; }
        public bool TestEnable { get; set; }
        public int TestIntervalInSeconds { get; set; }
        public bool SaveTestToDatabase { get; set; } = true;
        public bool LogTestToFile { get; set; } = false;
        public bool SendEmailWhenTestFailure { get; set; } = false;
    }
}
