using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Katalog_Muzyki
{
    public partial class Main_Window : Form, IView
    {
        #region Fields
        private List<Filters.Filter> filtersList;
        private string selectedCol;
        private int selectedIndex;
        private int sortColumn = -1;
        private string[] filterAlb, filterArt, filterGen;
        #endregion
        #region Delegates
        public event Action<Wrapper> AddEntry;
        public event Action<Wrapper, int> EditEntry;
        public event Func<Wrapper, int> FindEntry;
        public event Action<int> DeleteEntry;
        public event Func<List<Wrapper>> LoadCatalog;
        public event Action<Stream> SaveToFile;
        public event Action<Stream> OpenFromFile;
        public event Func<string, string[]> GetList;
        public event Func<string[], string[], string[], List<Wrapper>> LoadFilteredCatalog;
        #endregion
        #region Constructors
        public Main_Window()
        {
            InitializeComponent();
        }
        #endregion
        #region Controls methods
        private void Main_Window_Load(object sender, EventArgs e)
        {
            filtersList = new List<Filters.Filter>();
            filtersList.Add(new Filters.GroupFilter("Autor"));
            filtersList.Add(new Filters.Filter("Tytuł"));
            filtersList.Add(new Filters.GroupFilter("Album"));
            filtersList.Add(new Filters.GroupFilter("Gatunek"));
            filtersList.Add(new Filters.Filter("Czas trwania"));
            filtersList.Add(new Filters.Filter("Plik"));
            int width = listView_Catalog.Width;
            int count = filtersList.Count;
            foreach (Filters.Filter f in filtersList)
            {
                listView_Catalog.Columns.Add(f.Name, width / count);
                if (f is Filters.GroupFilter)
                {
                    filterToolStripMenuItem.DropDownItems.Add(f.Name);
                    grupToolStripMenuItem.DropDownItems.Add(f.Name);
                }
            }
            foreach (ToolStripDropDownItem i in filterToolStripMenuItem.DropDownItems)
            {
                i.Click += filterToolStrip_Click;
            }
            foreach (ToolStripDropDownItem i in grupToolStripMenuItem.DropDownItems)
            {
                i.Click += groupToolStrip_Click;
            }
        }
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream stream;
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
            open.FilterIndex = 1;
            open.RestoreDirectory = true;
            if (open.ShowDialog() == DialogResult.OK)
            {
                if ((stream = open.OpenFile()) != null)
                {
                    OpenFromFile(stream);
                    stream.Close();
                    Unpack_List(LoadCatalog());
                }
            }
        }
        private void contextMenuStrip_list_Opening(object sender, CancelEventArgs e)
        {
            if (listView_Catalog.SelectedItems.Count < 1)
            {
                editToolStripMenuItem.Enabled = false;
                deleteToolStripMenuItem.Enabled = false;
            }
            else
            {
                editToolStripMenuItem.Enabled = true;
                deleteToolStripMenuItem.Enabled = true;
            }
        }
        private void zapiszToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream stream;
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
            save.FilterIndex = 1;
            save.RestoreDirectory = true;
            save.OverwritePrompt = true;
            if (save.ShowDialog() == DialogResult.OK)
            {
                if ((stream = save.OpenFile()) != null)
                {
                    SaveToFile(stream);
                    stream.Close();
                }
            }
        }
        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            View.Item_Window tmp = new View.Item_Window();
            tmp.AddElement += Item_AddElement;
            tmp.WindowClosing += Item_Closing;
            this.Enabled = false;
            tmp.Show();
        }
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var tmp = new Wrapper();
            ListViewItem item = listView_Catalog.SelectedItems[0];
            selectedIndex = listView_Catalog.SelectedIndices[0];
            tmp.Artist = item.Tag as string[];
            tmp.Title = item.SubItems[1].Text;
            tmp.Album = item.SubItems[2].Text;
            tmp.Genre = item.SubItems[3].Tag as string[];
            tmp.Duration = item.SubItems[4].Text;
            tmp.File = item.SubItems[5].Tag as string;
            int id = FindEntry(tmp);
            View.Item_Window window = new View.Item_Window(tmp, id);
            window.EditElement += Item_EditElement;
            window.WindowClosing += Item_Closing;
            this.Enabled = false;
            window.Show();

        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var tmp = new Wrapper();
            ListViewItem item = listView_Catalog.SelectedItems[0];
            tmp.Artist = item.Tag as string[];
            tmp.Title = item.SubItems[1].Text;
            tmp.Album = item.SubItems[2].Text;
            tmp.Genre = item.SubItems[3].Tag as string[];
            tmp.Duration = item.SubItems[4].Text;
            tmp.File = item.SubItems[5].Tag as string;
            int id = FindEntry(tmp);
            DeleteEntry(id);
            listView_Catalog.Items.Remove(item);
        }
        private void listView_Catalog_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Determine whether the column is the same as the last column clicked.
            if (e.Column != sortColumn)
            {
                // Set the sort column to the new column.
                sortColumn = e.Column;
                // Set the sort order to ascending by default.
                listView_Catalog.Sorting = SortOrder.Ascending;
            }
            else
            {
                // Determine what the last sort order was and change it.
                if (listView_Catalog.Sorting == SortOrder.Ascending)
                    listView_Catalog.Sorting = SortOrder.Descending;
                else
                    listView_Catalog.Sorting = SortOrder.Ascending;
            }

            // Call the sort method to manually sort.
            listView_Catalog.Sort();
            // Set the ListViewItemSorter property to a new ListViewItemComparer
            // object.
            this.listView_Catalog.ListViewItemSorter = new ListViewItemComparer(e.Column,
                                                              listView_Catalog.Sorting);
        }
        private void filterToolStrip_Click(object sender, EventArgs e)
        {
            ToolStripDropDownItem tmp = sender as ToolStripDropDownItem;
            var window = new View.CheckList(GetList(tmp.Text));
            if (tmp.Text == "Album")
                window.CheckList_CheckTable(filterAlb);
            if (tmp.Text == "Autor")
                window.CheckList_CheckTable(filterArt);
            if (tmp.Text == "Gatunek")
                window.CheckList_CheckTable(filterGen);
            selectedCol = tmp.Text;
            window.GiveCheckedList += TakeList;
            window.WindowClosing += Item_Closing;
            this.Enabled = false;
            window.Show();
        }
        private void groupToolStrip_Click(object sender, EventArgs e)
        {
            ToolStripDropDownItem tmp = sender as ToolStripDropDownItem;
            if (tmp.Text == "Brak")
                listView_Catalog.ShowGroups = false;
            else
            {
                listView_Catalog.ShowGroups = true;
                string[] groups = GetList(tmp.Text);
                List<ListViewGroup> list = new List<ListViewGroup>();
                foreach (string str in groups)
                {
                    list.Add(new ListViewGroup(str));
                }
                listView_Catalog.Groups.AddRange(list.ToArray());
                foreach (ListViewItem item in listView_Catalog.Items)
                {
                    if (tmp.Text == "Album")
                    {
                        foreach (ListViewGroup gr in listView_Catalog.Groups)
                        {
                            if (gr.Header == item.SubItems[2].Text) item.Group = gr;
                        }
                    }
                    if (tmp.Text == "Autor")
                    {
                        foreach (ListViewGroup gr in listView_Catalog.Groups)
                        {
                            string[] text = item.Tag as string[];
                            if (gr.Header == text[0]) item.Group = gr;
                        }
                    }
                    if (tmp.Text == "Gatunek")
                    {
                        foreach (ListViewGroup gr in listView_Catalog.Groups)
                        {
                            string[] text = item.SubItems[3].Tag as string[];
                            if (gr.Header == text[0]) item.Group = gr;
                        }
                    }
                }
            }

        }
        #endregion
        #region Custom methods
        private void Item_Closing()
        {
            this.Enabled = true;
        }
        private void Item_EditElement(Wrapper arg, int index)
        {
            EditEntry(arg, index);
            listView_Catalog.Items[selectedIndex] = ListItem_Create(arg);

        }
        private void Item_AddElement(Wrapper arg)
        {
            AddEntry(arg);
            listView_Catalog.Items.Add(ListItem_Create(arg));
        }
        private ListViewItem ListItem_Create(Wrapper arg)
        {
            ListViewItem item = new ListViewItem();
            if (arg.Artist != null)
            {
                StringBuilder str = new StringBuilder(arg.Artist[0]);
                for (int i = 1; i < arg.Artist.Length; i++)
                {
                    str.AppendFormat(", {0}", arg.Artist[i]);
                }
                item.Tag = arg.Artist;
                item.Text = str.ToString();
            }
            ListViewItem.ListViewSubItem stitle = new ListViewItem.ListViewSubItem();
            stitle.Text = arg.Title;
            item.SubItems.Add(stitle);
            ListViewItem.ListViewSubItem salbum = new ListViewItem.ListViewSubItem();
            salbum.Text = arg.Album;
            item.SubItems.Add(salbum);
            ListViewItem.ListViewSubItem sgenre = new ListViewItem.ListViewSubItem();
            if (arg.Genre != null)
            {
                StringBuilder str = new StringBuilder(arg.Genre[0]);
                for (int i = 1; i < arg.Genre.Length; i++)
                {
                    str.AppendFormat(", {0}", arg.Genre[i]);
                }
                sgenre.Tag = arg.Genre;
                sgenre.Text = str.ToString();
            }
            item.SubItems.Add(sgenre);
            ListViewItem.ListViewSubItem sdur = new ListViewItem.ListViewSubItem();
            sdur.Text = arg.Duration;
            item.SubItems.Add(sdur);
            ListViewItem.ListViewSubItem sfile = new ListViewItem.ListViewSubItem();
            if (arg.File != null)
            {
                sfile.Tag = arg.File;
                sfile.Text = arg.File.Substring(arg.File.LastIndexOf('\\') + 1);
            }
            item.SubItems.Add(sfile);
            return item;
        }
        private void Unpack_List(List<Wrapper> arg)
        {
            listView_Catalog.Items.Clear();
            foreach (Wrapper wr in arg)
            {
                listView_Catalog.Items.Add(ListItem_Create(wr));
            }
        }
        private void TakeList(string[] arg)
        {
            if (selectedCol == "Album") filterAlb = arg;
            if (selectedCol == "Autor") filterArt = arg;
            if (selectedCol == "Gatunek") filterGen = arg;
            Unpack_List(LoadFilteredCatalog(filterAlb, filterArt, filterGen));
        }
        
        #endregion
    }
}
