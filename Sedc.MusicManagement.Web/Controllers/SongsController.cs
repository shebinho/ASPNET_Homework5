using Sedc.MusicManagement.Models;
using Sedc.MusicManagement.Repositories.EntityFramework;
using Sedc.MusicManagement.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sedc.MusicManagement.Web.Controllers
{
    public class SongsController : Controller
    {
        private readonly ISongRepository _songRepository;

        public SongsController()
        {
            _songRepository = new SongRepository();
        }

        public ActionResult Index()
        {
            var songs = _songRepository.GetAll();
            return View(songs);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Song s)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var song = _songRepository.Create(s);
                    return RedirectToAction("Details", new { id = song.Id });
                }
                catch (Exception ex)
                {
                    return View(s);
                }
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (!id.HasValue)
                return RedirectToAction("Index");

            var song = _songRepository.GetById(id.Value);

            if (song == null)
                return RedirectToAction("Index");

            return View(song);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
                return RedirectToAction("Index");

            var song = _songRepository.GetById(id.Value);

            if (song == null)
                return RedirectToAction("Index");

            return View(song);
        }

        [HttpPost]
        public ActionResult Edit(int? id, Song song)
        {
            if (!id.HasValue)
                return RedirectToAction("Index");

            if (!ModelState.IsValid)
                return View(song);

            var dbSong = _songRepository.GetById(id.Value);

            if (dbSong == null)
                return RedirectToAction("Index");

            dbSong.Title = song.Title;
            dbSong.Description = song.Description;
            dbSong.Duration = song.Duration;
            dbSong.AlbumId = song.AlbumId;

            _songRepository.Update(song);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (!id.HasValue)
                return RedirectToAction("Index");

            var song = _songRepository.GetById(id.Value);

            if (song == null)
                return RedirectToAction("Index");

            return View(song);
        }

        [HttpPost]
        public ActionResult Delete(int? id, Song song)
        {
            if (!id.HasValue)
                return RedirectToAction("Index");

            if (!ModelState.IsValid)
                return View(song);

            var dbSong = _songRepository.GetById(id.Value);

            if (dbSong == null)
                return RedirectToAction("Index");

            _songRepository.Delete(dbSong);
            _songRepository.Update(song);

            return RedirectToAction("Index");
        }
    }
}