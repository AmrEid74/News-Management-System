using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.BL.Models
{
  public  class ResetPasswordVM
    {
        [Required(ErrorMessage = "Please, Enter Password")]
        [StringLength(20, ErrorMessage = "Min Len 8")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please, Enter Full Name")]
        [StringLength(20, ErrorMessage = "Min Len 8")]
        [Compare("Password", ErrorMessageResourceName = "Not Match")]
        public string ConfirmPassword { get; set; }
    }
}
