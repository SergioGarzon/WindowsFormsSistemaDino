﻿using System;
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
            this.toolTip1.SetToolTip(this.button1,"Salir del formulario");
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


        }
    }
}
