using System;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using GoogleApi;
using GoogleApi.Entities.Places.Search.Text.Request;
using GoogleApi.Entities.Places.Details.Request;

namespace Postcode_and_Address_Finder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string YOUR_API_KEY = "";



        public void button1_Click(object sender, EventArgs e)
        {
            string PostCode = textBox1.Text;
            object er = null;

            try
            {
                listBox1.Items.Clear();

                var request = new PlacesTextSearchRequest // get Places id from text query
                {
                    Key = YOUR_API_KEY,
                    Query = PostCode
                };

                var response = GooglePlaces.TextSearch.Query(request);

                var results = response.Results;
                var results1 = response.Results.First();
               
                

                foreach (var r in results)
                { 

                var DetReq = new PlacesDetailsRequest // do a details request using place ID
                {
                    Key = YOUR_API_KEY,
                    PlaceId = r.PlaceId
                };


                var response1 = GooglePlaces.Details.Query(DetReq);

                String r1 = response1.Result.FormattedAddress;
                string r2 = response1.Result.Name;

                listBox1.Items.Add("Name: " + r2);
                listBox1.Items.Add("Address: " + r1);
                listBox1.Items.Add("");
                    }
            }
            catch
            {
                MessageBox.Show("No Records Found");
            }
            //Google.Maps.GoogleSigned.AssignAllServices(new Google.Maps.GoogleSigned(YOUR_API_KEY));

            //TextSearchRequest request1 = new TextSearchRequest()
            //{
            //    Query = textBox1.Text
            //};

            //var service = new PlacesService().GetResponse(request1);

            //var results = service.Results.First(); // first result for query
            //var results2 = service.Results; // all results from query

            //int i = 0;

            //foreach (PlacesDetailsResponse r in response1) // add results to a list box

            //{

            //    listBox1.Items.Add("Name: " + r.Name);
            //    listBox1.Items.Add("Address: " + r.FormattedAddress);
            //    listBox1.Items.Add("");

            //    i++;
            //}


            //}
        
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

            StreamWriter SaveFile = new StreamWriter(aPath);
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



                var request = new PlacesTextSearchRequest // get Places id from text query
                {
                    Key = YOUR_API_KEY,
                    Query = textBox2.Text
                };

                var response = GooglePlaces.TextSearch.Query(request);

                var results = response.Results;
                var results1 = response.Results.First();

                int i = 0;

                foreach (var r in results) // add results to a list box

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

        private void button4_Click(object sender, EventArgs e) // Load from File
        {
            string file, dir;
            listBox2.Items.Clear();

            
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

                    var request = new PlacesTextSearchRequest // get Places id from text query
                    {
                        Key = YOUR_API_KEY,
                        Query = line
                    };

                    var response = GooglePlaces.TextSearch.Query(request);

                    var results = response.Results;
                    //var results1 = response.Results.First();


                    foreach (var r in results)
                    {
                        listBox1.Items.Add(r.FormattedAddress);
                    }


                        }
               


            }
             

                    Console.ReadLine();
            }



        }
    }
    

        
 

