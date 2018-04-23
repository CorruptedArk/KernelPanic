using KernalPanic;
using KernalPanic.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;

namespace WindowsFormsApplication1
{
    public partial class FormMain : Form
    {
        //Navigation Panel Order
        const int LOGIN_NAV_ID = 0;
        const int ITEM_NAV_ID = 1;
        const int ORDER_NAV_ID = 2;
        const int WAREHOUSE_NAV_ID = 3;
        const int EMPLOYEE_NAV_ID = 4;
        const int BATCH_NAV_ID = 5;

        //Default Background color
        readonly Color DEFAULT_BACKGROUND = Color.FromArgb(64, 64, 64);

        //List of panels
        private List<Panel> panelList = new List<Panel>();
        private DataAccess session = new DataAccess();

        private string currentUser;
        private bool isInEditMode = false;

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            InitializePanelList();

            //Logout at start to initilize everything... removes code redundancy
            lblLogin.Text = "Logout";
            Logout();

            SetMainView(LOGIN_NAV_ID);
        }

        private void InitializePanelList()
        {
            panelList.Add(loginPanel);
            panelList.Add(itemPanel);
            panelList.Add(orderPanel);
            panelList.Add(warehousePanel);
            panelList.Add(employeePanel);
            panelList.Add(batchPanel);
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
            string name = currentUser;
            btnItem.Show();
            btnOrder.Show();
            btnWarehouse.Show();
            if (session.CheckAdmin(name)) // has permission to view/edit employees, check permission from database
            {
                btnEmployee.Show();
            }
        }

        private void DisplayError(string errorMsg)
        {
            lblStatus.Text = errorMsg;
            pnStatus.Show();
        }

        private void ClearError()
        {
            lblStatus.Text = "";
            pnStatus.Hide();
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
                panelList[i].Visible = false;
            }
            panelList[navID].Visible = true;
        }

        //**************
        //* log in/out *
        //**************

        private void Logout()
        {
            if (lblLogin.Text == "Logout")
            {
                ClearError();
                currentUser = "";
                lblLogin.Text = "Login";
                picLogin.BackColor = DEFAULT_BACKGROUND;
                lblLogin.BackColor = DEFAULT_BACKGROUND;
                HideNav();
                btnBatch.Visible = false;
                changeNav(LOGIN_NAV_ID);
                lblCurrentScreen.Text = "LOGIN";
                picLogin.Image = Resources.login;
                userNameBox.Focus();
                this.AcceptButton = loginEnterButton;
            }
        }
        
        private void btnLogin_Click(object sender, EventArgs e)
        {
            Logout();
        }

        private void lblLogin_Click(object sender, EventArgs e)
        {
            btnLogin_Click(null, null);
        }

        private void picLogin_Click(object sender, EventArgs e)
        {
            btnLogin_Click(null, null);
        }

        private void Login()
        {
            // check for valid login information
            string username = userNameBox.Text;
            string password = passwordBox.Text;           

            if(username == "")
            {
                DisplayError("Error: Username Cannot Be Empty!");
            }
            else if (password == "")
            {
                DisplayError("Error: Password Cannot Be Empty!");
            }           
            else if (session.VerifyUsernameAndPassword(username, password))  // verify user entered correct login credentials
            {
                ClearError();
                userNameBox.Text = "";
                passwordBox.Text = "";
                currentUser = username;
                lblLogin.Text = "Logout";
                lblLogin.BackColor = Color.Red;
                picLogin.BackColor = Color.Red;
                ShowNav();
                btnBatch.Visible = true;
                lblCurrentScreen.Text = "ITEM";
                changeNav(ITEM_NAV_ID);
                picLogin.Image = Resources.logout;

                itemViewButton.BackColor = Color.Gray;
                itemEditButton.BackColor = Color.White;
                isInEditMode = false;
            }
            else
            {
                DisplayError("Error: Username/Password Combination Is Invalid!");
            }
        }

        private void loginEnterButton_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void loginResetButton_Click(object sender, EventArgs e)
        {
            userNameBox.Text = "";
            passwordBox.Text = "";
            ClearError();
        }

        //******************
        //* End log in/out *
        //******************

        //*************
        //*   Item    *
        //*************

        // Item click function
        // Sets title, and changes background color
        private void btnItem_Click(object sender, EventArgs e)
        {
            lblCurrentScreen.Text = "ITEM";

            if(isInEditMode)
            {
                itemViewButton.BackColor = Color.White;
                itemEditButton.BackColor = Color.Gray;

            }
            else
            {
                itemViewButton.BackColor = Color.Gray;
                itemEditButton.BackColor = Color.White;
            }

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

        private void itemViewButton_Click(object sender, EventArgs e)
        {
            itemViewButton.BackColor = Color.Gray;
            itemEditButton.BackColor = Color.White;

            isInEditMode = false;
        }

        private void itemEditButton_Click(object sender, EventArgs e)
        {
            itemEditButton.BackColor = Color.Gray;
            itemViewButton.BackColor = Color.White;

            isInEditMode = true;
        }


        private void itemSearchBox_Click(object sender, EventArgs e)
        {
            if (itemSearchBox.Text == "Search")
            {
                itemSearchBox.Text = "";
            }
        }


        private void itemSearchBox_Leave(object sender, EventArgs e)
        {
            if (itemSearchBox.Text == "")
            {
                itemSearchBox.Text = "Search";
            }
        }

        private void itemSearchButton_Click(object sender, EventArgs e)
        {

        }

        //**************
        //*  End Item  *
        //**************

        //**************
        //*    Order   *
        //**************

        // Main Order click function
        // Sets title, and changes background color
        private void btnOrder_Click(object sender, EventArgs e)
        {
            lblCurrentScreen.Text = "ORDER";

            if(isInEditMode)
            {
                orderViewButton.BackColor = Color.White;
                orderEditButton.BackColor = Color.Gray;
            }
            else
            {
                orderViewButton.BackColor = Color.Gray;
                orderEditButton.BackColor = Color.White;
            }

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


        private void orderViewButton_Click(object sender, EventArgs e)
        {
            orderViewButton.BackColor = Color.Gray;
            orderEditButton.BackColor = Color.White;
            isInEditMode = false;
        }

        private void orderEditButton_Click(object sender, EventArgs e)
        {
            orderEditButton.BackColor = Color.Gray;
            orderViewButton.BackColor = Color.White;
            isInEditMode = true;
        }

        private void orderSearchBox_Click(object sender, EventArgs e)
        {
            if (orderSearchBox.Text == "Search")
            {
                orderSearchBox.Text = "";
            }
        }

        private void orderSearchBox_Leave(object sender, EventArgs e)
        {
            if (orderSearchBox.Text == "")
            {
                orderSearchBox.Text = "Search";
            }
        }

        //*************
        //* End Order *
        //*************


        //*****************
        //*   Warehouse   *
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

            if(isInEditMode)
            {
                warehouseEditButton.BackColor = Color.Gray;
                warehouseViewButton.BackColor = Color.White;
            }
            else
            {
                warehouseViewButton.BackColor = Color.Gray;
                warehouseEditButton.BackColor = Color.White;
            }

            changeNav(WAREHOUSE_NAV_ID);
        }


        private void warehouseViewButton_Click(object sender, EventArgs e)
        {
            warehouseViewButton.BackColor = Color.Gray;
            warehouseEditButton.BackColor = Color.White;
            isInEditMode = false;
        }

        private void warehouseEditButton_Click(object sender, EventArgs e)
        {
            warehouseViewButton.BackColor = Color.White;
            warehouseEditButton.BackColor = Color.Gray;
            isInEditMode = true;
        }

        
        //*****************
        //* End Warehouse *
        //*****************


        //*****************
        //*    Employee   *
        //*****************

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            lblCurrentScreen.Text = "EMPLOYEE";

            if (isInEditMode)
            {
                employeeEditButton.BackColor = Color.Gray;
                employeeViewButton.BackColor = Color.White;
            }
            else
            {
                employeeEditButton.BackColor = Color.White;
                employeeViewButton.BackColor = Color.Gray;
            }

            changeNav(EMPLOYEE_NAV_ID);

            InitList();
        }

        private void picEmployee_Click(object sender, EventArgs e)
        {
            btnEmployee_Click(null, null);
        }

        private void lblEmployee_Click(object sender, EventArgs e)
        {
            btnEmployee_Click(null, null);
        }

        private void employeeViewButton_Click(object sender, EventArgs e)
        {
            employeeViewButton.BackColor = Color.Gray;
            employeeEditButton.BackColor = Color.White;
            isInEditMode = false;
        }

        private void employeeEditButton_Click(object sender, EventArgs e)
        {
            employeeEditButton.BackColor = Color.Gray;
            employeeViewButton.BackColor = Color.White;
            isInEditMode = true;
        }


        private void InitList()
        {
            string employees = session.getEmployees();
            List<string> stringList = employees.Split(',').ToList<string>();
            lvEmployees.Clear();
            int size = lvEmployees.Width;
            lvEmployees.View = View.Details;
            lvEmployees.Columns.Add("ID", size / 4, HorizontalAlignment.Center);
            lvEmployees.Columns.Add("Username", size / 4, HorizontalAlignment.Center);
            lvEmployees.Columns.Add("EmailAddr", size / 4, HorizontalAlignment.Center);
            lvEmployees.Columns.Add("IsAdmin", size / 4, HorizontalAlignment.Center);
            //lines below are test data
            for(int i = 1; i < stringList.Count(); i+=4)
            {
                lvEmployees.Items.Add(new ListViewItem(new[] { stringList[i], stringList[i + 1], stringList[i+2], stringList[i+3] }));
            }
        }
        //*****************
        //* End Employee *
        //*****************

        //*****************
        //*     Batch     *
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
            BatchProcessor batch = new BatchProcessor();
            batchTestLabel.Text = "Starting...";
            Refresh();

            batch.run();

            batchTestLabel.Text = "Done";
            
        }
        //*****************
        //*   End Batch   *
        //*****************

    }
}
