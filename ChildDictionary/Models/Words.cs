using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChildDictionary.Models
{
    public class Words
    {
        [Key]
        public int Id { get; set; }
        
        public string WordEnglish { get; set; }
        public string WordTurkish { get; set; }
        public string Meaning { get; set; }
        public string ImagePath { get; set; }
    }
}
