using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Infraestructure.Entity.Models.Security
{
    [Table("User", Schema = "Security")]
    public class UserEntity
    {
        [Key]
        public int IdUSer { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "El apellido es requerido")]
        [MaxLength(100)]
        public string LastName { get; set; }

        [MaxLength(200)]
        [Required(ErrorMessage = "El email es requerido")]
        //[DataType(DataType.EmailAddress, ErrorMessage = "E-mail no es válido")]
        [EmailAddress(ErrorMessage = "E-mail no es válido")]
        public string Email { get; set; }

        [Required(ErrorMessage ="La contraseña es requerida")]
        [MaxLength(200)]
        public string Password { get; set; }

        public IEnumerable<RolUserEntity> RolUserEntities { get; set; }
    }
}
