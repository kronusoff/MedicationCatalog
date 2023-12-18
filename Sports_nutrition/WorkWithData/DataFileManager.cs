using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Medication
{
    public class DataFileManager
    {
        private string filePath;
        private SortDirection currentSortDirection = SortDirection.Ascending;

        public DataFileManager(string path)
        {
            filePath = path;
        }

        public List<Product> ReadProductsFromFile()
        {
            List<Product> productsList = new List<Product>();

            try
            {
                if (File.Exists(filePath))
                {
                    string jsonData = File.ReadAllText(filePath);
                    productsList = JsonConvert.DeserializeObject<List<Product>>(jsonData) ?? new List<Product>();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при чтении файла: {ex.Message}");
            }
            return productsList;
        }

        public bool AddProductToFile(Product newProduct)
        {
            try
            {
                List<Product> existingProducts = ReadProductsFromFile();

                // Проверка уникальности имени
                if (existingProducts.Any(p => p.Name.Trim().Equals(newProduct.Name, StringComparison.OrdinalIgnoreCase)))
                {                    
                    return false;
                }

                // Если файл пустой, устанавливаем новый продукт с ID = 1
                if (existingProducts.Count == 0)
                {
                    newProduct.ID = 1;
                }
                else
                {
                    // Получение максимального ID из существующих продуктов
                    int maxId = existingProducts.Max(p => p.ID);
                    newProduct.ID = maxId + 1;
                }

                existingProducts.Add(newProduct);
                string jsonData = JsonConvert.SerializeObject(existingProducts, Formatting.Indented);
                File.WriteAllText(filePath, jsonData);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при записи в файл: {ex.Message}");
            }
            return true;
        }

        public void RemoveProductById(int productId)
        {
            try
            {
                List<Product> existingProducts = ReadProductsFromFile();

                // Оставляем только те продукты, которые не соответствуют удаляемому ID
                existingProducts = existingProducts.Where(p => p.ID != productId).ToList();

                // Пересчет индексов после удаления
                for (int i = 0; i < existingProducts.Count; i++)
                {
                    existingProducts[i].ID = i + 1;
                }

                // Запись новых данных в файл
                string jsonData = JsonConvert.SerializeObject(existingProducts, Formatting.Indented);
                File.WriteAllText(filePath, jsonData);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении продукта: {ex.Message}");
            }
        }
        public bool UpdateProduct(Product updatedProduct)
        {
            try
            {
                List<Product> existingProducts = ReadProductsFromFile();

                // Проверка, что продукт с таким ID существует
                if (existingProducts.Any(p => p.ID == updatedProduct.ID))
                {
                    // Обновляем данные продукта
                    Product existingProduct = existingProducts.First(p => p.ID == updatedProduct.ID);
                    existingProduct.Name = updatedProduct.Name;
                    existingProduct.Category = updatedProduct.Category;
                    existingProduct.Price = updatedProduct.Price;

                    // Записываем обновленные данные в файл
                    string jsonData = JsonConvert.SerializeObject(existingProducts, Formatting.Indented);
                    File.WriteAllText(filePath, jsonData);

                    return true;
                }
                else
                {
                    Console.WriteLine($"Продукт с ID {updatedProduct.ID} не найден.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при обновлении продукта: {ex.Message}");
                return false;
            }
        }


        public void SortProductsByName()
        {
            SortProducts(p => p.Name);
        }

        public void SortProductsByCategory()
        {
            SortProducts(p => p.Category);
        }

        public void SortProductsById()
        {
            SortProducts(p => p.ID);
        }

        public void SortProductsByPrice()
        {
            SortProducts(p => p.Price);
        }

        private void SortProducts<TKey>(Func<Product, TKey> keySelector)
        {
            try
            {
                List<Product> existingProducts = ReadProductsFromFile();

                // Выбор направления сортировки в зависимости от текущего состояния
                existingProducts = (currentSortDirection == SortDirection.Ascending) ?
                    existingProducts.OrderBy(keySelector).ToList() :
                    existingProducts.OrderByDescending(keySelector).ToList();

                // Инвертирование текущего направления сортировки
                currentSortDirection = (currentSortDirection == SortDirection.Ascending) ?
                    SortDirection.Descending : SortDirection.Ascending;

                // Запись отсортированных данных в файл
                string jsonData = JsonConvert.SerializeObject(existingProducts, Formatting.Indented);
                File.WriteAllText(filePath, jsonData);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при сортировке продуктов: {ex.Message}");
            }
        }

        public List<Product> SearchProductsByName(string searchTerm)
        {
            try
            {
                List<Product> existingProducts = ReadProductsFromFile();

                // Производим поиск по названию, игнорируя регистр
                List<Product> searchResults = existingProducts
                    .Where(p => p.Name.Trim().ToLower().Contains(searchTerm.Trim().ToLower()))
                    .ToList();

                return searchResults;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при поиске продукта: {ex.Message}");
                return new List<Product>();
            }
        }

    }
}
