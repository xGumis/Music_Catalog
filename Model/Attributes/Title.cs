using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katalog_Muzyki.Attributes
{
    class Title : AAtribute
    {
        private string title;
        public Title(string title) : base("Title") { this.title = title; }
        public override string GetValue() { return title; }
    }
}
