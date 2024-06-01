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
            else
            {
                string selected = comboBox1.SelectedItem.ToString();

                if (selected == "Dokter")
                {
                    loginStatus = userStatus.DocLogin(textBox1.Text, textBox2.Text);

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
                    loginStatus = userStatus.Login(textBox1.Text, textBox2.Text);

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
    }
}
