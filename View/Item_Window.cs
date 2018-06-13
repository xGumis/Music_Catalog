using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Katalog_Muzyki.View
{
    public partial class Item_Window : Form
    {
        #region Delegates
        public event Action<Wrapper> AddElement;
        public event Action<Wrapper,int> EditElement;
        public event Action WindowClosing;
        public event Func<int, string[]> GetList;
        #endregion
        #region Fields
        private int id;
        #endregion
        #region Constructors
        public Item_Window()
        {
            InitializeComponent();
            this.id = -1;
        }
        public Item_Window(Wrapper arg,int index)
        {
            InitializeComponent();
            textBox_artist.Lines = arg.Artist;
            textBox_title.Text = arg.Title;
            textBox_album.Text = arg.Album;
            textBox_genre.Lines = arg.Genre;
            maskedTextBox_duration.Text = arg.Duration;
            textBox_file.Tag = arg.File;
            textBox_file.Text = arg.File.Substring(arg.File.LastIndexOf('\\') + 1);
            this.id = index;
        }
        #endregion
        #region Controls methods
        private void button_file_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Audio files (*.mp3,*.wav,*.flac)|*.mp3;*.wav;*.flac|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog.FileName != null)
                {
                    textBox_file.Tag = openFileDialog.FileName;
                    textBox_file.Text = openFileDialog.SafeFileName;
                }
            }
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_Accept_Click(object sender, EventArgs e)
        {
            var arg = new Wrapper();
            arg.Artist = textBox_artist.Lines;
            arg.Title = textBox_title.Text;
            arg.Album = textBox_album.Text;
            arg.Genre = textBox_genre.Lines;
            arg.Duration = maskedTextBox_duration.Text;
            if (textBox_file.Tag == null) arg.File = "";
            else arg.File = textBox_file.Tag as string;
            if (id >= 0)
            {
                EditElement(arg, id);
            }
            else AddElement(arg);
            this.Close();
        }

        private void Item_Window_FormClosed(object sender, FormClosedEventArgs e)
        {
            WindowClosing();
        }
        #endregion

    }
}
