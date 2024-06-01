using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserRating
    {
        public int Id { get; set; }

        public string UserName { get; set; } = default!;

        public int Rating { get; set; } = default!;
    }
}
