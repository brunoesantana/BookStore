using BookStore.Data.Interface.Base;
using BookStore.Domain;

namespace BookStore.Data.Interface
{
    public interface IBookRepository : IRepositoryBase<Book>
    {
    }
}
