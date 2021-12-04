using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Movin.Database.Enum;
using Movin.Dto.Host;
using Movin.Dto.Test;
using Movin.Dto.TestResult;
using Movin.Services.IServices;

namespace Movin.TestingMethod
{
    public abstract class Test
    {
        private TestDto _TestDto = null!;
        private readonly ITestResultServices _testResultServices;

        public Test(ITestResultServices testResultServices)
        {
            _testResultServices = testResultServices;
        }
        public abstract void SetTest(TestDto testDto);

        public void PrepareHosts()
        {
            if (!_TestDto.TestEnable || _TestDto is null || _TestDto.Hosts.Count == 0)
                return;

            var hosts = _TestDto.Hosts;

            foreach (var host in hosts)
            {
                Task.Run((() =>
                {
                    var result = StartTest(host);
                    if (_TestDto.SaveTestToDatabase)
                        SaveResultToDataBase(host, result);
                    if (_TestDto.LogTestToFile)
                        //TODO:Save to database
                        Console.WriteLine("LOG TO FILE");
                }));
            }
        }
        public abstract TestingMethodResult StartTest(HostDto hostDto);

        protected void SaveResultToDataBase(HostDto dto, TestingMethodResult result)
        {
            TestResultDto resultDto = new TestResultDto()
            {
                HostId = dto.Id,
                TestId = _TestDto.Id,
                Result = result,
                TestDate = DateTime.Now
            };
            _testResultServices.SaveTestResult(resultDto);
        }
    }
}
