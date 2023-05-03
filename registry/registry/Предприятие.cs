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
    public partial class Предприятие : Form
    {
        public Предприятие()
        {
            InitializeComponent();
        }
        int n;

        private void Предприятие_Load(object sender, EventArgs e)
        {
            if (Авторизация.polzov != "Администратор" && Авторизация.polzov != "Продавец")
            {
                button5.Enabled = false;
                button6.Enabled = false;
            }


            string sql = "SELECT comp_id as \"Код\", comp_name as \"Название\", comp_short_name as \"Краткое название\"" + " from company order by comp_id";
            Form1.Table_Fill("Предприятие",sql);

            if (Form1.ds.Tables["Предприятие"].Rows.Count > 0)
            {
                n = 0; FieldsForm_Fill();
            }

        }

        private void FieldsForm_Clear()
        {
            textBox1.Text = Convert.ToString(n+1);
            textBox2.Text = "";
            textBox3.Text = "";
            textBox1.ReadOnly = false;
            textBox1.Enabled = true;
            textBox1.Focus();
        }

        private void FieldsForm_Fill()
        {
            textBox1.Text = Form1.ds.Tables["Предприятие"].Rows[n]["Код"].ToString();
            textBox2.Text = Form1.ds.Tables["Предприятие"].Rows[n]["Название"].ToString();
            textBox3.Text = Form1.ds.Tables["Предприятие"].Rows[n]["Краткое название"].ToString();
            textBox1.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (n < Form1.ds.Tables["Предприятие"].Rows.Count) n++;
            if (Form1.ds.Tables["Предприятие"].Rows.Count > n)
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
            n = Form1.ds.Tables["Предприятие"].Rows.Count;
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
            if (Form1.ds.Tables["Предприятие"].Rows.Count > 0)
            {
                n = 0; FieldsForm_Fill();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || textBox3.Text == "")
            {
                DialogResult result = MessageBox.Show("Данная запись будет удалена, потому что поля пустые\nДалее?", "Предупреждение", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes) { return; }
            }


            string sql;
            if (n == Form1.ds.Tables["Предприятие"].Rows.Count)
            {
                sql = "insert into company values ( " + textBox1.Text + ",'" + textBox2.Text + "','" + textBox3.Text + "'" + ")";
                if (!Form1.Modification_Execute(sql))
                    return;
                textBox1.Enabled = false;

                Form1.ds.Tables["Предприятие"].Rows.Add(new object[] { textBox1.Text, textBox2.Text, textBox3.Text });
            }
            else
            {
                sql = "Update company set comp_name='" + textBox2.Text + "', comp_short_name='" + textBox3.Text + "' where comp_id="+ textBox1.Text;
                if (!Form1.Modification_Execute(sql))
                    return;
                Form1.ds.Tables["Предприятие"].Rows[n].ItemArray = new object[] { textBox1.Text, textBox2.Text, textBox3.Text };
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            string message = "Вы точно хотите удалить из списка предприятие с кодом " + textBox1.Text + "?";
            string caption = "Удаление компании";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, caption, buttons);
            if (result == DialogResult.No) { return; }

            string sql = "delete from company where comp_id =" + textBox1.Text;
            Form1.Modification_Execute(sql);

            try
            {
                Form1.ds.Tables["Предприятие"].Rows.RemoveAt(n);
            }
            catch(IndexOutOfRangeException)
            {
                MessageBox.Show("Удаление не было выполнено из-за указания несущетсвующего экземпляра!!!", "Ошибка");
                return;
            }
            if (Form1.ds.Tables["Предприятие"].Rows.Count > n)
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
