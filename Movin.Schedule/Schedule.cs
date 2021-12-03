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
        public static Dictionary<string, Timer> Schedulers;

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
            Schedulers = new Dictionary<string, Timer>();
            Schedulers.Clear();
            var tests = _services.GetActiveTest();
            Console.WriteLine($"Schedulers tests: {tests.Count()}");
            foreach (var test in tests)
            {
                CreateSchedule(test);
            }
            Console.WriteLine("Schedule Started successfully!");
            ServiceStarted = true;
        }

        private void CreateSchedule(Database.Entity.Test test)
        {
            TimerCallback callback = (x) =>
            {

                //TODO:Adding changer for test ping, ssh
                var ping = new PingTest(_testResultServices);
                ping.SetTest(_mapper.Map<TestDto>(test));
            };
            int intervalInMS = test.TestIntervalInSeconds * 1000 * 60;  // test time 
            var timer = new Timer(callback, state: null, dueTime: intervalInMS, period: intervalInMS);
            Schedulers.Add(test.TestName,timer);
        }
        
    }
}
