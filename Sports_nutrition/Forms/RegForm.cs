using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Medication
{
    public partial class RegForm : Form
    {
        private LoginForm loginForm;
        public RegForm()
        {
            InitializeComponent();
        }

     
      

        private void Reg_button_Click(object sender, EventArgs e)
        {
            UserFileManager writer = new UserFileManager("C:\\Users\\kronu\\OneDrive\\Рабочий стол\\MedicationCatalog\\Sports_nutrition\\WorkWithUsers\\users.json");
            string username = loginReg.Text;
            string password = passwordReg.Text;
            string verifiedPassword = verifiedpasswordReg.Text;

            if (writer.AddUser(username, password, verifiedPassword))
            {
                MessageBox.Show("Регистрация успешна!");
                this.Close();
                loginForm = new LoginForm();
                loginForm.Show();
            }
            else
            {
               
                passwordReg.Text = string.Empty;
                verifiedpasswordReg.Text = string.Empty;
            }
        }

        private void LinkToLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
            loginForm = new LoginForm();
            loginForm.Show();
        }
        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; 
                SelectNextControl((Control)sender, true, true, true, true);
            }
        }

    }
}
