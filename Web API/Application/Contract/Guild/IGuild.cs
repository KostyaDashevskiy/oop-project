using Application.DTOs.Guild.DeleteGuild;
using Application.DTOs.Guild.DeleteMember;
using Application.DTOs.Guild.EditDescription;
using Application.DTOs.Guild.GetGuild;
using Application.DTOs.Guild.RegisterGuild;

namespace Application.Contract.Guild
{
    //шаблон класса, здесь определяются какие методы будет реализовать данный класс, какие запросы обрабатывать
    public interface IGuild
    {
        Task<RegistrationGuildResponse> RegisterGuildAsync(RegistrationGuildDTO registerGuildDTO);
        Task<DeleteGuildResponse> DeleteGuildAsync(DeleteGuildDTO deleteGuildDTO);
        Task<EditGuildDescriptionResponse> EditGuildDescriptionAsync(EditGuildDescriptionDTO editGuildDescriptionDTO);
        Task<DeleteGuildMemberResponse> DeleteGuildMember(DeleteGuildMemberDTO manageGuildMembersDTO);
        Task<GetGuildResponse> GetGuild(GetGuildDTO getGuildDTO);
    }
}
