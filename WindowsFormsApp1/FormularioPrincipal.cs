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
            this.Close();
            ValidarUsuarioModificarCliente vaUsuario = new ValidarUsuarioModificarCliente(this);
            vaUsuario.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ExecuteURL("C:\\Windows\\System32\\mstsc.exe");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
            FormSGT frmSgt = new FormSGT();
            frmSgt.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ExecuteURL("\\\\srv-usuarios\\Sistemas\\Horarios\\Horarios 2021\\02-Febrero\\Horarios DEL 15-02 AL 21-02.xls");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Close();
            FormularioReportes frmReports = new FormularioReportes();
            frmReports.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            ExecuteURL("C:\\Program Files\\Microsoft SQL Server\\110\\Tools\\Binn\\ManagementStudio\\Ssms.exe");            
        }

        private void button11_Click(object sender, EventArgs e)
        {            
            ExecuteURL("C:\\Program Files\\Radmin Viewer 3\\Radmin.exe");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            ExecuteURL("C:\\Program Files\\SolarWinds\\DameWare Mini Remote Control #1\\DWRCC.exe");
        }

        private void ExecuteURL(string url)
        {
            System.Diagnostics.Process.Start(url);
        } 
    }
}
