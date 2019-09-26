using BookStore.Domain;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Data.Context
{
    public class DataContext : DbContext
    {
        public DbSet<Book> Book { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies();
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=master;Initial Catalog=bookstore;Trusted_Connection=True");
            }

            base.OnConfiguring(optionsBuilder);
        }

        //public virtual void UpdateDatabase()
        //{
        //    //FIXME
        //    if (Database.IsInMemory())
        //    {
        //        Database.EnsureCreated();

        //        return;
        //    }
        //    Database.Migrate();
        //}
    }
}
