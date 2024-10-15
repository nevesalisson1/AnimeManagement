using Application.Animes.ViewModel;
using AutoMapper;
using Domain.Animes.Models;

namespace Application.Animes.AutoMapper;

public class ViewModelToDomainMappingProfile : Profile
{
    public ViewModelToDomainMappingProfile()
    {
        CreateMap<CreateAnimeViewModel, Anime>();
    }
}