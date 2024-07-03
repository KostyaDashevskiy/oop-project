namespace Domain.Entities
{
    //описание полей сущности Twitch(столбцы таблицы Twitch)
    public class UserTwitch
    {
        public Guid Id { get; set; }
        public string UserName { get; set; } = default!;
        public string Link { get; set; } = default!;
    }
}
