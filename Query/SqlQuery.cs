using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using TestProjectVD;

namespace Query
{
    public static class SqlQuery
    {
        public static IEnumerable<T> SelectQuery<T>(string textQuery)
        {
            using (var context = new TestBdContext())
            {
                return context.Database.SqlQuery<T>(textQuery).ToList();
            };
        }

        public static int UpdateStatusContract(int textAge, string textStatus)
        {
            if (textAge <= 0)
            {
                throw new ArgumentException("Неккоректное значение", nameof(textAge));
            }

            if (textStatus == null)
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
