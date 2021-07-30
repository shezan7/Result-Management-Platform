using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResultSystem
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "number")]
        public int Roll { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string Password { get; set; }

        [Required]
        [Column(TypeName = "number")]
        public int Batch { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(30)")]
        public string Mail { get; set; }

        //[Required]
        [Column(TypeName = "number")]
        public double Result { get; set; }


        /*
         [Column(TypeName = "BOOLEAN")]
         public bool UserType { get; set; } //0 for student, 1 for admin 
        */


    }
}
