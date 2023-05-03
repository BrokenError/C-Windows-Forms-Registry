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
    public partial class Подразделение : Form
    {
        public Подразделение()
        {
            InitializeComponent();
        }
        int n;
        int kod;
        int kod2;

        private void Подразделение_Activated(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            string company = "Select comp_id as \"Код компании\",  comp_name as \"Название компании\" from company order by comp_id";
            Form1.Table_Fill("Предприятия", company);



            HashSet<string> set1 = new HashSet<string>();

            for (int o = 0; o < Form1.ds.Tables["Подразделение"].Rows.Count; o++)
            {
                set1.Add(Convert.ToString(Form1.ds.Tables["Подразделение"].Rows[o]["Код главного подразделения"]));
            }

            for (int i = 0; i < Form1.ds.Tables["Доступные главные подразделения"].Rows.Count; i++)
            {
                    comboBox2.Items.Add(Form1.ds.Tables["Доступные главные подразделения"].Rows[i]["Полное название"]);
            }
            comboBox2.Sorted = true;
        }

        private void Подразделение_Load(object sender, EventArgs e)
        {
            if (Авторизация.polzov != "Администратор" && Авторизация.polzov != "Продавец")
            {
                button5.Enabled = false;
                button6.Enabled = false;
            }


            string sql = "SELECT subd_id as \"Код\", subd_full_name as \"Полное название\", subd_short_name as \"Краткое название\", genitive as" +
                " \"Родительный падеж\", dative as \"Дательный падеж\", comp_id as \"Код предприятия\", subd_main as \"Код главного подразделения\""
                + " from subdivision order by subd_id";
            Form1.Table_Fill("Подразделение", sql);

            string company = "Select comp_id as \"Код компании\",  comp_name as \"Название компании\" from company order by comp_id";
            Form1.Table_Fill("Предприятия", company);

            for (int i = 0; i < Form1.ds.Tables["Предприятия"].Rows.Count; i++)
            {
                comboBox1.Items.Add(Form1.ds.Tables["Предприятия"].Rows[i]["Название компании"]);
            }
            comboBox1.Sorted = true;

            if (Form1.ds.Tables["Подразделение"].Rows.Count > 0)
            {
                n = 0; FieldsForm_Fill();
            }
        }

        private void FieldsForm_Clear()
        {
            textBox1.Text = Convert.ToString(n+1);
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";

            textBox1.Enabled = true;
            textBox1.Focus();
        }

        private void FieldsComboBox2()
        {
            for (int i = 0; i < Form1.ds.Tables["Предприятия"].Rows.Count; i++)
            {
                if (Form1.ds.Tables["Предприятия"].Rows[i]["Название компании"].ToString() == comboBox1.Text.ToString())
                {
                    kod = Convert.ToInt32(Form1.ds.Tables["Предприятия"].Rows[i]["Код компании"]);
                    break;
                }
                else
                {
                    kod = 0;
                }
            }

            string ps = "select subd_id as \"Код\", subd_full_name as \"Полное название\", subd_main as" +
                " \"Код главного подразделения\" from subdivision join company on subdivision.comp_id = company.comp_id where company.comp_id=" + kod;
            Form1.Table_Fill("Доступные главные подразделения", ps);
            comboBox2.Items.Clear();
            Console.WriteLine("yep");
            for (int i = 0; i < Form1.ds.Tables["Доступные главные подразделения"].Rows.Count; i++)
            {
                comboBox2.Items.Add(Form1.ds.Tables["Доступные главные подразделения"].Rows[i]["Полное название"]);
            }
            comboBox2.Sorted = true;
        }


        private void FieldsForm_Fill()
        {
            textBox1.Text = Form1.ds.Tables["Подразделение"].Rows[n]["Код"].ToString();
            textBox2.Text = Form1.ds.Tables["Подразделение"].Rows[n]["Полное Название"].ToString();
            textBox3.Text = Form1.ds.Tables["Подразделение"].Rows[n]["Краткое название"].ToString();
            textBox4.Text = Form1.ds.Tables["Подразделение"].Rows[n]["Родительный падеж"].ToString();
            textBox5.Text = Form1.ds.Tables["Подразделение"].Rows[n]["Дательный падеж"].ToString();
            for (int i = 0; i < Form1.ds.Tables["Предприятия"].Rows.Count; i++)
            {
                if (Convert.ToInt32(Form1.ds.Tables["Подразделение"].Rows[n]["Код предприятия"]) == Convert.ToInt32(Form1.ds.Tables["Предприятия"].Rows[i]["Код компании"]))
                {
                    comboBox1.Text = Form1.ds.Tables["Предприятия"].Rows[i]["Название компании"].ToString();
                }
            }

            FieldsComboBox2();

            for (int i = 0; i < Form1.ds.Tables["Подразделение"].Rows.Count; i++)
            {
                if (Convert.ToInt32(Form1.ds.Tables["Подразделение"].Rows[n]["Код главного подразделения"]) == Convert.ToInt32(Form1.ds.Tables["Подразделение"].Rows[i]["Код"]))
                {
                    comboBox2.Text = Form1.ds.Tables["Подразделение"].Rows[i]["Полное название"].ToString();
                }
            }

            textBox1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Form1.ds.Tables["Подразделение"].Rows.Count > 0)
            {
                n = 0; FieldsForm_Fill();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (n > 0)
            {
                n--; FieldsForm_Fill();
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (n < Form1.ds.Tables["Подразделение"].Rows.Count) n++;
            if (Form1.ds.Tables["Подразделение"].Rows.Count > n)
            {
                FieldsForm_Fill();
            }
            else
            {
                FieldsForm_Clear();
                FieldsComboBox2();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            n = Form1.ds.Tables["Подразделение"].Rows.Count;
            FieldsForm_Clear();
            FieldsComboBox2();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || comboBox1.Text == "" || comboBox2.Text == "")
            {
                DialogResult result = MessageBox.Show("Данная запись будет удалена, потому что поля пустые\nДалее?", "Предупреждение", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes) { return; }
            }


            for (int i = 0; i < Form1.ds.Tables["Подразделение"].Rows.Count; i++)
            {
                if (Form1.ds.Tables["Подразделение"].Rows[i]["Полное название"].ToString() == comboBox2.Text)
                    kod2 = Convert.ToInt32(Form1.ds.Tables["Подразделение"].Rows[i]["Код"]);

                if (comboBox2.Text == textBox2.Text)
                    kod2 = Convert.ToInt32(textBox1.Text);
            }

            string sql;
            if (n == Form1.ds.Tables["Подразделение"].Rows.Count)
            {
                sql = "insert into subdivision values ( " + textBox1.Text + ",'" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','"
                    + textBox5.Text + "','" + kod + "','" + kod2 + "')";
                if (!Form1.Modification_Execute(sql))
                    return;
                textBox1.Enabled = false;
                Form1.ds.Tables["Подразделение"].Rows.Add(new object[] { textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, kod, kod2 });
            }
            else
            {
                sql = "Update subdivision set subd_full_name='" + textBox2.Text + "', subd_short_name='" + textBox3.Text + "', genitive='"+ textBox4.Text + "'," +
                    " dative='"+ textBox5.Text + "', comp_id='" + kod + "', subd_main='" + kod2 + "' where subd_id=" + textBox1.Text;
                if (!Form1.Modification_Execute(sql))
                    return;
                Form1.ds.Tables["Подразделение"].Rows[n].ItemArray = new object[] { textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, kod, kod2};
            }
            Подразделение_Activated(sender, e);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string message = "Вы точно хотите удалить из списка подразделение с кодом " + textBox1.Text + "?";
            string caption = "Удаление подразделения";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, caption, buttons);
            if (result == DialogResult.No) { return; }
            string sql = "delete from subdivision where subd_id =" + textBox1.Text;
            Form1.Modification_Execute(sql);

            try
            {
                Form1.ds.Tables["Подразделение"].Rows.RemoveAt(n);
            }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("Удаление не было выполнено из-за указания несущетсвующего экземпляря!!!", "Ошибка");
                return;
            }
            Подразделение_Activated(sender, e);
            if (Form1.ds.Tables["Подразделение"].Rows.Count > n)
            {
                FieldsForm_Fill();
            }
            else
            {
                FieldsForm_Clear();
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            FieldsComboBox2();
        }
    }
}
