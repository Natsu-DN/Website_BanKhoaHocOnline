using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DACS.Models
{
    public class Category
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string Title { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}