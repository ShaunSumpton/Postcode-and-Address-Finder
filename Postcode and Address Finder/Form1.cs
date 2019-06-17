using System;
using System.Linq;
using System.Windows.Forms;
using Google.Maps.Places;
using Google.Maps.Direction;

namespace Postcode_and_Address_Finder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void button1_Click(object sender, EventArgs e)
        {
            string PostCode = textBox1.Text;

            Google.Maps.GoogleSigned.AssignAllServices(new Google.Maps.GoogleSigned("AIzaSyCHZsavlTHhco84LFZGAlZvEpVEm0YazcA"));

            TextSearchRequest request = new TextSearchRequest()
            {
                Query = textBox1.Text
            };

            var service = new PlacesService().GetResponse(request);

            var results = service.Results.First();
            var results1 = service.Results;

            int i = 0;

            foreach (PlacesResult r in results1)

            {

                listBox1.Items.Add(r.Name);
                listBox1.Items.Add(r.FormattedAddress);
                listBox1.Items.Add("");

                i++;
           }

          

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            const string sPath = @"C:\TEST FOLDER\Test.txt";

            System.IO.StreamWriter SaveFile = new System.IO.StreamWriter(sPath);
            foreach (var item in listBox1.Items)
            {
                SaveFile.WriteLine(item);
            }

            SaveFile.Close();
        }
    }

        
    }

