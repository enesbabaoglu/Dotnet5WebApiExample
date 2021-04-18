using DotNet5WebApiExample.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNet5WebApiExample.Entities;

namespace DotNet5WebApiExample.Repositories.Concrete
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        public List<Student> GetStudentsByName(string name)
        {
            using (var db = new WebApiContext())
            {
                return db.Set<Student>().Where(c => c.Name == name).ToList();
            }
        }
    }
}
