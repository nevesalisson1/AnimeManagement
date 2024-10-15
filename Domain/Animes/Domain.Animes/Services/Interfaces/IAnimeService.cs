using Domain.Animes.Models;

namespace Domain.Animes.Services.Interfaces;

public interface IAnimeService
{
    public decimal CalculatePaymentSlip(Anime paymentSlip);
}