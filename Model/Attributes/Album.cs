using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katalog_Muzyki.Attributes
{
    class Album : AAtribute
    {
        private string title;
        public Album(string title) : base("Album") { this.title = title; }
        public override string GetValue() { return title; }
    }
}
