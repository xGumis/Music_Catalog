using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Katalog_Muzyki
{
    class Catalog_Item : IXmlSerializable
    {
        private Attributes.Artist[] featArtists;
        private Attributes.Genre[] genres;
        public Attributes.Title Title { get; set; }
        public Attributes.Duration Duration { get; set; }
        public Attributes.HoldingFile File { get; set; }
        public  Attributes.Album Album { get; set; }
        public Attributes.Artist MainArtist { get; set; }
        public Attributes.Artist[] FeatArtist
        {
            get
            {
                if (featArtists == null || featArtists.Length < 1)
                {
                    return null;
                }
                return featArtists;
            }
            set
            {
                featArtists = value;
            }
        }
        public Attributes.Genre[] Genres {
            get
            {
                if (genres == null || genres.Length < 1)
                {
                    return null;
                }
                return genres;
            }
            set
            {
                genres = value;
            }
        }
        public Catalog_Item(Attributes.Artist[] artist, Attributes.Title title, Attributes.Album album, Attributes.Genre[] genre, Attributes.Duration duration, Attributes.HoldingFile file)
        {
            this.Title = title;
            this.Album = album;
            if(artist != null && artist.Length > 0)
            {
                this.MainArtist = artist[0];
                if (artist.Length > 1)
                {
                    Attributes.Artist[] tmp = new Attributes.Artist[artist.Length - 1];
                    for (int i = 1; i < artist.Length; i++)
                    {
                        tmp[i - 1] = artist[i];
                    }
                    this.featArtists = tmp;
                }
                else this.featArtists = new Attributes.Artist[] { };
            }
            if (genre != null)
            {
                if (genre.Length > 0)
                {
                    Attributes.Genre[] tmp = new Attributes.Genre[genre.Length];
                    for (int i = 0; i < genre.Length; i++)
                    {
                        tmp[i] = genre[i];
                    }
                    this.genres = tmp;
                }
            }
            else this.genres = new Attributes.Genre[] { };
            this.File = file;
            this.Duration = duration;
         }
        public Catalog_Item(XmlReader reader)
        {
            ReadXml(reader);
        }
        public bool Equals(Catalog_Item x)
        {
            if (x.Title.GetValue() == this.Title.GetValue())
                if (x.Album.GetValue() == this.Album.GetValue())
                    if (x.Duration.GetValue() == this.Duration.GetValue())
                        if (x.File.GetValue() == this.File.GetValue())
                            if (x.MainArtist.GetValue() == this.MainArtist.GetValue())
                            {
                                if (!(x.FeatArtist != null ^ this.FeatArtist != null))
                                {
                                    if (x.FeatArtist != null)
                                        if (x.FeatArtist.Length == this.FeatArtist.Length)
                                        {
                                            for (int i = 0; i < x.FeatArtist.Length; i++)
                                            {
                                                if (x.FeatArtist[i].GetValue() != this.FeatArtist[i].GetValue())
                                                    return false;
                                            }}
                                        else return false;
                                    if (!(x.Genres != null ^ this.Genres != null))
                                    {
                                        if (x.Genres != null)
                                            if (x.Genres.Length == this.Genres.Length)
                                            {
                                                for (int i = 0; i < x.Genres.Length; i++)
                                                {
                                                    if (x.Genres[i].GetValue() != this.Genres[i].GetValue())
                                                        return false;
                                                }}
                                            else return false;
                                        return true;
                                    }
                                        
                                }
                            }
            return false;
        }

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            int i = 0,k=0;
            while (reader.Read())
            {
                if (reader.IsStartElement())
                {
                    if (reader.Name == "Title")
                    {
                        this.Title = new Attributes.Title(reader.ReadElementContentAsString());
                    }
                    if (reader.Name == "Duration")
                    {
                        this.Duration = new Attributes.Duration(reader.ReadElementContentAsString());
                    }
                    if (reader.Name == "Album")
                    {
                        this.Album = new Attributes.Album(reader.ReadElementContentAsString());
                    }
                    if (reader.Name == "File")
                    {
                        this.File = new Attributes.HoldingFile(reader.ReadElementContentAsString());
                    }
                    if (reader.Name == "Artist")
                    {
                        if (i < 1)
                        {
                            this.MainArtist = new Attributes.Artist(reader.ReadElementContentAsString());
                            i++;
                        }
                        else
                        {
                            Attributes.Artist[] tmp = new Attributes.Artist[i];
                            for (int j = 0; j < i-1; j++)
                            {
                                tmp[j] = FeatArtist[j];
                            }
                            tmp[i] = new Attributes.Artist(reader.ReadElementContentAsString());
                            FeatArtist = tmp;
                            i++;
                        }
                    }
                    if (reader.Name == "Genre")
                    {
                        Attributes.Genre[] tmp = new Attributes.Genre[k+1];
                        for (int j = 0; j < k; j++)
                        {
                            tmp[j] = Genres[j];
                        }
                        tmp[k] = new Attributes.Genre(reader.ReadElementContentAsString());
                        Genres = tmp;
                        k++;
                    }
                }
                if (reader.NodeType == XmlNodeType.EndElement && reader.Name == "Item") break;
            }
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteStartElement("Attributes");
            if (Title != null) writer.WriteElementString("Title", Title.GetValue());
            if (Album != null) writer.WriteElementString("Album", Album.GetValue());
            if (Duration != null) writer.WriteElementString("Duration", Duration.GetValue());
            if (File != null) writer.WriteElementString("File", File.GetValue());
            if (MainArtist != null) writer.WriteElementString("Artist", MainArtist.GetValue());
            if(FeatArtist != null)
            foreach(Attributes.Artist a in FeatArtist)
            {
                writer.WriteElementString("Artist", a.GetValue());
            }
            if(Genres != null)
            foreach(Attributes.Genre g in Genres)
            {

                writer.WriteElementString("Genre", g.GetValue());
            }
            writer.WriteEndElement();
        }
    }
}

