using LoginRegister;

namespace StatForm
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoginState loginStatus;
            UserLogin userStatus = new UserLogin();

            object selectedRole = comboBox1.SelectedItem;

            if (selectedRole == null)
            {
                label4.Text = "Error: Anda perlu memilih role pengguna!";
            }
            else if (textBox1.Text == null)
            {
                label4.Text = "Error: Username tidak terisi";
            }
            else if (textBox2.Text == null)
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
                }
                else if (selected == "Tim mikrobiologi")
                {
                    loginStatus = userStatus.Login(textBox1.Text, textBox2.Text);
                    if (loginStatus != LoginState.SUDAH_LOGIN)
                    {
                        label4.Text = "Username atau password salah untuk seorang" + selected;
                    }
                    else
                    {
                        StatsUI stats = new StatsUI();
                        stats.Show();
                        Hide();
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
