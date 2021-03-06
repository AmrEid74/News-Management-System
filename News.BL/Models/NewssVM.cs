using Microsoft.AspNetCore.Http;
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
  public  class NewssVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title Required")]
        [MaxLength(50, ErrorMessage = "Max len 50 Letter")]
        [MinLength(3, ErrorMessage = "Min Len 3 Letter")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Content")]
        [MaxLength(100, ErrorMessage = "Max len 100 Letter")]
        [MinLength(10, ErrorMessage = "Min Len 10 Letter")]
        public string Content { get; set; }

        public string Photo { get; set; }
        
        public IFormFile PhotoUrl{ get; set; }

        [Required(ErrorMessage = "Department Required")]
        public int CategoryId { get; set; }


        [ForeignKey("CategoryId")]
        public Categories Categories { get; set; }
    
      
    }
}
