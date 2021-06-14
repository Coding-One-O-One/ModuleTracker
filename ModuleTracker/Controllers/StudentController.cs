using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using ModuleTracker.Data;
using ModuleTracker.Dtos;
using ModuleTracker.Models;
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
    [Route("api/student")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IRepo _repository;
        private readonly IMapper _mapper;

        //Constructor dependancy injection
        public StudentController(IRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
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

        //Return a single student
        //[HttpGet] indicates that the method will repond to a GET verb
        //GET api/ModuleTracker/student/{id}
        [HttpGet("{id}", Name = "GetStudentById")]
        public ActionResult <StudentReadDto> GetStudentById(int id)
        {
            var studentItem = _repository.GetStudentById(id);
            if(studentItem != null)
            {
                return Ok(_mapper.Map<StudentReadDto>(studentItem));
            }
            return NotFound();
        }

        //POST api/student
        [HttpPost]
        public ActionResult<StudentReadDto> CreateStudent(StudentCreateDto studentCreateDto)
        {
            var studentModel = _mapper.Map<Student>(studentCreateDto);  //Use automapper to create model
            _repository.CreateStudent(studentModel);
            _repository.SaveChanges();
            var studentReadDto = _mapper.Map<StudentReadDto>(studentModel);
            //return Ok(studentReadDto);
            return CreatedAtRoute(nameof(GetStudentById), new { studentReadDto.StudentID }, studentReadDto);
        }

        //PUT api/student/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateStudent(int id, StudentUpdateDto studentUpdateDto)
        {
            var studentModelFromRepo = _repository.GetStudentById(id);
            if (studentModelFromRepo == null)    //Check if resource exists
            {
                return NotFound();
            }

            _mapper.Map(studentUpdateDto, studentModelFromRepo);
            _repository.UpdateStudent(studentModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }

        //PATCH api/student/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialStudentUpdate(int id, JsonPatchDocument<StudentUpdateDto> patchDoc)
        {
            var studentModelFromRepo = _repository.GetStudentById(id);
            if (studentModelFromRepo == null)   //Check if resource exists
            {
                return NotFound();
            }

            var studentToPatch = _mapper.Map<StudentUpdateDto>(studentModelFromRepo);
            patchDoc.ApplyTo(studentToPatch, ModelState);
            if (!TryValidateModel(studentToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(studentToPatch, studentModelFromRepo);
            _repository.UpdateStudent(studentModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }

        //DELETE api/student/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteStudent(int id)
        {
            var studentModelFromRepo = _repository.GetStudentById(id);
            if (studentModelFromRepo == null)   //Check if resource exists
            {
                return NotFound();
            }
            _repository.DeleteStudent(studentModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }

    }
}
