using Application.Animes.ViewModel;
using Application.Localidade.AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Service.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AnimeController : ControllerBase
{
    private readonly IAnimeAppService _animeAppService;

    public AnimeController(IAnimeAppService animeAppService)
    {
        _animeAppService = animeAppService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAnime([FromBody] CreateAnimeViewModel createAnimeViewModel)
    {
        var animeId = await _animeAppService.CreateAnime(createAnimeViewModel);
        return CreatedAtAction(nameof(GetAnime), new { id = animeId }, animeId);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAnime(int id)
    {
        var anime = await _animeAppService.GetAnime(id);
        if (anime == null)
        {
            return NotFound();
        }

        return Ok(anime);
    }

    [HttpGet]
    public async Task<IActionResult> GetAnimeList()
    {
        var animeList = await _animeAppService.GetAnimeList();
        if (!animeList.Any())
        {
            return NotFound();
        }

        return Ok(animeList);
    }
}