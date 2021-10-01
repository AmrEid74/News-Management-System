using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.BL.Models
{

    public class CreateRoleVM
    {

        public int Id { get; set; }

        [Required]
        [Display(Name = "Role")]
        public string RoleName { get; set; }
    }
}