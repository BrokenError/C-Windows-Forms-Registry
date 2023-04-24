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
        public Журнал_Документ()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Документ документ = new Документ();
            документ.ShowDialog();
            this.Show();
        }
    }
}
