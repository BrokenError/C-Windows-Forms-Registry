using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace registry
{
    public partial class Регистрация : Form
    {
        public Регистрация()
        {
            InitializeComponent();
        }

        string sql;

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            Авторизация form = new Авторизация(); form.ShowDialog();
            Close();
        }

        private void Регистрация_Load(object sender, EventArgs e)
        {
            textBox3.UseSystemPasswordChar = true;
            textBox4.UseSystemPasswordChar = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sql = "select userr_id from userr";
            Form1.Table_Fill("Кол-во аккаунтов", sql);

            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("Вы ввели не все данные!");
            }
            else if (textBox3.Text != textBox4.Text)
            {
                MessageBox.Show("Пароли не совпадают!");
            }
            else
            {
                sql = "insert into userr values (" + (Convert.ToInt32(Form1.ds.Tables["Кол-во аккаунтов"].Rows.Count) + 1)
                    + ", '" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "');";
                Form1.Modification_Execute(sql);

                MessageBox.Show("Ваш аккаунт успешно создан. Ожидайте подтверждение аккаунта!", "Успешно");
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            textBox4.UseSystemPasswordChar = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox3.UseSystemPasswordChar = false;
        }
    }
}
