using Application.Animes.ViewModel;
using Application.Localidade.AutoMapper;
using AutoMapper;
using Domain.Animes.Models;
using Domain.Animes.Repository;

namespace Application.Animes.AppServices;

public class AnimeAppService : IAnimeAppService
{
    private readonly IAnimeRepository _animeRepository;
    private readonly IMapper _mapper;

    public AnimeAppService(IAnimeRepository animeRepository, IMapper mapper)
    {
        _animeRepository = animeRepository;
        _mapper = mapper;
    }

    public async Task<int> CreateAnime(CreateAnimeViewModel createAnimeViewModel)
    {
        var anime = _mapper.Map<Anime>(createAnimeViewModel);
        return await _animeRepository.CreateAnimeAsync(anime);
    }

    public async Task<AnimeViewModel> GetAnime(int id)
    {
        var animeList = await _animeRepository.GetAnimeAsync(id);
        return _mapper.Map<AnimeViewModel>(animeList);
    }

    public async Task<List<AnimeViewModel>> GetAnimeList()
    {
        var animeList = await _animeRepository.GetAnimeListAsync();
        return _mapper.Map<List<AnimeViewModel>>(animeList);
    }
}