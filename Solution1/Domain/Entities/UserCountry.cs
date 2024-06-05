namespace Domain.Entities
{
    //описание полей сущности Country(столбцы таблицы Country)
    public class UserCountry
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Country { get; set; } = default!;

    }
}
