using Sedc.MusicManagement.Models;
using System;
using System.Collections.Generic;

namespace Sedc.MusicManagement.Repositories.Interfaces
{
    public interface IArtistRepository
    {
        //Read
        IEnumerable<Artist> GetAll();
        Artist GetById(int id);

        //Write
        Artist Create(Artist artist);
        Artist Update(Artist artist);
        Artist Delete(Artist artist);
    }
}
