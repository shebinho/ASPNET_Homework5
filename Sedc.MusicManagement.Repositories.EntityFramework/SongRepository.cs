using Sedc.MusicManagement.Models;
using Sedc.MusicManagement.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sedc.MusicManagement.Repositories.EntityFramework
{
    public class SongRepository : ISongRepository
    {
        private readonly MusicDb _db;

        public SongRepository()
        {
            _db = new MusicDb();
        }

        public IEnumerable<Song> GetAll()
        {
            List<Song> songs = _db.Songs.ToList();
            return songs;
        }

        public Song GetById(int id)
        {
            Song song = _db.Songs.FirstOrDefault(x => x.Id == id);
            return song;
        }

        public Song Create(Song song)
        {
            var createdArtist = _db.Songs.Add(song);
            _db.SaveChanges();
            return song;
        }

        public Song Update(Song song)
        {

            _db.SaveChanges();
            return song;

        }

        public Song Delete(Song song)
        {
            var deletedArtist = _db.Songs.Remove(song);
            return song;

        }
    }
}
