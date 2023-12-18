using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Medication.Forms; // Используйте правильное пространство имен, если оно отличается


namespace Medication
{
    public partial class MedicationCatalog : Form
    {
        private static DataFileManager dataManager = new DataFileManager("C:\\Users\\kronu\\OneDrive\\Рабочий стол\\MedicationCatalog\\Sports_nutrition\\WorkWithData\\data.json");
        public MedicationCatalog()
        {

            InitializeComponent();
            FillProductListView();
        }

        private void FillProductListView()
        {
            listView1.Items.Clear();
            List<Product> products = dataManager.ReadProductsFromFile();
            foreach (var product in products)
            {
                ListViewItem item = new ListViewItem(product.ID.ToString()); // Добавляем ID в ListViewItem
                item.SubItems.Add(product.Category);
                item.SubItems.Add(product.Name);
                item.SubItems.Add(product.Price.ToString());

                listView1.Items.Add(item);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];

                string category = selectedItem.SubItems[1].Text;
                string name = selectedItem.SubItems[2].Text;
                string price = selectedItem.SubItems[3].Text;
            }

        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            AddProductForm addProductForm = new AddProductForm();
            addProductForm.FormClosed += (s, args) => FillProductListView();
            addProductForm.Show();
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                // Получаем выбранный элемент списка
                ListViewItem selectedItem = listView1.SelectedItems[0];

                // Предупреждение перед удалением продукта
                DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить выбранный продукт?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                // Если пользователь выбрал "Да", удаляем продукт и обновляем список
                if (result == DialogResult.Yes)
                {
                    if (int.TryParse(selectedItem.SubItems[0].Text, out int selectedProductId))
                    {
                        dataManager.RemoveProductById(selectedProductId);
                        FillProductListView();
                    }
                    else
                    {
                        MessageBox.Show("Не удалось получить ID выбранного продукта.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите продукт для удаления.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void FixButton_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                // Получаем выбранный элемент списка
                ListViewItem selectedItem = listView1.SelectedItems[0];

                // Получаем данные о продукте из выбранного элемента
                int selectedProductId = int.Parse(selectedItem.SubItems[0].Text);
                string selectedCategory = selectedItem.SubItems[1].Text;
                string selectedName = selectedItem.SubItems[2].Text;
                int selectedPrice = int.Parse(selectedItem.SubItems[3].Text);

                // Предупреждение перед открытием формы редактирования
                DialogResult result = MessageBox.Show("Вы уверены, что хотите редактировать выбранный продукт?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                // Если пользователь выбрал "Да", открываем форму редактирования
                if (result == DialogResult.Yes)
                {
                    // Создаем объект Product на основе выбранных данных
                    Product selectedProduct = new Product(selectedProductId, selectedCategory, selectedName, selectedPrice);

                    // Создаем форму редактирования и передаем выбранный продукт в конструктор
                    EditProductForm editProductForm = new EditProductForm(selectedProduct);
                    editProductForm.FormClosed += (s, args) => FillProductListView();
                    editProductForm.Show();
                }
            }
            else
            {
                MessageBox.Show("Выберите продукт для редактирования.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }



        private void AlphbetSortButton_Click(object sender, EventArgs e)
        {
            dataManager.SortProductsByName();
            FillProductListView();
        }

        private void IdSortButton_Click(object sender, EventArgs e)
        {
            dataManager.SortProductsById();
            FillProductListView();
        }

        private void PriceSortButton_Click(object sender, EventArgs e)
        {
            dataManager.SortProductsByPrice();
            FillProductListView();
        }

        private void SortComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedSortOption = sortComboBox.SelectedItem.ToString();

            switch (selectedSortOption)
            {
                case "По имени":
                    dataManager.SortProductsByName();
                    break;

                case "По категории": // Изменено на "По категории"
                    dataManager.SortProductsByCategory();
                    break;

                case "По цене":
                    dataManager.SortProductsByPrice();
                    break;

                default:
                    // Добавьте обработку для других опций сортировки, если необходимо
                    break;
            }

            FillProductListView();
        }

        private void SearchTextBox_Enter(object sender, EventArgs e)
        {
            if (searchTextBox.Text == "Введите текст для поиска")
            {
                searchTextBox.Text = "";
                searchTextBox.ForeColor = SystemColors.WindowText; // Восстанавливаем цвет текста по умолчанию
            }
        }
        private void SearchTextBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(searchTextBox.Text))
            {
                searchTextBox.Text = "Введите текст для поиска";
                searchTextBox.ForeColor = SystemColors.GrayText; // Устанавливаем серый цвет текста
            }
        }

        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {
            string searchText = searchTextBox.Text.Trim();

            if (searchText.Equals("Введите текст для поиска", StringComparison.OrdinalIgnoreCase))
            {
                // Если текст в поле поиска равен начальному тексту, показать весь список
                FillProductListView();
            }
            else
            {
                // В противном случае выполнить поиск
                List<Product> searchResults = dataManager.SearchProductsByName(searchText);

                // Очистить и заполнить ListView с результатами поиска
                listView1.Items.Clear();
                foreach (var product in searchResults)
                {
                    ListViewItem item = new ListViewItem();
                    item.SubItems.Add(product.Category);
                    item.SubItems.Add(product.Name);
                    item.SubItems.Add(product.Price.ToString());
                    listView1.Items.Add(item);
                }
            }
        }



        private void MedicationCatalog_Resize(object sender, EventArgs e)
        {
            // Здесь настраиваем размер и позицию ваших контролов
            listView1.Size = new System.Drawing.Size(ClientSize.Width - 10, ClientSize.Height - 100);
            listView1.Location = new System.Drawing.Point(5, 39);

            AddButton.Location = new System.Drawing.Point(5, ClientSize.Height - 55);
            RemoveButton.Location = new System.Drawing.Point(180, ClientSize.Height - 55);
            FixButton.Location = new System.Drawing.Point(355, ClientSize.Height - 55);
            sortComboBox.Location = new System.Drawing.Point(ClientSize.Width - 180, 12);
            searchTextBox.Location = new System.Drawing.Point(5, 12);
            searchTextBox.Width = 195;
        }   


    }
}
