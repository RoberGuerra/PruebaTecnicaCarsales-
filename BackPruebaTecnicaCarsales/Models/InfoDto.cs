#nullable disable

namespace PruebaTecnicaCarsales.Models
{
    public class InfoDto
    {
        public int Count { get; set; }
        public int Pages { get; set; }
        public string Next { get; set; }
        public string Prev { get; set; }
    }
}