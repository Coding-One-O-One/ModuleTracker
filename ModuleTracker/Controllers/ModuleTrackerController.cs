using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModuleTracker.Data;
using ModuleTracker.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModuleTracker.Controllers
{
    /// <summary>
    /// ApiController atribute gives some default behaviours "out-of-the-box"
    /// Controller level Route determines how to get to the endpoint. If with [Route("api/[controller]")]: The [controller] part of the string in the param, takes the class name and puts it in the string.
    /// </summary>
    [Route("api/moduletracker")]
    [ApiController]
    public class ModuleTrackerController : ControllerBase
    {
        private readonly IRepo _repository;
        private readonly IMapper _mapper;

        //Constructor dependancy injection
        public ModuleTrackerController(IRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //Return a single student
        //[HttpGet] indicates that the method will repond to a GET verb
        //GET api/ModuleTracker/student/{id}
        [HttpGet("student/{id}", Name = "GetStudentById")]
        public ActionResult <StudentReadDto> GetStudentById(int id)
        {
            var studentItem = _repository.GetStudentById(id);
            if(studentItem != null)
            {
                return Ok(_mapper.Map<StudentReadDto>(studentItem));
            }
            return NotFound();
        }

        //Returns an actionresult as <IEnumerable> list of students
        //[HttpGet] indicates that method will respond to a GET verb
        //GET api/students
        [HttpGet]
        public ActionResult<IEnumerable<StudentReadDto>> GetAllStudents()
        {
            var items = _repository.GetAllStudents();
            return Ok(_mapper.Map<IEnumerable<StudentReadDto>>(items));
        }
    }
}
