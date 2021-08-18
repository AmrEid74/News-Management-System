using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.BL.Models
{
  public  class EditorVM
    {

        public int Id { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage = "Name Required")]
        [MaxLength(50, ErrorMessage = "Max len 50 Letter")]
        [MinLength(3, ErrorMessage = "Min Len 3 Letter")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Age Required")]
        public int Age { get; set; }

        [Required(ErrorMessage = "E-mail Required")]
        [EmailAddress(ErrorMessage = "Insert Valied Mail")]
        public string Email { get; set; }
        [Required(ErrorMessage = "salary Required")]
        public double Salary { get; set; }
    }
}
