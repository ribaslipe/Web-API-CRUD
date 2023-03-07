using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Srv.Crud.Repository.Models
{
    [Table("LOGIN")]
    public class Login
    {

        [Key]
        [Column("COD_LOGIN")]
        public int CodLogin { get; set; }

        [Column("USUARIO")]
        [Required]
        public string Usuario { get; set; }

        [Column("SENHA")]
        [Required]
        public string Senha { get; set; }
    }
}
