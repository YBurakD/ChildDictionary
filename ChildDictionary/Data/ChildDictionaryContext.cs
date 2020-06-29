using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ChildDictionary.Models;

namespace ChildDictionary.Data
{
    public class ChildDictionaryContext : DbContext
    {
        public ChildDictionaryContext (DbContextOptions<ChildDictionaryContext> options)
            : base(options)
        {
        }

        public DbSet<ChildDictionary.Models.Words> Words { get; set; }
    }
}
