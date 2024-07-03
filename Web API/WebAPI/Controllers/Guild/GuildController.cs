using Application.Contract.Guild;
using Application.DTOs.Guild.DeleteGuild;
using Application.DTOs.Guild.DeleteMember;
using Application.DTOs.Guild.EditDescription;
using Application.DTOs.Guild.GetGuild;
using Application.DTOs.Guild.RegisterGuild;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.Guild
{
    [Route("api/[controller]")]
    [ApiController]

    public class GuildController : Controller
    {
        public readonly IGuild guild;

        public GuildController(IGuild guild)
        {
            this.guild = guild;
        }

        //запрос на создание гильдии
        [HttpPost("RegisterGuild")]
        public async Task<ActionResult<RegistrationGuildResponse>> CreateGuild(RegistrationGuildDTO registrationGuildDTO)
        {
            var result = await guild.RegisterGuildAsync(registrationGuildDTO);
            return Ok(result);
        }

        //запрос на удаление гильдии
        [HttpDelete("DeleteGuild")]
        public async Task<ActionResult<DeleteGuildResponse>> DeleteGuild(DeleteGuildDTO deleteGuildDTO)
        {
            var result = await guild.DeleteGuildAsync(deleteGuildDTO);
            return Ok(result);
        }

        //запрос на изменение описания
        [HttpPatch("EditDescription")]
        public async Task<ActionResult<EditGuildDescriptionResponse>> EditDescription(EditGuildDescriptionDTO editDescriptionDTO)
        {
            var result = await guild.EditGuildDescriptionAsync(editDescriptionDTO);
            return Ok(result);
        }

        //запрос на удаление члена гильдии
        [HttpPatch("RemoveMember")]
        public async Task<ActionResult<DeleteGuildMemberResponse>> RemoveMember(DeleteGuildMemberDTO deleteGuildMemberDTO)
        {
            var result = await guild.DeleteGuildMember(deleteGuildMemberDTO);
            return Ok(result);
        }

        //запрос на получение гильдии
        [HttpGet("GetGuild")]
        public async Task<ActionResult<GetGuildResponse>> GetGuildInfo([FromQuery]GetGuildDTO getGuildDTO)
        {
            var result = await guild.GetGuild(getGuildDTO);
            return Ok(result);
        }
    }
}
