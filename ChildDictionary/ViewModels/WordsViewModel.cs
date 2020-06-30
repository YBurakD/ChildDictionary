using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChildDictionary.ViewModels
{
    public class WordsViewModel
    {
        public int Id { get; set; }
        [Display(Name = "English")]
        public string WordEnglish { get; set; }

        [Display(Name = "Turkish")]
        public string WordTurkish { get; set; }

        [Display(Name = "Description")]
        public string Meaning { get; set; }
        public string ImagePath { get; set; }

        [Display(Name = "Image")]
        public IFormFile Image { get; set; }
    }
}
