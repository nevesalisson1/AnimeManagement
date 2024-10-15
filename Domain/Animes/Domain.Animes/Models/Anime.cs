using System.ComponentModel.DataAnnotations;

namespace Domain.Animes.Models;

public class Anime
{
    [Required] public int Id { get; set; }

    [Required] public string Name { get; set; }

    [Required] public string Summary { get; set; }

    [Required] public string Director { get; set; }
}