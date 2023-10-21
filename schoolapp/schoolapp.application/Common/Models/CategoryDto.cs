using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace schoolapp.Application.Common.Models;
public class CategoryDto
{
    public string Name { get; set; }
    public string ModifiedBy { get; set; }
    public int DisplayOrder { get; set; }
    [NotMapped]
    public IFormFile ImageFile { get; set; }
}
