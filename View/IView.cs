using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Katalog_Muzyki
{
    interface IView
    {
        event Action<Wrapper> AddEntry;
        event Action<Wrapper, int> EditEntry;
        event Func<Wrapper, int> FindEntry;
        event Action<int> DeleteEntry;
        event Func<List<Wrapper>> LoadCatalog;
        event Action<Stream> SaveToFile;
        event Action<Stream> OpenFromFile;
        event Func<string, string[]> GetList;
    }
}
