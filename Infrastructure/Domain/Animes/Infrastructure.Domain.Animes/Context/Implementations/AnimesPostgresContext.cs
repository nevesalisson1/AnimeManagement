using Domain.Animes.Models;
using Infrastructure.Domain.Animes.Context.Interfaces;
using Infrastructure.Domain.Animes.Mapping.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Domain.Animes.Context.Implementations
{
    public class AnimesPostgresContext : DbContext, IAnimesContext
    {
        private readonly IAnimeMapping _animeMapping;
        private readonly IConfiguration _configuration;

        public AnimesPostgresContext(IConfiguration configuration, IAnimeMapping animeMapping)
        {
            _configuration = configuration;
            _animeMapping = animeMapping;
        }

        public DbSet<Anime> Animes { get; set; }

        public new async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("PostgresConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(_animeMapping);
        }
    }
}