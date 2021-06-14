using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ModuleTracker.Models
{
    public class ModuleDependency
    {
        [Required]
        [Key]
        public int ModuleID { get; set; }
        [Required]
        [Key]
        public int DependencyModuleID { get; set; }
    }
}
