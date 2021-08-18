using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.BL.Models
{
   public class ForgetPasswordVM
    {
        [Required(ErrorMessage = "Please, E-Mail")]
        [EmailAddress(ErrorMessage = "Invalied Email Address")]
        public string Email { get; set; }
    }
}
