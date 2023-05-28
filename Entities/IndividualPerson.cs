using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    /// <summary>
    /// Сущность физическое лицо.
    /// </summary>
    [Table(name: "IndividualPerson")]
    public class IndividualPerson:IEqualityComparer<IndividualPerson>
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        [Key]
        public Guid PersonId { get; set; }

        /// <summary>
        /// Имя.
        /// </summary>
        [Column]
        public string Name { get; set; }

        /// <summary>
        /// Фамилия.
        /// </summary>
        [Column]
        public string SurName { get; set; }

        /// <summary>
        /// Отчество.
        /// </summary>
        [Column]
        public string Patronymic { get; set; }

        /// <summary>
        /// Пол.
        /// </summary>
        [Column]
        public string Gender { get; set; }

        /// <summary>
        /// Возраст.
        /// </summary>
        [Column]
        public int Age { get; set; }

        /// <summary>
        /// Место работы.
        /// </summary>
        [Column]
        public string PlaceWork { get; set; }

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

        /// <summary>
        /// Дата рождения.
        /// </summary>
        [Column]
        public DateTime DateBirthday { get; set; }


        /// <summary>
        /// Сравнение объектов.
        /// </summary>
        /// <param name="x">Первый объект.</param>
        /// <param name="y">Второй объект.</param>
        /// <returns>Результат сравнения.</returns>
        public bool Equals(IndividualPerson x, IndividualPerson y)
        {
            return x.PersonId == y.PersonId;
        }

        /// <summary>
        /// Получение хеш-кода.
        /// </summary>
        /// <param name="obj">Объект.</param>
        /// <returns>хеш-код свойства объекта.</returns>
        public int GetHashCode(IndividualPerson obj)
        {
            return obj.PersonId.GetHashCode();
        }
    }
}
