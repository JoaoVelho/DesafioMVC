using System.ComponentModel.DataAnnotations;

namespace DesafioMVC.DTO
{
    public class CategoryDTO
    {
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage="Nome da categoria é obrigatório!")]
        [StringLength(100, ErrorMessage="Nome de categoria muito grande!")]
        [MinLength(2, ErrorMessage="Nome de categoria muito pequeno!")]
        public string Name { get; set; }
    }
}