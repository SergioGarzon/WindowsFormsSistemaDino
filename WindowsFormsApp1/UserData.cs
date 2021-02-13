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
    public partial class UserData : Form
    {

        private int valueFlag;

        public UserData()
        {
            InitializeComponent();            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conectionDataBase con = new conectionDataBase();

            DataTable dt = null;

            try
            {
                int valueLegajo = -1, tipo = -1, sucursal = -1, nroSucursal = -1;                

                if(!this.txtLegajo.Text.Equals(""))
                    valueLegajo = int.Parse(txtLegajo.Text);

                tipo = comboBox1.SelectedIndex;

                sucursal = cmbSucursales.SelectedIndex;

                switch(sucursal)
                {
                    case(0): nroSucursal = 1; //SUPER MAMI AV
                        break;
                    case(1): nroSucursal = 13; //VESTA AV
                        break;
                    case(2): nroSucursal = 3; //KARMYA AV
                        break;
                    case(3): nroSucursal = 50; //SUPER MAMI R20
                        break;
                    case(4): nroSucursal = 54; //VESTA R20
                        break;
                    case(5): nroSucursal = 110; //SUPER MAMI SV
                        break;
                    case(6): nroSucursal = 200; //SUPER MAMI CVL
                        break;
                    case(7): nroSucursal = 350; //SUPER MAMI 60C
                        break;
                    case(8): nroSucursal = 370; //SUPER MAMI AGR
                        break;
                    case(9): nroSucursal = 380; //SUPER TADICOR LH
                        break;
                    case(10): nroSucursal = 390; //SUPER TADICOR SM
                        break;
                }

                dt = con.UserDataConnections(this.txtNombreApellido.Text, valueLegajo, tipo, nroSucursal);
            }
            catch(Exception)
            {
                MessageBox.Show("Ha ingresado un legajo no valido!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtLegajo.Text = "";
                this.txtLegajo.Focus();
                return;
            }            

            if (dt == null)
                MessageBox.Show("Error, no se encuentra nada de lo solicitado!");
            else
                this.dataGridView1.DataSource = dt;

            this.txtLegajo.Text = "";
            this.txtNombreApellido.Text = "";
            this.comboBox1.SelectedIndex = -1;
            this.txtNombreApellido.Focus();
        }

        private void UserData_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = -1;
            cmbSucursales.SelectedIndex = -1;
            dataGridView1.DataSource = null;
            valueFlag = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            FormularioPrincipal frmPrincipal = new FormularioPrincipal();
            frmPrincipal.Show();
        }
    }
}
