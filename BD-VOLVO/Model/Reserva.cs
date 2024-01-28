using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BD_VOLVO
{
    public class Reserva
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdReserva { get; set; }

        public int fkFuncionarioIdFuncionario { get; set; }
        
        public int fkTipoQuarto { get; set; }

        [Required]
        public DateTime DTCheckOut { get; set; }

        [Required]
        public DateTime DTCheckIn { get; set; }

        [Required]
        [MaxLength(20)]
        public string EstadoReserva { get; set; }

        public DateTime? DataCancelamento { get; set; }

        public float CobrancaDiaria { get; set; }

        [ForeignKey("fkFuncionarioIdFuncionario")]
        public Funcionario Funcionario { get; set; }

        [ForeignKey("fkTipoQuarto")]
        public TipoQuarto TipoQuarto { get; set; }
    }
}