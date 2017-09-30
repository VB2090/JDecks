using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace JDecks.Models
{
    public class JDecksContext : DbContext
    {
        public JDecksContext (DbContextOptions<JDecksContext> options)
            : base(options)
        {
        }

        public DbSet<JDecks.Models.Decks> Decks { get; set; }
    }
}
