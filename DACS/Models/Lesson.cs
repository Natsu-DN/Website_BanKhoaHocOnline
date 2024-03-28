using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DACS.Models
{
    public class Lesson
    {
        [Key]
        public int LessonID { get; set; }

        [StringLength(100)]
        public string LessonName { get; set; }

        [StringLength(maximumLength: 1000)]
        public string Description { get; set; }

        [ForeignKey("Course")]

        public int? CourseID { get; set; }

        public virtual Course Course { get; set; }

    }
}