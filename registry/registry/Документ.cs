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



            string kod1 = null, kod2 = null;

            for (int i = 0; i < Form1.ds.Tables["Подразделения выбор"].Rows.Count; i++)
            {
                if (Form1.ds.Tables["Подразделения выбор"].Rows[i]["Название подразделения"].ToString() == comboBox1.Text)
                    kod1 = Form1.ds.Tables["Подразделения выбор"].Rows[i]["Код"].ToString();

                if (Form1.ds.Tables["Подразделения выбор"].Rows[i]["Название подразделения"].ToString() == comboBox2.Text)
                    kod2 = Form1.ds.Tables["Подразделения выбор"].Rows[i]["Код"].ToString();
            }
            string sql = "update document set doc_date_action='" + dateTimePicker2.Value + "', doc_date='" + dateTimePicker1.Value + "'," +
                " subd_id1=" + kod1 + ", subd_id2=" + kod2 + " where doc_id=" + textBox1.Text;
            if (!Form1.Modification_Execute(sql))
                return;
            Form1.ds.Tables["Журнал документов"].Rows[Журнал_Документ.n].ItemArray = new object[]
            { textBox1.Text, textBox2.Text,dateTimePicker1.Value, textBox4.Text, dateTimePicker2.Value, comboBox1.Text, comboBox2.Text};

            sql = "delete from document where doc_id=" + textBox1.Text;
            Form1.Modification_Execute(sql);

            sql = "insert into document values (" + textBox1.Text + ", '" + textBox2.Text + "', '" + dateTimePicker1.Value + "', '" + textBox4.Text
             + "', '" + dateTimePicker2.Value + "', " + kod1 + ", " + kod2 + ");";
            Console.WriteLine(sql);
            Form1.Modification_Execute(sql);

            for (int j = 0; j < Form1.ds.Tables["Помещения"].Rows.Count; j++)
            {
                sql = "insert into fixed_placement values (" + textBox1.Text + ", " + Form1.ds.Tables["Помещения"].Rows[j]["Код помещения"] + ");";
                Console.WriteLine(sql);
                Form1.Modification_Execute(sql);
            }
            this.Close();
        }

        private void Документ_Load(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = Form1.ds.Tables["Журнал документов"].Rows[Журнал_Документ.n]["Номер"].ToString();
                textBox2.Text = Form1.ds.Tables["Журнал документов"].Rows[Журнал_Документ.n]["Название"].ToString();
                if (Form1.ds.Tables["Журнал документов"].Rows[Журнал_Документ.n]["Дата заключения"] != DBNull.Value)
                    dateTimePicker1.Value = Convert.ToDateTime(Form1.ds.Tables["Журнал документов"].Rows[Журнал_Документ.n]["Дата заключения"].ToString());
                textBox4.Text = Form1.ds.Tables["Журнал документов"].Rows[Журнал_Документ.n]["Действие"].ToString();
                comboBox1.Text = Form1.ds.Tables["Журнал документов"].Rows[Журнал_Документ.n]["Арендодатель"].ToString();
                comboBox2.Text = Form1.ds.Tables["Журнал документов"].Rows[Журнал_Документ.n]["Арендатор"].ToString();
            }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("Не указана редактируемая запись таблицы!!!", "Ошибка");
                this.Close(); return;
            }
            textBox1.Enabled = false;

            dataGridView1.DataSource = Form1.ds.Tables["Помещения"];
            dataGridView1.Columns["Номер документа"].Visible = false;
            dataGridView1.BackgroundColor = SystemColors.Control;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void Документ_Activated(object sender, EventArgs e)
        {
            string sql = "select subd_id as \"Код\", subd_full_name as \"Название подразделения\", genitive as \"Арендодатель\", dative as \"Арендатор\" from subdivision order by subd_id";
            Form1.Table_Fill("Подразделения выбор", sql);

            comboBox1.Items.Clear();
            for (int i = 0; i < Form1.ds.Tables["Подразделения выбор"].Rows.Count; i++)
            {
                comboBox1.Items.Add(Form1.ds.Tables["Подразделения выбор"].Rows[i]["Арендодатель"]);
            }

            comboBox2.Items.Clear();
            for (int i = 0; i < Form1.ds.Tables["Подразделения выбор"].Rows.Count; i++)
            {
                comboBox2.Items.Add(Form1.ds.Tables["Подразделения выбор"].Rows[i]["Арендатор"]);
            }

            dataGridView1.AutoResizeColumns();
            dataGridView1.CurrentCell = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Подразделение подразделение= new Подразделение();
            подразделение.Show();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            n = dataGridView1.CurrentRow.Index;

            for (int i =0;i < Form1.ds.Tables["Помещения"].Rows.Count; i++)
            {
                if (Convert.ToInt32(Form1.ds.Tables["Помещения"].Rows[i]["Код помещения"]) == Convert.ToInt32(Form1.ds.Tables["Добавление помещения"].Rows[n]["Код"]))
                    Добавить_Помещение.n = i;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            kod = textBox1.Text;

            Добавить_Помещение добавить_Помещение = new Добавить_Помещение();
            добавить_Помещение.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string message = "Вы точно хотите удалить из документа помещение с кодом " + dataGridView1.Rows[n].Cells["Код помещения"].Value + "?";
            string caption = "Удаление помещения из документа";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, caption, buttons);
            if (result == DialogResult.No) { return; }
            string sql = "delete from document where doc_id = "+n;
            Form1.Modification_Execute(sql);
            Form1.ds.Tables["Помещения"].Rows.RemoveAt(n);
            dataGridView1.AutoResizeColumns();
            dataGridView1.CurrentCell = null;
            n = -1;
        }
    }
}
