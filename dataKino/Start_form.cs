using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinuVorm
{
    class Start_form: System.Windows.Forms.Form
    {
        public List<string> listOfMovies;
        public List<string> listOfMovies_2;
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
            this.Size = new System.Drawing.Size(700, 900);
            this.BackgroundImage = new Bitmap("../../image/wallpaper.jpg");
            this.Text = "Cinema 'Galaxy'";
            this.Icon = Properties.Resources.cinema;

            listOfMovies_2 = new List<string>() { "Avatar", "DoctorStrange", "StarWars" };

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
                Text = listOfMovies_2[m],
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

            listOfMovies = new List<string>() { "Avatar.jpg", "DoctorStrange.jpg", "StarWars.jpg" };

            var dictionary = new Dictionary<int, string>()
            {
                {12, "Doctor Strange"},
                {13, "Avatar"},
                {14, "Star Wars"}
            };

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
            picture.ImageLocation = ($"../../image/{listOfMovies[m]}");
            choose.Hide();
            select.Show();
            lbl_w.Hide();
            nameMovie.Show();
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
                btn_scroll_back.Show();
                m++;
                picture.ImageLocation = ($"../../image/{listOfMovies[m]}");
                nameMovie.Text = listOfMovies_2[m];
                if (m == 0 || m == 2)
                {
                    nameMovie.Location = new Point(290, 50);
                }
                else
                {
                    nameMovie.Location = new Point(240, 50);
                }
            }
            if (m == 2)
            {
                btn_scroll_next.Hide();
            }

            return nameMovie.Text;
        }

        public string M1()
        {
            if (m > 0)
            {
                btn_scroll_next.Show();
                m--;
                picture.ImageLocation = ($"../../image/{listOfMovies[m]}");
                nameMovie.Text = listOfMovies_2[m];
                if (m == 0 || m == 2)
                {
                    nameMovie.Location = new Point(290, 50);
                }
                else
                {
                    nameMovie.Location = new Point(240, 50);
                }
            }
            if (m == 0)
            {
                btn_scroll_back.Hide();
            }
            return nameMovie.Text;
        }
    }
}
