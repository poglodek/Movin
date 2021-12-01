using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Movin.Dto.TestResult;

namespace Movin.Dto
{
    public class MovinMapper : Profile
    {
        public MovinMapper()
        {
            CreateMap<Database.Entity.TestResult, TestResultDto>()
                .ForMember(x => x.HostId, z => z.MapFrom(c => c.Host.Id))
                .ForMember(x => x.TestId, z => z.MapFrom(c => c.Test.Id))
                .ReverseMap();

        }
    }
}
