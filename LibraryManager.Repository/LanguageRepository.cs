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
    internal class LanguageRepository : ILanguageRepository
    {
        private readonly LibraryManagerContext _context;
        public LanguageRepository(LibraryManagerContext context)
        {
            _context = context;
        }

        public Language LanguageExist(int id)
        {
            return _context.Languages.Find(id);
        }

        public async Task<Language> Create(LanguageModel model)
        {
            var entity = new Language();
            entity.LanguageId = model.LanguageId;
            entity.Name = model.Name;
            _context.Languages.Add(entity);
            await _context.SaveChangesAsync();
            return await GetLanguage(entity.LanguageId);
        }

        public async Task Delete(Language entity)
        {
            _context.Languages.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<Language> GetLanguage(int id)
        {
            return await _context.Languages.Include(x => x.Books).Where(x => x.LanguageId == id).FirstOrDefaultAsync();
        }

        public async Task<List<Language>> GetLanguages()
        {
            return await _context.Languages.ToListAsync();
        }

        public async Task Update(LanguageModel model)
        {
            var entity = new Language();
            entity.LanguageId = model.LanguageId;
            entity.Name = model.Name;
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
