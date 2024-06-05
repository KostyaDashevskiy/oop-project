using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    //описание полей сущности Country(столбцы таблицы Country)
    public class UserCountry
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }

    }
}
