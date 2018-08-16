using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;

namespace MusicViewer
{
    public partial class MusicViewer : Form
    {
        private IEnumerable<string> attributes = new List<string>();
        private IDictionary<string, string> idAndNamesAlbums = new Dictionary<string, string>();
        private IDictionary<string, string> idAndNamesArtists = new Dictionary<string, string>();
        private IDictionary<string, string> idAndNamesGenres = new Dictionary<string, string>();     
   
        public MusicViewer()
        {
            InitializeComponent();
            toDateTime.Tag = toDateTime;
            fromDateTime.Tag = fromDateTime;
        }

        private void ButtonLoad_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                idAndNamesAlbums.Clear();
                idAndNamesArtists.Clear();
                idAndNamesGenres.Clear();
                comboBox.Items.Clear();

                List<string> artists = new List<string>();
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
                            artists.Add(item.Attributes["name"].Value);
                            idAndNamesArtists.Add(item.Attributes["id"].Value, item.Attributes["name"].Value);
                        }
                        artists.Sort();

                        foreach (string artist in artists)
                        {
                            comboBox.Items.Add(artist);
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
        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetMinOrMaxDate();
            fromDateTime.Enabled = true;
            toDateTime.Enabled = true;
            DownloadMusic();
        }

        private void FromDateTime_ValueChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            SetMinOrMaxDate();
            DownloadMusic();
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
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

                                XmlNodeList nodesTrack = track.ChildNodes;

                                foreach (XmlNode nodeTrack in nodesTrack)
                                {
                                    XmlNodeList genres = nodeTrack.ChildNodes;
                                    if (nodeTrack.Name == "genres")
                                    {
                                        List<string> genrerList = new List<string>();

                                        foreach (XmlNode genre in genres)
                                        {
                                            if (genre.Name == "genre")
                                            {
                                                genrerList.Add(idAndNamesGenres[genre.Attributes["genre-id"].Value]);
                                            }
                                        }
                                        genrerList.Sort();

                                        foreach (string item in genrerList)
                                        {
                                            genresText.Text = string.Concat(genresText.Text, item);
                                            if (genrerList[genrerList.Count - 1] != item)
                                            {
                                                genresText.Text = string.Concat(genresText.Text, ", ");
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

        private void ToDateTime_ValueChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            SetMinOrMaxDate();
            DownloadMusic();
        }

        public void DownloadMusic()
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(openFileDialog.FileName);
            XmlNodeList nodes = xmlDocument.DocumentElement.ChildNodes;
            List<string> tracksList = new List<string>();

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
                            if (DateTime.Parse(track.Attributes["released"].Value) >= fromDateTime.Value &&
                                DateTime.Parse(track.Attributes["released"].Value) <= toDateTime.Value)
                            {
                                tracksList.Add(track.Attributes["name"].Value);
                            }
                        }
                    }
                    tracksList.Sort();

                    foreach (string track in tracksList)
                    {
                        listBox1.Items.Add(track);
                    }
                }
            }
        }

        public DateTime GetMinimumOrMaximumDateReleased(string sign)
        {
            try
            {
                if (sign != ">" && sign != "<")
                {
                    throw new Exception("Concrete parameter is incorrect");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

            DateTime date = new DateTime();

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(openFileDialog.FileName);
            XmlNodeList nodes = xmlDocument.DocumentElement.ChildNodes;

            string id = null;
            bool signMore = true;
            signMore = sign == "<";

            for (int i = 1; i < idAndNamesArtists.Count + 1; i++)
            {
                if (idAndNamesArtists[i.ToString()] == comboBox.SelectedItem.ToString())
                {
                    id = i.ToString();
                    break;
                }
            }

            foreach (XmlNode node in nodes)
            {
                listBox1.Items.Clear();

                if (!signMore)
                {
                    date = DateTime.MaxValue;
                }

                if (node.Name == "tracks")
                {
                    XmlNodeList tracks = node.ChildNodes;
                    foreach (XmlNode track in tracks)
                    {
                        if (id != null && track.Attributes["album-id"].Value == id)
                        {
                            if (signMore)
                            {
                                if (DateTime.Parse(track.Attributes["released"].Value) > date)
                                {
                                    date = DateTime.Parse(track.Attributes["released"].Value);
                                }
                            }
                            else
                            {
                                if (DateTime.Parse(track.Attributes["released"].Value) < date)
                                {
                                    date = DateTime.Parse(track.Attributes["released"].Value);
                                }
                            }
                        }
                    }
                }
            }
            return date;
        }

        public void SetMinOrMaxDate()
        {
            toDateTime.MaxDate = DateTimePicker.MaximumDateTime;
            toDateTime.MinDate = DateTimePicker.MinimumDateTime;
            fromDateTime.MaxDate = DateTimePicker.MaximumDateTime;
            fromDateTime.MinDate = DateTimePicker.MinimumDateTime;

            toDateTime.MaxDate = GetMinimumOrMaximumDateReleased(">");
            toDateTime.MinDate = GetMinimumOrMaximumDateReleased("<");
            fromDateTime.MaxDate = GetMinimumOrMaximumDateReleased(">");
            fromDateTime.MinDate = GetMinimumOrMaximumDateReleased("<");
        }

        public void Zeroing()
        {
            albumText.Text = string.Empty;
            releasedText.Text = string.Empty;
            playTime.Text = string.Empty;
            genresText.Text = string.Empty;
        }
    }
}