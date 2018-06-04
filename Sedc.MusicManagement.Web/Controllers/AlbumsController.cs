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
    public class AlbumsController : Controller
    {
        // GET: Albums
        private readonly IAlbumRepository _albumRepository;

        public AlbumsController()
        {
            _albumRepository = new AlbumRepository();
        }

        public ActionResult Index()
        {
            var albums = _albumRepository.GetAll();
            return View(albums);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Album a)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var album = _albumRepository.Create(a);
                    return RedirectToAction("Details", new { id = album.Id });
                }
                catch (Exception ex)
                {
                    return View(a);
                }
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (!id.HasValue)
                return RedirectToAction("Index");

            var album = _albumRepository.GetById(id.Value);

            if (album == null)
                return RedirectToAction("Index");

            return View(album);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
                return RedirectToAction("Index");

            var album = _albumRepository.GetById(id.Value);

            if (album == null)
                return RedirectToAction("Index");

            return View(album);
        }

        [HttpPost]
        public ActionResult Edit(int? id, Album album)
        {
            if (!id.HasValue)
                return RedirectToAction("Index");

            if (!ModelState.IsValid)
                return View(album);

            var dbAlbum = _albumRepository.GetById(id.Value);

            if (dbAlbum == null)
                return RedirectToAction("Index");

            dbAlbum.Title = album.Title;
            dbAlbum.Genre = album.Genre;
            dbAlbum.Artist = album.Artist;
            dbAlbum.Songs = album.Songs;

            _albumRepository.Update(album);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (!id.HasValue)
                return RedirectToAction("Index");

            var album = _albumRepository.GetById(id.Value);

            if (album == null)
                return RedirectToAction("Index");

            return View(album);
        }

        [HttpPost]
        public ActionResult Delete(int? id, Album album)
        {
            if (!id.HasValue)
                return RedirectToAction("Index");

            if (!ModelState.IsValid)
                return View(album);

            var dbArtist = _albumRepository.GetById(id.Value);

            if (dbArtist == null)
                return RedirectToAction("Index");

            _albumRepository.Delete(dbArtist);
            _albumRepository.Update(album);

            return RedirectToAction("Index");
        }
    }
}