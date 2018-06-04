using Sedc.MusicManagement.Models;
using Sedc.MusicManagement.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sedc.MusicManagement.Repositories.EntityFramework
{
    public class AlbumRepository : IAlbumRepository
    {
        private readonly MusicDb _db;

        public AlbumRepository()
        {
            _db = new MusicDb();
        }

        public IEnumerable<Album> GetAll()
        {
            List<Album> albums = _db.Albums.ToList();
            return albums;
        }

        public Album GetById(int id)
        {
            Album album = _db.Albums.FirstOrDefault(x => x.Id == id);
            return album;
        }

        public Album Create(Album album)
        {
            var createdArtist = _db.Albums.Add(album);
            _db.SaveChanges();
            return album;
        }

        public Album Update(Album album)
        {

            _db.SaveChanges();
            return album;

        }

        public Album Delete(Album album)
        {
            var deletedArtist = _db.Albums.Remove(album);
            return album;

        }
    }
}
