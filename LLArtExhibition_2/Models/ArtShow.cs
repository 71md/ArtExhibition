namespace LLArtExhibition_2.Models
{
    public class ArtShow
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string CoverUrl { get; set; }
    }
}
