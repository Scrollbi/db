using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        private SqlConnection dbConnection; // Подключение к базе данных
        private string dbConnectionString = @"Server=dbsrv\dub2024;Database=oshkinng207b2;Integrated Security=True;TrustServerCertificate=True;"; 

        private string currentSortDirection = "ASC"; // Текущее направление сортировки
        private string currentSearchTerm = ""; // Текущий поисковый термин
        private List<string> searchTermsList = new List<string>(); // Список поисковых терминов

        public Form1()
        {
            InitializeComponent();
            this.Text = "БД"; // Заголовок окна

            // Инициализация подключения к базе данных
            dbConnection = new SqlConnection(dbConnectionString);

            // Загрузка данных из базы данных
            LoadProducts();
        }

        private void LoadProducts()
        {
            listView1.Items.Clear(); // Очистка ListView

            try
            {
                dbConnection.Open();

                // Создание SQL-запроса с использованием WHERE и AND
                StringBuilder queryBuilder = new StringBuilder("SELECT * FROM Products WHERE ");

                // Добавление условий поиска
                if (searchTermsList.Count > 0)
                {
                    for (int i = 0; i < searchTermsList.Count; i++)
                    {
                        queryBuilder.Append($"Manufacturer LIKE '%{searchTermsList[i]}%'");
                        if (i < searchTermsList.Count - 1)
                        {
                            queryBuilder.Append(" OR ");
                        }
                    }
                }
                else
                {
                    queryBuilder.Append("1=1"); // Условие "истина" для всех записей
                }

                queryBuilder.Append($" ORDER BY Price {currentSortDirection}");

                // Выполнение SQL-запроса
                SqlCommand command = new SqlCommand(queryBuilder.ToString(), dbConnection);
                SqlDataReader reader = command.ExecuteReader();

                // Чтение данных из SqlDataReader и добавление их в ListView
                while (reader.Read())
                {
                    ListViewItem Product_NameItem = new ListViewItem(reader["Product_Name"].ToString());
                    ListViewItem priceItem = new ListViewItem(reader["Price"].ToString());
                    ListViewItem manufacturerItem = new ListViewItem(reader["Manufacturer"].ToString());
                    ListViewItem quantityItem = new ListViewItem(reader["quantity"].ToString());
                    ListViewItem descriptionItem = new ListViewItem(reader["description"].ToString());

                    listView1.Items.Add(Product_NameItem);
                    listView1.Items.Add(priceItem);
                    listView1.Items.Add(manufacturerItem);
                    listView1.Items.Add(quantityItem);
                    listView1.Items.Add(descriptionItem);
                }

                reader.Close();

                // Обновление текста лейбла
                UpdateRecordCountLabel();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
            finally
            {
                dbConnection.Close();
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                currentSortDirection = "DESC"; // Установка направления сортировки на убывание
                LoadProducts();
            }
        }

        private void UpdateRecordCountLabel()
        {
            // Обновление текста лейбла количеством записей в ListView
            label1.Text = $"Записей в ListView: {listView1.Items.Count}";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                currentSortDirection = "ASC"; // Установка направления сортировки на возрастание
                LoadProducts();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            currentSearchTerm = textBox1.Text; // Получение текста из текстового поля
            searchTermsList.Clear(); // Очистка списка поисковых терминов
            if (!string.IsNullOrEmpty(currentSearchTerm))
            {
                string[] terms = currentSearchTerm.Split(' '); // Разбиваем поисковую строку по пробелам
                searchTermsList.AddRange(terms); // Добавляем термины в список
            }
            LoadProducts(); // Перезагрузка продуктов с новыми условиями поиска
        }
    }
}
