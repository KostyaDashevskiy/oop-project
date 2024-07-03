namespace Application.DTOs.GameProfile.Rating
{
    //класс определяет какие поля мы передаем в ответе на "РЕЙТИНГ"
    public record RatingResponse(int Code, string Message, string Rating);
}
