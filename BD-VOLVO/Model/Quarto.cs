using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BD_VOLVO
{
    public class Quarto
    {   
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdQuarto { get; set; }

        [Required]
        public int fkReservaIdReserva { get; set; }

        [Required]
        public int fkTipoQuarto { get; set; } 

        [Required]
        public int? fkIdFilial { get; set; } 

        [Required]
        public bool SituacaoQuarto { get; set; }

        [ForeignKey("fkReservaIdReserva")]
        public Reserva Reserva { get; set; }

        [ForeignKey("fkTipoQuarto")]
        public TipoQuarto TipoQuarto { get; set; }

        [ForeignKey("fkIdFilial")]
        public Filial Filial { get; set; }
    }
}