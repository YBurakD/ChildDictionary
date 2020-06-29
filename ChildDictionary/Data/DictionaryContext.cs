using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ChildDictionary.Models;

namespace ChildDictionary.Data
{
    public class DictionaryContext : DbContext
    {
        public DictionaryContext(DbContextOptions<DictionaryContext> options)
            : base(options)
        {
        }
        public DbSet<Words> Dictionary { get; set;}
    }
}
