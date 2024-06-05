using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserInfo
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Country { get; set; } = default!;
        public string Link { get; set; } = default!;
    }
}
