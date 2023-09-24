using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestePratico.Models
{
    public class Movimentacao
    {
        [Key]
        public int Id { get; set; }
        public TipoMovimentacaoEnum Tipo { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fim { get; set; }

        [ForeignKey("Conteiner")]
        public int ConteinerId { get; set; }
        public Conteiner? Conteiner { get; set; }
    }
}
