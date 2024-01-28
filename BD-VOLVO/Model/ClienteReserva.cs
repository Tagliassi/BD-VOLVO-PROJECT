using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BD_VOLVO
{
    public class ClienteReserva
    {
        [Key]
        public int FkIdCliente { get; set; }

        [Key]
        public int FkIdConta { get; set; }

        [Key]
        public int fkReservaIdReserva { get; set; }

        [ForeignKey("FkIdCliente, FkIdConta")]
        public ClienteConta ClienteConta { get; set; }

        [ForeignKey("fkReservaIdReserva")]
        public Reserva Reserva { get; set; }
    }
}