using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinuVorm
{
    class Start_form: System.Windows.Forms.Form
    {
        public static Administrator admin = new Administrator();

        public string conn_KinoDB = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Admin\source\repos\dataCinema\dataKino\AppData\Kino_DB.mdf;Integrated Security=True";
        public SqlConnection connect_to_DB;
        public SqlCommand command;
        public SqlDataAdapter adapter;
        public static List<string> listOfPictures, listOfNames;
        public Label nameMovie;
        Label lbl_w;
        public PictureBox picture;
        Button btn_scroll_back;
        Button btn_scroll_next;
        Button choose;
        Button select;
        Button administrator;
        public string rt;
        //----------------
        public static int m = 1;

        public Start_form()
        {
            connect_to_DB = new SqlConnection(conn_KinoDB);
            this.Size = new System.Drawing.Size(700, 900);
            this.BackgroundImage = new Bitmap("../../image/wallpaper.jpg");
            this.Text = "Cinema 'Galaxy'";
            this.Icon = Properties.Resources.cinema;



            //listOfMovies_2 = new List<string>() { "Avatar", "DoctorStrange", "StarWars" };
            //listOfMovies = new List<string>() { "Avatar.jpg", "DoctorStrange.jpg", "StarWars.jpg" };
            listOfNames = new List<string>();
            listOfPictures = new List<string>();
            GetFromDB();
            administrator = new Button()
            {
                Text = "Add movie",
                Size = new Size(100, 40),
                BackColor = Color.Purple,
                ForeColor = Color.White,
                Location = new Point(10, 10),
                Font = new Font(Font.FontFamily, 10)
            };

            administrator.Click += Administrator_Click;

            nameMovie = new Label()
            {
                Text = listOfNames[m],
                Font = new Font(Font.FontFamily, 20),
                Location = new Point(240, 50),
                BackColor = Color.Purple,
                ForeColor = Color.White,
                AutoSize = true
            };
           
            nameMovie.Hide();

            lbl_w = new Label()
            {
                Text = "Welcome to 'Galaxy!'",
                Font = new Font(Font.FontFamily, 20),
                Location = new Point(215, 50),
                BackColor = Color.Purple,
                ForeColor = Color.White
            };

            Size size_pl = TextRenderer.MeasureText(lbl_w.Text, lbl_w.Font);
            lbl_w.Size = new Size(size_pl.Width, size_pl.Height);

            /*admin.connect_to_DB.Open();
            DataTable tabel = new DataTable();
            dataGridView = new DataGridView();

            SqlDataAdapter adapter = new SqlDataAdapter("select name, dateM from [dbo].[Movie]", admin.connect_to_DB);
            adapter.Fill(tabel);
            dataGridView.DataSource = tabel;
            dataGridView.Location = new Point(210, 175);
            dataGridView.Size = new Size(240, 200);
            this.Controls.Add(dataGridView);
            connect_to_DB.Close();*/

            picture = new PictureBox()
            {
                Size = new Size(400, 650),
                Location = new Point(140, 100),
                ImageLocation = ("../../image/start.gif"),
                SizeMode = PictureBoxSizeMode.StretchImage
            };

            //----------------------------------------------------------
            btn_scroll_back = new Button()
            {
                Size = new Size(75, 75),
                Location = new Point(40, 320),
                BackgroundImage = new Bitmap("../../image/left.png"),
            };
            
            btn_scroll_back.Click += Btn_scroll_back_Click;
            btn_scroll_back.Hide();

            btn_scroll_next = new Button()
            {
                Size = new Size(75, 75),
                Location = new Point(570, 320),
                BackgroundImage = new Bitmap("../../image/right.png"),
            };

            btn_scroll_next.Click += Btn_scroll_next_Click;
            btn_scroll_next.Hide();
            //----------------------------------------------------------

            

            /*var dictionary = new Dictionary<int, string>()
            {
                {12, "Doctor Strange"},
                {13, "Avatar"},
                {14, "Star Wars"}
            };*/

            choose = new Button()
            {
                Text = "Start choosing a movie",
                Size = new Size(160, 40),
                BackColor = Color.Purple,
                ForeColor = Color.White,
                Location = new Point(265, 780),
                Font = new Font(Font.FontFamily, 10)
            };

            choose.Click += Choose_Click;
            
            select = new Button()
            {
                Text = "Select movie",
                Size = new Size(160, 40),
                BackColor = Color.Purple,
                ForeColor = Color.White,
                Location = new Point(265, 780),
                Font = new Font(Font.FontFamily, 10),
            };

            select.Click += Select_Click;
            select.Hide();
            
            this.Controls.Add(choose);
            this.Controls.Add(administrator);
            this.Controls.Add(nameMovie);
            this.Controls.Add(select);
            this.Controls.Add(lbl_w);
            this.Controls.Add(btn_scroll_back);
            this.Controls.Add(btn_scroll_next);
            this.Controls.Add(picture);           
        }

        private void GetFromDB()
        {
            listOfNames = new List<string>();
            listOfPictures = new List<string>();
            adapter = new SqlDataAdapter($"Select name, image from Movie", connect_to_DB);
            DataTable table = new DataTable();
            adapter.Fill(table);
            foreach (DataRow item in table.Rows)
            {
                listOfPictures.Add(item.ItemArray[1].ToString());
                listOfNames.Add(item.ItemArray[0].ToString());
            }
            connect_to_DB.Close();
        }

        private void Administrator_Click(object sender, EventArgs e)
        {
            Administrator admin = new Administrator();
            admin.Show();
        }

        private void Select_Click(object sender, EventArgs e)
        {            
            MyForm uus_aken = new MyForm("Choose a hall", "", "Small", "Middle", "Big", "VIP");
            uus_aken.StartPosition = FormStartPosition.CenterScreen;
            uus_aken.ShowDialog();
        }

        private void Choose_Click(object sender, EventArgs e)
        {
            btn_scroll_back.Show();
            btn_scroll_next.Show();
            picture.Image = SaveImage(listOfPictures[m]);
            choose.Hide();
            select.Show();
            lbl_w.Hide();
            nameMovie.Show();
            administrator.Hide();
        }

        public void Btn_scroll_next_Click(object sender, EventArgs e)
        {
            rt = M();
        }

        public void Btn_scroll_back_Click(object sender, EventArgs e)
        {
            rt = M1();  
        }

        public string M()
        {
            if (m <= 1)
            {
                m++;
                picture.Image = SaveImage(listOfPictures[m]);
                nameMovie.Text = listOfNames[m];
            }

            else if (m == 2)
            {
                m = 0;
                picture.Image = SaveImage(listOfPictures[m]);
                nameMovie.Text = listOfNames[m];
            }

            return nameMovie.Text;
        }

        public string M1()
        {
            if (m > 0)
            {
                m--;
                picture.Image = SaveImage(listOfPictures[m]);
                nameMovie.Text = listOfNames[m];
            }

            else if (m == 0)
            {
                m = listOfPictures.Count-1;
                picture.Image = SaveImage(listOfPictures[m]);
                nameMovie.Text = listOfNames[m];
            }
            return nameMovie.Text;
        }
        public Bitmap SaveImage(string imageUrl)
        {
            try { Uri url = new Uri(imageUrl); } catch { return null; }
            WebClient client = new WebClient();
            Stream stream; stream = client.OpenRead(imageUrl);
            Bitmap bitmap; bitmap = new Bitmap(stream);

            stream.Flush();
            stream.Close();
            client.Dispose();
            if (bitmap != null)
            {
                return bitmap;
            }
            return null;
        }
    }
}
