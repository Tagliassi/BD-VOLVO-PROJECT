using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BD_VOLVO
{
    public class Frigobar
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdFrigobar { get; set; }

        public int fkFrigobarIdFilial { get; set; }

        [Required]
        [MaxLength(100)]
        public string Descricao { get; set; }

        [Required]
        public float Valor { get; set; }

        [ForeignKey("fkFrigobarIdFilial")]
        public Filial Filial { get; set; }
    }
}