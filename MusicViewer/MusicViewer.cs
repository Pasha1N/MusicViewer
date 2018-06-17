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
        public MusicViewer()
        {
            InitializeComponent();
        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {




        }

        private void ButtonLoad_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
            using (XmlReader reader = XmlReader.Create(openFileDialog.FileName))
            {
                while (reader.Read())
                {
                    if (reader.IsStartElement())
                    {
                        if (reader.Name == "track")
                        {
                            if (reader.GetAttribute("artist-id") != null)
                            {
                                bool addMore = true;

                                foreach (string item in comboBox.Items)
                                {
                                    if (item == ConverteToName(reader.GetAttribute("artist-id")))
                                    {
                                        addMore = false;
                                        break;
                                    }
                                }

                                if(addMore)
                                {
                                    comboBox.Items.Add(ConverteToName(reader.GetAttribute("artist-id")));
                                }
                            }
                        }
                    }
                }
            }
        }

        public string ConverteToName(string id)
        {
            string conversionResult = null;

            if (id == "1")
            {
                conversionResult = "Deftones";
            }
            else if (id == "2")
            {
                conversionResult = "Adema";
            }
            else if (id == "3")
            {
                conversionResult = "Marilyn Manson";
            }
            else if (id == "4")
            {
                conversionResult = "Red Hot Chili Peppers";
            }

            return conversionResult;
        }
    }
}