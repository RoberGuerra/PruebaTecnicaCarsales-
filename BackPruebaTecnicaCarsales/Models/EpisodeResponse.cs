#nullable disable

namespace PruebaTecnicaCarsales.Models
{
    public class EpisodeResponse
    {
        public InfoDto Info { get; set; }
        public List<EpisodeDto> Results { get; set; }
    }
}