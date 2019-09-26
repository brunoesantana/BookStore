using BookStore.Business.Base;
using BookStore.Business.Interface;
using BookStore.Data.Interface;
using BookStore.Domain;

namespace BookStore.Business
{
    public class BookService : BaseService<Book>, IBookService
    {
        public BookService(IBookRepository repository) : base(repository)
        {
        }
    }
}
