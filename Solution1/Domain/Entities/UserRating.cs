namespace Domain.Entities
{
    //описание полей сущности Rating(столбцы таблицы Rating)
    public class UserRating
    {
        public int Id { get; set; }

        public string UserName { get; set; } = default!;

        public int Rating { get; set; } = default!;
    }
}
