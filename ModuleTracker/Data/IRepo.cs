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
        IEnumerable<Module> GetAllModules();
        IEnumerable<Module> GetAllDependencies(int moduleId);
        Student GetStudentById(int id);
        Module GetModuleById(int id);
        IEnumerable<Module> GetModulesForCourse(int courseId);
        IEnumerable<Module> GetDependancyModulesForModule(int moduleId);
        University GetUniversityForStudent(int studentId);
        void CreateStudent(Student stud);
        void DeleteStudent(Student student);
        void CreateModule(Module module);
        void DeleteModule(Module module);
        void CreateUniversity(University university);
        void DeleteUniversity(University university);
    }
}
