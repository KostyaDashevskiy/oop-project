namespace Domain.Entities
{
    //описание полей сущности AboutUsers(столбцы таблицы AboutUsers)
    public class AboutUser
    {
        public Guid Id { get; set; }
        public string UserName { get; set; } = default!;
        public string About { get; set; } = default!;
    }
}
