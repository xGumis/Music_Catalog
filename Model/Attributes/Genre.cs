using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katalog_Muzyki.Attributes
{
    class Genre : AAtribute
    {
        private string genre;
        public Genre(string genre) : base("Genre") { this.genre = genre; }
        public override string GetValue() { return genre; }
    }
}
