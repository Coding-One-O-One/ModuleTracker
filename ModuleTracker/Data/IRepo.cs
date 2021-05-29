using ModuleTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModuleTracker.Data
{
    /// <summary>
    /// This inferface represents the data repository, for example a SQL serve database.
    /// </summary>
    public interface IRepo
    {
        bool SaveChanges();
        IEnumerable<Student> GetAllStudents();
        Student GetStudentById(int id);
        IEnumerable<Module> GetAllModules();
        Module GetModuleById(int id);
        void CreateStudent(Student stud);
        void DeleteStudent(int id);
    }
}
