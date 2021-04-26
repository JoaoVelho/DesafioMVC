using System.ComponentModel.DataAnnotations;

namespace DesafioMVC.DTO
{
    public class BusinessDTO
    {
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage="Nome de negócio é obrigatório!")]
        [StringLength(100, ErrorMessage="Nome de negócio muito grande!")]
        [MinLength(2, ErrorMessage="Nome de negócio muito pequeno!")]
        public string Name { get; set; }
    }
}