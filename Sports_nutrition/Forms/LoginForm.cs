using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Medication
{
    public partial class LoginForm : Form
    {
        private RegForm regForm;
        public LoginForm()
        {
           
            InitializeComponent();
            
        }            
        private void Reg_button_Click(object sender, EventArgs e)
        {
            string username = loginField.Text;
            string password = passwordField.Text;
            UserFileManager reader = new UserFileManager("C:\\Users\\kronu\\OneDrive\\Рабочий стол\\MedicationCatalog\\Sports_nutrition\\WorkWithUsers\\users.json");
            if (reader.AuthenticateUser(username, password))
            {
                
                MessageBox.Show("Аутентификация успешна!");
                this.Hide();
                MedicationCatalog catalog = new MedicationCatalog();
                catalog.Show();
               
            }
            
        }
       
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            this.Hide();
            regForm = new RegForm();
            regForm.Show();
            
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
