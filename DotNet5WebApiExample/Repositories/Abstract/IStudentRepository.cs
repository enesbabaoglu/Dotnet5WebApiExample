using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNet5WebApiExample.Entities;

namespace DotNet5WebApiExample.Repositories.Abstract
{
    public interface IStudentRepository :IGenericRepository<Student>
    {
        List<Student> GetStudentsByName(string name);
    }
}
