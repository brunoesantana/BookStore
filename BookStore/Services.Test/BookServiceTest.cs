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
using System;
using System.Linq;

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
            var response = InsertBook();
            Assert.IsNotNull(response);
        }

        [Test]
        public void Deve_retornar_livros_corretamente()
        {
            InsertBook();

            var list = _bookService.GetAll();
            Assert.IsTrue(list.Any());

            var book = list.FirstOrDefault();
            var response = _bookService.Find(book.Id);
            Assert.IsNotNull(response);
        }

        [Test]
        public void Deve_atualizar_livros_corretamente()
        {
            var bookGuid = InsertBook();
            var book = _bookService.Find(bookGuid);
            var version = book.Version;
            var dto = UpdateBookDTO(book);

            var response = _bookService.Update(MapperHelper.Map<BookUpdateDTO, Book>(dto));

            Assert.IsTrue(response.Version > version);
        }

        [Test]
        public void Deve_remover_livros_corretamente()
        {
            var bookGuid = InsertBook();
            var book = _bookService.Find(bookGuid);

            Assert.IsNotNull(book);

            _bookService.Remove(book.Id);

            var response = _bookService.GetAll().FirstOrDefault(f => f.Id.Equals(book.Id));

            Assert.IsNull(response);
        }

        private Guid InsertBook()
        {
            var dto = GetBookInsertDTO();
            return _bookService.Create(MapperHelper.Map<BookInsertDTO, Book>(dto));
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

        private BookUpdateDTO UpdateBookDTO(Book book)
        {
            return new BookUpdateDTO
            {
                Id = book.Id,
                Title = book.Title,
                Description = book.Description,
                Author = book.Author,
                UrlImage = book.UrlImage
            };
        }
    }
}