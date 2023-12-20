using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Medication
{
    public class UserFileManager
    {
        private string filePath;

        public UserFileManager(string filePath)
        {
            this.filePath = filePath;
        }

        public bool AuthenticateUser(string username, string password)
        {
            List<UserData> users = ReadUserData();

            UserData user = users.Find(u => u.Username == username && u.Password == password);

            if (user != null)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Неверное имя пользователя или пароль.");
                return false;
            }
        }

        public bool AddUser(string username, string password, string verifiedPassword)
        {
            if (password.Length < 4 || password.Length > 16)
            {
                MessageBox.Show("Пароль должен быть от 4 до 16 символов.");
                return false;
            }

            if (username.Length < 4 || username.Length > 16)
            {
                MessageBox.Show("Имя пользователя должно быть от 4 до 16 символов.");
                return false;
            }

            if (password != verifiedPassword)
            {
                MessageBox.Show("Пароли не совпадают.");
                return false;
            }

            List<UserData> existingUsers = ReadUserData();
            if (existingUsers.Exists(u => u.Username == username))
            {
                MessageBox.Show("Данный пользователь уже зарегистрирован.");
                return false;
            }

            try
            {
                existingUsers.Add(new UserData { Username = username, Password = password });

                string jsonData = JsonConvert.SerializeObject(existingUsers, Formatting.Indented);
                File.WriteAllText(filePath, jsonData);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при записи в файл: {ex.Message}");
                return false;
            }
        }

        private List<UserData> ReadUserData()
        {
            List<UserData> users = new List<UserData>();

            try
            {
                if (File.Exists(filePath))
                {
                    string jsonData = File.ReadAllText(filePath);
                    users = JsonConvert.DeserializeObject<List<UserData>>(jsonData) ?? new List<UserData>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при чтении файла: {ex.Message}");
            }

            return users;
        }
    }

    public class UserData
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
