using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    //описание полей сущности Twitch(столбцы таблицы Twitch)
    public class UserTwitch
    {
        public int Id { get; set; }
        public string UserName { get; set; } = default!;
        public string Link { get; set; } = default!;
    }
}
