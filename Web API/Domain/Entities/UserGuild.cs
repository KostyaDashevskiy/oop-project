using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    //описание полей сущности Guild(столбцы таблицы Guilds)
    public class UserGuild
    {
        [Key]
        public Guid GuildId {  get; set; }
        public string GuildName { get; set; } = default!;
        public List<string> Members { get; set; } = default!;
        public string GuildAdmin { get; set; } = default!;
        public int GuildRatirng { get; set; } = default!;
        public int MembersCount { get; set; } = default!;
        public string GuildDescription { get; set; } = default!;
    }
}
