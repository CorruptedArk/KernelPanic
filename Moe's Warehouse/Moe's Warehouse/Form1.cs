using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            lblCurrentScreen.Text = "ITEM";
            lblStatus.Text = "";
        }


        // Handles which button is currently selected, changes the background color
        // val is based on what order the button comes in, starting at 0
        private void changeNav(int val)
        {
            btnOrder.BackColor = Color.FromArgb(64, 64, 64);
            btnItem.BackColor = Color.FromArgb(64, 64, 64);
            btnWarehouse.BackColor = Color.FromArgb(64, 64, 64);
            switch (val)
            {
                case 0:
                    btnItem.BackColor = Color.Gray;
                    break;
                case 1:
                    btnOrder.BackColor = Color.Gray;
                    break;
                case 2:
                    btnWarehouse.BackColor = Color.Gray;
                    break;
            }
        }

        //*************
        //*Item Button*
        //*************

        // Item click function
        // Sets title, and changes background color
        private void btnItem_Click(object sender, EventArgs e)
        {
            lblCurrentScreen.Text = "ITEM";
            changeNav(0);
        }

        // calls item click function
        private void picItem_Click(object sender, EventArgs e)
        {
            btnItem_Click(null, null);
        }

        // calls main home click function
        private void lblItem_Click(object sender, EventArgs e)
        {
            btnItem_Click(null, null);
        }
        //**************
        //* End Button *
        //**************

        //**************
        //*Order Button*
        //**************

        // Main Order click function
        // Sets title, and changes background color
        private void btnOrder_Click(object sender, EventArgs e)
        {
            lblCurrentScreen.Text = "ORDER";
            changeNav(1);
        }

        // calls main order click function
        private void lblOrder_Click(object sender, EventArgs e)
        {
            btnOrder_Click(null, null);
        }

        // calls main order click function
        private void picOrder_Click(object sender, EventArgs e)
        {
            btnOrder_Click(null, null);
        }
        //*************
        //* End Order *
        //*************


        //*****************
        //* Warehouse *
        //*****************

        // calls main Warehouse click function
        private void picWarehouse_Click(object sender, EventArgs e)
        {
            btnWarehouse_Click(null, null);
        }

        // calls main Warehouse click function
        private void lblWarehouse_Click(object sender, EventArgs e)
        {
            btnWarehouse_Click(null, null);
        }

        // Sets title, and changes background color
        private void btnWarehouse_Click(object sender, EventArgs e)
        {
            lblCurrentScreen.Text = "WAREHOUSE";
            changeNav(2);
        }
        //*****************
        //* End Warehouse *
        //*****************
    }
}
