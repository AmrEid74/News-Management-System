using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.DAL.Entity
{
    [Table("Newss")]
  public  class Newss
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }
        public string Content { get; set; }

        public string Images { get; set; }
        public int CategoryId { get; set; }


        [ForeignKey("CategoryId")]
        public Categories Categories { get; set; }
        [ForeignKey("EditorId")]
        public Editor Editor { get; set; }

    }
}
