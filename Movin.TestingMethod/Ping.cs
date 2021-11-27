using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Movin.Database.Entity;
using Movin.Dto.Host;
using Movin.Dto.Test;

namespace Movin.TestingMethod
{
    public class Ping
    {
        private readonly TestDto _TestDto;

        public Ping(TestDto testDto)
        {
            _TestDto = testDto;
        }
        

        private void PrepareHosts()
        {
            if (!_TestDto.TestEnable)
                return;
            var hosts = _TestDto.Hosts;
            //TODO: 

        }
        public void Test(HostDto hostDto)
        {
            //TODO: Test 
        }
      
    }
}
