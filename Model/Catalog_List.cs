using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using System.IO;
using System.Windows.Forms;

namespace Katalog_Muzyki
{
    public class Catalog_List : IXmlSerializable
    {
        #region Fields
        private List<Attributes.Album> albumsList;
        private List<Attributes.Artist> artistsList;
        private List<Attributes.Genre> genresList;
        private List<Catalog_Item> list;
        #endregion
        #region Data mangement
        private Catalog_Item Create_Item(Wrapper arg)
        {
            #region Ini
            Attributes.HoldingFile arg_file;
            Attributes.Duration arg_duration;
            Attributes.Album arg_album;
            Attributes.Title arg_title;
            Attributes.Artist[] arg_artist;
            Attributes.Genre[] arg_genre;
            #endregion
            #region Unique
            if (arg.File != null) arg_file = new Attributes.HoldingFile(arg.File);
            else arg_file = null;
            if (arg.Duration != null) arg_duration = new Attributes.Duration(arg.Duration);
            else arg_duration = null;
            if (arg.Title != null) arg_title = new Attributes.Title(arg.Title);
            else arg_title = null;
            #endregion
            #region Lists elements
            if (arg.Album != null)
            {
                arg.Album = arg.Album.Trim();
                if (albumsList == null) albumsList = new List<Attributes.Album>();
                int indx = albumsList.FindIndex(x => x.GetValue().ToLower() == arg.Album.ToLower());
                if (indx >= 0) arg_album = albumsList[indx];
                else
                {
                    Attributes.Album temp = new Attributes.Album(arg.Album);
                    albumsList.Add(temp);
                    arg_album = temp;
                }
            }
            else arg_album = null;

            if (arg.Artist != null)
            {
                if (artistsList == null) artistsList = new List<Attributes.Artist>();
                arg_artist = new Attributes.Artist[arg.Artist.Length];
                for (int i = 0; i < arg.Artist.Length; i++)
                {
                    int indx = artistsList.FindIndex(x => x.GetValue().ToLower() == arg.Artist[i].ToLower().Trim());
                    if (indx >= 0) arg_artist[i] = artistsList[indx];
                    else
                    {
                        Attributes.Artist temp = new Attributes.Artist(arg.Artist[i].Trim());
                        artistsList.Add(temp);
                        arg_artist[i] = temp;
                    }
                }
            }
            else arg_artist = null;

            if (arg.Genre != null)
            {
                if (genresList == null) genresList = new List<Attributes.Genre>();
                arg_genre = new Attributes.Genre[arg.Genre.Length];
                for (int i = 0; i < arg.Genre.Length; i++)
                {
                    int indx = genresList.FindIndex(x => x.GetValue().ToLower() == arg.Genre[i].ToLower().Trim());
                    if (indx >= 0) arg_genre[i] = genresList[indx];
                    else
                    {
                        Attributes.Genre temp = new Attributes.Genre(arg.Genre[i].Trim());
                        genresList.Add(temp);
                        arg_genre[i] = temp;
                    }
                }
            }
            else arg_genre = null;
            #endregion
            return new Catalog_Item(arg_artist, arg_title, arg_album, arg_genre, arg_duration, arg_file);
        }
        public int AddEntry(Wrapper arg,int index)
        {
            if (list == null)
            {
                list = new List<Catalog_Item>();
            }
            Catalog_Item tmp = Create_Item(arg);
            if(index>=0)list[index] = tmp;
            else list.Add(tmp);
            return list.Count;
        }
        public void DeleteEntry(int id) { list.RemoveAt(id); }
        public List<Wrapper> LoadCatalog(string[] albums, string[] artists, string[] genres)
        {
            List<Wrapper> list = new List<Wrapper>();
            foreach (Catalog_Item i in this.list)
            {
                if (albums != null)
                    if (!albums.Contains(i.Album.GetValue()))
                        continue;
                if(artists != null)
                {
                    if (!artists.Contains(i.MainArtist.ToString()))
                    {
                        if (i.FeatArtist == null) continue;
                        else
                        {
                            bool flag = false;
                            foreach(Attributes.Artist a in i.FeatArtist)
                            {
                                if (artists.Contains(a.GetValue())) flag = true;
                            }
                            if (flag == false) continue;
                        }
                    }
                }
                if(genres != null)
                {
                    if (i.Genres == null) continue;
                    else
                    {
                        bool flag = false;
                        foreach (Attributes.Genre g in i.Genres)
                        {
                            if (genres.Contains(g.GetValue())) flag = true;
                        }
                        if (flag == false) continue;
                    }
                }

                Wrapper tmp = new Wrapper();
                if (i.MainArtist != null)
                {
                    List<string> tmptable = new List<string>();
                    tmptable.Add(i.MainArtist.GetValue());
                    if(i.FeatArtist != null)
                    foreach (Attributes.Artist a in i.FeatArtist)
                    {
                        tmptable.Add(a.GetValue());
                    }
                    tmp.Artist = tmptable.ToArray();
                }
                else tmp.Artist = null;
                if (i.Title != null)
                {
                    tmp.Title =  i.Title.GetValue();
                }
                else tmp.Title = null;
                if (i.Album != null)
                {
                    tmp.Album =  i.Album.GetValue();
                }
                else tmp.Album = null;
                if (i.Genres != null)
                {
                    List<string> tmptable = new List<string>();
                    foreach (Attributes.Genre a in i.Genres)
                    {
                        tmptable.Add(a.GetValue());
                    }
                    tmp.Genre = tmptable.ToArray();
                }
                else tmp.Genre = null;
                if (i.Duration != null)
                {
                    tmp.Duration = i.Duration.GetValue();
                }
                else tmp.Duration = null;
                if (i.File != null)
                {
                    tmp.File = i.File.GetValue();
                }
                else tmp.File = null;
                list.Add(tmp);
            }
            return list;
        }
        public int FindEntry(Wrapper arg)
        {
            Catalog_Item tmp = Create_Item(arg);
            if (list != null)
            {
                return list.FindIndex(x => x.Equals(tmp));
            }
            return -1;
        }
        public string[] GetList(string arg)
        {
            if (arg == "Album")
            {
                if (albumsList != null)
                {
                    var tab = new string[albumsList.Count];
                    for(int i =0; i< albumsList.Count; i++)
                    {
                        tab[i] = albumsList[i].GetValue();
                    }
                    return tab;
                }
            }
            if (arg == "Autor")
            {
                if (artistsList != null)
                {
                    var tab = new string[artistsList.Count];
                    for (int i = 0; i < artistsList.Count; i++)
                    {
                        tab[i] = artistsList[i].GetValue();
                    }
                    return tab;
                }
            }
            if (arg == "Gatunek")
            {
                if (genresList != null)
                {
                    var tab = new string[genresList.Count];
                    for (int i = 0; i < genresList.Count; i++)
                    {
                        tab[i] = genresList[i].GetValue();
                    }
                    return tab;
                }
            }
            return null;
        }
        #endregion

        #region File management
        public void SaveToFile(Stream stream)
        {
            XmlSerializer xs = new XmlSerializer(typeof(Catalog_List));
            xs.Serialize(stream, this);
        }
        public void OpenFromFile(Stream stream)
        {
            XmlReaderSettings sett = new XmlReaderSettings();
            XmlReader reader = XmlReader.Create(stream, sett);
            ReadXml(reader);
        }
        public XmlSchema GetSchema()
        {
            return null;
        }
        public void ReadXml(XmlReader reader)
        {
            while (reader.Read())
            {
                if (reader.IsStartElement())
                {
                    if(reader.Name == "Items")
                    {
                        Loading_Items(reader);
                    }
                    if(reader.Name == "Albums_List")
                    {
                        Loading_AlbumList(reader);
                    }
                    if (reader.Name == "Artists_List")
                    {
                        Loading_ArtistList(reader);
                    }
                    if (reader.Name == "Genres_List")
                    {
                        Loading_GenreList(reader);
                    }
                }
            }
        }
        public void WriteXml(XmlWriter writer)
        {
            writer.WriteStartElement("Items");
            foreach(Catalog_Item item in list)
            {
                writer.WriteStartElement("Item");
                item.WriteXml(writer);
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
            writer.WriteStartElement("Albums_List");
            foreach (Attributes.Album a in albumsList)
            {
                writer.WriteStartElement("Album");
                a.WriteXml(writer);
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
            writer.WriteStartElement("Artists_List");
            foreach (Attributes.Artist a in artistsList)
            {
                writer.WriteStartElement("Artist");
                a.WriteXml(writer);
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
            writer.WriteStartElement("Genres_List");
            foreach (Attributes.Genre g in genresList)
            {
                writer.WriteStartElement("Genre");
                g.WriteXml(writer);
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
        }
        private void Loading_Items(XmlReader reader)
        {
            list = new List<Catalog_Item>();
            while (reader.Read())
            {
                if (reader.IsStartElement())
                {
                    if (reader.Name == "Item")
                    {
                        list.Add(new Catalog_Item(reader));
                    }
                }
                if (reader.NodeType == XmlNodeType.EndElement && reader.Name == "Items") break;
            }
        }
        private void Loading_AlbumList(XmlReader reader)
        {
            albumsList = new List<Attributes.Album>();
            while (reader.Read())
            {
                if (reader.IsStartElement())
                {
                    if(reader.Name == "Album")
                    {
                        albumsList.Add(new Attributes.Album(reader.ReadElementContentAsString()));
                    }
                }
                if (reader.NodeType == XmlNodeType.EndElement && reader.Name == "Albums_List") break;

            }
        }
        private void Loading_ArtistList(XmlReader reader)
        {
            artistsList = new List<Attributes.Artist>();
            while (reader.Read())
            {
                if (reader.IsStartElement())
                {
                    if (reader.Name == "Artist")
                    {
                        artistsList.Add(new Attributes.Artist(reader.ReadElementContentAsString()));
                    }
                }
                if (reader.NodeType == XmlNodeType.EndElement && reader.Name == "Artists_List") break;

            }
        }
        private void Loading_GenreList(XmlReader reader)
        {
            genresList = new List<Attributes.Genre>();
            while (reader.Read())
            {
                if (reader.IsStartElement())
                {
                    if (reader.Name == "Genre")
                    {
                        genresList.Add(new Attributes.Genre(reader.ReadElementContentAsString()));
                    }
                }
                if (reader.NodeType == XmlNodeType.EndElement && reader.Name == "Genres_List") break;

            }
        }
        #endregion
    }
}
