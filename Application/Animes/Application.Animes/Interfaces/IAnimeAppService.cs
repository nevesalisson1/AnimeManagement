using Application.Animes.ViewModel;

namespace Application.Localidade.AutoMapper;

public interface IAnimeAppService
{
    Task<int> CreateAnime(CreateAnimeViewModel createAnimeViewModel);
    Task<AnimeViewModel> GetAnime(int id);
    Task<List<AnimeViewModel>> GetAnimeList();
}