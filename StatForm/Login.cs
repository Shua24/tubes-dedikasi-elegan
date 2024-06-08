using LoginRegister;
using Microsoft.Extensions.FileSystemGlobbing.Internal;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Text.RegularExpressions;
using System.Net.NetworkInformation;

namespace StatForm
{
    public partial class Login : Form
    {
        public string? dirReference;

        string[] ErrorMessages =
        {
            "Error: Anda perlu memilih role pengguna!", // 0
            "Error: Username tidak terisi", // 1
            "Error: password tidak terisi", // 2
            "Panjang username minimal 3 karakter", // 3
            "Panjang password minimal 8 karakter", // 4
            "Username harus berupa huruf", // 5
            "Password harus memiliki karakter spesial" // 6
        };

        public Login(string? dirReference)
        {
            InitializeComponent();
            this.dirReference = dirReference;
        }

        public string GetErrorState()
        {
            string usernamePattern = @"^[a-zA-Z]+$";
            string passwordPattern = @"^(?=.*[!@#$%^&*(),.?""{}|<>])[\S]{8,}$";

            bool[] errorConditions =
            {
                comboBox1.SelectedItem == null,
                string.IsNullOrEmpty(textBox1.Text),
                string.IsNullOrEmpty(textBox2.Text),
                textBox1.Text.Length < 3,
                textBox2.Text.Length < 8,
                !Regex.IsMatch(textBox1.Text, usernamePattern),
                !Regex.IsMatch(textBox2.Text, passwordPattern)
            };

            for (int i = 0; i < errorConditions.Length; i++)
            {
                if (errorConditions[i])
                {
                    return ErrorMessages[i];
                }
            }
            return string.Empty;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoginState loginStatus = LoginState.BELUM_LOGIN;
            UserLogin userStatus = new();
            object selectedRole = comboBox1.SelectedItem;

            // Regex patterns
            string usernamePattern = @"^[a-zA-Z]+$";
            string passwordPattern = @"^(?=.*[!@#$%^&*(),.?""{}|<>])[\S]{8,}$";
            DokterUI nextDoc;
            string error = GetErrorState();
            if (!string.IsNullOrEmpty(error))
            {
                label4.Text = error;
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
    }
}
