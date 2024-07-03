using Application.DTOs.GameProfile.Rating;

namespace Application.Contract.GameProfile
{
    //перечисление того, что мы можем сделать с рейтингом
    public enum RatigStatus
    {
        Victory,
        Defeat,
        Draw,
        Show
    }

    //шаблон класса, здесь определяются какие методы будет реализовать данный класс, какие запросы обрабатывать
    public interface IRating
    {
        Task<RatingResponse> ManipulateMMR(RatingDTO ratingDTO);
    }
}
