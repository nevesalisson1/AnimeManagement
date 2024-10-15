using Domain.Animes.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Domain.Animes.Context.Interfaces
{
    public interface IAnimesContext
    {
        DbSet<Anime> Animes { get; set; }

        Task<int> SaveChangesAsync();
    }
}