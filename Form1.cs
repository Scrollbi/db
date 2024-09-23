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
        private SqlConnection dbConnection; // ����������� � ���� ������
        private string dbConnectionString = @"Server=dbsrv\dub2024;Database=oshkinng207b2;Integrated Security=True;TrustServerCertificate=True;"; 

        private string currentSortDirection = "ASC"; // ������� ����������� ����������
        private string currentSearchTerm = ""; // ������� ��������� ������
        private List<string> searchTermsList = new List<string>(); // ������ ��������� ��������

        public Form1()
        {
            InitializeComponent();
            this.Text = "��"; // ��������� ����

            // ������������� ����������� � ���� ������
            dbConnection = new SqlConnection(dbConnectionString);

            // �������� ������ �� ���� ������
            LoadProducts();
        }

        private void LoadProducts()
        {
            listView1.Items.Clear(); // ������� ListView

            try
            {
                dbConnection.Open();

                // �������� SQL-������� � �������������� WHERE � AND
                StringBuilder queryBuilder = new StringBuilder("SELECT * FROM Products WHERE ");

                // ���������� ������� ������
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
                    queryBuilder.Append("1=1"); // ������� "������" ��� ���� �������
                }

                queryBuilder.Append($" ORDER BY Price {currentSortDirection}");

                // ���������� SQL-�������
                SqlCommand command = new SqlCommand(queryBuilder.ToString(), dbConnection);
                SqlDataReader reader = command.ExecuteReader();

                // ������ ������ �� SqlDataReader � ���������� �� � ListView
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

                // ���������� ������ ������
                UpdateRecordCountLabel();
            }
            catch (Exception ex)
            {
                MessageBox.Show("������: " + ex.Message);
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
                currentSortDirection = "DESC"; // ��������� ����������� ���������� �� ��������
                LoadProducts();
            }
        }

        private void UpdateRecordCountLabel()
        {
            // ���������� ������ ������ ����������� ������� � ListView
            label1.Text = $"������� � ListView: {listView1.Items.Count}";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                currentSortDirection = "ASC"; // ��������� ����������� ���������� �� �����������
                LoadProducts();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            currentSearchTerm = textBox1.Text; // ��������� ������ �� ���������� ����
            searchTermsList.Clear(); // ������� ������ ��������� ��������
            if (!string.IsNullOrEmpty(currentSearchTerm))
            {
                string[] terms = currentSearchTerm.Split(' '); // ��������� ��������� ������ �� ��������
                searchTermsList.AddRange(terms); // ��������� ������� � ������
            }
            LoadProducts(); // ������������ ��������� � ������ ��������� ������
        }
    }
}
