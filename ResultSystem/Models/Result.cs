using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResultSystem.Models
{
    public class Result
    {
        [Key]
        public int Id { get; set; }
        
        [ForeignKey("Roll")]
        [Column(TypeName = "number")]

        public int Roll { get; set;  }
        
        [Required]
        [Column(TypeName = "number")]

        public int Semester { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(10)")]

        public string CourseCode { get; set;  }

        [Required]
        public double Mid { get; set; }

        [Required]
        [Column(TypeName = "number")]

        public double Quiz { get; set; }

        [Required]
        [Column(TypeName = "number")]
        public double Lab { get; set; }

        [Required]
        [Column(TypeName = "number")]
        public double Final { get; set; }

        //[Required]
        [Column(TypeName = "number")]
        public double CourseResult { get; set; }



    }
}
