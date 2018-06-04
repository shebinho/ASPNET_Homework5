using Sedc.MusicManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sedc.MusicManagement.Repositories.Interfaces
{
    public interface IAlbumRepository
    {
        //Read
        IEnumerable<Album> GetAll();
        Album GetById(int id);

        //Write
        Album Create(Album album);
        Album Update(Album album);
        Album Delete(Album album);
    }
}
