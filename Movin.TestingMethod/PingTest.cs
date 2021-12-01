using Movin.Database.Enum;
using Movin.Dto.Host;
using Movin.Dto.Test;
using Movin.Dto.TestResult;
using Movin.Exception;
using Movin.Services.IServices;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;

namespace Movin.TestingMethod
{
    public class PingTest
    {
        private readonly ITestResultServices _testResultServices;
        private TestDto _TestDto = null!;

        public PingTest(ITestResultServices testResultServices)
        {
            _testResultServices = testResultServices;
            //TODO: Adding services to save 
        }
        public void SetTest(TestDto testDto)
        {
            if (testDto.TestType != TestType.PING)
                throw new WrongTypeTestException($"Cannot parse this test to Ping Test");
            foreach (var host in testDto.Hosts)
            {
                if (!TestHelper.TryParseToIPAddress(host.Ip))
                    throw new InCorrectIpAddress($"IP: {host.Ip} is in correct");
            }
            _TestDto = testDto;
        }

        public void PrepareHosts()
        {
            if (!_TestDto.TestEnable || _TestDto is null || _TestDto.Hosts.Count == 0)
                return;

            var hosts = _TestDto.Hosts;

            foreach (var host in hosts)
            {
                Task.Run((() =>
                {
                    var result = Test(host);
                    if (_TestDto.SaveTestToDatabase)
                        SaveResultToDataBase(host, result);
                    if (_TestDto.LogTestToFile)
                        //TODO:Save to database
                        Console.WriteLine("LOG TO FILE");
                }));
            }
        }
        public TestingMethodResult Test(HostDto hostDto)
        {
            if (!TestHelper.TryParseToIPAddress(hostDto.Ip))
                return TestingMethodResult.INVALID_IP_ADDRESS;

            Ping pingTest = new Ping();

            // Create a buffer of 32 bytes of data to be transmitted.
            string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            try
            {
                PingReply reply = pingTest.Send(IPAddress.Parse(hostDto.Ip), 30, buffer);
                if (reply.Status == IPStatus.Success)
                    return TestingMethodResult.SUCCESS;
                else if (reply.Status == IPStatus.DestinationHostUnreachable)
                    return TestingMethodResult.HOST_UNREACHABLE;
                else
                    return TestingMethodResult.FAIL;
            }
            catch
            {
                return TestingMethodResult.HOST_UNREACHABLE;
            }

        }

        private void SaveResultToDataBase(HostDto dto, TestingMethodResult result)
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
