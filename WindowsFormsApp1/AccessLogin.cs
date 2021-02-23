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
    public partial class AccessLogin : Form
    {
        public AccessLogin()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string user, pass, data;
            int value = 0;

            user = pass = data = "";


            user = this.txtIngreseUsuario.Text;
            pass = this.txtIngresePassword.Text;

            data = getDataError(user, pass);

            if(data == "No ha ingresado ")
            {
                value = 1;
                data = getValidateUserPass(user, pass);                
            }
                
            if(value == 1)
                if(!data.Equals(""))
                    MessageBox.Show(data, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                if(!data.Equals(""))
                    MessageBox.Show(data, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            txtIngreseUsuario.Text = "";
            txtIngresePassword.Text = "";
            txtIngreseUsuario.Focus();

            if(data.Equals(""))
            {
                this.Hide();
                FormularioPrincipal frmPrincipal = new FormularioPrincipal();
                frmPrincipal.ShowDialog();
            }

        }


        private string getDataError(string user, string pass)
        {
            string data = "No ha ingresado ";

            if (user == "")
                data += "el nombre de usuario";

            if (pass == "")
                data += "la contraseña!";

            if (user == "" && pass == "")
                data += "ni usuario ni contraseña!";

            return data;
        }

        private string getValidateUserPass(string user, string pass)
        {
            string data = "";

            if (!(user == "Administrador" && pass == "12345678"))
                data = "Usuario y Contraseña incorrectos";

            return data;                
        }


    }
}
