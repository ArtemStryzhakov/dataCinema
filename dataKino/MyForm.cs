using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace MinuVorm
{
    public partial class MyForm: Form
    {
        Start_form startForm = new Start_form();
        Label message = new Label();
        Button[] btn = new Button[4];
        string[] texts = new string[4];
        TableLayoutPanel tlp = new TableLayoutPanel();
        Button btn_tabel;
        public static List<Pilet> piletid;
        public static Pilet pilet;
        int k, r;
        static string[] read_kohad;
        static string conn_KinoDB = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Admin\source\repos\dataKino\AppData\Kino_DB.mdf;Integrated Security=True";

        public SqlConnection connect_to_DB = new SqlConnection(conn_KinoDB);

        public SqlCommand command;
        SqlDataAdapter adapter;
        public MyForm()
        {}

        public MyForm(string title,string body,string button1,string button2,string button3,string button4)
        {
            this.ClientSize = new System.Drawing.Size(400, 100);

            Button btn1 = new Button()
            {
                Location = new Point(10, 50),
                Size = new Size(80, 25),
                Text = button1
            };

            btn1.Click += Btn1_Click;

            Button btn2 = new Button()
            {
                Location = new Point(110, 50),
                Size = new Size(80, 25),
                Text = button2
            };

            btn2.Click += Btn2_Click;

            Button btn3 = new Button()
            {
                Location = new Point(210, 50),
                Size = new Size(80, 25),
                Text = button3
            };

            btn3.Click += Btn3_Click;

            Button btn4 = new Button()
            {
                Location = new Point(310, 50),
                Size = new Size(80, 25),
                Text = button4
            };

            btn4.Click += Btn4_Click;

            this.Controls.Add(btn1);
            this.Controls.Add(btn2);
            this.Controls.Add(btn3);
            this.Controls.Add(btn4);
        }

        private void Btn4_Click(object sender, EventArgs e)
        {
            MyForm uus_aken = new MyForm(5, 5);

            uus_aken.StartPosition = FormStartPosition.CenterScreen;
            uus_aken.ShowDialog();
        }

        private void Btn3_Click(object sender, EventArgs e)
        {
            MyForm uus_aken = new MyForm(12, 7);

            uus_aken.StartPosition = FormStartPosition.CenterScreen;
            uus_aken.ShowDialog();
        }

        private void Btn2_Click(object sender, EventArgs e)
        {
            MyForm uus_aken = new MyForm(10, 6);

            uus_aken.StartPosition = FormStartPosition.CenterScreen;
            uus_aken.ShowDialog();
        }

        private void Btn1_Click(object sender, EventArgs e)
        {
            MyForm uus_aken = new MyForm(8, 5);

            uus_aken.StartPosition = FormStartPosition.CenterScreen;
            uus_aken.ShowDialog();
        }

        public MyForm(string title, string body, string button1, string button2)
        {
            texts[0] = button1;
            texts[1] = button2;

            this.ClientSize = new System.Drawing.Size(400, 100);
            this.Text = title;
            int x = 10;
            for (int i = 0; i < 3; i++)
            {
                btn[i] = new Button
                {
                    Location = new System.Drawing.Point(x, 50),
                    Size = new System.Drawing.Size(80, 25),
                    Text = texts[i]
                };
                x += 100;
                this.Controls.Add(btn[i]);
            }
            message.Location = new System.Drawing.Point(10, 10);
            message.Text = "Kas tahad saada e-mailile?";
            this.Controls.Add(message);
        }
        public string[] Ostetud_piletid()
        {
            try               
            {/*
                if (Start_form.m == 0)
                {
                    StreamReader f = new StreamReader(@"../../Piletid/Avatar.txt");
                    read_kohad = f.ReadToEnd().Split(';');
                    f.Close();
                }
                else if (Start_form.m == 1)
                {
                    StreamReader f = new StreamReader(@"../../Piletid/DoctorStrange.txt");
                    read_kohad = f.ReadToEnd().Split(';');
                    f.Close();
                }
                else
                {                 
                    StreamReader f = new StreamReader(@"../../Piletid/StarWars.txt");
                    read_kohad = f.ReadToEnd().Split(';');
                    f.Close();
                }*/

                connect_to_DB.Open();
                adapter = new SqlDataAdapter("select * from [dbo].[Piletid]", connect_to_DB);
                DataTable tabel = new DataTable();
                adapter.Fill(tabel);
                read_kohad = new string[tabel.Rows.Count];
                var index = 0;
                foreach (DataRow row in tabel.Rows)
                {
                    var rida = row["Rida"];
                    var koht = row["Koht"];
                    read_kohad[index++] = $"{rida}{koht}";
                }
                connect_to_DB.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return read_kohad;
        }
        public Button Uusnupp(Action<object, EventArgs> click)
        {
            btn_tabel = new Button
            {
                Text = string.Format($"{r + 1}{k + 1}"),
                Name = string.Format("{1}{0}", k+1, r+1),
                Dock = DockStyle.Fill,
                BackColor = Color.Green
            };           
            btn_tabel.Click += new EventHandler(Pileti_valik);
            return btn_tabel;
        }
        public MyForm(int read, int kohad)
        {
            this.tlp.ColumnCount = kohad;
            this.tlp.RowCount = read;
            this.tlp.ColumnStyles.Clear();
            this.tlp.RowStyles.Clear();
            int i, j;
            read_kohad = Ostetud_piletid();
            piletid = new List<Pilet> { };
           
            for (i = 0; i < read; i++)
            {
                this.tlp.RowStyles.Add(new RowStyle(SizeType.Percent));
                this.tlp.RowStyles[i].Height = 100 / read;
            }            
            for (j = 0; j < kohad; j++)
            {
                this.tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent));
                this.tlp.ColumnStyles[j].Width = 100 / kohad;
            }            
            this.Size = new System.Drawing.Size(read*100, kohad*100);
            for (r = 0; r < read; r++)
            {
                for (k = 0; k < kohad; k++)
                {
                    Button btn_tabel = Uusnupp((sender,e)=> Pileti_valik(sender,e));
                    foreach (var item in read_kohad)
                    {
                        if (item.ToString() == btn_tabel.Name)
                        {
                            btn_tabel.BackColor = Color.Red;
                        }
                    }
                    this.tlp.Controls.Add(btn_tabel, k, r);
                }
            }
            this.tlp.Dock = DockStyle.Fill;
            this.Controls.Add(tlp);    
        }
               
        private void Pileti_valik(object sender, EventArgs e)
        {
            Button btn_click = (Button)sender;
            btn_click.BackColor = Color.Yellow;
            MessageBox.Show(btn_click.Name.ToString());
            var rida = int.Parse(btn_click.Name[0].ToString());
            var koht = int.Parse(btn_click.Name[1].ToString());
            var vas = MessageBox.Show("Sinu pilet on: Rida: " + rida + " Koht: " +koht, "Kas ostad?", MessageBoxButtons.YesNo);
            if (vas == DialogResult.Yes)
            {
                btn_click.BackColor = Color.Red;
                try
                {
                    pilet = new Pilet(rida, koht);
                    piletid.Add(pilet);

                    if (Start_form.m == 0)
                    {
                        StreamWriter ost = new StreamWriter(@"..\..\Piletid\Avatar.txt", true);
                        ost.Write(btn_click.Name.ToString() + ';');
                        ost.Close();
                    }
                    else if (Start_form.m == 1)
                    {
                        StreamWriter ost = new StreamWriter(@"..\..\Piletid\DoctorStrange.txt", true);
                        ost.Write(btn_click.Name.ToString() + ';');
                        ost.Close();
                    }
                    else
                    {
                        StreamWriter ost = new StreamWriter(@"..\..\Piletid\StarWars.txt", true);
                        ost.Write(btn_click.Name.ToString() + ';');
                        ost.Close();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (vas == DialogResult.No)
            {
                btn_click.BackColor = Color.Green;
            };

            if (MessageBox.Show("Sul on ostetud: " + piletid.Count() + "piletid", "Kas tahad saada neid e-mailile?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Email gmail = new Email();
                gmail.Show();
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "Kino";
            this.ResumeLayout(false);
        }
    }
}
