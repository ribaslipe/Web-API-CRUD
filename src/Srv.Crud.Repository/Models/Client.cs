using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Srv.Crud.Repository.Models
{
    [Table("CLIENTE")]
    public class Client
    {
        [Key]
        [Required]
        [Column("COD_CLIENTE")]
        public int CodCliente { get; set; }

        [Required]
        [Column("NOME")]
        public string Nome { get; set; }

        [Required]
        [Column("ENDERECO")]
        public string Endereco { get; set; }

        [Required]
        [Column("CIDADE")]
        public string Cidade { get; set; }

        [Required]
        [Column("UF")]
        public string Uf { get; set; }

        [Required]
        [Column("DATA_INSERCAO")]
        public string DataInsercao { get; set; }
    }
}
