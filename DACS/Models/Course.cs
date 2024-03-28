using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DACS.Models
{
    public class Course
    {
        public int ID { get; set; }

        [StringLength(100)]
        public string Title { get; set; }

        [StringLength(50)]
        public string Author { get; set; }

        [StringLength(500)]
        public string Des { get; set; }

        public decimal Price { get; set; }

        [StringLength(250)]
        public string Image { get; set; }
        [ForeignKey("Category")]

        public int? CateID { get; set; }
        public virtual Category Category { get; set; }
    }
}