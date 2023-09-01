using LLArtExhibition_2.Models;
using LLArtExhibition_2.ViewModels;

namespace LLArtExhibition_2.Services
{
    public interface IArtService
    {
        Task<List<ArtShow>> GetAllAsync();
        Task<ArtShow> GetByIdAsync(int id);
        Task<ArtShow> AddAsync(ArtShow model);
        Task UptateAsync(ArtShow model);
        Task DelateAsync(ArtShow model);
    }
}
