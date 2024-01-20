using schoolapp.Domain.Entities.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace schoolapp.Application.DTOs
{
    public class StudentDto
    {
        public Student  Student { get; set; }
        public List<Parent> Parents { get; set; }
    }
}
