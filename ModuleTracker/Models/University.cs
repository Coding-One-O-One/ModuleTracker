using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ModuleTracker.Models
{
    public class University
    {
        [Required]
        [Key]
        public int UniversityID { get; set; }
        [Required]
        [MaxLength(256)]
        public string FullName { get; set; }
    }
}
