using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ModuleTracker.Dtos
{
    /// <summary>
    /// DTOs are objects that carry data between processes.
    /// </summary>
    public class CourseCreateDto
    {
        [Required]
        [MaxLength(64)]
        public string Code { get; set; }
        [Required]
        public int NfqLevel { get; set; }
        [Required]
        [MaxLength(256)]
        public string FullName { get; set; }
        [Required]
        public bool InternationallyRecognised { get; set; }
        [Required]
        public int TypeID { get; set; }
    }
}
