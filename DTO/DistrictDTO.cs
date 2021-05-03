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

        [Required(ErrorMessage="Município é obrigatório!")]
        [Range(1, Int32.MaxValue, ErrorMessage="Município é obrigatório!")]
        public int CityId { get; set; }

        [Required(ErrorMessage="UF é obrigatório!")]
        [Range(1, Int32.MaxValue, ErrorMessage="UF é obrigatório!")]
        public int StateId { get; set; }
    }
}