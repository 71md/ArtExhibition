using LLArtExhibition_2.Data;
using LLArtExhibition_2.Models;
using Microsoft.EntityFrameworkCore;

namespace LLArtExhibition_2.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options) 
        { 
        
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ArtShowConfiguration());
        }

        public DbSet<Example> Examples { get; set; }
        public DbSet<ArtShow> ArtShows { get; set; }
    }
}
