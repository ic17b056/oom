using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6.Models
{
    class Composition : ITrack
    {
        private string title;
        private double duration;
        private Artist composer;
        private List<Artist> artists = new List<Artist>();

        public Composition(string title, double duration, Artist composer, List<Artist> artists)
        {
            Title = title;
            Duration = duration;
            Composer = composer;
            Artists = artists;
        }

        public List<Artist> GetArtists()
        {
            return this.artists;
        }

        public List<Artist> Artists
        {
            get { return this.artists; }
            set { this.artists = value; }
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

        public Artist Composer
        {
            get
            {
                return this.composer;
            }
            set
            {
                this.composer = value;
            }
        }
    }
}
