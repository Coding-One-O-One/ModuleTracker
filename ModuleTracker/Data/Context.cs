using Microsoft.EntityFrameworkCore;
using ModuleTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModuleTracker.Data
{
    /// <summary>
    /// Represents a session with a database.
    /// </summary>
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> opt) : base(opt)
        {

        }

        //Representation of Student model in database, as a DbSet
        public DbSet<Student> Student { get; set; }
    }
}
