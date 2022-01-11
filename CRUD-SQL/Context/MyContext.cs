using CRUD_SQL.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_SQL.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {

        }

        public DbSet<Pessoa> Pessoas { get; set; }
    }
}
