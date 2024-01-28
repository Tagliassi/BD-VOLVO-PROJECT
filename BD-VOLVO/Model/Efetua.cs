using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BD_VOLVO
{
    public class Efetua
    {
        [Key]
        public int fkClienteContaIdCliente { get; set; }

        [Key]
        public int fkClienteContaIdConta { get; set; }

        [Key]
        public int fkPagamentoIdPagamento { get; set; }

        public DateTime DataPagamento { get; set; }

        [ForeignKey("fkClienteContaIdCliente, fkClienteContaIdConta")]
        public ClienteConta ClienteConta { get; set; }

        [ForeignKey("fkPagamentoIdPagamento")]
        public Pagamento Pagamento { get; set; }
    }
}