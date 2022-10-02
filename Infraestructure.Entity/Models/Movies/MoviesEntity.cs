using Infraestructure.Entity.Models.Master;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Infraestructure.Entity.Models.Movies
{
    [Table("Movies", Schema = "Movies")]
    public class MoviesEntity
    {
        [Key]
        public int IdMovie { get; set; }
        [MaxLength(100)]
        public string Title  { get; set; }
        [MaxLength(300)]
        public string Sipnosis { get; set; }
        [ForeignKey("DirectorEntity")]
        public int IdDirector { get; set; }

        public DirectorEntity DirectorEntity { get; set; }

        [ForeignKey("GenderEntity")]
        public int IdGender { get; set; }

        public GenderEntity GenderEntity { get; set; }
        [MaxLength(4)]
        public string Anio { get; set; }
        [MaxLength(100)]
        public string Pais { get; set; }
        [MaxLength(200)]
        public string ProtagonistMain { get; set; }
        [MaxLength(100)]
        public string Duration { get; set; }

        [ForeignKey("TypeStateEntity")]
        public int IdTypeState { get; set; }

        public TypeStateEntity TypeStateEntity { get; set; }

    }
}
