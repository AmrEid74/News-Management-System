using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.DAL.Entity
{
    [Table("Categories")]

    public class Categories
    {

        [Key]
        public int Id { get; set; }

        public string CategoryName { get; set; }
        public string Description { get; set; }

        [ForeignKey("AdminId")]
        public User Admin { get; set; }

    }
}
