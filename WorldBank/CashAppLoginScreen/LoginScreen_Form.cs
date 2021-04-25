
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginScreen
{
    public partial class LoginScreen_Form : Form
    {
        public LoginScreen_Form()
        {
            InitializeComponent();

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            if (txtUserName.Text=="poi" && txtpassword.Text== "456")
            {
                Form_addMonto addmonto = new Form_addMonto();
                addmonto.Show();
                this.Hide();

                

            }

            else
            {
                MessageBox.Show("Usuario o contraseña incorrecto, favor intentar de nuevo");
                txtUserName.Clear();
                txtpassword.Clear();
                txtUserName.Focus();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            txtUserName.Clear();
            txtpassword.Clear();
            txtUserName.Focus();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtpassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (checkPassword.Checked)
            {
                txtpassword.UseSystemPasswordChar = true;
            }
            else
            {
                txtpassword.UseSystemPasswordChar = false;
            }
        }
    }
}
