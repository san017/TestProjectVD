using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    /// <summary>
    /// Сущность договор.
    /// </summary>
    [Table(name: "Contract")]
    public class Contract
    {
        /// <summary>
        /// Идентификатор договора.
        /// </summary>
        [Key]
        public Guid ContractId { get; set; } 

        /// <summary>
        /// Идентификатор контрагента(юр.лицо).
        /// </summary>
        [Column]
        public Guid ContractorId { get; set; }

        /// <summary>
        /// Идентификатор уполномоченного лица(физ.лицо)
        /// </summary>
        [Column]
        public Guid AuthorisedPersonId { get; set; }
        
        /// <summary>
        /// Сумма договора.
        /// </summary>
        [Column]
        public double Amount { get; set; }

        /// <summary>
        /// Статус.
        /// </summary>
        [Column]
        public string Status { get; set; }

        /// <summary>
        /// Дата подписания.
        /// </summary>
        [Column]
        public DateTime DateSigning { get; set; }
    }
}
