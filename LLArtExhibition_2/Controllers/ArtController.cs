using LLArtExhibition_2.Services;
using LLArtExhibition_2.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Identity.Client;

namespace LLArtExhibition_2.Controllers
{
    public class ArtController:Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;


        public readonly IArtService _artService;
        public ArtController(IArtService artService, SignInManager<IdentityUser> signInManager)
        {
            _artService = artService;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Index() 
        {
            var arts = await _artService.GetAllAsync();
            return View(arts);
        }

        public async Task<IActionResult> Details(int id)
        {
            var model = await _artService.GetByIdAsync(id);
            if (model == null) {
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }


        public async Task<IActionResult> Create() 
        {
            if (!_signInManager.IsSignedIn(User)) {
                return RedirectToAction("Login", "Example");
            }
            var nowModel = new ArtViewModel (){ 
                ReleaseDate = DateTime.Now,
            };
            return View(nowModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ArtViewModel artViewModel)
        {
            if (!ModelState.IsValid) 
            {
                ModelState.AddModelError(string.Empty, "Model id not valid");
                return View();
            }

            try { 
                var newModel =  await _artService.AddAsync(new Models.ArtShow { 
                Title = artViewModel.Title,
                Author = artViewModel.Author,
                ReleaseDate = artViewModel.ReleaseDate,
                CoverUrl = artViewModel.CoverUrl,
            });
            return RedirectToAction(nameof(Details), new { id = newModel.Id });
            } catch {
                return View(artViewModel);
            }
        }

 
        public async Task<IActionResult> Edit(int id)
        {
            if (!_signInManager.IsSignedIn(User))
            {
                return RedirectToAction("Login", "Example");
            }
            var model = await _artService.GetByIdAsync(id);
            if (model == null) { 
                return RedirectToAction(nameof(Index));
            }
            var EditModel = new ArtViewModel
            {
                Title = model.Title,
                Author = model.Author,
                ReleaseDate = model.ReleaseDate,
                CoverUrl = model.CoverUrl,
            };

            return View(EditModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,ArtViewModel artViewModel)
        {
            var model = await _artService.GetByIdAsync(id);
            if (model == null) { 
                return View(model);
            }
            try
            {
                model.Title = artViewModel.Title;
                model.Author = artViewModel.Author;
                model.ReleaseDate = artViewModel.ReleaseDate;
                model.CoverUrl = artViewModel.CoverUrl;

                await _artService.UptateAsync(model);

                return RedirectToAction(nameof(Index));
            }
            catch { 
                return View(artViewModel);
            }
        }

        /*Get*/

        public async Task<IActionResult> Delete(int id) 
        {
            if (!_signInManager.IsSignedIn(User))
            {
                return RedirectToAction("Login", "Example");
            }
            var model = await _artService.GetByIdAsync(id);
            if (model == null) {
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id,IFormCollection collection)
        {
            var model = await _artService.GetByIdAsync(id);
            if (model == null)
            {
                return View(model);
            }
            try {
                await _artService.DelateAsync(model);
                return RedirectToAction(nameof(Index));
            } catch {
                return View(model);
            }
            
        }
    }
}
