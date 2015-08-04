using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Newtonsoft.Json;

namespace Client
{
    public partial class Form2 : Form
    {
        private bool _signed = false;
        public Form2()
        {
            InitializeComponent();
        }

        private void signButton_Click(object sender, EventArgs e)
        {
            try
            {
                var authData = new KeyValuePair<string, string>(loginTextBox.Text, passwordTextBox.Text);
                var request = (HttpWebRequest)WebRequest.Create(ExtraData.LoginData.ConnectionString);
                request.Method = WebRequestMethods.Http.Post;
                request.ContentType = "application/json";
                var json = JsonConvert.SerializeObject(authData, new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All
                });
                var data = Encoding.Default.GetBytes(json);
                request.ContentLength = data.Length;

                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }
                var response = (HttpWebResponse)request.GetResponse();
                _signed = true;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void russianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!ExtraData.IsEnglish)
                return;
            Localize();
        }

        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ExtraData.IsEnglish)
                return;
            Localize();
            
        }

        private void Localize()
        {
            if (ExtraData.IsEnglish)
            {
                ExtraData.IsEnglish = false;
                fileToolStripMenuItem.Text = @"Файл";
                exitToolStripMenuItem.Text = @"Выход";
                languageToolStripMenuItem.Text = @"Язык";
                helpToolStripMenuItem.Text = @"Помощь";
                helpToolStripMenuSubItem.Text = @"Помощь";

                loginLabel.Text = @"Имя пользователя";
                passwordLabel.Text = @"Пароль";

                signButton.Text = @"Войти";
            }
            else
            {
                ExtraData.IsEnglish = true;
                fileToolStripMenuItem.Text = @"File";
                exitToolStripMenuItem.Text = @"Exit";
                languageToolStripMenuItem.Text = @"Language";
                helpToolStripMenuItem.Text = @"Help";
                helpToolStripMenuSubItem.Text = @"Help";

                loginLabel.Text = @"Login";
                passwordLabel.Text = @"Password";

                signButton.Text = @"Sign in";

            }
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(e.CloseReason == CloseReason.UserClosing && !_signed)
                Application.Exit();
        }


    }
}
