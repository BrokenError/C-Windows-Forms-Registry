using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace registry
{
    public partial class Добавить_Помещение : Form
    {
        public Добавить_Помещение()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (n == -1) return;

            if (Form1.ds.Tables["Помещения"].Rows.Count > Документ.n)
            {
                Form1.ds.Tables["Помещения"].Rows[Документ.n]["Номер документа"] = Документ.kod;
                Form1.ds.Tables["Помещения"].Rows[Документ.n]["Код помещения"] = textBox1.Text;
                Form1.ds.Tables["Помещения"].Rows[Документ.n]["Тип"] = dataGridView1.CurrentRow.Cells["Тип помещения"].Value;
                Form1.ds.Tables["Помещения"].Rows[Документ.n]["Площадь"] = dataGridView1.CurrentRow.Cells["Площадь помещения"].Value;
            }
            else
            {
                try
                {
                    Form1.ds.Tables["Помещения"].Rows.Add(new object[] { Документ.kod, textBox1.Text, dataGridView1.CurrentRow.Cells["Тип помещения"].Value, dataGridView1.CurrentRow.Cells["Площадь помещения"].Value });
                }
                catch(NullReferenceException)
                {
                    MessageBox.Show("Сохранение экземпляра не было произведено из-за неуказания его кода!!!", "Ошибка"); return;
                }
            }

            n = -1;
            Документ.n = -1;
            this.Close();
        }

        public static int n = -1;
        private void Добавить_Помещение_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Form1.ds.Tables["Добавление помещения"];
            dataGridView1.Columns["Код"].Visible = false;
            dataGridView1.BackgroundColor = SystemColors.Control;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AutoResizeColumns();
            dataGridView1.CurrentCell = null;

            if (Form1.ds.Tables["Помещения"].Rows.Count > Документ.n)
            {
                try
                {
                    textBox1.Text = Form1.ds.Tables["Помещения"].Rows[Документ.n]["Код помещения"].ToString();
                }
                catch(IndexOutOfRangeException)
                {
                    MessageBox.Show("Не указан редактируемый экземпляр!!!", "Ошибка");
                    Close(); return;
                }

                for (int i =0; i < Form1.ds.Tables["Добавление помещения"].Rows.Count; i++)
                {
                    if (Form1.ds.Tables["Добавление помещения"].Rows[i]["Код"].ToString() == textBox1.Text)
                        n = i;
                }
                dataGridView1.Rows[n].Selected = true;
                dataGridView1.Enabled = true;
            }
            textBox1.Enabled = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            n = dataGridView1.CurrentRow.Index;
            textBox1.Text = dataGridView1.CurrentRow.Cells["Код"].Value.ToString();
        }

        private void Добавить_Помещение_FormClosed(object sender, FormClosedEventArgs e)
        {
            n = -1;
            Документ.n = -1;
        }
    }
}
