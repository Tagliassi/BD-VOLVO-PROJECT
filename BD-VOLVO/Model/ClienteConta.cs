using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BD_VOLVO
{
    public class ClienteConta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCliente { get; set; }

        [Key]
        public int IdConta { get; set; }

        [Required]
        [MaxLength(100)]
        public string NomeCliente { get; set; }

        [Required]
        [MaxLength(11)]
        public string CEPCliente { get; set; }

        [Required]
        [MaxLength(100)]
        public string RuaCliente { get; set; }

        public string EmailCliente { get; set; }

        [Required]
        [MaxLength(40)]
        public string NacionalidadeCliente { get; set; }

    }
}