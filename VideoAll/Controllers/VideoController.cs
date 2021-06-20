using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoAll.Data;
using VideoAll.Interfaces;
using VideoAll.Models;
using VideoAll.Repositories;

namespace VideoAll.Controllers
{
    public class VideoController : Controller
    {
        private IRepository _repository;
        private ApplicationContext _context;      

        public VideoController(ApplicationContext context, IRepository repository)
        {
            _repository = repository;
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            IList<Video> videos = _context.Videos.Include(g => g.Genres).ToList();
            var model = await _repository.SelectAll<Video>();
            return View(videos);
        }

        [HttpGet]
        public async Task<IActionResult> CreateVideo()
        {
            if (ModelState.IsValid)
            {
                //string folder = "Videos/Cover";
                //folder = += Guid.NewGuid().ToString() + "_" + _repository.
                ViewBag.GenreId = new SelectList(await _repository.SelectAll<Genre>(), "GenreId", "Name");
                return View();
            }
            return View();
        }
        public async Task<IActionResult> CreateVideo(Video video)
        {
            var newVideo = new Video() { Name = video.Name, ImagePath = video.ImagePath, GenreId = video.GenreId };
            await _repository.CreateAsync<Video>(newVideo);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> UpdateVideo(int id)
        {
            ViewBag.GenreId = new SelectList(await _repository.SelectAll<Genre>(), "GenreId", "Name");
            var Findmodel = await _repository.SelectById<Video>(id);

            return View(Findmodel);
        }

       

        [HttpPost]
        public async Task<IActionResult> UpdateVideo(int? id, Video model)
        {
            if (id == null)
            {
                return NotFound();
            }

            await _repository.UpdateAsync<Video>(model);

            return RedirectToAction(nameof(Index));
        }
    }
}
