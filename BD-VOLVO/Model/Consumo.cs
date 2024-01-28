using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BD_VOLVO
{
    public class Consumo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdConsumo { get; set; }

        public int? fkFrigobar { get; set; }

        public int? fkRestaurante { get; set; }

        public int? fkServico { get; set; }

        public int fkClienteContaIdCliente { get; set; }
        
        public int fkClienteContaIdConta { get; set; }  

        [ForeignKey("fkFrigobar")]
        public Frigobar Frigobar { get; set; }

        [ForeignKey("fkRestaurante")]
        public Restaurante Restaurante { get; set; }

        [ForeignKey("fkServico")]
        public Servicos Servico { get; set; }

        [ForeignKey("fkClienteContaIdCliente, fkClienteContaIdConta")]  
        public ClienteConta ClienteConta { get; set; }
    }
}
