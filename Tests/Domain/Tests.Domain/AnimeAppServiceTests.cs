using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Animes.AppServices;
using Application.Animes.ViewModel;
using AutoMapper;
using Domain.Animes.Models;
using Domain.Animes.Repository;
using Moq;
using Xunit;

public class AnimeAppServiceTests
{
    private readonly AnimeAppService _animeAppService;
    private readonly Mock<IAnimeRepository> _animeRepositoryMock;
    private readonly Mock<IMapper> _mapperMock;

    public AnimeAppServiceTests()
    {
        _animeRepositoryMock = new Mock<IAnimeRepository>();
        _mapperMock = new Mock<IMapper>();
        _animeAppService = new AnimeAppService(_animeRepositoryMock.Object, _mapperMock.Object);
    }

    [Fact]
    public async Task CreateAnime_ShouldReturnExpectedResult()
    {
        // Arrange
        var createAnimeViewModel = new CreateAnimeViewModel();
        var anime = new Anime();
        _mapperMock.Setup(m => m.Map<Anime>(createAnimeViewModel)).Returns(anime);
        _animeRepositoryMock.Setup(r => r.CreateAnimeAsync(anime)).ReturnsAsync(1);

        // Act
        var result = await _animeAppService.CreateAnime(createAnimeViewModel);

        // Assert
        Assert.Equal(1, result);
    }

    [Fact]
    public async Task GetAnime_ShouldReturnExpectedResult()
    {
        // Arrange
        var id = 1;
        var anime = new Anime();
        var animeViewModel = new AnimeViewModel();
        _animeRepositoryMock.Setup(r => r.GetAnimeAsync(id)).ReturnsAsync(anime);
        _mapperMock.Setup(m => m.Map<AnimeViewModel>(anime)).Returns(animeViewModel);

        // Act
        var result = await _animeAppService.GetAnime(id);

        // Assert
        Assert.Equal(animeViewModel, result);
    }

    [Fact]
    public async Task GetAnimeList_ShouldReturnExpectedResult()
    {
        // Arrange
        var animeList = new List<Anime>();
        var animeViewModelList = new List<AnimeViewModel>();
        _animeRepositoryMock.Setup(r => r.GetAnimeListAsync()).ReturnsAsync(animeList);
        _mapperMock.Setup(m => m.Map<List<AnimeViewModel>>(animeList)).Returns(animeViewModelList);

        // Act
        var result = await _animeAppService.GetAnimeList();

        // Assert
        Assert.Equal(animeViewModelList, result);
    }
}