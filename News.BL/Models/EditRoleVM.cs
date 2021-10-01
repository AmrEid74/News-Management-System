using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.BL.Models
{
   public class EditRoleVM
    {
        public EditRoleVM()
        {
            Users = new List<string>();
        }

        public string Id { get; set; }

        [Required(ErrorMessage ="Role Name Is Required")]
        public string RoleName { get; set; }

        public List<string> Users { get; set; }

    }

}
