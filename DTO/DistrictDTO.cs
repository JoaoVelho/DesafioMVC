using System;
using System.ComponentModel.DataAnnotations;

namespace DesafioMVC.DTO
{
    public class DistrictDTO
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage="Nome do bairro é obrigatório!")]
        [StringLength(100, ErrorMessage="Nome do bairro muito grande!")]
        [MinLength(2, ErrorMessage="Nome do bairro muito pequeno!")]
        public string Name { get; set; }

        [Required(ErrorMessage="Cidade é obrigatória!")]
        [Range(1, Int32.MaxValue, ErrorMessage="Cidade é obrigatória!")]
        public int CityId { get; set; }
    }
}