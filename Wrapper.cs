using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katalog_Muzyki
{
    public class Wrapper
    {
        string[] artist,genre;
        string title,album,duration,file;

        public string Title {
            get { return title; }
            set
            {
                if (value == "") title = "Unknown";
                else title = value;
            }
        }
        public string Album {
            get { return album; }
            set {
                if (value == "") album = "Unknown";
                else album = value;
            }
        }
        public string Duration {
            get { return duration; }
            set {
                if (value == "  :  :") duration = "---";
                else duration = value;
            }
        }
        public string File {
            get { return file; }
            set {
                if (value == "") file = "Unknown";
                else file = value;
            }
        }
        public string[] Artist {
            get { return artist; }
            set
            {
                if (value == null || value.Length < 1) artist = new string[] { "Unknown" };
                else artist = value;
            }
        }
        public string[] Genre {
            get { return genre; }
            set
            {
                if (value == null || value.Length < 1) genre = new string[] { "Unknown" };
                else genre = value;
            }
        }

    }
}
