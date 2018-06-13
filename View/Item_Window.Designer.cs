namespace Katalog_Muzyki.View
{
    partial class Item_Window
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox_artist = new System.Windows.Forms.TextBox();
            this.textBox_album = new System.Windows.Forms.TextBox();
            this.textBox_title = new System.Windows.Forms.TextBox();
            this.textBox_genre = new System.Windows.Forms.TextBox();
            this.textBox_file = new System.Windows.Forms.TextBox();
            this.label_artist = new System.Windows.Forms.Label();
            this.label_title = new System.Windows.Forms.Label();
            this.label_album = new System.Windows.Forms.Label();
            this.label_genre = new System.Windows.Forms.Label();
            this.label_duration = new System.Windows.Forms.Label();
            this.label_file = new System.Windows.Forms.Label();
            this.button_file = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.button_Accept = new System.Windows.Forms.Button();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.maskedTextBox_duration = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // textBox_artist
            // 
            this.textBox_artist.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_artist.Location = new System.Drawing.Point(91, 28);
            this.textBox_artist.Multiline = true;
            this.textBox_artist.Name = "textBox_artist";
            this.textBox_artist.Size = new System.Drawing.Size(246, 72);
            this.textBox_artist.TabIndex = 0;
            // 
            // textBox_album
            // 
            this.textBox_album.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_album.Location = new System.Drawing.Point(91, 129);
            this.textBox_album.Name = "textBox_album";
            this.textBox_album.Size = new System.Drawing.Size(246, 20);
            this.textBox_album.TabIndex = 1;
            // 
            // textBox_title
            // 
            this.textBox_title.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_title.Location = new System.Drawing.Point(91, 103);
            this.textBox_title.Name = "textBox_title";
            this.textBox_title.Size = new System.Drawing.Size(246, 20);
            this.textBox_title.TabIndex = 2;
            // 
            // textBox_genre
            // 
            this.textBox_genre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_genre.Location = new System.Drawing.Point(91, 155);
            this.textBox_genre.Multiline = true;
            this.textBox_genre.Name = "textBox_genre";
            this.textBox_genre.Size = new System.Drawing.Size(246, 72);
            this.textBox_genre.TabIndex = 3;
            // 
            // textBox_file
            // 
            this.textBox_file.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_file.Location = new System.Drawing.Point(91, 259);
            this.textBox_file.Name = "textBox_file";
            this.textBox_file.ReadOnly = true;
            this.textBox_file.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.textBox_file.Size = new System.Drawing.Size(246, 20);
            this.textBox_file.TabIndex = 5;
            // 
            // label_artist
            // 
            this.label_artist.AutoSize = true;
            this.label_artist.Location = new System.Drawing.Point(40, 28);
            this.label_artist.Name = "label_artist";
            this.label_artist.Size = new System.Drawing.Size(45, 13);
            this.label_artist.TabIndex = 6;
            this.label_artist.Text = "Artysta: ";
            // 
            // label_title
            // 
            this.label_title.AutoSize = true;
            this.label_title.Location = new System.Drawing.Point(47, 103);
            this.label_title.Name = "label_title";
            this.label_title.Size = new System.Drawing.Size(38, 13);
            this.label_title.TabIndex = 7;
            this.label_title.Text = "Tytuł: ";
            // 
            // label_album
            // 
            this.label_album.AutoSize = true;
            this.label_album.Location = new System.Drawing.Point(43, 132);
            this.label_album.Name = "label_album";
            this.label_album.Size = new System.Drawing.Size(42, 13);
            this.label_album.TabIndex = 8;
            this.label_album.Text = "Album: ";
            // 
            // label_genre
            // 
            this.label_genre.AutoSize = true;
            this.label_genre.Location = new System.Drawing.Point(34, 158);
            this.label_genre.Name = "label_genre";
            this.label_genre.Size = new System.Drawing.Size(51, 13);
            this.label_genre.TabIndex = 9;
            this.label_genre.Text = "Gatunek:";
            // 
            // label_duration
            // 
            this.label_duration.AutoSize = true;
            this.label_duration.Location = new System.Drawing.Point(12, 233);
            this.label_duration.Name = "label_duration";
            this.label_duration.Size = new System.Drawing.Size(73, 13);
            this.label_duration.TabIndex = 10;
            this.label_duration.Text = "Czas trwania: ";
            // 
            // label_file
            // 
            this.label_file.AutoSize = true;
            this.label_file.Location = new System.Drawing.Point(55, 259);
            this.label_file.Name = "label_file";
            this.label_file.Size = new System.Drawing.Size(30, 13);
            this.label_file.TabIndex = 11;
            this.label_file.Text = "Plik: ";
            // 
            // button_file
            // 
            this.button_file.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_file.Location = new System.Drawing.Point(275, 285);
            this.button_file.Name = "button_file";
            this.button_file.Size = new System.Drawing.Size(62, 23);
            this.button_file.TabIndex = 12;
            this.button_file.Text = "Wybierz..";
            this.button_file.UseVisualStyleBackColor = true;
            this.button_file.Click += new System.EventHandler(this.button_file_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // button_Accept
            // 
            this.button_Accept.Location = new System.Drawing.Point(15, 309);
            this.button_Accept.Name = "button_Accept";
            this.button_Accept.Size = new System.Drawing.Size(75, 23);
            this.button_Accept.TabIndex = 13;
            this.button_Accept.Text = "Zatwierdź";
            this.button_Accept.UseVisualStyleBackColor = true;
            this.button_Accept.Click += new System.EventHandler(this.button_Accept_Click);
            // 
            // button_Cancel
            // 
            this.button_Cancel.Location = new System.Drawing.Point(96, 309);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(75, 23);
            this.button_Cancel.TabIndex = 14;
            this.button_Cancel.Text = "Anuluj";
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // maskedTextBox_duration
            // 
            this.maskedTextBox_duration.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.maskedTextBox_duration.Location = new System.Drawing.Point(91, 233);
            this.maskedTextBox_duration.Mask = "00:00:00";
            this.maskedTextBox_duration.Name = "maskedTextBox_duration";
            this.maskedTextBox_duration.Size = new System.Drawing.Size(246, 20);
            this.maskedTextBox_duration.TabIndex = 15;
            this.maskedTextBox_duration.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Item_Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 351);
            this.Controls.Add(this.maskedTextBox_duration);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_Accept);
            this.Controls.Add(this.button_file);
            this.Controls.Add(this.label_file);
            this.Controls.Add(this.label_duration);
            this.Controls.Add(this.label_genre);
            this.Controls.Add(this.label_album);
            this.Controls.Add(this.label_title);
            this.Controls.Add(this.label_artist);
            this.Controls.Add(this.textBox_file);
            this.Controls.Add(this.textBox_genre);
            this.Controls.Add(this.textBox_title);
            this.Controls.Add(this.textBox_album);
            this.Controls.Add(this.textBox_artist);
            this.Name = "Item_Window";
            this.Text = "Szczegóły";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Item_Window_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_artist;
        private System.Windows.Forms.TextBox textBox_album;
        private System.Windows.Forms.TextBox textBox_title;
        private System.Windows.Forms.TextBox textBox_genre;
        private System.Windows.Forms.TextBox textBox_file;
        private System.Windows.Forms.Label label_artist;
        private System.Windows.Forms.Label label_title;
        private System.Windows.Forms.Label label_album;
        private System.Windows.Forms.Label label_genre;
        private System.Windows.Forms.Label label_duration;
        private System.Windows.Forms.Label label_file;
        private System.Windows.Forms.Button button_file;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button button_Accept;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_duration;
    }
}