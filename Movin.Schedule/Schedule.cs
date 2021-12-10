using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Movin.Database.Entity;
using Movin.Dto.Test;
using Movin.Services.IServices;
using Movin.TestingMethod;

namespace Movin.Schedule
{
    public class Schedule
    {
        private readonly ITestServices _services;
        private readonly ITestResultServices _testResultServices;
        private readonly IMapper _mapper;

        public static bool ServiceStarted { get; set; }
        public static IEnumerable<Database.Entity.Test> Tests;
        public Schedule(ITestServices services, 
            ITestResultServices testResultServices, 
            IMapper mapper)
        {
            _services = services;
            _testResultServices = testResultServices;
            _mapper = mapper;
        }

        public void RestartService()
        {
            Console.WriteLine("Schedule stopping...");
            StartService();
            Console.WriteLine("Schedule restated successfully!");
        }

        public void StartService()
        {
            Console.WriteLine("Schedule starting...");

            Tests = _services.GetActiveTest();
            Console.WriteLine($"Schedulers tests: {Tests.Count()}");
            CreateSchedule();
            Console.WriteLine("Schedule Started successfully!");
            ServiceStarted = true;
        }

        private void CreateSchedule()
        {
            foreach (var test in Tests)
            {
                Task.Run( async () =>
                {
                    Console.WriteLine($"Create Task: {test.TestName}");
                    var ping = new PingTest(_testResultServices);
                    //TODO:Adding changer for test ping, ssh
                    var testDto = _mapper.Map<TestDto>(test);
                    ping.SetTest(testDto);
                    while (true)
                    {
                        ping.PrepareHosts();
                        await Task.Delay(test.TestIntervalInSeconds * 1000 * 60);
                    }
                    
                });
            }
            
        }
        
    }
}
