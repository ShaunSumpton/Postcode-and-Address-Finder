using System;
using System.Linq;
using System.Windows.Forms;
using Google.Maps.Places;
using System.IO;


namespace Postcode_and_Address_Finder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string YOUR_API_KEY = "AIzaSyC-9zzqbbwKwFeVnajSAAacruCJFljqahI";

        public void button1_Click(object sender, EventArgs e)
        {
            string PostCode = textBox1.Text;
            object er = null;

            try
            {
                listBox1.Items.Clear();

                Google.Maps.GoogleSigned.AssignAllServices(new Google.Maps.GoogleSigned(YOUR_API_KEY));

                TextSearchRequest request = new TextSearchRequest()
                {
                    Query = textBox1.Text
                };

                var service = new PlacesService().GetResponse(request);

                var results = service.Results.First(); // first result for query
                var results1 = service.Results; // all results from query

                int i = 0;

                foreach (PlacesResult r in results1) // add results to a list box

                {

                    listBox1.Items.Add("Name: " + r.Name);
                    listBox1.Items.Add("Address: " + r.FormattedAddress);
                    listBox1.Items.Add("");

                    i++;
                }
                

            }
            catch
            {

                MessageBox.Show("No Records Found" + er);
            }

            
        }

        private void button2_Click(object sender, EventArgs e) // write results to a text file
        {
            string aPath;

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.Title = "Save a Text File";
            saveFileDialog1.ShowDialog();
            aPath = saveFileDialog1.FileName;

            const string sPath = @"C:\TEST FOLDER\Test.txt";

            System.IO.StreamWriter SaveFile = new System.IO.StreamWriter(aPath);
            foreach (var item in listBox1.Items)
            {
                SaveFile.WriteLine(item);
            }

            SaveFile.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string AddData = textBox2.Text;
            listBox2.Items.Clear();

            try
            {

                Google.Maps.GoogleSigned.AssignAllServices(new Google.Maps.GoogleSigned(YOUR_API_KEY));

                TextSearchRequest request = new TextSearchRequest()
                {
                    Query = textBox2.Text
                };

                var service = new PlacesService().GetResponse(request);

                var results = service.Results.First(); // first result for query
                var results1 = service.Results; // all results from query

                int i = 0;

                foreach (PlacesResult r in results1) // add results to a list box

                {

                    listBox2.Items.Add("Name" + " " + r.Name);
                    listBox2.Items.Add("Address" + " " + r.FormattedAddress);
                    listBox2.Items.Add("");

                    i++;
                }

            }
            catch
            {
                MessageBox.Show("No Records Found");
            }


        }

        private void button4_Click(object sender, EventArgs e)
        {
            string file, dir;
            listBox2.Items.Clear();

            Google.Maps.GoogleSigned.AssignAllServices(new Google.Maps.GoogleSigned(YOUR_API_KEY));

            OpenFileDialog openFileDialog2 = new OpenFileDialog(); 
            openFileDialog2.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
            openFileDialog2.ShowDialog();

            file = openFileDialog2.FileName; // get file path for PGP 
            dir = Path.GetDirectoryName(file);


            using (StreamReader sr = new StreamReader(file))
            {
                String line;

                while ((line = sr.ReadLine()) != null)
                {

                    TextSearchRequest request = new TextSearchRequest()
                    {
                        Query = line
                    };

                var service = new PlacesService().GetResponse(request);
                var results = service.Results;

                    foreach (PlacesResult r in results)
                    {
                        listBox1.Items.Add(r.FormattedAddress);
                    }


                        }
               


            }
             

                    Console.ReadLine();
            }



        }
    }
    

        
 

