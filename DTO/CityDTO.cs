using System.ComponentModel.DataAnnotations;

namespace DesafioMVC.DTO
{
    public class CityDTO
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage="Nome do município é obrigatório!")]
        [StringLength(100, ErrorMessage="Nome do município muito grande!")]
        [MinLength(2, ErrorMessage="Nome do município muito pequeno!")]
        public string Name { get; set; }

        [Required(ErrorMessage="Estado é obrigatório!")]
        public string StateUf { get; set; }
    }
}