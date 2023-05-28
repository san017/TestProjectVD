using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Table(name: "Contract")]
    public class Contract
    {
        [Key]
        public Guid ContractId { get; set; } 
        [Column]
        public Guid ContractorId { get; set; }
        [Column]
        public Guid AuthorisedPersonId { get; set; }
        [Column]
        public double Amount { get; set; }
        [Column]
        public string Status { get; set; }
        [Column]
        public DateTime DateSigning { get; set; }
    }
}
