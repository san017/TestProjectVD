using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Table(name: "IndividualPerson")]
    public class IndividualPerson
    {
        [Key]
        public Guid PersonId { get; set; }
        [Column]
        public string Name { get; set; }
        [Column]
        public string SurName { get; set; }
        [Column]
        public string Patronymic { get; set; }
        [Column]
        public string Gender { get; set; }
        [Column]
        public int Age { get; set; }
        [Column]
        public string PlaceWork { get; set; }
        [Column]
        public string Country { get; set; }
        [Column]
        public string City { get; set; }
        [Column]
        public string Address { get; set; }
        [Column]
        public string Mail { get; set; }
        [Column]
        public string NumberPhone { get; set; }
        [Column]
        public DateTime DateBirthday { get; set; }

    }
}
