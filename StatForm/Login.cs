using LoginRegister;
using Microsoft.Extensions.FileSystemGlobbing.Internal;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Text.RegularExpressions;

namespace StatForm
{
    public partial class Login : Form
    {
        public string? dirReference;
        public Login(string? dirReference)
        {
            InitializeComponent();
            this.dirReference = dirReference;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoginState loginStatus = LoginState.BELUM_LOGIN;
            UserLogin userStatus = new UserLogin();
            object selectedRole = comboBox1.SelectedItem;
            
            // Regex patterns
            string usernamePattern = @"^[a-zA-Z]+$";
            string passwordPattern = @"^(?=.*[!@#$%^&*(),.?""{}|<>])[\S]{8,}$";
            DokterUI nextDoc;
            if (selectedRole == null)
            {
                label4.Text = "Error: Anda perlu memilih role pengguna!";
            }
            else if (string.IsNullOrEmpty(textBox1.Text))
            {
                label4.Text = "Error: Username tidak terisi";
            }
            else if (string.IsNullOrEmpty(textBox2.Text))
            {
                label4.Text = "Error: password tidak terisi";
            }
            else if (textBox1.Text.Length < 3)
            {
                label4.Text = "Panjang username minimal 3 karakter";
            }
            else if (textBox2.Text.Length < 8)
            {
                label4.Text = "Panjang password minimal 8 karakter";
            }
            else if (!Regex.IsMatch(textBox1.Text, usernamePattern))
            {
                label4.Text = "Username harus berupa huruf";
            }
            else if (!Regex.IsMatch(textBox2.Text, passwordPattern))
            {
                label4.Text = "Password harus memiliki karakter spesial";
            }
            else
            {
                string selected = comboBox1.SelectedItem.ToString();
                if (selected == "Dokter")
                {
                    userStatus.DocLogin(textBox1.Text, textBox2.Text);
                    loginStatus = userStatus.GetLoginState();
                    if (loginStatus != LoginState.SUDAH_LOGIN)
                    {
                        label4.Text = "Username atau password salah untuk seorang " + selected;
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(dirReference))
                        {
                            label4.Text = "Tim mikrobiologi belum memberikan pola kuman!";
                        }
                        else
                        {
                            Hide();
                            nextDoc = new DokterUI(dirReference);
                            nextDoc.Show();
                        }
                    }
                }
                else if (selected == "Tim mikrobiologi")
                {
                    userStatus.Login(textBox1.Text, textBox2.Text);
                    loginStatus = userStatus.GetLoginState();
                    if (loginStatus != LoginState.SUDAH_LOGIN)
                    {
                        label4.Text = "Username atau password salah untuk seorang " + selected;
                    }
                    else
                    {
                        StatsUI stats = new StatsUI("");
                        stats.Show();
                        Hide();
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
