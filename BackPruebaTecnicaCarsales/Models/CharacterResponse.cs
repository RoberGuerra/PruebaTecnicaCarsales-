#nullable disable

namespace PruebaTecnicaCarsales.Models
{
	public class CharacterResponse
	{
		public InfoDto Info { get; set; }
		public List<CharacterDto> Results { get; set; }
	}
}