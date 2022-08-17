using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Team
    {
        [Key]
        public int Id { get; set; }
        public string NameTeam { get; set; }
        public string City { get; set; }
        public string Owner { get; set; }
        public string Telephone { get; set; }
    }
}
