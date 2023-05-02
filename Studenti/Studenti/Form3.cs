using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace Studenti
{
    public partial class Form3 : Form
    {
        DataTable dt;
        string filterField = "Фамилия";
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // открываем файл на считывание
            StreamReader file = new StreamReader(@"C:\Users\Иван\Desktop\Studenti\Studenti\sourse\student.txt");
            // таблица данных
            dt = new DataTable();
            // добавляем столбцы
            dt.Columns.Add("Фамилия");
            dt.Columns.Add("Имя");
            dt.Columns.Add("Группа");
            dt.Columns.Add("Экзамен");
            dt.Columns.Add("Курсовая работа");

            // считываем файл

            string[] values; //
            string newline; // считанная строка и файла
                            // считываем до конца файла
            while ((newline = file.ReadLine()) != null)
            {
                DataRow dr = dt.NewRow(); // строки таблицы
                values = newline.Split(' '); 
                for (int i = 0; i < values.Length; i++)
                {
                    dr[i] = values[i]; // присваиваем ячейкам строки
                }

                dt.Rows.Add(dr); // строку добавляем в таблицу
            }
            file.Close();
            // таблицу данных dt используем как DataSource для dataGridView1
            dataGridView1.DataSource = dt;
            // устанавливаем автоматическую ширину столбцов
            dataGridView1.AutoResizeColumns();
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            // если checkBox1 выбран будем рассчитывать средний балл
            if (checkBox1.Checked)
            {
                // добавляем новый столбец
                dt.Columns.Add("Средний балл");
                dataGridView1.Columns.Add("Средний балл", "Средний балл");
                // и рассчитаем средний балл
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    double exam = Convert.ToDouble(dt.Rows[i]["Экзамен"]);
                    double coursework = Convert.ToDouble(dt.Rows[i]["Курсовая работа"]);
                    dt.Rows[i]["Средний балл"] = (exam + coursework) / 2;
                }
                dataGridView1.DataSource = dt;
            }
            else
            // если checkBox1 не выбран - удаляем столбец
            {
                dt.Columns.Remove("Средний балл");
                dataGridView1.Columns.Remove("Средний балл");
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // фильтрация данных
            dt.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", filterField,
            textBox1.Text);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}