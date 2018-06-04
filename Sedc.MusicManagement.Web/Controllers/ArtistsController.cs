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
    public class ArtistsController : Controller
    {
        private readonly IArtistRepository _artistRepository;

        public ArtistsController()
        {
            _artistRepository = new ArtistRepository();
        }

        public ActionResult Index()
        {
            var artists = _artistRepository.GetAll();
            return View(artists);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Artist a)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var artist = _artistRepository.Create(a);
                    return RedirectToAction("Details", new { id = artist.Id });
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

            var artist = _artistRepository.GetById(id.Value);

            if (artist == null)
                return RedirectToAction("Index");

           return View(artist);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
                return RedirectToAction("Index");

            var artist = _artistRepository.GetById(id.Value);

            if (artist == null)
                return RedirectToAction("Index");

            return View(artist);
        }

        [HttpPost]
        public ActionResult Edit(int? id, Artist artist)
        {
            if (!id.HasValue)
                return RedirectToAction("Index");

            if (!ModelState.IsValid)
                return View(artist);

            var dbArtist = _artistRepository.GetById(id.Value);

            if (dbArtist == null)
                return RedirectToAction("Index");

            dbArtist.Albums = artist.Albums;
            dbArtist.ArtistType = artist.ArtistType;
            dbArtist.FullName = artist.FullName;

            _artistRepository.Update(artist);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (!id.HasValue)
                return RedirectToAction("Index");

            var artist = _artistRepository.GetById(id.Value);

            if (artist == null)
                return RedirectToAction("Index");

            return View(artist);
        }

        [HttpPost]
        public ActionResult Delete(int? id , Artist artist)
        {
            if (!id.HasValue)
                return RedirectToAction("Index");

            if (!ModelState.IsValid)
                return View(artist);

            var dbArtist = _artistRepository.GetById(id.Value);

            if (dbArtist == null)
                return RedirectToAction("Index");

            _artistRepository.Delete(dbArtist);
            _artistRepository.Update(artist);

            return RedirectToAction("Index");
        }

        


    }

        
    
}