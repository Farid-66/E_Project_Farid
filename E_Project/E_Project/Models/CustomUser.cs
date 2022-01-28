using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_Project.Models
{
    public class CustomUser:IdentityUser
    {
        [MaxLength(70)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string Surname { get; set; }
    }
}
