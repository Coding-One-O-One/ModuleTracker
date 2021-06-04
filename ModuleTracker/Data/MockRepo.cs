using ModuleTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModuleTracker.Data
{
    /// <summary>
    /// This mock repository can be used for testing.
    /// </summary>
    public class MockRepo : IRepo
    {
        public void CreateStudent(Student stud)
        {
            throw new NotImplementedException();
        }

        public void DeleteStudent(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Student> GetAllStudents()
        {
            var students = new List<Student>
            {
                new Student { StudentID = 0, FullName = "Divan van Zyl"},
                new Student { StudentID = 1, FullName = "Edrich Verburg" },
                new Student { StudentID = 2, FullName = "Lious Le Grange" },
                new Student { StudentID = 3, FullName = "Renato Nel" },
                new Student { StudentID = 4, FullName = "Mikael Barnard"}
            };

            return students;
        }
        public IEnumerable<Module> GetAllModules()
        {
            var modules = new List<Module>
            {
                new Module { ModuleID = 0, Code = "MAT1503", FullName = "Linear Algebra 1"},
                new Module { ModuleID = 1, Code = "COS1501", FullName = "Theoretical Computer Science 1" },
                new Module { ModuleID = 2, Code = "COS1521", FullName = "Computer Systems Fundamental Concepts" },
                new Module { ModuleID = 3, Code = "COS2601", FullName = "Theoretical Computer Science 2" }
            };

            return modules;
        }

        public IEnumerable<Module> GetAllDependencies(int moduleId)
        {
            const int LinearAlgebraOneId = 3;
            if(moduleId == LinearAlgebraOneId)
            {
                return new List<Module> {
                    new Module { ModuleID = 1, Code = "COS2601", FullName = "Theoretical Computer Science 1" },
                    new Module { ModuleID = 0, Code = "MAT1503", FullName = "Linear Algebra 1"}
                };
            }
              
            return  null;
        }

        public Module GetModuleById(int id)
        {
            List<Module> modules = new List<Module>
            {
                new Module { ModuleID = 0, Code = "MAT1503", FullName = "Linear Algebra 1" }
            };

            return modules[id];
        }

        public Student GetStudentById(int id)
        {
            List<Student> students = new List<Student>
            {
                new Student { StudentID = 0, FullName = "Divan van Zyl" }
            };

            return students[id];
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
