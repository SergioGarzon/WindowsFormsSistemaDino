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

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            AccessLogin access = new AccessLogin();
            access.Show();               
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ValidarUsuarioModificarCliente vaUsuario = new ValidarUsuarioModificarCliente(this);
            vaUsuario.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string url = "C:\\Windows\\System32\\mstsc.exe";
            StartURL(url);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
            FormSGT frmSgt = new FormSGT();
            frmSgt.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string url = "\\\\srv-usuarios\\Sistemas\\Horarios\\Horarios 2021\\02-Febrero\\Horarios DEL 15-02 AL 21-02.xls";
            StartURL(url);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Close();
            FormularioReportes frmReports = new FormularioReportes();
            frmReports.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string url = "C:\\Program Files\\Microsoft SQL Server\\110\\Tools\\Binn\\ManagementStudio\\Ssms.exe";
            StartURL(url);
        }

        private void button11_Click(object sender, EventArgs e)
        {            
            string url = "C:\\Program Files\\Radmin Viewer 3\\Radmin.exe";
            StartURL(url);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            string url = "C:\\Program Files\\SolarWinds\\DameWare Mini Remote Control #1\\DWRCC.exe";
            StartURL(url);
        }

        private void ExecuteURL(string url)
        {
            System.Diagnostics.Process.Start(url);
        }

        private void FormularioPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void StartURL(string url)
        {
            ExecuteURL(url);
        }
            

        private void button4_Click(object sender, EventArgs e)
        {
            BuscarTelefono buscarTel = new BuscarTelefono();
            buscarTel.Show();
        }
    }
}
