using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.DataModels
{
    public class LanguageModel
    {
        public int LanguageId { get; set; }
        [Required]
        [MaxLength(25)]
        public string Name { get; set; }
    }
}
