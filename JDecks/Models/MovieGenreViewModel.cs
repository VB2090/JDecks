using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace JDecks.Models
{
    public class MovieGenreViewModel
    {
        public List<Decks> movies;
        public SelectList genres;
        public string movieGenre { get; set; }
    }
} 