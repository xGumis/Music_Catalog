using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katalog_Muzyki
{
    class Presenter
    {
        IView view;
        Catalog_List model;
        public Presenter(IView view, Catalog_List model)
        {
            this.view = view;
            this.model = model;
            view.AddEntry += View_AddEntry;
            view.DeleteEntry += View_DeleteEntry;
            view.EditEntry += View_EditEntry;
            view.LoadCatalog += View_LoadCatalog;
            view.FindEntry += View_FindEntry;
            view.SaveToFile += View_SaveToFile;
            view.OpenFromFile += View_OpenFromFile;
            view.GetList += View_GetList;
            view.LoadFilteredCatalog += View_LoadFilteredCatalog;
        }

        private List<Wrapper> View_LoadFilteredCatalog(string[] arg1, string[] arg2, string[] arg3)
        {
           return model.LoadCatalog(arg1,arg2,arg3);
        }

        private string[] View_GetList(string arg)
        {
            return model.GetList(arg);
        }

        private void View_OpenFromFile(System.IO.Stream stream)
        {
            model.OpenFromFile(stream);
        }

        private void View_SaveToFile(System.IO.Stream stream)
        {
            model.SaveToFile(stream);
        }

        private int View_FindEntry(Wrapper arg)
        {
            return model.FindEntry(arg);
        }

        private List<Wrapper> View_LoadCatalog()
        {
            return model.LoadCatalog(null,null,null);
        }

        private void View_EditEntry(Wrapper arg, int index)
        {
            model.AddEntry(arg,index);
        }

        private void View_DeleteEntry(int obj)
        {
            model.DeleteEntry(obj);
        }

        private void View_AddEntry(Wrapper arg)
        {
            model.AddEntry(arg,-1);
        }
    }
}
