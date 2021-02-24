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
                int[] value = { 1, 13, 3, 50, 54, 110, 200, 350, 370, 380, 390};

                if(!this.txtLegajo.Text.Equals(""))
                    valueLegajo = int.Parse(txtLegajo.Text);

                tipo = comboBox1.SelectedIndex;

                sucursal = cmbSucursales.SelectedIndex;

                for(int i = 0; i< value.Length ; i++)
                {
                    if (sucursal == i)
                        nroSucursal = value[i];
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
            {
                MessageBox.Show("Error, no se encuentra nada de lo solicitado!");
                this.dataGridView1.DataSource = null;
            }                
            else
                this.dataGridView1.DataSource = dt;

            this.txtLegajo.Text = "";
            this.txtNombreApellido.Text = "";
            this.comboBox1.SelectedIndex = -1;
            this.cmbSucursales.SelectedIndex = -1;
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
        }
    }
}
