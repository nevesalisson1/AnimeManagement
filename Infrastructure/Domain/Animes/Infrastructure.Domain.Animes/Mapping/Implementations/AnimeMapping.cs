using Domain.Animes.Models;
using Infrastructure.Domain.Animes.Mapping.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Domain.Animes.Mapping.Implementations;

public class AnimeMapping : IAnimeMapping
{
    public void Configure(EntityTypeBuilder<Anime> builder)
    {
        builder.ToTable("anime");

        builder.Property(b => b.Id).HasColumnName("id");
        builder.Property(b => b.Summary).HasColumnName("summary");
        builder.Property(b => b.Name).HasColumnName("name");
        builder.Property(b => b.Director).HasColumnName("director");
    }
}