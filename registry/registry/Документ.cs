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
    public partial class Документ : Form
    {
        public Документ()
        {
            InitializeComponent();
        }

        public static int n = -1;
        public static object kod = null;

        private void button3_Click(object sender, EventArgs e)
        {
            kod = textBox1.Text;
            n = dataGridView1.Rows.Count;

            Добавить_Помещение добавить_Помещение = new Добавить_Помещение();
            добавить_Помещение.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void Документ_Load(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = Form1.ds.Tables["Журнал документов"].Rows[Журнал_Документ.n]["Номер"].ToString();
                textBox2.Text = Form1.ds.Tables["Журнал документов"].Rows[Журнал_Документ.n]["Название"].ToString();
                if (Form1.ds.Tables["Журнал документов"].Rows[Журнал_Документ.n]["Дата заключения"] != DBNull.Value)
                    dateTimePicker1.Value = Convert.ToDateTime(Form1.ds.Tables["Журнал документов"].Rows[Журнал_Документ.n]["Дата заключения"].ToString());
                comboBox1.Text = Form1.ds.Tables["Журнал документов"].Rows[Журнал_Документ.n]["Первое подразделение"].ToString();
                comboBox2.Text = Form1.ds.Tables["Журнал документов"].Rows[Журнал_Документ.n]["Второе подразделение"].ToString();
            }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("Не указана редактируемая запись таблицы!!!", "Ошибка");
                this.Close(); return;
            }
            textBox1.Enabled = false;

            dataGridView1.DataSource = Form1.ds.Tables["Помещения"];
            dataGridView1.Columns["Номер"].Visible = false;
            dataGridView1.BackgroundColor = SystemColors.Control;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void Документ_Activated(object sender, EventArgs e)
        {
            string sql = "select subd_id, subd_full_name as \"Название подразделения\" from subdivision order by subd_id";
            Form1.Table_Fill("Подразделения выбор", sql);

            comboBox1.Items.Clear();
            for (int i = 0; i < Form1.ds.Tables["Подразделения выбор"].Rows.Count; i++)
            {
                comboBox1.Items.Add(Form1.ds.Tables["Подразделения выбор"].Rows[i]["Название подразделения"]);
            }

            comboBox2.Items.Clear();
            for (int i = 0; i < Form1.ds.Tables["Подразделения выбор"].Rows.Count; i++)
            {
                comboBox2.Items.Add(Form1.ds.Tables["Подразделения выбор"].Rows[i]["Название подразделения"]);
            }

            dataGridView1.AutoResizeColumns();
            dataGridView1.CurrentCell = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Подразделение подразделение= new Подразделение();
            подразделение.Show();

        }
    }
}
