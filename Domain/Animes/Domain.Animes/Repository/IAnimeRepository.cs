using Domain.Animes.Models;

namespace Domain.Animes.Repository;

public interface IAnimeRepository
{
    public Task<Anime?> GetAnimeAsync(int id);
    public Task<List<Anime>> GetAnimeListAsync();
    public Task<int> CreateAnimeAsync(Anime anime);
}