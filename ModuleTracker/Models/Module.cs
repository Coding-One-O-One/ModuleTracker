using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ModuleTracker.Models
{
    public class Module
    {
        [Required]
        [Key]
        public int ModuleID { get; set; }
        [Required]
        [MaxLength(32)]
        public string Code { get; set; }
        [Required]
        [MaxLength(256)]
        public string FullName { get; set; }
    }
}
