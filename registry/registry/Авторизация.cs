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
    public partial class Авторизация : Form
    {
        public Авторизация()
        {
            InitializeComponent();
        }
        string name = "", is_activate = "false";
        bool activate = true;
        string kod = "000";

        private void Авторизация_Load(object sender, EventArgs e)
        {
            string sql = "select * from usser order by login";

            Form1.Table_Fill("Пользователь", sql);

            for (int i =0; i < Form1.ds.Tables["Пользователь"].Rows.Count; i++)
            {
                comboBox1.Items.Add(Form1.ds.Tables["Пользователь"].Rows[i]["login"]);
            }

            sql = "select * from userr order by userr_login";
            Form1.Table_Fill("Добавленные", sql);

            for (int i = 0; i < Form1.ds.Tables["Добавленные"].Rows.Count; i++)
            {
                comboBox1.Items.Add(Form1.ds.Tables["Добавленные"].Rows[i]["userr_login"]);
            }

            textBox1.UseSystemPasswordChar = true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                textBox1.UseSystemPasswordChar = false;
            else
                textBox1.UseSystemPasswordChar = true;
        }
        public static string polzov = "";
        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Form1.ds.Tables["Добавленные"].Rows.Count; i++)
            {
                if (comboBox1.Text == Form1.ds.Tables["Добавленные"].Rows[i]["userr_login"].ToString())
                {
                    activate = false;
                    name = "Добавленные";
                    kod = Form1.ds.Tables["Добавленные"].Rows[i]["password"].ToString();
                    is_activate = Form1.ds.Tables["Добавленные"].Rows[i]["is_activate"].ToString();
                }
                else if (comboBox1.Text == Form1.ds.Tables["Пользователь"].Rows[i]["login"].ToString())
                {
                    activate = true;
                    name = "Пользователь";
                    kod = Form1.ds.Tables["Пользователь"].Rows[i]["password"].ToString();
                }
            }


            if (textBox1.Text == kod.ToString() && activate == true)
            {
                if (comboBox1.Text == "Менеджер")
                    polzov = "Администратор";
                Hide();
                Form1 form = new Form1(); form.ShowDialog();
                Close();
            }
            else if (kod == "000" && name == "")
            {
                MessageBox.Show("Нет такого пользователя");
            }
            else if (activate == false)
            {
                if (is_activate.ToLower() == "true" && textBox1.Text == kod.ToString())
                {
                    Hide();
                    Form1 form = new Form1(); form.ShowDialog();
                    Close();
                }
                else if (is_activate.ToLower() == "false") 
                {
                    MessageBox.Show("Доступ запрещен! Аккаунт не подтверждён");
                }
                else
                {
                    MessageBox.Show("Неправильный пароль");
                } 
            }
            else
            {
                MessageBox.Show("Неправильный пароль");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
            Регистрация form = new Регистрация(); form.ShowDialog();
            Close();
        }
    }
}
