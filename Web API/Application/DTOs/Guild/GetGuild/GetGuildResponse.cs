using Domain.Entities;

namespace Application.DTOs.Guild.GetGuild
{
    //класс определяет какие поля мы передаем в ответе на "ПОЛУЧЕНИЕ ГИЛЬДИИ"
    public record GetGuildResponse(int Code, string Message, string GuildName, 
        int CountOfMembers, int TotalRating, string LeaderName, List<string> Members);
}
