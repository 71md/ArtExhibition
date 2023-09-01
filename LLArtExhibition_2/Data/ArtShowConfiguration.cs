using LLArtExhibition_2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LLArtExhibition_2.Data
{
    public class ArtShowConfiguration : IEntityTypeConfiguration<ArtShow>
    {
        public void Configure(EntityTypeBuilder<ArtShow> builder)
        {
            builder.Property(x => x.Title).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Author).IsRequired().HasMaxLength(100);
            builder.Property(x => x.ReleaseDate).HasColumnType("date");
            builder.Property(x => x.CoverUrl).IsRequired().HasMaxLength(200);
        }
    }
}