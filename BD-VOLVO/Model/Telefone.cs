using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BD_VOLVO
{
    public class Telefone
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdTelefone { get; set; }

        public int fkClienteContaIdCliente { get; set; }
        
        public int fkClienteContaIdConta { get; set; }  

        [Required]
        [MaxLength(20)]
        public string TipoTelefone { get; set; }

        [Required]
        [MaxLength(11)]
        public string NumeroTelefone { get; set; }

        [ForeignKey("fkClienteContaIdCliente, fkClienteContaIdConta")]  
        public ClienteConta ClienteConta { get; set; }
    }
}
