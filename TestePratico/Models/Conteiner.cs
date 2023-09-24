using System.ComponentModel.DataAnnotations;

namespace TestePratico.Models
{
    public class Conteiner
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Cliente { get; set; }
        [Required]
        [StringLength(11)]
        [RegularExpression("[A-Za-z]{4}[0-9]{7}")]
        public string Numero { get; set; }
        public TipoConteinerEnum Tipo { get; set; }
        public StatusConteinerEnum Status { get; set; }
        public CategoriaConteinerEnum Categoria { get; set; }
    }
}
