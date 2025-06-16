using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaCarsales.Services;
using PruebaTecnicaCarsales.Models;

namespace PruebaTecnicaCarsales.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RickAndMortyController : ControllerBase
    {
        private readonly RickAndMortyService _rickAndMortyService;

        public RickAndMortyController(RickAndMortyService rickAndMortyService)
        {
            _rickAndMortyService = rickAndMortyService;
        }

        [HttpGet("episodes")]
        public async Task<IActionResult> GetEpisodes([FromQuery] int page = 1)
        {
            try
            {
                var episodes = await _rickAndMortyService.GetEpisodesAsync(page);
                return Ok(episodes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        [HttpGet("characters")]
        public async Task<IActionResult> GetCharacters([FromQuery] int page = 1)
        {
            try
            {
                var characters = await _rickAndMortyService.GetCharactersAsync(page);
                return Ok(characters);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        [HttpGet("charactersIds")]
        public async Task<IActionResult> GetCharacterByIds([FromQuery] string ids)
        {
            if (string.IsNullOrWhiteSpace(ids))
                return BadRequest("Must send at least one id, e.g.: ?ids=1,2,3");

            try
            {
                var idList = ids
                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(s => int.TryParse(s, out var i) ? i : (int?)null)
                    .Where(i => i.HasValue)
                    .Select(i => i.Value)
                    .ToList();

                if (!idList.Any())
                    return BadRequest("Invalid format.");

                var characters = await _rickAndMortyService.GetCharactersByIdsAsync(idList);
                return Ok(characters);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        [HttpGet("locations")]
        public async Task<IActionResult> GetLocations([FromQuery] int page = 1)
        {
            try
            {
                var locations = await _rickAndMortyService.GetLocationsAsync(page);
                return Ok(locations);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }
    }
}
