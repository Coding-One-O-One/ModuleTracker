using AutoMapper;
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
    [Route("api/module")]
    [ApiController]
    public class ModuleController : Controller
    {
        private readonly IRepo _repository;
        private readonly IMapper _mapper;

        //Constructor dependancy injection
        public ModuleController(IRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //Returns an actionresult as <IEnumerable> list of modules
        //[HttpGet] indicates that method will respond to a GET verb
        //GET api/modules
        [HttpGet]
        public ActionResult<IEnumerable<ModuleReadDto>> GetAllModules()
        {
            var items = _repository.GetAllModules();
            return Ok(_mapper.Map<IEnumerable<ModuleReadDto>>(items));
        }

        //Return a single student
        //[HttpGet] indicates that the method will repond to a GET verb
        //GET api/ModuleTracker/student/{id}
        [HttpGet("{id}", Name = "GetModuleById")]
        public ActionResult<ModuleReadDto> GetModuleById(int id)
        {
            var moduleItem = _repository.GetModuleById(id);
            if (moduleItem != null)
            {
                return Ok(_mapper.Map<ModuleReadDto>(moduleItem));
            }
            return NotFound();
        }

        //POST api/module
        [HttpPost]
        public ActionResult<ModuleReadDto> CreateModule(ModuleCreateDto moduleCreateDto)
        {
            var moduleModel = _mapper.Map<Module>(moduleCreateDto);  //Use automapper to create model
            _repository.CreateModule(moduleModel);
            _repository.SaveChanges();
            var moduleReadDto = _mapper.Map<ModuleReadDto>(moduleModel);
            //return Ok(moduleReadDto);
            return CreatedAtRoute(nameof(GetModuleById), new { moduleReadDto.ModuleId }, moduleReadDto);
        }

        //PUT api/module/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateModule(int id, ModuleUpdateDto moduleUpdateDto)
        {
            var moduleModelFromRepo = _repository.GetModuleById(id);
            if (moduleModelFromRepo == null)    //Check if resource exists
            {
                return NotFound();
            }

            _mapper.Map(moduleUpdateDto, moduleModelFromRepo);
            _repository.UpdateModule(moduleModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }

        //PATCH api/module/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialModuleUpdate(int id, JsonPatchDocument<ModuleUpdateDto> patchDoc)
        {
            var moduleModelFromRepo = _repository.GetModuleById(id);
            if (moduleModelFromRepo == null)   //Check if resource exists
            {
                return NotFound();
            }

            var moduleToPatch = _mapper.Map<ModuleUpdateDto>(moduleModelFromRepo);
            patchDoc.ApplyTo(moduleToPatch, ModelState);
            if (!TryValidateModel(moduleToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(moduleToPatch, moduleModelFromRepo);
            _repository.UpdateModule(moduleModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }

        //DELETE api/module/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteModule(int id)
        {
            var moduleModelFromRepo = _repository.GetModuleById(id);
            if (moduleModelFromRepo == null)   //Check if resource exists
            {
                return NotFound();
            }
            _repository.DeleteModule(moduleModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }
    }
}
