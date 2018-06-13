using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katalog_Muzyki.Filters
{
    class GroupFilter : Filter
    {
        protected List<string> entries;
        public string[] GetEntries() { return entries.ToArray(); }
        public void AddEntry(string value)
        {
            if (!entries.Contains(value.Trim(),StringComparer.OrdinalIgnoreCase))
            {
                entries.Add(value);
            }
        }
        public GroupFilter(string name): base(name) { }
    }
}
