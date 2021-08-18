using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.BL.Models
{
   public class RegistrationVM
    {

        [Required(ErrorMessage ="Please, Enter Full Name")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Please, E-Mail")]
        [EmailAddress(ErrorMessage ="Invalied Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please, Enter Password")]
        [StringLength(8,ErrorMessage ="Min Len 8")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Enter Password")]
        [StringLength(8, ErrorMessage = "Min Len 8")]
        [Compare("Password", ErrorMessage = "Not Match")]
        public string ConfirmPassword { get; set; }

    }
}
