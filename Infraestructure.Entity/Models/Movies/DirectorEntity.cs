using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Infraestructure.Entity.Models.Movies
{
    [Table("Director", Schema = "Movies")]
    public class DirectorEntity
    {
      
            [Key]
            public int IdDirector { get; set; }

            [MaxLength(100)] 
            public string Name { get; set; }
            [MaxLength(100)]
            public string LastName { get; set; }

            public IEnumerable<MoviesEntity> MoviesEntities { get; set; }
     
    }
}
