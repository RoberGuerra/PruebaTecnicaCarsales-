#nullable disable

namespace PruebaTecnicaCarsales.Models
{
    public class LocationDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Dimension { get; set; }
        public List<string> Residents { get; set; }
        public string Url { get; set; }
        public DateTime Created { get; set; }
    }
}