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

        public IEnumerable<Module> GetAllModules()
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

        public Module GetModuleById(int id)
        {
            return new Module { ModuleID = 0, Code = "MAT1503", FullName = "Linear Algebra 1" };
        }

        public Student GetStudentById(int id)
        {
            return new Student { StudentID = 0, FullName = "Divan van Zyl" };
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
