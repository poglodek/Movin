using Movin.TestingMethod;
using Xunit;

namespace Movin.Test.TestingMethod
{
    public class TestHelperTest
    {
        [Theory]
        [InlineData("123.123.123.123")]
        [InlineData("192.168.1.1")]
        [InlineData("10.12.51.8")]
        [InlineData("185.67.245.99")]
        public void TryParseToIPAddress_ValidIp_ShouldReturnTrue(string ip)
        {
            var result = TestHelper.TryParseToIPAddress(ip);
            Assert.True(result);
        }
        [Theory]
        [InlineData("123.123.123.123.1")]
        [InlineData("999.999.999.999")]
        [InlineData("test")]
        [InlineData("test.test.test.test")]
        [InlineData("0.-3.12.23")]
        [InlineData("10.-3.12.23")]
        [InlineData("10.-3")]
        [InlineData("....")]
        [InlineData("google.com")]
        public void TryParseToIPAddress_InValidIp_ShouldReturnFalse(string ip)
        {
            var result = TestHelper.TryParseToIPAddress(ip);
            Assert.False(result);
        }
    }
}
