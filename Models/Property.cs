using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioMVC.Models
{
    public class Property
    {
        public int Id { get; set; }

        public int? CategoryId { get; set; }
        public Category Category { get; set; }

        public int? BusinessId { get; set; }
        public Business Business { get; set; }

        public int? DistrictId { get; set; }
        public District District { get; set; }
        
        public string Address { get; set; }
        public int Rooms { get; set; }

        private static readonly char delimiter = ';';
        private string _images;

        [NotMapped]
        public string[] Images {
            get { return _images.Split(delimiter); } 
            set {
                _images = string.Join($"{delimiter}", value);
            }
        }
    }
}