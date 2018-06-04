using Sedc.MusicManagement.Models;
using Sedc.MusicManagement.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sedc.MusicManagement.Repositories.EntityFramework
{
    public class ArtistRepository : IArtistRepository
    {
        private readonly MusicDb _db;

        public ArtistRepository()
        {
            _db = new MusicDb();
        }

        public IEnumerable<Artist> GetAll()
        {
            List<Artist> artists = _db.Artists.ToList();
            return artists;
        }

        public Artist GetById(int id)
        {
            Artist artist = _db.Artists.FirstOrDefault(x => x.Id == id);
            return artist;
        }

        public Artist Create(Artist artist)
        {
            var createdArtist = _db.Artists.Add(artist);
            _db.SaveChanges();
            return artist;
        }

        public Artist Update(Artist artist)
        {

            _db.SaveChanges();
            return artist;

        }

        public Artist Delete(Artist artist)
        {
            var deletedArtist = _db.Artists.Remove(artist);
            return artist;
            
        }
    }
}
