namespace Domain.Entities
{
    //описание полей сущности Info(столбцы таблицы Info)
    public class UserInfo
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string Country { get; set; } = default!;
        public string Link { get; set; } = default!;
        public int? Age { get; set; } = default!;
        public string About { get; set; } = default!;
    }
}
