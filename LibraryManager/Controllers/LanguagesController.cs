using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryManager.Data;
using LibraryManager.Storage.Entities;
using LibraryManager.Repository.Interfaces;
using LibraryManager.DataModels;

namespace LibraryManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguagesController : ControllerBase
    {
        private readonly ILanguageRepository _languageRepository;

        public LanguagesController(ILanguageRepository languagesRepository)
        {
            _languageRepository = languagesRepository;
        }

        // GET: api/Languages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Language>>> GetLanguages()
        {
            var languages = await _languageRepository.GetLanguages();
            if (languages == null)
            {
                return NotFound();
            }
            return languages;
        }

        // GET: api/Language/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Language>> GetLanguage(int id)
        {
            var language = await _languageRepository.GetLanguage(id);
            if (language == null)
            {
                return NotFound();
            }

            return language;
        }

        // PUT: api/Books/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLanguage(int id, LanguageModel languagemodel)
        {
            if (id != languagemodel.LanguageId)
            {
                return BadRequest();
            }
            try
            {
                await _languageRepository.Update(languagemodel);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LanguageExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Languages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Language>> PostLanguage(LanguageModel languagemodel)
        {
            var language = await _languageRepository.Create(languagemodel);

            return CreatedAtAction("GetLanguage", new { id = language.LanguageId }, language);
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLanguage(int id)
        {

            var language = await _languageRepository.GetLanguage(id);
            if (language == null)
            {
                return NotFound();
            }

            await _languageRepository.Delete(language);

            return NoContent();
        }

        private bool LanguageExists(int id)
        {
            return _languageRepository.LanguageExist(id) != null;
        }
    }
}