using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace MusicViewer
{
    public partial class MusicViewer : Form
    {
        private Dictionary<string, string> idAndNamesAlbums = new Dictionary<string, string>();
        private Dictionary<string, string> idAndNamesArtists = new Dictionary<string, string>();
        private Dictionary<string, string> idAndNamesGenres = new Dictionary<string, string>();
        private IEnumerable<string> attributes = new List<string>();

        public MusicViewer()
        {
            InitializeComponent();
        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DownloadMusic();
        }

        private void ButtonLoad_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(openFileDialog.FileName);
            XmlNodeList nodes = xmlDocument.DocumentElement.ChildNodes;

            foreach (XmlNode node in nodes)
            {
                if (node.Name == "albums")
                {
                    XmlNodeList albums = node.ChildNodes;

                    foreach (XmlNode item in albums)
                    {
                        idAndNamesAlbums.Add(item.Attributes["id"].Value, item.Attributes["name"].Value);
                    }
                }

                if (node.Name == "artists")
                {
                    XmlNodeList albums = node.ChildNodes;

                    foreach (XmlNode item in albums)
                    {
                        comboBox.Items.Add(item.Attributes["name"].Value);
                        idAndNamesArtists.Add(item.Attributes["id"].Value, item.Attributes["name"].Value);
                    }
                }

                if (node.Name == "genres")
                {
                    XmlNodeList albums = node.ChildNodes;

                    foreach (XmlNode item in albums)
                    {
                        idAndNamesGenres.Add(item.Attributes["id"].Value, item.Attributes["name"].Value);
                    }
                }
            }
        }

        private void FromDateTime_ValueChanged(object sender, EventArgs e)
        {
            DownloadMusic();
        }

        private void ToDateTime_ValueChanged(object sender, EventArgs e)
        {
            DownloadMusic();
        }

        public void DownloadMusic()
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(openFileDialog.FileName);
            XmlNodeList nodes = xmlDocument.DocumentElement.ChildNodes;

            foreach (XmlNode node in nodes)
            {
                listBox1.Items.Clear();
                if (node.Name == "tracks")
                {
                    XmlNodeList tracks = node.ChildNodes;
                    foreach (XmlNode track in tracks)
                    {
                        int key = int.Parse(track.Attributes["artist-id"].Value);
                        if (comboBox.SelectedItem != null && idAndNamesArtists[key.ToString()] == comboBox.SelectedItem.ToString())
                        {
                            if (DateTime.Parse(track.Attributes["released"].Value) > fromDateTime.Value && DateTime.Parse(track.Attributes["released"].Value) < toDateTime.Value)
                            {
                                listBox1.Items.Add(track.Attributes["name"].Value);
                            }
                        }
                    }
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Zeroing();
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(openFileDialog.FileName);
            XmlNodeList nodes = xmlDocument.DocumentElement.ChildNodes;

            foreach (XmlNode node in nodes)
            {
                if (node.Name == "tracks")
                {
                    XmlNodeList tracks = node.ChildNodes;

                    foreach (XmlNode track in tracks)
                    {
                        if (track.Name == "track")
                        {
                            if (track.Attributes["name"].Value == listBox1.SelectedItem.ToString())
                            {
                                albumText.Text = idAndNamesAlbums[track.Attributes["album-id"].Value];
                                releasedText.Text = track.Attributes["released"].Value;
                                playTime.Text = track.Attributes["length"].Value;

                                XmlNodeList nodesTrack  = track.ChildNodes;

                                foreach (XmlNode nodeTrack in nodesTrack)
                                {
                                    XmlNodeList genres = nodeTrack.ChildNodes;
                                    if (nodeTrack.Name == "genres")
                                    {
                                        foreach (XmlNode genre in genres)
                                        {
                                            if (genre.Name == "genre")
                                            {
                                                genresText.Text = string.Concat(genresText.Text, idAndNamesGenres[genre.Attributes["genre-id"].Value] + ", ");
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        public void Zeroing()
        {
            albumLabel.Text = string.Empty;
            releasedLabel.Text = string.Empty;
            playTime.Text = string.Empty;
            genresText.Text = string.Empty;
        }
    }
}