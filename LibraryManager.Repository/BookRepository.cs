using LibraryManager.Data;
using LibraryManager.DataModels;
using LibraryManager.Repository.Interfaces;
using LibraryManager.Storage.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Repository
{
    internal class BookRepository : IBookRepository
    {
        private readonly LibraryManagerContext _context;
        public BookRepository(LibraryManagerContext context)
        {
            _context = context;
        }

        public Book BookExist(int id)
        {
            return _context.Books.Find(id);
        }

        public async Task<Book> Create(BookModel model)
        {
            var entity = new Book();
            entity.Author=model.Author;
            entity.Title=model.Title;
            entity.LanguageId=model.LanguageId;
            entity.Content=model.Content;
            _context.Books.Add(entity);
            await _context.SaveChangesAsync();
            return await GetBook(entity.Id);
        }

        public async Task Delete(Book book)
        {
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }

        public async Task<Book> GetBook(int id)
        {
            return await _context.Books.FindAsync(id);
        }

        public async Task<List<Book>> GetBooks()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task Update(BookModel model)
        {
            var entity = new Book();
            entity.Id = model.Id;
            entity.Author = model.Author;
            entity.Content = model.Content;
            entity.Title = model.Title;
            entity.LanguageId= model.LanguageId;
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
