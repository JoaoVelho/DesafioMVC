namespace DesafioMVC.Models
{
    public class District
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public City City { get; set; }
        public bool Deleted { get; set; }
    }
}