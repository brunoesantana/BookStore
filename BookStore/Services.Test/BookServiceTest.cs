using BookStore.Api.Mapper;
using BookStore.Business;
using BookStore.Business.Interface;
using BookStore.CrossCutting.DTO.Book;
using BookStore.CrossCutting.Helper;
using BookStore.Data.Context;
using BookStore.Data.Interface;
using BookStore.Data.Repository;
using BookStore.Domain;
using NUnit.Framework;

namespace Services.Test
{
    public class BookServiceTest
    {
        private IBookService _bookService;
        private IBookRepository _bookRepository;

        [SetUp]
        public void Setup()
        {
            MapperConfig.RegisterMappings();

            _bookRepository = new BookRepository(new DataContext());
            _bookService = new BookService(_bookRepository);
        }

        [Test]
        public void Deve_inserir_registro_de_livro_corretamente()
        {
            var dto = GetBookInsertDTO();
            var response = _bookService.Create(MapperHelper.Map<BookInsertDTO, Book>(dto));

            Assert.IsNotNull(response);
        }

        private BookInsertDTO GetBookInsertDTO()
        {
            return new BookInsertDTO
            {
                Title = $"Livro Teste {TestHelper.GetRandomNumber()}",
                Description = $"Descrição Teste {TestHelper.GetRandomNumber()}",
                Author = $"Bruno Santana {TestHelper.GetRandomNumber()}",
                UrlImage = "https://awebic.com/wp-content/uploads/2017/04/a-menina-que-roubava-livros-markus-zusak.jpg"
            };
        }
    }
}