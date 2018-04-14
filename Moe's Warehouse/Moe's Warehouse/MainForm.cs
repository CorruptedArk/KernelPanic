using KernalPanic.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class FormMain : Form
    {
        const int LOGIN_NAV_ID = 0;
        const int ITEM_NAV_ID = 1;
        const int ORDER_NAV_ID = 2;
        const int WAREHOUSE_NAV_ID = 3;
        const int EMPLOYEE_NAV_ID = 4;
        const int BATCH_NAV_ID = 5;
        readonly Color DEFAULT_BACKGROUND = Color.FromArgb(64, 64, 64);
        private List<Panel> panelList = new List<Panel>();

        private string currentUser;

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            lblCurrentScreen.Text = "LOGIN";
            lblStatus.Text = "";
            HideNav();
            panelList.Add(loginPanel);
            panelList.Add(itemPanel);
            panelList.Add(orderPanel);
            panelList.Add(warehousePanel);
            panelList.Add(employeePanel);
            panelList.Add(batchPanel);
            SetMainView(LOGIN_NAV_ID);
            btnBatch.Visible = false;
        }

        private void HideNav()
        {
            btnItem.Hide();
            btnOrder.Hide();
            btnWarehouse.Hide();
            btnEmployee.Hide();
        }

        private void ShowNav()
        {
            btnItem.Show();
            btnOrder.Show();
            btnWarehouse.Show();
            btnEmployee.Show();
        }

        // Handles which button is currently selected, changes the background color
        // val is based on what order the button comes in, starting at 0
        private void changeNav(int val)
        {
            btnLogin.BackColor = DEFAULT_BACKGROUND;
            btnOrder.BackColor = DEFAULT_BACKGROUND;
            btnItem.BackColor = DEFAULT_BACKGROUND;
            btnWarehouse.BackColor = DEFAULT_BACKGROUND;
            btnEmployee.BackColor = DEFAULT_BACKGROUND;
            switch (val)
            {
                case LOGIN_NAV_ID:
                    btnLogin.BackColor = Color.Gray;
                    SetMainView(LOGIN_NAV_ID);
                    break;
                case ITEM_NAV_ID:
                    btnItem.BackColor = Color.Gray;
                    SetMainView(ITEM_NAV_ID);
                    break;
                case ORDER_NAV_ID:
                    btnOrder.BackColor = Color.Gray;
                    SetMainView(ORDER_NAV_ID);
                    break;
                case WAREHOUSE_NAV_ID:
                    btnWarehouse.BackColor = Color.Gray;
                    SetMainView(WAREHOUSE_NAV_ID);
                    break;
                case EMPLOYEE_NAV_ID:
                    btnEmployee.BackColor = Color.Gray;
                    SetMainView(EMPLOYEE_NAV_ID);
                    break;
                case BATCH_NAV_ID:
                    SetMainView(BATCH_NAV_ID);
                    break;
                
            }
        }

        // Sets the panel at navID in panelList as the visible panel and hides the others
        private void SetMainView(int navID)
        {
            for (int i = 0; i < panelList.Count; i++)
            {
                if (i == navID)
                {
                    panelList[i].Visible = true;
                }
                else
                {
                    panelList[i].Visible = false;
                }
            }
        }

        //**************
        //* log in/out *
        //**************
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (lblLogin.Text == "Logout")
            {
                lblLogin.Text = "Login";
                HideNav();
                btnBatch.Visible = false;
                changeNav(LOGIN_NAV_ID);
                lblCurrentScreen.Text = "LOGIN";
                picLogin.Image = Resources.login;
            }
            
        }

        private void lblLogin_Click(object sender, EventArgs e)
        {
            btnLogin_Click(null, null);
        }

        private void picLogin_Click(object sender, EventArgs e)
        {
            btnLogin_Click(null, null);
        }

        private void loginEnterButton_Click(object sender, EventArgs e)
        {
            // check for valid login information
            string username = userNameBox.Text;
            string password = passwordBox.Text;

            if (true) // this needs to be the login success condition when the database is established.
            {
                userNameBox.Text = "";
                passwordBox.Text = "";
                currentUser = username;
                lblLogin.Text = "Logout";
                ShowNav();
                btnBatch.Visible = true;
                lblCurrentScreen.Text = "ITEM";
                changeNav(ITEM_NAV_ID);
                picLogin.Image = Resources.logout;
            }
        }

        //******************
        //* End log in/out *
        //******************

        //*************
        //*Item Button*
        //*************

        // Item click function
        // Sets title, and changes background color
        private void btnItem_Click(object sender, EventArgs e)
        {
            lblCurrentScreen.Text = "ITEM";
            changeNav(ITEM_NAV_ID);
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
            changeNav(ORDER_NAV_ID);
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
            changeNav(WAREHOUSE_NAV_ID);
        }
        //*****************
        //* End Warehouse *
        //*****************


        //*****************
        //* Employee *
        //*****************

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            lblCurrentScreen.Text = "EMPLOYEE";
            changeNav(EMPLOYEE_NAV_ID);
        }

        private void picEmployee_Click(object sender, EventArgs e)
        {
            btnEmployee_Click(null, null);
        }

        private void lblEmployee_Click(object sender, EventArgs e)
        {
            btnEmployee_Click(null, null);
        }


        //*****************
        //* End Employee *
        //*****************

        //*****************
        //* Batch *
        //*****************
        private void btnBatch_Click(object sender, EventArgs e)
        {
            HideNav();
            btnBatch.Visible = false;
            lblCurrentScreen.Text = "BATCH";
            changeNav(BATCH_NAV_ID);

            batchProcess();

            ShowNav();
            btnBatch.Visible = true;
        }

        // This function will hold the batch process. The contents are currently a placeholder for demonstration
        private void batchProcess()
        {
            batchTestLabel.Text = "Starting...";
            Refresh();

            System.Threading.Thread.Sleep(5000);

            batchTestLabel.Text = "Done";
            
        }

        //*****************
        //* End Batch *
        //*****************

    }
}
