using Sedc.MusicManagement.Models;
using System.Configuration;
using System.Data.Entity;

namespace Sedc.MusicManagement.Repositories.EntityFramework
{
    public class MusicDb : DbContext
    {
        public MusicDb()
        {

        }
        public DbSet<Artist> Artists { get; set; }

        public DbSet<Album> Albums { get; set; }

        public DbSet<Song> Songs { get; set; }
    }
}
