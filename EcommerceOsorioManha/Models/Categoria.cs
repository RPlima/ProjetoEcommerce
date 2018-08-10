using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceOsorioManha.Models
{
    [Table("Categorias")]
    public class Categoria
    {
        [Key]
        public int CategoriaId { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório")]
        [Display(Name = "Nome da Categoria")]
        public string NomeCateg { get; set; }

        [MaxLength(100, ErrorMessage = "deve ter no máximo 50 caracteres")]
        [Display(Name = "Desc. da Categoria")]
        [DataType(DataType.MultilineText)]
        public string DescCategoria { get; set; }
    }
}