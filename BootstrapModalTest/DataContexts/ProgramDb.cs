using BootstrapModalTest.Models;
using System.Data.Entity;


namespace BootstrapModalTest.DataContexts
{
    public class ProgramDb: DbContext
    {
       
        public ProgramDb(): base("DefaultConnection")
        {
        }

        public DbSet<Person> People { get; set; }

        public DbSet<Socio> Socios { get; set; }

        public DbSet<Pessoa> Pessoas { get; set; }

    }
}