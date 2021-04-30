namespace DesafioMVC.DTO
{
    public class SearchDataDTO
    {
        public int CategoryId { get; set; }
        public int BusinessId { get; set; }
        public int StateId { get; set; }
        public int CityId { get; set; }
        public int DistrictId { get; set; }
        public int? Rooms { get; set; }
    }
}