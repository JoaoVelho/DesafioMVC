using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DesafioMVC.Validation;
using Microsoft.AspNetCore.Http;

namespace DesafioMVC.DTO
{
    public class PropertyEditDTO
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage="Categoria é obrigatória!")]
        [Range(1, Int32.MaxValue, ErrorMessage="Categoria é obrigatória!")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage="Negócio é obrigatório!")]
        [Range(1, Int32.MaxValue, ErrorMessage="Negócio é obrigatório!")]
        public int BusinessId { get; set; }

        [Required(ErrorMessage="UF é obrigatório!")]
        [Range(1, Int32.MaxValue, ErrorMessage="UF é obrigatório!")]
        public int StateId { get; set; }

        [Required(ErrorMessage="Município é obrigatório!")]
        [Range(1, Int32.MaxValue, ErrorMessage="Município é obrigatório!")]
        public int CityId { get; set; }

        [Required(ErrorMessage="Bairro é obrigatório!")]
        [Range(1, Int32.MaxValue, ErrorMessage="Bairro é obrigatório!")]
        public int DistrictId { get; set; }

        [Required(ErrorMessage="Endereço é obrigatório!")]
        [StringLength(200, ErrorMessage="Endereço muito grande!")]
        [MinLength(2, ErrorMessage="Endereço muito pequeno!")]
        public string Address { get; set; }

        [Required(ErrorMessage="Número de quartos é obrigatório!")]
        [Range(0, 100, ErrorMessage="Número de quartos deve ser entre {1} e {2}!")]
        public int? Rooms { get; set; }

        [AllowedExtensions(new string[] { ".jpg", ".jpeg", ".png" })]
        public List<IFormFile> Images { get; set; }
    }
}