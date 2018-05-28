using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4.Model
{
    class Song : ITrack
    {
        private string title;
        private double duration;
        private List<Artist> artists = new List<Artist>();

        public Song(string title, double duration, string artist)
        {
            Title = title;
            Duration = duration;
            AddArtist(artist);
        }

        public void AddArtist(string artist)
        {
            Artist newArtist = new Artist(artist);
            this.artists.Add(newArtist);
        }

        public List<Artist> GetArtists()
        {
            return this.artists;
        }

        public double Duration
        {
            get
            {
                return this.duration;
            }
            set
            {
                // the keyword 'value' represents the value that is assigned
                if (value < 0) throw new Exception("Duration must not be negative.");
                this.duration = value;
            }
        }

        public string Title
        {
            get
            {
                return this.title;
            }
            set
            {
                // the keyword 'value' represents the value that is assigned
                if (value == null || value.Length == 0) throw new Exception("Title must not be empty.");
                this.title = value;
            }
        }
    }

}
