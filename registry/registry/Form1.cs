using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace registry
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static NpgsqlConnection connection = new NpgsqlConnection("Server=127.0.0.1; User Id=postgres; Password=12345; Database=registry;");

        public static DataSet ds = new DataSet();

        public static void Table_Fill(string name, string sql)
        {
            if (ds.Tables[name] != null)
                ds.Tables[name].Clear();
            NpgsqlDataAdapter dat;
            dat = new NpgsqlDataAdapter(sql, connection);
            dat.Fill(ds, name);
            connection.Close();
        }

        public static bool Modification_Execute(string sql)
        {
            NpgsqlCommand com;
            com = new NpgsqlCommand(sql, connection);
            connection.Open();
            try
            {
                com.ExecuteNonQuery();
            }
            catch(NpgsqlException)
            {
                MessageBox.Show("Обновление базы данных не было выполнено из-за не указания обновляемых данных" + " или несоответствия их типов!!!", "Ошибка");
                connection.Close(); return false;
            }
            connection.Close();
            return true;
        }


        private void пToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void предприятиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Предприятие предприятие = new Предприятие();
            this.Hide();
            предприятие.ShowDialog();
            this.Show();
        }

        private void подразделениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Подразделение подразделение = new Подразделение();
            this.Hide();
            подразделение.ShowDialog();
            this.Show();
        }

        private void помещениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Помещение помещение = new Помещение();
            this.Hide();
            помещение.ShowDialog();
            this.Show();
        }

        private void предприятиеToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Запрос_Предприятие запрос_Предприятие = new Запрос_Предприятие();
            this.Hide();
            запрос_Предприятие.ShowDialog();
            this.Show();
        }

        private void подразделениеToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Запрос_Подразделение запрос_Подразделение = new Запрос_Подразделение();
            this.Hide();
            запрос_Подразделение.ShowDialog();
            this.Show();
        }

        private void помещениеToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Запрос_Помещение запрос_Помещение = new Запрос_Помещение();
            this.Hide();
            запрос_Помещение.ShowDialog();
            this.Show();
        }

        private void документToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Журнал_Документ журнал_Документ= new Журнал_Документ();
            this.Hide();
            журнал_Документ.ShowDialog();
            this.Show();
        }

        private void настройкаПаролейToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Настройка_паролей настройка_Паролей = new Настройка_паролей();
            this.Hide();
            настройка_Паролей.ShowDialog();
            this.Show();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            О_программе о_Программе = new О_программе();
            this.Hide();
            о_Программе.ShowDialog();
            this.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
