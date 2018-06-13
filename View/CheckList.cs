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
    public partial class CheckList : Form
    {
        public Action WindowClosing;
        public Action<string[]> GiveCheckedList;
        public CheckList(string[] list)
        {
            InitializeComponent();
            if(list != null)
                checkedListBox.Items.AddRange(list);
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_accept_Click(object sender, EventArgs e)
        {
            var tmp = new List<string>();
            foreach(object i in this.checkedListBox.CheckedItems)
            {
                tmp.Add(i.ToString());
            }
            if (tmp.Count > 0) GiveCheckedList(tmp.ToArray());
            else GiveCheckedList(null);
        }

        private void CheckList_FormClosing(object sender, FormClosingEventArgs e)
        {
            WindowClosing();
        }
    }
}
