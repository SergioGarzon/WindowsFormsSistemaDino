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
    public partial class VentasCajero : Form
    {
        public VentasCajero()
        {
            InitializeComponent();
        }

        private void VentasCajero_Load(object sender, EventArgs e)
        {
            this.toolTip1.SetToolTip(this.btnQuit,"Salir del formulario");
            this.toolTip1.SetToolTip(this.btnExcel, "Generar Excel de Ventas");
        }

        private void button1_Click(object sender, EventArgs e)
        {            
            this.Close();
            FormularioPrincipal frmPrincipal = new FormularioPrincipal();
            frmPrincipal.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            UserData usrData = new UserData();
            usrData.ShowDialog();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int legajoCashier, nroPV, nroTicket;
            legajoCashier = nroPV = nroTicket = 0;


            conectionDataBase conecDB = new conectionDataBase();

            try
            {
                if(!this.txtNroTicket.Text.Equals(""))
                    nroTicket = int.Parse(this.txtNroTicket.Text);
                
                if(!this.txtNroPV.Text.Equals(""))
                    nroPV = int.Parse(this.txtNroPV.Text);
            }
            catch(System.FormatException)
            {
                nroTicket = -1;
                nroPV = -1;
            }
            
            DataTable dt = new DataTable();
            dt = conecDB.ReportsCashierDataConnections(nroPV, nroTicket);

            DataTable dt2 = new DataTable();
            dt2 = conecDB.ReportCashierCreditDataConnections(int.Parse(this.txtNroPV.Text));
            

            dgvReportVenta.DataSource = dt;
            dgvFormaPago.DataSource = dt2;
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
           
        }
    }
}
