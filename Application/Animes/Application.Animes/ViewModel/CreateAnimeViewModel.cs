using System.ComponentModel.DataAnnotations;

namespace Application.Animes.ViewModel;

public record CreateAnimeViewModel
{
    [Required] public string Name { get; set; }

    [Required] public string Summary { get; set; }

    public string Director { get; set; }
};