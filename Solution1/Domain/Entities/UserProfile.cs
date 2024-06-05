namespace Domain.Entities
{
    //описание полей сущности Profile(столбцы таблицы Profile)
    public class UserProfile
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Rating { get; set; } = default!;
        public string Wins { get; set; } = default!;
    }
}
