namespace Domain.Entities
{
    //описание полей сущности Users(столбцы таблицы Users)
    public class ApplicationUser
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;

    }
}
