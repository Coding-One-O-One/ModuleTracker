using ModuleTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModuleTracker.Data
{
    public class SqlServerRepo : IRepo
    {
        private readonly Context _context;

        public SqlServerRepo(Context context)
        {
            _context = context;
        }

        public void CreateModule(Module module)
        {
            if (module == null)
            {
                throw new ArgumentNullException(nameof(module));
            }
            _context.Module.Add(module);
        }

        public void CreateStudent(Student stud)
        {
            if (stud == null)
            {
                throw new ArgumentNullException(nameof(stud));
            }
            _context.Student.Add(stud);
        }

        public void DeleteModule(Module module)
        {
            if (module == null)
            {
                throw new ArgumentNullException(nameof(module));
            }
            _context.Module.Remove(module);
        }

        public void DeleteStudent(Student stud)
        {
            if (stud == null)
            {
                throw new ArgumentNullException(nameof(stud));
            }
            _context.Student.Remove(stud);
        }

        public IEnumerable<Module> GetAllDependencies(int moduleId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Module> GetAllModules()
        {
            return _context.Module.ToList();
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _context.Student.ToList();
        }

        public Module GetModuleById(int id)
        {
            return _context.Module.FirstOrDefault(p => p.ModuleID == id);
        }

        public Student GetStudentById(int id)
        {
            return _context.Student.FirstOrDefault(p => p.StudentID == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
