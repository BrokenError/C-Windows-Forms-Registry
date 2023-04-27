using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace registry
{
    public partial class Запрос_Предприятие : Form
    {
        int kod;
        string sql;
        public Запрос_Предприятие()
        {
            InitializeComponent();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                sql = "SELECT company.comp_name as \"Компания\" ,s.subd_full_name AS \"Наименование подразделения\", p.place_id as \"Номер помещения\", p.place_type as \"Тип помещения\" " +
                    "FROM subdivision s " +
                    "join company on company.comp_id = s.comp_id " +
                    "JOIN document d ON s.subd_id = d.subd_id1 or s.subd_id = d.subd_id2 " +
                    "JOIN fixed_placement fp ON d.doc_id = fp.doc_id " +
                    "JOIN placement p ON fp.place_id = p.place_id " +
                    "WHERE(d.doc_date ='" + dateTimePicker1.Value + "') order by company.comp_name;";
            }
            else
            {
                for (int i = 0; i < Form1.ds.Tables["Наименования подразделений"].Rows.Count; i++)
                {
                    if (comboBox1.Text == Form1.ds.Tables["Наименования подразделений"].Rows[i]["Наименование подразделения"].ToString())
                    {
                        kod = Convert.ToInt32(Form1.ds.Tables["Наименования подразделений"].Rows[i]["Код"]);
                    }
                }

                sql = "SELECT company.comp_name as \"Компания\", s.subd_full_name AS \"Наименование подразделения\", p.place_id as \"Номер помещения\", p.place_type as \"Тип помещения\" " +
                    "FROM subdivision s " +
                    "join company on company.comp_id = s.comp_id " +
                    "JOIN document d ON(s.subd_id = d.subd_id1 or s.subd_id = d.subd_id2) " +
                    "JOIN fixed_placement fp ON d.doc_id = fp.doc_id " +
                    "JOIN placement p ON fp.place_id = p.place_id " +
                    "WHERE(d.doc_date ='" + dateTimePicker1.Value +
                    "' AND s.comp_id =" + kod + ") order by s.subd_full_name;";
            }
            Form1.Table_Fill("Выбранное предприятие по дате", sql);
            dataGridView1.DataSource = Form1.ds.Tables["Выбранное предприятие по дате"];
            dataGridView1.BackgroundColor = SystemColors.Control;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dataGridView1.AutoResizeColumns();
            dataGridView1.CurrentCell = null;
        }

        private void Запрос_Предприятие_Load(object sender, EventArgs e)
        {
            sql = "Select comp_id as \"Номер\", comp_name as \"Наименование\", comp_short_name as \"Краткое название\" from company;";
            Form1.Table_Fill("Журнал документов", sql);

            string ps = "select subd_id as \"Код\", subd_full_name AS \"Наименование подразделения\" from subdivision order by subd_id";
            Form1.Table_Fill("Наименования подразделений", ps);

            for (int i = 0; i < Form1.ds.Tables["Наименования подразделений"].Rows.Count; i++)
            {
                comboBox1.Items.Add(Form1.ds.Tables["Наименования подразделений"].Rows[i]["Наименование подразделения"]);
            }
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            radioButton4_CheckedChanged(sender, e);
            radioButton4. = true;
        }
    }
}
