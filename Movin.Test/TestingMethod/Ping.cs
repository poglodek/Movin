using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Movin.Database.Enum;
using Movin.Dto.Host;
using Movin.Dto.Test;
using Movin.TestingMethod;
using Xunit;

namespace Movin.Test.TestingMethod
{
    
    public class Ping
    {
        [Fact]
        public void Test_ForValidHost_Return_SUCCESS()
        {
            var pingTest = new Mock<PingTest>();
            var host =
                new HostDto()
                {
                    Ip = "192.168.1.1",
                    HostName = "Router",
                    Login = "pablos",
                    Password = "S3cr3t&P455w0rd!",
                    Port = 0
                };

            var result = pingTest.Object.Test(host);
            Assert.Equal(TestingMethodResult.SUCCESS, result);
        }
        [Fact]
        public void Test_ForInValidHost_Return_Fail()
        {
            var pingTest = new Mock<PingTest>();
            var host =
                new HostDto()
                {
                    Ip = "123.11",
                    HostName = "Router",
                    Login = "pablos",
                    Password = "S3cr3t&P455w0rd!",
                    Port = 0
                };

            var result = pingTest.Object.Test(host);
            Assert.Equal(TestingMethodResult.FAIL, result);
        }
        [Fact]
        public void Test_ForUnreachableHost_Return_HOST_UNREACHABLE()
        {
            var pingTest = new Mock<PingTest>();
            var host =
                new HostDto()
                {
                    Ip = "255.255.255.254",
                    HostName = "Router",
                    Login = "pablos",
                    Password = "S3cr3t&P455w0rd!",
                    Port = 0
                };

            var result = pingTest.Object.Test(host);
            Assert.Equal(TestingMethodResult.HOST_UNREACHABLE, result);
        }
        [Fact]
        public void SetTest_ForValidTest_Return_SUCCESS()
        {
            var pingTest = new Mock<PingTest>();
            var hosts = new List<HostDto>()
            {
                new HostDto()
                {
                    Ip = "192.168.1.1",
                    HostName = "Router",
                    Login = "pablos",
                    Password = "S3cr3t&P455w0rd!",
                    Port = 0
                }
            };
            var test = new TestDto()
            {
                Hosts = hosts,
                TestEnable = true,
                SaveTestToDatabase = false,
                LogTestToFile = false
            };

            pingTest.Object.SetTest(test);
            var result = pingTest.Object.Test(hosts.First());
            Assert.Equal(TestingMethodResult.SUCCESS, result);
        }
        [Fact]
        public void PrepareHosts_ForValidTest_Return_SUCCESS()
        {
            var pingTest = new Mock<PingTest>();
            var hosts = new List<HostDto>()
            {
                new HostDto()
                {
                    Ip = "192.168.1.1",
                    HostName = "Router",
                    Login = "pablos",
                    Password = "S3cr3t&P455w0rd!",
                    Port = 0
                }
            };
            var test = new TestDto()
            {
                Hosts = hosts,
                TestEnable = true,
                SaveTestToDatabase = false,
                LogTestToFile = false
            };

            pingTest.Object.SetTest(test);
            pingTest.Object.PrepareHosts();
        }
    }
}
