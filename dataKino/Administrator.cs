using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinuVorm
{
    public partial class Administrator : Form
    {
        MyForm form = new MyForm();
        Start_form startForm = new Start_form();

        Label authorization;
        Label login_lbl;
        TextBox login_txt;
        Label password_lbl;
        TextBox password_txt;
        Button accept_admin;
        //-------------
        Label title;
        Label lbl1;
        Label lbl2;
        Label lbl3;
        Label lbl4;
        TextBox text1;
        TextBox text2;
        TextBox text3;
        TextBox text4;
        Button add;
        //-------------
        Label title_UP;
        Label lbl1_UP;
        Label lbl2_UP;
        Label lbl3_UP;
        Label lbl4_UP;
        TextBox text1_UP;
        TextBox text2_UP;
        TextBox text3_UP;
        TextBox text4_UP;

        Button add_UP;

        int Id;
        //-------------
        Button add_DL;

        public static string conn_KinoDB = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\opilane\source\repos\dataCinema\dataKino\AppData\Kino_DB.mdf;Integrated Security=True";

        public SqlConnection connect_to_DB = new SqlConnection(conn_KinoDB);
        public SqlCommand command;

        DataGridView dataGridView;
        DataGridView dataGridView1;
        DataGridView dataGridView2;

        public Administrator()
        {
            this.Size = new Size(450, 300);
            this.Text = "Administrator";

            this.BackgroundImage = new Bitmap("../../image/wallpaper.jpg");
            this.Icon = Properties.Resources.administrator;

            authorization = new Label()
            {
                Text = "Authorization:",
                Size = new Size(185, 35),
                Font = new Font(Font.FontFamily, 20),
                Location = new Point(140, 40),
                BackColor = Color.Purple,
                ForeColor = Color.White
            };

            login_lbl = new Label()
            {
                Text = "Login: ",
                Size = new Size(50, 20),
                Font = new Font(Font.FontFamily, 10),
                Location = new Point(150, 100),
                BackColor = Color.Purple,
                ForeColor = Color.White
            };

            login_txt = new TextBox()
            {
                Size = new Size(100, 20),
                Location = new Point(210, 100)
            };

            password_lbl = new Label()
            {
                Text = "Password: ",
                Size = new Size(80, 20),
                Font = new Font(Font.FontFamily, 10),
                Location = new Point(120, 140),
                BackColor = Color.Purple,
                ForeColor = Color.White
            };

            password_txt = new TextBox()
            {
                Size = new Size(100, 20),
                Location = new Point(210, 140),
                PasswordChar = '*'
            };

            accept_admin = new Button()
            {
                Text = "Confirm",
                Size = new Size(100, 40),
                BackColor = Color.Purple,
                ForeColor = Color.White,
                Location = new Point(170, 185),
                Font = new Font(Font.FontFamily, 10)
            };

            accept_admin.Click += Accept_admin_Click;

            this.Controls.Add(authorization);
            this.Controls.Add(login_lbl);
            this.Controls.Add(password_lbl);
            this.Controls.Add(login_txt);
            this.Controls.Add(password_txt);
            this.Controls.Add(accept_admin);                     
        }

        private void Accept_admin_Click(object sender, EventArgs e)
        {
            if (login_txt.Text == "admin" && password_txt.Text == "admin")
            {
                login_lbl.Hide();
                login_txt.Hide();
                password_lbl.Hide();
                password_txt.Hide();
                accept_admin.Hide();
                authorization.Hide();

                this.Size = new Size(700, 600);

                Button select = new Button()
                {
                    Text = "Select",
                    Size = new Size(100, 40),
                    BackColor = Color.Purple,
                    ForeColor = Color.White,
                    Location = new Point(50, 20),
                    Font = new Font(Font.FontFamily, 10)
                };

                select.Click += select_Click;

                Button insert = new Button()
                {
                    Text = "Insert",
                    Size = new Size(100, 40),
                    BackColor = Color.Purple,
                    ForeColor = Color.White,
                    Location = new Point(210, 20),
                    Font = new Font(Font.FontFamily, 10)
                };

                insert.Click += Insert_Click;

                Button update = new Button()
                {
                    Text = "Update",
                    Size = new Size(100, 40),
                    BackColor = Color.Purple,
                    ForeColor = Color.White,
                    Location = new Point(375, 20),
                    Font = new Font(Font.FontFamily, 10)
                };

                update.Click += Update_Click;

                Button delete = new Button()
                {
                    Text = "Delete",
                    Size = new Size(100, 40),
                    BackColor = Color.Purple,
                    ForeColor = Color.White,
                    Location = new Point(530, 20),
                    Font = new Font(Font.FontFamily, 10)
                };

                delete.Click += Delete_Click;

                this.Controls.Add(select);
                this.Controls.Add(insert);
                this.Controls.Add(update);
                this.Controls.Add(delete);
            }
            else
            {
                login_txt.Text = "";
                password_txt.Text = "";
                MessageBox.Show("Error, uncorrect login or password");                
            }
        }

        private void select_Click(object sender, EventArgs e)
        {
            this.Size = new Size(700, 600);
            connect_to_DB.Open();
            DataTable tabel = new DataTable();
            dataGridView = new DataGridView();

            SqlDataAdapter adapter = new SqlDataAdapter("select name, dateM from [dbo].[Movie]", connect_to_DB);
            adapter.Fill(tabel);
            dataGridView.DataSource = tabel;
            dataGridView.Location = new Point(210, 175);
            dataGridView.Size = new Size(240, 200);
            this.Controls.Add(dataGridView);
            connect_to_DB.Close();

            if (title != null)
            {
                title.Hide();
                lbl1.Hide();
                lbl2.Hide();
                lbl3.Hide();
                lbl4.Hide();
                text1.Hide();
                text2.Hide();
                text3.Hide();
                text4.Hide();
                add.Hide();
            }

            if (title_UP != null)
            {
                title_UP.Hide();
                lbl1_UP.Hide();
                lbl2_UP.Hide();
                lbl3_UP.Hide();
                lbl4_UP.Hide();
                text1_UP.Hide();
                text2_UP.Hide();
                text3_UP.Hide();
                text4_UP.Hide();
                add_UP.Hide();
                dataGridView1.Hide();
            }


            if (add_DL != null)
            {
                add_DL.Hide();
                dataGridView2.Hide();
            }
        }

        private void Insert_Click(object sender, EventArgs e)
        {
            this.Size = new Size(700, 600);

            if (dataGridView != null)
            {
                dataGridView.Hide();
            }

            if (title_UP != null)
            {
                title_UP.Hide();
                lbl1_UP.Hide();
                lbl2_UP.Hide();
                lbl3_UP.Hide();
                lbl4_UP.Hide();
                text1_UP.Hide();
                text2_UP.Hide();
                text3_UP.Hide();
                text4_UP.Hide();
                add_UP.Hide();
                dataGridView1.Hide();             
            }

            if (add_DL != null)
            {
                add_DL.Hide();
                dataGridView2.Hide();
            }

            title = new Label()
            {
                Text = "Add data:",
                Size = new Size(130, 35),
                Font = new Font(Font.FontFamily, 20),
                Location = new Point(260, 100),
                BackColor = Color.Purple,
                ForeColor = Color.White
            };

            lbl1 = new Label()
            {
                Text = "Name: ",
                Size = new Size(60, 20),
                Font = new Font(Font.FontFamily, 10),
                Location = new Point(220, 160),
                BackColor = Color.Purple,
                ForeColor = Color.White
            };

            lbl2 = new Label()
            {
                Text = "Genre: ",
                Size = new Size(60, 20),
                Font = new Font(Font.FontFamily, 10),
                Location = new Point(220, 200),
                BackColor = Color.Purple,
                ForeColor = Color.White
            };

            lbl3 = new Label()
            {
                Text = "Date: ",
                Size = new Size(60, 20),
                Font = new Font(Font.FontFamily, 10),
                Location = new Point(220, 240),
                BackColor = Color.Purple,
                ForeColor = Color.White
            };

            lbl4 = new Label()
            {
                Text = "Image: ",
                Size = new Size(60, 20),
                Font = new Font(Font.FontFamily, 10),
                Location = new Point(220, 280),
                BackColor = Color.Purple,
                ForeColor = Color.White
            };

            text1 = new TextBox()
            {
                Size = new Size(120, 30),
                Location = new Point(290, 160)
            };

            text2 = new TextBox()
            {
                Size = new Size(120, 30),
                Location = new Point(290, 200)
            };

            text3 = new TextBox()
            {
                Size = new Size(120, 30),
                Location = new Point(290, 240)
            };

            text4 = new TextBox()
            {
                Size = new Size(120, 30),
                Location = new Point(290, 280)
            };

            add = new Button()
            {
                Text = "Add",
                Size = new Size(160, 40),
                BackColor = Color.Purple,
                ForeColor = Color.White,
                Location = new Point(235, 320),
                Font = new Font(Font.FontFamily, 10)
            };

            add.Click += Add_Click;

            this.Controls.Add(title);
            this.Controls.Add(lbl1);
            this.Controls.Add(lbl2);
            this.Controls.Add(lbl3);
            this.Controls.Add(lbl4);
            this.Controls.Add(text1);
            this.Controls.Add(text2);
            this.Controls.Add(text3);
            this.Controls.Add(text4);
            this.Controls.Add(add);            
        }

        private void Add_Click(object sender, EventArgs e)
        {
            connect_to_DB.Open();

            command = new SqlCommand("insert into Movie(name, genre, dateM, image) values(@name, @genre, @dateM, @image)", connect_to_DB);
            command.Parameters.AddWithValue("@name", text1.Text);
            command.Parameters.AddWithValue("@genre", text2.Text);
            command.Parameters.AddWithValue("@dateM", text3.Text);
            command.Parameters.AddWithValue("@image", text4.Text);
            command.ExecuteNonQuery();

            MessageBox.Show("Insert is completed.");

            connect_to_DB.Close();
        }

        private void Update_Click(object sender, EventArgs e)
        {
            this.Size = new Size(700, 600);

            if (dataGridView != null)
            {
                dataGridView.Hide();
            }

            if (title != null)
            {
                title.Hide();
                lbl1.Hide();
                lbl2.Hide();
                lbl3.Hide();
                lbl4.Hide();
                text1.Hide();
                text2.Hide();
                text3.Hide();
                text4.Hide();
                add.Hide();
            }

            if (add_DL != null)
            {
                add_DL.Hide();
                dataGridView2.Hide();
            }

            title_UP = new Label()
            {
                Text = "Update data:",
                Size = new Size(180, 35),
                Font = new Font(Font.FontFamily, 20),
                Location = new Point(230, 100),
                BackColor = Color.Purple,
                ForeColor = Color.White
            };

            lbl1_UP = new Label()
            {
                Text = "Name: ",
                Size = new Size(60, 20),
                Font = new Font(Font.FontFamily, 10),
                Location = new Point(220, 160),
                BackColor = Color.Purple,
                ForeColor = Color.White
            };

            lbl2_UP = new Label()
            {
                Text = "Genre: ",
                Size = new Size(60, 20),
                Font = new Font(Font.FontFamily, 10),
                Location = new Point(220, 200),
                BackColor = Color.Purple,
                ForeColor = Color.White
            };

            lbl3_UP = new Label()
            {
                Text = "Date: ",
                Size = new Size(60, 20),
                Font = new Font(Font.FontFamily, 10),
                Location = new Point(220, 240),
                BackColor = Color.Purple,
                ForeColor = Color.White
            };

            lbl4_UP = new Label()
            {
                Text = "Image: ",
                Size = new Size(60, 20),
                Font = new Font(Font.FontFamily, 10),
                Location = new Point(220, 280),
                BackColor = Color.Purple,
                ForeColor = Color.White
            };

            text1_UP = new TextBox()
            {
                Size = new Size(120, 30),
                Location = new Point(290, 160)
            };

            text2_UP = new TextBox()
            {
                Size = new Size(120, 30),
                Location = new Point(290, 200)
            };

            text3_UP = new TextBox()
            {
                Size = new Size(120, 30),
                Location = new Point(290, 240)
            };

            text4_UP = new TextBox()
            {
                Size = new Size(120, 30),
                Location = new Point(290, 280)
            };

            add_UP = new Button()
            {
                Text = "Update",
                Size = new Size(160, 40),
                BackColor = Color.Purple,
                ForeColor = Color.White,
                Location = new Point(235, 310),
                Font = new Font(Font.FontFamily, 10)
            };

            add_UP.Click += Add_UP_Click;

            DataTable tabel = new DataTable();
            dataGridView1 = new DataGridView();

            SqlDataAdapter adapter = new SqlDataAdapter("select id, name, genre, dateM, image from [dbo].[Movie]", connect_to_DB);
            adapter.Fill(tabel);
            dataGridView1.DataSource = tabel;
            dataGridView1.Location = new Point(50, 370);
            dataGridView1.Size = new Size(545, 150);

            dataGridView1.RowHeaderMouseClick += DataGridView1_RowHeaderMouseClick;
            
            this.Controls.Add(dataGridView1);

            this.Controls.Add(title_UP);
            this.Controls.Add(lbl1_UP);
            this.Controls.Add(lbl2_UP);
            this.Controls.Add(lbl3_UP);
            this.Controls.Add(lbl4_UP);
            this.Controls.Add(text1_UP);
            this.Controls.Add(text2_UP);
            this.Controls.Add(text3_UP);                                                       
            this.Controls.Add(text4_UP);
            this.Controls.Add(add_UP);
        }

        private void DataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            text1_UP.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            text2_UP.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            text3_UP.Text = "0000-00-00";
            if (dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString() == "")
            {
                text4_UP.Text = "null";
            }
            else
            {
                text4_UP.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            }          
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            this.Size = new Size(700, 500);

            if (dataGridView != null)
            {
                dataGridView.Hide();
            }

            if (title != null)
            {
                title.Hide();
                lbl1.Hide();
                lbl2.Hide();
                lbl3.Hide();
                lbl4.Hide();
                text1.Hide();
                text2.Hide();
                text3.Hide();
                text4.Hide();
                add.Hide();
            }

            if (title_UP != null)
            {
                title_UP.Hide();
                lbl1_UP.Hide();
                lbl2_UP.Hide();
                lbl3_UP.Hide();
                lbl4_UP.Hide();
                text1_UP.Hide();
                text2_UP.Hide();
                text3_UP.Hide();
                text4_UP.Hide();
                add_UP.Hide();
                dataGridView1.Hide();
            }

            add_DL = new Button()
            {
                Text = "Delete",
                Size = new Size(160, 40),
                BackColor = Color.Purple,
                ForeColor = Color.White,
                Location = new Point(235, 140),
                Font = new Font(Font.FontFamily, 10)
            };

            add_DL.Click += Add_DL_Click;

            DataTable tabel = new DataTable();
            dataGridView2 = new DataGridView();

            SqlDataAdapter adapter = new SqlDataAdapter("select id, name, dateM from [dbo].[Movie]", connect_to_DB);
            adapter.Fill(tabel);
            dataGridView2.DataSource = tabel;
            dataGridView2.Location = new Point(150, 200);
            dataGridView2.Size = new Size(355, 150);

            dataGridView2.RowHeaderMouseClick += DataGridView2_RowHeaderMouseClick;

            this.Controls.Add(dataGridView2);

            this.Controls.Add(add_DL);
        }

        private void DataGridView2_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Id = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString());
        }

        private void Add_DL_Click(object sender, EventArgs e)
        {
            connect_to_DB.Open();

            command = new SqlCommand("delete from Movie where id = @id", connect_to_DB);
            command.Parameters.AddWithValue("@id", Id);
            command.ExecuteNonQuery();

            MessageBox.Show("Delete is completed.");

            connect_to_DB.Close();
        }

        private void Add_UP_Click(object sender, EventArgs e)
        {
            connect_to_DB.Open();

            command = new SqlCommand("update Movie set name = @name, genre = @genre, dateM = @dateM, image = @image where id = @id", connect_to_DB);
            command.Parameters.AddWithValue("@id", Id);
            command.Parameters.AddWithValue("@name", text1_UP.Text);
            command.Parameters.AddWithValue("@genre", text2_UP.Text);
            command.Parameters.AddWithValue("@dateM", text3_UP.Text);
            command.Parameters.AddWithValue("@image", text4_UP.Text);
            command.ExecuteNonQuery();

            MessageBox.Show("Update is completed.");

            connect_to_DB.Close();
        }
    }
}