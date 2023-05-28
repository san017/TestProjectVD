using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    /// <summary>
    /// Юридическое лицо.
    /// </summary>
    [Table(name: "JuridicalPerson")]
    public class JuridicalPerson
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        [Key]
        public Guid JuridicalPersonID { get; set; }

        /// <summary>
        /// Наименнование компании.
        /// </summary>
        [Column]
        public string CompanyName { get; set; }

        /// <summary>
        /// ИНН.
        /// </summary>
        [Column]
        public string INN { get; set; }

        /// <summary>
        /// ОГРН.
        /// </summary>
        [Column]
        public string OGRN { get; set; }

        /// <summary>
        /// Страна.
        /// </summary>
        [Column]
        public string Country { get; set; }

        /// <summary>
        /// Город.
        /// </summary>
        [Column]
        public string City { get; set; }
        /// <summary>
        /// Адрес.
        /// </summary>
        [Column]
        public string Address { get; set; }

        /// <summary>
        /// Почта.
        /// </summary>
        [Column]
        public string Mail { get; set; }

        /// <summary>
        /// Номер телефона.
        /// </summary>
        [Column]
        public string NumberPhone { get; set; }
    }
}
