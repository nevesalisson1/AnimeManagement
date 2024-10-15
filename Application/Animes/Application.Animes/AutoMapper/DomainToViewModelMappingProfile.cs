using Application.Animes.ViewModel;
using AutoMapper;
using Domain.Animes.Models;

namespace Application.Animes.AutoMapper;

public class DomainToViewModelMappingProfile : Profile
{
    public DomainToViewModelMappingProfile()
    {
        CreateMap<Anime, AnimeViewModel>();
    }
}