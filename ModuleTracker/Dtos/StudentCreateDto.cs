﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ModuleTracker.Dtos
{
    /// <summary>
    /// DTOs are objects that carrey data between processes.
    /// </summary>
    public class StudentCreateDto
    {
        [Required]
        [MaxLength(256)]
        public string FullName { get; set; }
    }
}
