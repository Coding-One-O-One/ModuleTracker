using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ModuleTracker.Dtos
{
    public class StudentReadDto
    {        
        public int StudentID { get; set; }

        public string FullName { get; set; }
    }
}
