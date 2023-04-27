using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace registry
{
    public partial class Помещение : Form
    {
        public Помещение()
        {
            InitializeComponent();
        }

        int n;

        private void Помещение_Load(object sender, EventArgs e)
        {
            string sql = "SELECT place_id as \"Код\", place_type as \"Тип\", place_area as \"Площадь\"" + " from placement order by place_id";
            Form1.Table_Fill("Помещение", sql);

            if (Form1.ds.Tables["Помещение"].Rows.Count > 0)
            {
                n = 0; FieldsForm_Fill();
            }

            comboBox1.Items.Add("Офис");
            comboBox1.Items.Add("Склад");
            comboBox1.Items.Add("Отдел");
            comboBox1.Items.Add("Столовая");
            comboBox1.Items.Add("Цех");

        }

        private void FieldsForm_Clear()
        {
            textBox1.Text = Convert.ToString(n + 1);
            comboBox1.Text = "";
            textBox3.Text = "";
            textBox1.ReadOnly = false;
            textBox1.Enabled = true;
            textBox1.Focus();
        }

        private void FieldsForm_Fill()
        {
            textBox1.Text = Form1.ds.Tables["Помещение"].Rows[n]["Код"].ToString();
            comboBox1.Text = Form1.ds.Tables["Помещение"].Rows[n]["Тип"].ToString();
            textBox3.Text = Form1.ds.Tables["Помещение"].Rows[n]["Площадь"].ToString();
            textBox1.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (n < Form1.ds.Tables["Помещение"].Rows.Count) n++;
            if (Form1.ds.Tables["Помещение"].Rows.Count > n)
            {
                FieldsForm_Fill();
            }
            else
            {
                FieldsForm_Clear();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            n = Form1.ds.Tables["Помещение"].Rows.Count;
            FieldsForm_Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (n > 0)
            {
                n--; FieldsForm_Fill();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Form1.ds.Tables["Помещение"].Rows.Count > 0)
            {
                n = 0; FieldsForm_Fill();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "" || textBox3.Text == "")
            {
                DialogResult result = MessageBox.Show("Данная запись будет удалена, потому что поля пустые\nДалее?", "Предупреждение", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes) { return; }
            }


            string correct = Convert.ToString(textBox3.Text).Replace(',', '.');

            string sql;
            if (n == Form1.ds.Tables["Помещение"].Rows.Count)
            {
                sql = "insert into placement values ( " + textBox1.Text + ",'" + comboBox1.Text + "'," + correct + ")";
                Console.WriteLine(sql);
                if (!Form1.Modification_Execute(sql))
                    return;
                textBox1.Enabled = false;

                Form1.ds.Tables["Помещение"].Rows.Add(new object[] { textBox1.Text, comboBox1.Text, textBox3.Text});
            }
            else
            {
                sql = "Update placement set place_type='" + comboBox1.Text + "', place_area='" + correct + "' where place_id=" + textBox1.Text;
                if (!Form1.Modification_Execute(sql))
                    return;
                Form1.ds.Tables["Помещение"].Rows[n].ItemArray = new object[] { textBox1.Text, comboBox1.Text, textBox3.Text};
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string message = "Вы точно хотите удалить из списка помещение с кодом " + textBox1.Text + "?";
            string caption = "Удаление помещения";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, caption, buttons);
            if (result == DialogResult.No) { return; }

            string sql = "delete from placement where place_id =" + textBox1.Text;
            Form1.Modification_Execute(sql);

            try
            {
                Form1.ds.Tables["Помещение"].Rows.RemoveAt(n);
            }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("Удаление не было выполнено из-за указания несущетсвующего экземпляра!!!", "Ошибка");
                return;
            }
            if (Form1.ds.Tables["Помещение"].Rows.Count > n)
            {
                FieldsForm_Fill();
            }
            else
            {
                FieldsForm_Clear();
            }
        }
    }
}
