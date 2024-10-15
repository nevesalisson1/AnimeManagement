using Domain.Animes.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Domain.Animes.Mapping.Interfaces;

public interface IAnimeMapping : IEntityTypeConfiguration<Anime>
{
}