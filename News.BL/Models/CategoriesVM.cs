using News.DAL.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.BL.Models
{
   public class CategoriesVM
    {
        
        public int Id { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage = "Name Required")]
        [MaxLength(50, ErrorMessage = "Max len 50 Letter")]
        [MinLength(3, ErrorMessage = "Min Len 3 Letter")]
        public string CategoryName { get; set; }


        [Required(ErrorMessage = "Description Required")]
        [MaxLength(100, ErrorMessage = "Max len 100 Letter")]
        [MinLength(10, ErrorMessage = "Min Len 10 Letter")]
        public string Description { get; set; }

       

    }
}
