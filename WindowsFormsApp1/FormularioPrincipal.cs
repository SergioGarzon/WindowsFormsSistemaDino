using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FormularioPrincipal : Form
    {
        public FormularioPrincipal()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserData usr = new UserData();
            usr.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            VentasCajero vtnCashier = new VentasCajero();
            vtnCashier.ShowDialog();            
        }
    }
}
