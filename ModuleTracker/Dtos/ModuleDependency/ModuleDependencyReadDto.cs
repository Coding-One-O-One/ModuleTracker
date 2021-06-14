using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ModuleTracker.Dtos
{
    public class ModuleDependencyReadDto
    {
        [Required]
        public int ModuleId { get; set; }
        [Required]
        public int ModuleDependencyId { get; set; }
    }
}
