using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChildDictionary.ViewModels
{
    public class WordsViewModel
    {
        public int Id { get; set; }
        public string WordEnglish { get; set; }
        public string WordTurkish { get; set; }
        public string Meaning { get; set; }
        public string ImagePath { get; set; }
        public IFormFile Image { get; set; }
    }
}
