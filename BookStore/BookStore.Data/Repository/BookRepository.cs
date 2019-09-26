using BookStore.Data.Base;
using BookStore.Data.Context;
using BookStore.Data.Interface;
using BookStore.Domain;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Data.Repository
{
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        public BookRepository(DataContext context) : base(context)
        {
        }

        public override List<Book> GetAll()
        {
            using (var context = GetContext())
            {
                return context.Set<Book>().Where(w => w.Active).OrderBy(a => a.Title).ToList();
            }
        }
    }
}
