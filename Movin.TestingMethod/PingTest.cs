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
    public class PingTest : Test
    {
        private readonly ITestResultServices _testResultServices;
        private TestDto _TestDto = null!;

        public PingTest(ITestResultServices testResultServices) : base(testResultServices)
        {
            
        }

        public override TestingMethodResult StartTest(HostDto hostDto)
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

    }
}
