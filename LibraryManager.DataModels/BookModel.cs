using System.ComponentModel.DataAnnotations;

namespace LibraryManager.DataModels
{
    public class BookModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(25)]
        public string Author { get; set; }
        public int LanguageId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
    }
}