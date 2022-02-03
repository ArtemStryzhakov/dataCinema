using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinuVorm
{
    public partial class Email : Form
    {
        Start_form startForm = new Start_form();
        MyForm form = new MyForm();
        MyForm myform = new MyForm();
        TextBox tbox;

        public Email()
        {
            this.Size = new Size(500, 500);
            this.BackgroundImage = new Bitmap(@"../../image/wallpaperE.jpg");

            Label Email_w = new Label()
            {
                Text = "Sisesta Emaili:",
                Location = new Point(145, 150),
                Font = new Font(Font.FontFamily, 20),
                BackColor = Color.Purple,
                ForeColor = Color.White
            };
            
            Size size_pl = TextRenderer.MeasureText(Email_w.Text, Email_w.Font);
            Email_w.Size = new Size(size_pl.Width, size_pl.Height);

            tbox = new TextBox()
            {
                Text = "programmeeriminetthk2@gmail.com",
                Location = new Point(140, 190),
                Size = new Size(200, 120)
            };

            Button btnEmail = new Button()
            {
                Text = "Confirm",
                Size = new Size(160, 40),
                BackColor = Color.Purple,
                ForeColor = Color.White,
                Location = new Point(158, 225),
                Font = new Font(Font.FontFamily, 10)
            };

            btnEmail.Click += BtnEmail_Click;

            this.Controls.Add(Email_w);
            this.Controls.Add(tbox);
            this.Controls.Add(btnEmail);
        }

        private void BtnEmail_Click(object sender, EventArgs e)
        {
            Saada_piletid(MyForm.piletid, tbox.Text);
        }

        public void Saada_piletid(List<Pilet> piletid, string eMail)
        {
            form.connect_to_DB.Open();
            string text = "Sinu pilet on ostad. \n";
            foreach (var item in piletid)
            {
                text += "<h1>Film: " + startForm.nameMovie.Text + "<br>Pilet: rida: " + item.Rida + "; roht: " + item.Koht + "</h1>\n";
                form.command = new SqlCommand("insert into Piletid(Rida, Koht, Film) values(@rida, @koht, @film)", form.connect_to_DB);
                form.command.Parameters.AddWithValue("@rida", item.Rida);
                form.command.Parameters.AddWithValue("@koht", item.Koht);
                form.command.Parameters.AddWithValue("@film", 1);
                form.command.ExecuteNonQuery();
            }
            form.connect_to_DB.Close();

            //message.Attachments.Add(new Attachment("file.pdf"));
            string email = "programmeeriminetthk2@gmail.com";
            string password = "2.kuursus tarpv20";
            SmtpClient client = new SmtpClient("smtp.gmail.com");
            client.Port = 587;
            client.Credentials = new NetworkCredential(email, password);
            client.EnableSsl = true;
            //client.UseDefaultCredentials = true;

            try
            {
                if (eMail != "")
                {
                    MailMessage message = new MailMessage();
                    message.To.Add(new MailAddress(eMail));//kellele saada vaja küsida
                    message.From = new MailAddress("programmeeriminetthk@gmail.com");
                    message.Subject = "Ostetud piletid";
                    message.Body = text;
                    message.IsBodyHtml = true;
                    client.Send(message);
                    //await client.SendMailAsync(message);
                    this.Close();
                }               
            }
            catch
            {
                MessageBox.Show("Something go wrong!");
            }
        }
    }
}
