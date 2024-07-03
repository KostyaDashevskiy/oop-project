namespace Domain.Entities
{
    //описание полей сущности Ages(столбцы таблицы Ages)
    public class UserAge
    {
        public Guid Id { get; set; }
        public string UserName { get; set; } = default!;
        public int? Age { get; set; } = default!;
    }
}
