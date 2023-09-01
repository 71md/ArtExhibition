using LLArtExhibition_2.Data;
using System.Threading.Tasks;
using LLArtExhibition_2.Models;
using LLArtExhibition_2.ViewModels;
using Microsoft.EntityFrameworkCore;
using static System.Net.WebRequestMethods;

namespace LLArtExhibition_2.Services
{
    public class ArtService : IArtService
    {
        public readonly DataContext _context;
        public ArtService(DataContext context)
        {
            _context= context;
        }
        public static void Seed(DataContext context)
        {
            if (!context.ArtShows.Any())
            {
                context.ArtShows.AddRange
                (new List<ArtShow>
                    {
                        new ArtShow { Author = "无名", Title = "Daoist Wang Ye", CoverUrl = "https://i.ibb.co/3SDYjCq/wangye.jpg",  ReleaseDate = new DateTime(2017, 6, 12) },
                        new ArtShow { Author = "LWY", Title = "Boa Girl", CoverUrl = "https://i.ibb.co/PMct0Tx/sketch1650691494932.png", ReleaseDate = new DateTime(2022, 9, 6) },
                        new ArtShow { Author = "LWY", Title = "Cool Girl", CoverUrl = "https://i.ibb.co/41n3WLC/sketch1651052082273.png", ReleaseDate = new DateTime(2022, 9, 24) },
                        new ArtShow { Author = "LWY", Title = "Betelgeuse", CoverUrl = "https://i.ibb.co/ZgsMxX9/sketch1647868356322.png",  ReleaseDate = new DateTime(2022, 9, 26) },
                        new ArtShow { Author = "无名", Title = "The rising sun", CoverUrl = "https://i.ibb.co/k39csRr/Screenshot-20230624-095319-com-xingin-xhs-edit-30.jpg",  ReleaseDate = new DateTime(2020, 10, 13) },
                        new ArtShow { Author = "LWY", Title = "embrace", CoverUrl = "https://i.ibb.co/7RqMHZ9/d2c776c1898defd.jpg",  ReleaseDate = new DateTime(2022, 11, 13) }

                    });
            }
            context.SaveChanges();
        }

        public async Task<ArtShow> AddAsync(ArtShow model)
        {
            _context.AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task IDelateAsync(ArtShow model)
        {
            _context.ArtShows.Remove(model);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ArtShow>> GetAllAsync()
        {
            Seed(_context);
            return await _context.ArtShows.ToListAsync();
        }

        public async Task<ArtShow> GetByIdAsync(int id)
        {
            return await _context.ArtShows.FindAsync(id);
        }

        public async Task UptateAsync(ArtShow model)
        {
            _context.Entry(model).State = EntityState.Modified;
             await _context.SaveChangesAsync();
        }

        async Task IArtService.DelateAsync(ArtShow model)
        {
            _context.Remove(model);
            await _context.SaveChangesAsync();
        }
    }
}
