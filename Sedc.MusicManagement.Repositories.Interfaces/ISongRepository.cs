using Sedc.MusicManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sedc.MusicManagement.Repositories.Interfaces
{
    public interface ISongRepository
    {
        //Read
        IEnumerable<Song> GetAll();
        Song GetById(int id);

        //Write
        Song Create(Song song);
        Song Update(Song song);
        Song Delete(Song song);
    }
}
