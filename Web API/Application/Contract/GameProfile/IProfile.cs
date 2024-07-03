using Application.DTOs.GameProfile.Profile.EntryGuild;
using Application.DTOs.GameProfile.Profile.GetProfile;
using Application.DTOs.GameProfile.Profile.IsAdminOfGuild;
using Application.DTOs.GameProfile.Profile.QuitGuild;

namespace Application.Contract.GameProfile
{
    //шаблон класса, здесь определяются какие методы будет реализовать данный класс, какие запросы обрабатывать
    public interface IProfile
    {
        Task<ProfileResponse> GetProfile(ProfileDTO profileDTO);
        Task<EntryGuildResponse> EntryGuild(EntryGuildDTO entryGuildDTO);
        Task<QuitGuildResponse> QuitGuild(QuitGuildDTO quitGuildDTO);
        Task<IsAdminOfGuildResponse> IsAdminOfGuild(IsAdminOfGuildDTO isAdminOfGuild);
    }
}
