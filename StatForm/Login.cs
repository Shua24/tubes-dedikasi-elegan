using LoginRegister;

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
            LoginState loginStatus;
            UserLogin userStatus = new UserLogin();
            object selectedRole = comboBox1.SelectedItem;
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
            else if (textBox2.Text.Length < 3)
            {
                label4.Text = "Panjang password minimal 3 karakter";
            }
            else
            {
                string selected = comboBox1.SelectedItem.ToString();

                if (selected == "Dokter")
                {
                    userStatus.DocLogin(textBox1.Text, textBox2.Text);
                    loginStatus = userStatus.getLoginState();
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
                    loginStatus = userStatus.getLoginState();
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
