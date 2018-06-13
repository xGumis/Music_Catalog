using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katalog_Muzyki.Attributes
{
    class Artist : AAtribute
    {
        private string author;
        public Artist(string author) : base("Author") { this.author = author; }
        public override string GetValue() { return author; }
    }
}
