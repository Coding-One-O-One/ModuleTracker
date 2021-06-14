using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ModuleTracker.Dtos
{
    public class StudentUpdateDto
    {
        [Required]
        [MaxLength(256)]
        public string FullName { get; set; }
    }
}
