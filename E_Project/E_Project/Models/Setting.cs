using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_Project.Models
{
    public class Setting
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string SiteName { get; set; }
        [MaxLength(150)]
        public string Title { get; set; }
        [MaxLength(100)]
        public string TitleContent1 { get; set; }
        [MaxLength(150)]
        public string TitleContent2 { get; set; }
        [MaxLength(150)]
        public string Address { get; set; }
        [MaxLength(50)]
        public string Phone { get; set; }
        [MaxLength(100)]
        public string Email { get; set; }
        [MaxLength(100)]
        public string Web { get; set; }
    }
}
