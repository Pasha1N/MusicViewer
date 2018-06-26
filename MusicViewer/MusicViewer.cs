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
            toDateTime.Text = "1.1.1";

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
                        int key = int.Parse(track.Attributes["artist-id"].Value);
                        if (idAndNamesArtists[key.ToString()] == comboBox.SelectedItem.ToString())
                        {
                            if (int.Parse(track.Attributes["released"].Value) > int.Parse(fromDateTime.Value.ToString()) && int.Parse(track.Attributes["released"].Value) < int.Parse(toDateTime.Value.ToString()))
                            {
                                listBox1.Items.Add(track.Attributes["name"].Value + "<<<>>>" + track.Attributes["released"].Value);
                            }



                        }
                    }
                }
            }
        }

        private void ButtonLoad_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(openFileDialog.FileName);
            XmlNodeList nodes =xmlDocument.DocumentElement.ChildNodes;

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

                if (node.Name == "genre")
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
}