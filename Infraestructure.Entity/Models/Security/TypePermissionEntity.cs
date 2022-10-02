using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Infraestructure.Entity.Models.Security
{
    [Table("TypePermission", Schema = "Security")]

    public class TypePermissionEntity
    {
        [Key]
        public int IdTypePermission { get; set; }
        public string TypePermission { get; set; }
        public IEnumerable<PermissionEntity> PermissionEntities { get; set; }

    }
}
