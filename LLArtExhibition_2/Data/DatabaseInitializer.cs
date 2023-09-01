using LLArtExhibition_2.Data;
using LLArtExhibition_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LLArtExhibition_2.Data
{
    public class DatabaseInitializer
    {
        public static void Seed(DataContext context)
        {
            if (!context.ArtShows.Any())
            {
                context.ArtShows.AddRange
                (new List<ArtShow>
                    {
                        new ArtShow { Author = "Megadeth", Title = "Killing Is My Business... and Business Is Good!", CoverUrl = "https://upload.wikimedia.org/wikipedia/en/thumb/5/54/Combat_KIMB.jpg/220px-Combat_KIMB.jpg",  ReleaseDate = new DateTime(1985, 6, 12) },
                        new ArtShow { Author = "Megadeth", Title = "Peace Sells... but Who's Buying?", CoverUrl = "https://en.wikipedia.org/wiki/File:Megadeth_-_Peace_Sells..._But_Who%27s_Buying-.jpg", ReleaseDate = new DateTime(1989, 9, 19) },
                        new ArtShow { Author = "Megadeth", Title = "Rust in Peace", CoverUrl = "https://upload.wikimedia.org/wikipedia/en/thumb/d/dc/Megadeth-RustInPeace.jpg/220px-Megadeth-RustInPeace.jpg", ReleaseDate = new DateTime(1990, 9, 24) },
                        new ArtShow { Author = "Gojira", Title = "L'Enfant Sauvage", CoverUrl = "https://upload.wikimedia.org/wikipedia/en/thumb/8/86/Gojira_-_L%27Enfant_Sauvage_cover.jpg/220px-Gojira_-_L%27Enfant_Sauvage_cover.jpg",  ReleaseDate = new DateTime(2012, 6, 26) },
                        new ArtShow { Author = "Gojira", Title = "The Way of All Flesh", CoverUrl = "https://upload.wikimedia.org/wikipedia/en/thumb/1/16/Gojira_-_The_Way_of_All_Flesh_-_2008.jpg/220px-Gojira_-_The_Way_of_All_Flesh_-_2008.jpg",  ReleaseDate = new DateTime(2008, 10, 13) }
                    });
            }
            context.SaveChanges();
        }
    }
}
