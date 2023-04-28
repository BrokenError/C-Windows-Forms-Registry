using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace registry
{
    public partial class Настройка_паролей : Form
    {
        public Настройка_паролей()
        {
            InitializeComponent();
        }
        string name_table, name_login;
        string sql;
        bool activate = false, valid_login = false;
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Настройка_паролей_Load(object sender, EventArgs e)
        {
            panel1.Hide();
            sql = "select * from usser order by login";

            Form1.Table_Fill("Пользователь", sql);

            for (int i = 0; i < Form1.ds.Tables["Пользователь"].Rows.Count; i++)
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
            textBox2.UseSystemPasswordChar = true;
        }


        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            activate = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < Form1.ds.Tables["Добавленные"].Rows.Count; i++)
            {
                if (comboBox1.Text == Form1.ds.Tables["Добавленные"].Rows[i]["userr_login"].ToString())
                {
                    panel1.Show();
                    valid_login = true;
                    name_login = "userr_login";
                    name_table = "userr";
                }
                else if (comboBox1.Text == Form1.ds.Tables["Пользователь"].Rows[i]["login"].ToString())
                {
                    panel1.Hide();
                    valid_login = true;
                    name_login = "login";
                    name_table = "usser";
                }
            }
        }

        private void Настройка_паролей_Activated(object sender, EventArgs e)
        {
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            activate = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sq;
            if (textBox1.Text == textBox2.Text && valid_login == true && textBox1.Text != "")
            {
                if (name_table == "userr")
                {
                    sq = "update " + name_table + " set password = '" + textBox1.Text + "', is_activate =" + activate + " where " + name_login + "='" + comboBox1.Text + "';";
                }
                else
                {
                    sq = "update " + name_table + " set password = '" + textBox1.Text + "' where " + name_login + "='" + comboBox1.Text + "';";
                }
                Form1.Modification_Execute(sq);
                Console.WriteLine(sq);
                Close();
            }
            else if (valid_login == false)
            {
                MessageBox.Show("Учётной записи не существует", "Внимание");
            }
            else if (valid_login == true)
            {
                sq = "update " + name_table + " set is_activate =" + activate + " where " + name_login + "='" + comboBox1.Text + "';";
                Console.WriteLine(sq);
                Form1.Modification_Execute(sq);
                Close();
            }
            else
            {
                MessageBox.Show("Неверное подтверждение пароля", "Внимание");
            }
        }
    }
}
