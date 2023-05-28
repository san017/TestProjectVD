using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using TestProjectVD;

namespace Query
{
    /// <summary>
    /// SQL - запросы.
    /// </summary>
    public static class SqlQuery
    {

        /// <summary>
        /// Обработка SELECT запроса.
        /// </summary>
        /// <typeparam name="T">Тип объекта.</typeparam>
        /// <param name="textQuery">Тело запроса.</param>
        /// <returns>Результат обработки запроса.</returns>
        /// <exception cref="ArgumentException">Пустое значение.</exception>
        public static IEnumerable<T> SelectQuery<T>(string textQuery)
        {
            if (string.IsNullOrEmpty(textQuery))
            {
                throw new ArgumentException("Пустое значение", nameof(textQuery));
            }

            using (var context = new TestBdContext())
            {
                return context.Database.SqlQuery<T>(textQuery).ToList();
            };
        }

        /// <summary>
        /// UPDATE запрос статуса договора для людей опрелённого возраста.
        /// </summary>
        /// <param name="textAge">Возраст физ. лица.</param>
        /// <param name="textStatus">Статус договора.</param>
        /// <returns>Количество изменных записей.</returns>
        /// <exception cref="ArgumentException">Пустое значение.</exception>
        public static int UpdateStatusContract(int textAge, string textStatus)
        {
            if (textAge <= 0)
            {
                throw new ArgumentException("Неккоректное значение", nameof(textAge));
            }

            if (string.IsNullOrEmpty(textStatus))
            {
                throw new ArgumentException("Пустое значение", nameof(textStatus));
            }

            using (var context = new TestBdContext())
            {
                var updateStatusContract = context.Contracts
                    .Join(context.IndividualPersons,
                    b => b.AuthorisedPersonId,
                    c => c.PersonId,
                    (b, c) => new
                    {
                        b.ContractId,
                        b.Status,
                        c.Age
                    }).Where(h => h.Age > textAge)
                    .AsEnumerable()
                    .Select(f => new Contract
                    {
                        ContractId = f.ContractId,
                        Status = textStatus
                    });

                foreach (var item in updateStatusContract)
                {
                    context.Contracts.Attach(item);
                    context.Entry(item).Property(c => c.Status).IsModified = true;
                }

                return context.SaveChanges();
            }
        }
    }
}
