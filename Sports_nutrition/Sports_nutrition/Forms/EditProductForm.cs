using System;
using System.Windows.Forms;

namespace Medication.Forms
{
    public partial class EditProductForm : Form
    {
        private Product productToEdit;
        private DataFileManager dataManager;

        public EditProductForm(Product product)
        {
            InitializeComponent();
            productToEdit = product;
            dataManager = new DataFileManager("data.json");

            // Инициализация формы информацией о существующем продукте
            NameTextBox.Text = productToEdit.Name;
            CategoryComboBox.Text = productToEdit.Category;
            PriceTextBox.Text = productToEdit.Price.ToString();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            string name = NameTextBox.Text.Trim();
            string category = CategoryComboBox.Text.Trim();

            // Проверка, введена ли цена правильно
            if (!int.TryParse(PriceTextBox.Text, out int price))
            {
                MessageBox.Show("Пожалуйста, введите правильную цену.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Проверка, является ли цена положительным числом
            if (int.Parse(PriceTextBox.Text) <= 0)
            {
                MessageBox.Show("Пожалуйста, введите правильную цену.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Обновление информации о продукте
            productToEdit.Name = name;
            productToEdit.Category = category;
            productToEdit.Price = price;

            // Сохранение обновленного продукта в файл
            if (dataManager.UpdateProduct(productToEdit))
            {
                MessageBox.Show("Продукт успешно обновлен.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Ошибка обновления продукта.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.Close();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
