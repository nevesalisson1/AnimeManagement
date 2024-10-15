using System.ComponentModel.DataAnnotations;

namespace Application.Animes.ViewModel;

public record AnimeViewModel
{
    [Required] public int Id { get; set; }

    [Required] public string Name { get; set; }

    [Required] public string Summary { get; set; }

    [Required] public decimal Director { get; set; }
};