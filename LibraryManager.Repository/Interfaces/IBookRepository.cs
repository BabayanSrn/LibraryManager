using LibraryManager.DataModels;
using LibraryManager.Storage.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Repository.Interfaces
{
    public interface IBookRepository
    {
        Task<List<Book>> GetBooks();
        Task<Book> GetBook(int id);
        Task Update(BookModel bookmodel);
        Task<Book> Create(BookModel model);
        Task Delete(Book book);
        Book BookExist(int id);
    }
}
