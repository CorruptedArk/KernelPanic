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
            lblCurrentScreen.Text = "HOME";
            lblStatus.Text = "";
        }


        // Handles which button is currently selected, changes the background color
        // val is based on what order the button comes in, starting at 0
        private void changeNav(int val)
        {
            switch(val)
            {
                case 0:
                    btnHome.BackColor = Color.Gray;
                    btnOrder.BackColor = Color.FromArgb(64, 64, 64);
                    break;
                case 1:
                    btnHome.BackColor = Color.FromArgb(64, 64, 64);
                    btnOrder.BackColor = Color.Gray;
                    break;
            }
        }

        //*************
        //*Home Button*
        //*************

        // Main Home click function
        // Sets title, and changes background color
        private void btnHome_Click(object sender, EventArgs e)
        {
            lblCurrentScreen.Text = "HOME";
            changeNav(0);
        }

        // calls main home click function
        private void picHome_Click(object sender, EventArgs e)
        {
            btnHome_Click(null, null);
        }

        // calls main home click function
        private void lblHome_Click(object sender, EventArgs e)
        {
            btnHome_Click(null, null);
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
    }
}
