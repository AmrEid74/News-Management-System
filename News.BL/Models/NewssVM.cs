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

        [StringLength(50)]
        [Required(ErrorMessage = "Title Required")]
        [MaxLength(50, ErrorMessage = "Max len 50 Letter")]
        [MinLength(3, ErrorMessage = "Min Len 3 Letter")]
        public string Title { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Title Required")]
        [MaxLength(50, ErrorMessage = "Max len 50 Letter")]
        [MinLength(3, ErrorMessage = "Min Len 10 Letter")]
        public string Content { get; set; }
        [Required(ErrorMessage = "Title Required")]
        public string Images { get; set; }

        [Required(ErrorMessage = "Department Required")]
        public int CategoryId { get; set; }


        [ForeignKey("CategoryId")]
        public Categories Categories { get; set; }
    
        [ForeignKey("EditorId")]
        public Editor Editor { get; set; }

    }
}
