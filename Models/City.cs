namespace DesafioMVC.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public State State { get; set; }
        public bool Deleted { get; set; }
    }
}