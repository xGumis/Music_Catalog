using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katalog_Muzyki.Attributes
{
    class Duration : AAtribute
    {
        private string time_stamp;
        public Duration(string time) : base("Duration") { this.time_stamp = time; }
        public override string GetValue() { return time_stamp; }
    }
}
