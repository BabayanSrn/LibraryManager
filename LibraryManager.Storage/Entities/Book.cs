using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Storage.Entities
{
    public class Book
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(25)]
        public string Author { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.UtcNow;
        public int LanguageId { get; set; }
        public Language Language { get; set; }
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
    }
}
