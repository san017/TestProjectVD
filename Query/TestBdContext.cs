using Entities;
using System.Data.Entity;

namespace TestProjectVD
{
    /// <summary>
    /// Подключение к БД.
    /// </summary>
    public class TestBdContext : DbContext
    {
        public TestBdContext()
            : base("DbConnection")
        { }

        /// <summary>
        /// Таблица физ.лиц.
        /// </summary>
        public DbSet<IndividualPerson> IndividualPersons { get; set; }

        /// <summary>
        /// Таблица договоров.
        /// </summary>
        public DbSet<Contract> Contracts { get; set; }

        /// <summary>
        /// Таблица юр.лиц.
        /// </summary>
        public DbSet<JuridicalPerson> JuridicalPersons { get; set; }
    }
}
