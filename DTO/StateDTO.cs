using System.ComponentModel.DataAnnotations;

namespace DesafioMVC.DTO
{
    public class StateDTO
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Uf { get; set; }

        [Required(ErrorMessage="Nome do estado é obrigatório!")]
        [StringLength(100, ErrorMessage="Nome do estado muito grande!")]
        [MinLength(2, ErrorMessage="Nome do estado muito pequeno!")]
        public string Name { get; set; }
    }
}