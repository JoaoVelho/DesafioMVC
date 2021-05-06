using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace DesafioMVC.Validation
{
    public class AllowedExtensionsAttribute : ValidationAttribute
    {
        private readonly string[] _extensions;

        public AllowedExtensionsAttribute(string[] extensions)
        {
            _extensions = extensions;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var files = value as List<IFormFile>;
            if (files != null) {
                foreach (var file in files)
                {
                    var extension = Path.GetExtension(file.FileName);
                    if (file != null)
                    {
                        if (!_extensions.Contains(extension.ToLower()))
                        {
                            return new ValidationResult(GetErrorMessage());
                        }
                    }
                }
            }
            return ValidationResult.Success;
        }

        public string GetErrorMessage()
        {
            return $"Tipo de imagem não válido!";
        }
    }
}