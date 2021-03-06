using Movin.Database.Enum;
using Movin.Dto.Host;
using Movin.Dto.TestResult;

namespace Movin.Dto.Test
{
    public class TestDto
    {
        public int Id { get; set; }
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
        public List<TestResultDto> TestResults { get; set; }
    }
}
