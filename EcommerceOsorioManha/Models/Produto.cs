using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EcommerceOsorioManha.Models
{
    [Table("Produtos")]
    public class Produto
    {
        [Key]
        public int ProdutoId { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório")]
        [MaxLength(50, ErrorMessage = "deve ter no máximo 50 caracteres")]
        [Display(Name = "Nome do Produto")]
        public string Nome { get; set; }

        [MaxLength(100, ErrorMessage = "deve ter no máximo 50 caracteres")]
        [Display(Name = "Desc. do Produto")]
        [DataType(DataType.MultilineText)]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório")]
        [Display(Name = "Preço do Produto R$")]
        public double Preco { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório")]
        [Display(Name = "Categ. do Produto")]
        public Categoria Categoria { get; set; }

        public string Imagem { get; set; }
    }
}