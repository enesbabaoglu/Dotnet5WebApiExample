using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNet5WebApiExample
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ContactDetails ContactDetails { get; set; }
    }
}
