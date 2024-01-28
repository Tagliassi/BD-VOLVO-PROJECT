using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BD_VOLVO
{
    public class Filial
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdFilial { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }

        [Required]
        [MaxLength(11)]
        public string CEPFilial { get; set; }

        [Required]
        [MaxLength(100)]
        public string RuaFilial { get; set; }

        [Required]
        public int QuantidadeEstrelas { get; set; }

        [Required]
        public int NumeroQuartos { get; set; }
    }
}