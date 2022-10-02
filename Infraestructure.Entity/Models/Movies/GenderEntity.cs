using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Infraestructure.Entity.Models.Movies
{

    [Table("Gender", Schema = "Movies")]
    public class GenderEntity
    { 
        [Key]
        public int IdGender { get; set; }
        [MaxLength(100)]
        public string Gender { get; set; }
    }
}
