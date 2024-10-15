using Domain.Animes.Models;
using Domain.Animes.Repository;
using Infrastructure.Domain.Animes.Context.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Domain.Animes.Repository;

public class AnimeRepository : IAnimeRepository
{
    private readonly IAnimesContext _context;

    public AnimeRepository(IAnimesContext context)
    {
        _context = context;
    }

    public async Task<Anime?> GetAnimeAsync(int id)
    {
        return await _context.Animes.FindAsync(id);
    }

    public async Task<List<Anime>> GetAnimeListAsync()
    {
        return await _context.Animes.ToListAsync();
    }

    public async Task<int> CreateAnimeAsync(Anime anime)
    {
        _context.Animes.Add(anime);
        await _context.SaveChangesAsync();
        return anime.Id;
    }
}