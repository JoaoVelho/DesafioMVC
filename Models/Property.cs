namespace DesafioMVC.Models
{
    public class Property
    {
        public int Id { get; set; }
        public Category Category { get; set; }
        public Business Business { get; set; }
        public District District { get; set; }
        public string Address { get; set; }
        public int Rooms { get; set; }
        public bool Deleted { get; set; }
    }
}