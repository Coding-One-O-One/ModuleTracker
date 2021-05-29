using AutoMapper;
using ModuleTracker.Dtos;
using ModuleTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModuleTracker.Profiles
{
    public class ModuleTrackerProfile : Profile
    {
        public ModuleTrackerProfile()
        {
            //Source -> Destination
            CreateMap<StudentCreateDto, Student>();
            CreateMap<Student, StudentReadDto>();
        }
    }
}
