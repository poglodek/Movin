using System.Net;

namespace Movin.TestingMethod
{
    public class TestHelper
    {
        //TODO: Adding save test to base, log, send email.

        public static bool TryParseToIPAddress(string ip)
        {
            try
            {
                IPAddress ipAddress = IPAddress.Parse(ip);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
