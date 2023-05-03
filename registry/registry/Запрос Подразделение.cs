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
    public partial class Запрос_Подразделение : Form
    {
        string sql; int kod;
        public Запрос_Подразделение()
        {
            InitializeComponent();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text == "")
            {
                sql = "select extract(YEAR from d.doc_date) as \"Год\", s.subd_full_name as \"Название_предприятия\", d.doc_date_action as \"Дата_действия\", count(distinct fp.place_id) " +
                    "as \"Количество\", sum(placement.place_area) as \"Сумма площадей\" from document d join fixed_placement fp on d.doc_id = fp.doc_id" +
                    " join placement on placement.place_id = fp.place_id join subdivision s on d.subd_id1 = s.subd_id join company on company.comp_id = s.comp_id" +
                    " where d.doc_date between '" + dateTimePicker1.Value + "' and '" + dateTimePicker2.Value + "' group by Год, Дата_действия, Название_предприятия order by Год;";
            }
            else
            {
                for (int i = 0; i < Form1.ds.Tables["Наименования подразделений"].Rows.Count; i++)
                {
                    if (comboBox2.Text == Form1.ds.Tables["Наименования подразделений"].Rows[i]["Наименование подразделения"].ToString())
                    {
                        kod = Convert.ToInt32(Form1.ds.Tables["Наименования подразделений"].Rows[i]["Код"]);
                    }
                }

                sql = "select extract (YEAR from d.doc_date) as \"Год\", s.subd_full_name as \"Название_предприятия\", d.doc_date_action as \"Дата_действия\", count(distinct fp.place_id) as \"Количество помещений\"," +
                    " sum(placement.place_area) as \"Суммарная площадь\" from document d join fixed_placement fp on d.doc_id=fp.doc_id join" +
                    " placement on placement.place_id = fp.place_id join subdivision s on d.subd_id1 = s.subd_id" +
                    " where s.subd_id =" + kod + " and d.doc_date between '" + dateTimePicker1.Value + "' and '" + dateTimePicker2.Value + "' group by Год, Дата_действия, Название_предприятия order by Год;";
            }
            Form1.Table_Fill("Динамика площадей", sql);

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = Form1.ds.Tables["Динамика площадей"];
            dataGridView1.BackgroundColor = SystemColors.Control;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dataGridView1.AutoResizeColumns();
            dataGridView1.CurrentCell = null;
        }

        private void Запрос_Подразделение_Load(object sender, EventArgs e)
        {
            sql = "Select subdivision.subd_id as \"Номер\", subdivision.subd_full_name as \"Наименование\", subdivision.subd_short_name as \"Краткое название\"," +
                "subdivision.genitive as \"Родительный падеж\", subdivision.dative as \"Дательный падеж\", company.comp_name as \"Название компании\"," +
                "sb1.subd_full_name as \"Главное подразеделение\"  from subdivision join company on company.comp_id = subdivision.comp_id join subdivision as sb1 on sb1.subd_main = subdivision.subd_id;";
            Form1.Table_Fill("Запрос предприятия", sql);

            string ps = "select subd_id as \"Код\", subd_full_name AS \"Наименование подразделения\" from subdivision order by subd_id";
            Form1.Table_Fill("Наименования подразделений", ps);

            for (int i = 0; i < Form1.ds.Tables["Наименования подразделений"].Rows.Count; i++)
            {
                comboBox2.Items.Add(Form1.ds.Tables["Наименования подразделений"].Rows[i]["Наименование подразделения"]);
            }

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = Form1.ds.Tables["Запрос предприятия"];
            dataGridView1.Columns["Номер"].Visible = false;
            dataGridView1.BackgroundColor = SystemColors.Control;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dataGridView1.AutoResizeColumns();
            dataGridView1.CurrentCell = null;

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = Form1.ds.Tables["Запрос предприятия"];
            dataGridView1.Columns["Номер"].Visible = false;
            dataGridView1.BackgroundColor = SystemColors.Control;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dataGridView1.AutoResizeColumns();
            dataGridView1.CurrentCell = null;

        }
    }
}
