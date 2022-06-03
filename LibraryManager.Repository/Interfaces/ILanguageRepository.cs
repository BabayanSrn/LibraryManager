using LibraryManager.DataModels;
using LibraryManager.Storage.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Repository.Interfaces
{
    public interface ILanguageRepository
    {
        Task<List<Language>> GetLanguages();
        Task<Language> GetLanguage(int id);
        Language LanguageExist(int id);
        Task Update(LanguageModel languageModel);
        Task<Language> Create(LanguageModel languageModel);
        Task Delete(Language entity);
    }
}
