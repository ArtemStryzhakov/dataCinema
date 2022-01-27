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
        Label lbl5_UP;
        Label lbl_ID;
        TextBox text1_UP;
        TextBox text2_UP;
        TextBox text3_UP;
        TextBox text4_UP;
        TextBox text5_UP;
        Button add_UP;
        //-------------
        Label lbl_ID_1;
        Label lbl5_DL;
        TextBox text5_DL;
        Button add_DL;

        static string conn_KinoDB = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Admin\source\repos\dataKino\AppData\Kino_DB.mdf;Integrated Security=True";

        public SqlConnection connect_to_DB = new SqlConnection(conn_KinoDB);
        public SqlCommand command;

        DataGridView dataGridView;
        DataGridView dataGridView1;
        DataGridView dataGridView2;

        public Administrator()
        {
            this.Size = new Size(700, 600);
            this.Text = "Administrator";
            this.BackgroundImage = new Bitmap("../../image/wallpaper.jpg");
            this.Icon = Properties.Resources.administrator;           

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
                dataGridView2.Hide();
                lbl_ID.Hide();
                lbl_ID_1.Hide();
                text5_UP.Hide();
                lbl5_UP.Hide();
                lbl5_DL.Hide();
                text5_DL.Hide();
                add_DL.Hide();
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
                dataGridView2.Hide();
                lbl_ID.Hide();
                lbl_ID_1.Hide();
                text5_UP.Hide();
                lbl5_UP.Hide();
                lbl5_DL.Hide();
                text5_DL.Hide();
                add_DL.Hide();                
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
            this.Size = new Size(700, 750);

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

            if (lbl_ID_1 != null)
            {
                lbl_ID_1.Hide();
                lbl5_DL.Hide();
                text5_DL.Hide();
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

            lbl_ID = new Label()
            {
                Text = "Select ID: ",
                Size = new Size(140, 30),
                Font = new Font(Font.FontFamily, 20),
                Location = new Point(260, 340),
                BackColor = Color.Purple,
                ForeColor = Color.White
            };

            lbl5_UP = new Label()
            {
                Text = "ID: ",
                Size = new Size(30, 20),
                Font = new Font(Font.FontFamily, 10),
                Location = new Point(270, 380),
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

            text5_UP = new TextBox()
            {
                Size = new Size(50, 30),
                Location = new Point(310, 380)
            };

            add_UP = new Button()
            {
                Text = "Update",
                Size = new Size(160, 40),
                BackColor = Color.Purple,
                ForeColor = Color.White,
                Location = new Point(235, 420),
                Font = new Font(Font.FontFamily, 10)
            };

            add_UP.Click += Add_UP_Click;

            DataTable tabel = new DataTable();
            dataGridView1 = new DataGridView();

            SqlDataAdapter adapter = new SqlDataAdapter("select id, name, dateM from [dbo].[Movie]", connect_to_DB);
            adapter.Fill(tabel);
            dataGridView1.DataSource = tabel;
            dataGridView1.Location = new Point(150, 500);
            dataGridView1.Size = new Size(355, 150);
            
            this.Controls.Add(dataGridView1);

            this.Controls.Add(title_UP);
            this.Controls.Add(lbl1_UP);
            this.Controls.Add(lbl2_UP);
            this.Controls.Add(lbl3_UP);
            this.Controls.Add(lbl4_UP);
            this.Controls.Add(lbl5_UP);
            this.Controls.Add(text1_UP);
            this.Controls.Add(text2_UP);
            this.Controls.Add(text3_UP);                                                       
            this.Controls.Add(text4_UP);
            this.Controls.Add(lbl_ID);
            this.Controls.Add(text5_UP);
            this.Controls.Add(add_UP);
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
                lbl_ID.Hide();
                text5_UP.Hide();
                lbl5_UP.Hide();
            }

            lbl_ID_1 = new Label()
            {
                Text = "Select ID: ",
                Size = new Size(140, 30),
                Font = new Font(Font.FontFamily, 20),
                Location = new Point(260, 110),
                BackColor = Color.Purple,
                ForeColor = Color.White
            };

            lbl5_DL = new Label()
            {
                Text = "ID: ",
                Size = new Size(30, 20),
                Font = new Font(Font.FontFamily, 10),
                Location = new Point(270, 150),
                BackColor = Color.Purple,
                ForeColor = Color.White
            };

            text5_DL = new TextBox()
            {
                Size = new Size(50, 30),
                Location = new Point(310, 150)
            };

            add_DL = new Button()
            {
                Text = "Delete",
                Size = new Size(160, 40),
                BackColor = Color.Purple,
                ForeColor = Color.White,
                Location = new Point(235, 190),
                Font = new Font(Font.FontFamily, 10)
            };

            add_DL.Click += Add_DL_Click;

            DataTable tabel = new DataTable();
            dataGridView2 = new DataGridView();

            SqlDataAdapter adapter = new SqlDataAdapter("select id, name, dateM from [dbo].[Movie]", connect_to_DB);
            adapter.Fill(tabel);
            dataGridView2.DataSource = tabel;
            dataGridView2.Location = new Point(150, 250);
            dataGridView2.Size = new Size(355, 150);

            this.Controls.Add(dataGridView2);

            this.Controls.Add(lbl_ID_1);
            this.Controls.Add(lbl5_DL);
            this.Controls.Add(text5_DL);
            this.Controls.Add(add_DL);
        }

        private void Add_DL_Click(object sender, EventArgs e)
        {
            connect_to_DB.Open();

            command = new SqlCommand("delete from Movie where id = @id", connect_to_DB);
            command.Parameters.AddWithValue("@id", text5_DL.Text);
            command.ExecuteNonQuery();

            MessageBox.Show("Delete is completed.");

            connect_to_DB.Close();
        }

        private void Add_UP_Click(object sender, EventArgs e)
        {
            connect_to_DB.Open();

            command = new SqlCommand("update Movie set name = @name, genre = @genre, dateM = @dateM, image = @image where id = @id", connect_to_DB);
            command.Parameters.AddWithValue("@name", text1_UP.Text);
            command.Parameters.AddWithValue("@genre", text2_UP.Text);
            command.Parameters.AddWithValue("@dateM", text3_UP.Text);
            command.Parameters.AddWithValue("@image", text4_UP.Text);
            command.Parameters.AddWithValue("@id", text5_UP.Text);
            command.ExecuteNonQuery();

            MessageBox.Show("Update is completed.");

            connect_to_DB.Close();
        }
    }
}
