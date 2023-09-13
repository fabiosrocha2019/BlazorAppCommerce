using System.ComponentModel.DataAnnotations;

namespace BlazorAppCommerce.Models
{
    public class Produto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [StringLength(255, ErrorMessage = "O campo Nome deve ter no máximo 255 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo Valor é obrigatório.")]
        [Range(0, double.MaxValue, ErrorMessage = "O campo Valor deve ser um número positivo.")]
        public double Valor { get; set; }

        [Required(ErrorMessage = "O campo Estoque é obrigatório.")]
        public int Estoque { get; set; }
    }
}
