using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.BL.Models
{
  public  class LoginVM
    {
      
        [Required(ErrorMessage = "Please, E-Mail")]
        [EmailAddress(ErrorMessage = "Invalied Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please, Enter Password")]
        [StringLength(8, ErrorMessage = "Min Len 8")]
        public string Password { get; set; }

    public bool RememberMe { get; set; }
    }
}
