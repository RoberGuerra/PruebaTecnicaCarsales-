#nullable disable

namespace PruebaTecnicaCarsales.Models
{
    public class LocationResponse
    {
        public InfoDto Info { get; set; }
        public List<LocationDto> Results { get; set; }
    }
}