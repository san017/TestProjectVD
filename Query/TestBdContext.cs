using Entities;
using System.Data.Entity;

namespace TestProjectVD
{
    public class TestBdContext: DbContext
    {
        public TestBdContext()
            : base("DbConnection")
        { }

        public DbSet<IndividualPerson> IndividualPersons { get; set; }
        public DbSet<Contract> Contracts { get; set; }
    }
}
