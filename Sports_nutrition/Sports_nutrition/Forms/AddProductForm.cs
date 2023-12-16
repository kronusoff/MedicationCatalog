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
    public partial class AddProductForm : Form
    {
        public AddProductForm()
        {
            InitializeComponent();
        }
        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            DataFileManager dataManager = new DataFileManager("data.json");
            string name = NameTextBox.Text.Trim();
            string category = CategoryComboBox.Text.Trim();

            // Проверяем, что цена введена корректно
            if (!int.TryParse(PriceTextBox.Text, out int price))
            {
                MessageBox.Show("Пожалуйста, введите корректную цену.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Проверяем, что число цены положительное
            if(int.Parse(PriceTextBox.Text)<=0)
            {
                MessageBox.Show("Пожалуйста, введите корректную цену.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Product newProduct = new Product(0, category, name, price);
           if(dataManager.AddProductToFile(newProduct))
            {
                MessageBox.Show("Продукт успешно добавлен.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
              
                MessageBox.Show("Продукт с данным наименованием уже занесен в католог.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
                
            
            
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
