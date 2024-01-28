using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BD_VOLVO
{
    public class TipoQuarto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdTipoQuarto { get; set; }
        [Required]
        [MaxLength(20)]
        public string Descricao { get; set; }
        //Required?
        public int Capacidade { get; set; }
        public bool CapacidadeOpcional { get; set; }
    }
}