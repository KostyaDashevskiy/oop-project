namespace Domain.Entities
{
    //описание полей сущности Info(столбцы таблицы Info)
    public class UserInfo
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Country { get; set; } = default!;
        public string Link { get; set; } = default!;
    }
}
