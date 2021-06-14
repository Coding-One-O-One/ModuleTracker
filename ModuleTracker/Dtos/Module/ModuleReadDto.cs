using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ModuleTracker.Dtos
{
    public class ModuleReadDto
    {
        [Required]
        public int ModuleId { get; set; }
        [Required]
        [MaxLength(32)]
        public string Code { get; set; }
        [Required]
        [MaxLength(256)]
        public string FullName { get; set; }
    }
}
