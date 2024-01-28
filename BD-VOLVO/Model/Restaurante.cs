using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BD_VOLVO
{
    public class Restaurante
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdRestaurante { get; set; }

        public int fkRestauranteIdFilial { get; set; }

        [MaxLength(20)]
        public string LocalConsumo { get; set; }

        [Required]
        [MaxLength(100)]
        public string Descricao { get; set; }

        [Required]
        public float Valor { get; set; }

        [ForeignKey("fkRestauranteIdFilial")]
        public Filial Filial { get; set; }
    }
}