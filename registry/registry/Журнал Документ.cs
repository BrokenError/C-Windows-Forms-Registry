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
    public partial class Журнал_Документ : Form
    {
        string sql;
        public static int n = -1;
        public Журнал_Документ()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            n = dataGridView1.Rows.Count;
            int kod;
            if (n > 0)
                kod = Convert.ToInt32(dataGridView1.Rows[n - 1].Cells["Номер"].Value) + 1;
            else kod = 1;

            string sql = "Insert into document(doc_id) values (" + kod + ")";
            Form1.Modification_Execute(sql);

            Form1.ds.Tables["Журнал документов"].Rows.Add(new object[] { kod, null, null, null, null, null, null, null, null });

            sql = "select placement.place_id as \"Номер\", place_type as \"Тип\", place_area as \"Площадь\" from document inner join fixed_placement on fixed_placement.doc_id=document.doc_id inner join placement on fixed_placement.place_id=placement.place_id";
            Form1.Table_Fill("Помещения", sql);

            Документ документ = new Документ();
            документ.Show();
        }

        private void Журнал_Документ_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoResizeColumns();
            dataGridView1.CurrentCell = null;

            sql = "Select document.doc_id as \"Номер\", doc_name as \"Название\", doc_date as \"Дата заключения\", doc_action as \"Действие\", " +
                "doc_date_action as \"Дата действия\", sb1.subd_full_name as \"Первое подразделение\", sb2.subd_full_name as \"Второе подразделение\", " +
                "place_type as \"Тип помещения\", place_area as \"Площадь помещения\" from document inner join subdivision as sb1 on document.subd_id1 = sb1.subd_id join subdivision as sb2 on document.subd_id2 = sb2.subd_id inner join fixed_placement on fixed_placement.doc_id=document.doc_id" +
                " inner join placement on placement.place_id=fixed_placement.place_id";
            Form1.Table_Fill("Журнал документов", sql);
        }

        private void Журнал_Документ_Activated(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Form1.ds.Tables["Журнал документов"];
            dataGridView1.BackgroundColor = SystemColors.Control;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AutoResizeColumns();
            dataGridView1.CurrentCell = null;


            sql = "Select doc_id as \"Код\", doc_name as \"Номер\", doc_date as \"Дата заключения\", doc_action as \"Действие\"," +
                " doc_date_action as \"Дата действия\", subd_id1 as \"Код первого подразделения\", subd_id2 as \"Код второго подразделения\"" +
                " from document";
            Form1.Table_Fill("Документы", sql);

            int p = dataGridView1.Rows.Count - 1;
            if (dataGridView1.Rows[p].Cells["Действие"].Value.ToString() == "" || dataGridView1.Rows[p].Cells["Дата действия"].Value.ToString() == "")
            {
                sql = "delete from document where doc_id=" + dataGridView1.Rows[p].Cells["Номер"].Value;
                Form1.Modification_Execute(sql);
                Form1.ds.Tables["Журнал документов"].Rows.RemoveAt(p);

                dataGridView1.AutoResizeColumns();
                dataGridView1.CurrentCell = null;
                n = -1;
            }
        }
    }
}
