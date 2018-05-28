using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4.Model
{
    interface ITrack
    {
     
        string Title { get; }

        void AddArtist(String Artist);

        List<Artist> GetArtists();
    }
}
