using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Katalog_Muzyki.Attributes
{
    class HoldingFile : AAtribute
    {
        private FileInfo file;
        public HoldingFile(string path) : base("File") { this.file = new FileInfo(path); }
        public override string GetValue() { return file.Name; }
    }
}
