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

        //current display
        private int currentNavID;

        //Default Background color
        readonly Color DEFAULT_BACKGROUND = Color.FromArgb(64, 64, 64);

        //List of panels
        private List<Panel> panelList = new List<Panel>();

        // Establish database connections
        private DataAccess session = new DataAccess();

        private string currentUser; // Current user, changes on login / logout
        private bool isInEditMode = false; // Determines if content can be changed or not

        //constructor
        public FormMain()
        {
            InitializeComponent();
            InitializePanelList();
        }

        // Main form load component that handles setting up the initial view
        private void FormMain_Load(object sender, EventArgs e)
        {
            //Logout at start to initilize everything... removes code redundancy
            lblLogin.Text = "Logout";
            Logout();

            SetMainView(LOGIN_NAV_ID);
        }

        // Initializes main displays for future use
        private void InitializePanelList()
        {
            panelList.Add(loginPanel);
            panelList.Add(itemPanel);
            panelList.Add(orderPanel);
            panelList.Add(warehousePanel);
            panelList.Add(employeePanel);
            panelList.Add(batchPanel);
        }

        // Hides all panels after user logout, during batch process, and on other system lock downs
        private void HideNav()
        {
            btnItem.Hide();
            btnOrder.Hide();
            btnWarehouse.Hide();
            btnEmployee.Hide();
        }

        // Determines the type of access a user has and customizes the interface accordingly
        private void ShowNav()
        {
            string name = currentUser;
            btnItem.Show();
            btnOrder.Show();
            btnWarehouse.Show();
            if (session.CheckAdmin(name)) // Has permission to view/edit employees, check permission from database
            {
                btnEmployee.Show();
            }
        }

        // Displays error to user
        private void DisplayError(string errorMsg)
        {
            lblStatus.Text = errorMsg;
            pnStatus.Show();
        }

        // Clears bottom error / status bar
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

        // Sets the panel at navID in panelList as the visible panel and hides the others, also handles docking the panels
        private void SetMainView(int navID)
        {
            for (int i = 0; i < panelList.Count; i++)
            {
                panelList[i].Dock = DockStyle.None;
                panelList[i].Visible = false;
            }
            panelList[navID].Visible = true;
            panelList[navID].BringToFront();
            panelList[navID].Dock = DockStyle.Fill;
            currentNavID = navID;
        }



        //handles all windows form resize adjustments, to keep the UI consistent and reduce overflow
        private void FormMain_ResizeEnd(object sender, EventArgs e)
        {
            int maxSize;
            switch (currentNavID)
            {
                case ITEM_NAV_ID:
                    // Add If Needed
                    break;
                case ORDER_NAV_ID:
                    // Add If Needed
                    break;
                case WAREHOUSE_NAV_ID:
                    // Add If Needed
                    break;
                case EMPLOYEE_NAV_ID:
                    // resizes listview columns, to keep everything within margins
                    maxSize = (lvEmployees.Width - 4) / 4;
                    for (int i = 0; i < lvEmployees.Columns.Count; i++)
                    {
                        lvEmployees.Columns[i].Width = maxSize;
                    }
                    break;
            }
        }

        //**************
        //* log in/out *
        //**************

        // Verifies logout is possible, if it is it clears the session and sets it up for the next user
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
                picBatch.Image = Resources.gear;
                userNameBox.Focus();
                this.AcceptButton = loginEnterButton;
            }
        }

        // Calls function to check if log out is possible
        private void btnLogin_Click(object sender, EventArgs e)
        {
            Logout();
        }

        // Calls main login / logout click function
        private void lblLogin_Click(object sender, EventArgs e)
        {
            btnLogin_Click(null, null);
        }

        // Calls main login / logout click function
        private void picLogin_Click(object sender, EventArgs e)
        {
            btnLogin_Click(null, null);
        }

        // Verifies login, checks for user name, password, if it's in database, and if they match
        private void Login()
        {
            // Check for valid login information
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
            else if (session.VerifyUsernameAndPassword(username, password))  // Verify user entered correct login credentials
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

        // Calls function to verify login
        private void loginEnterButton_Click(object sender, EventArgs e)
        {
            Login();
        }

        // Reset button, clears errors and textboxes
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

        // Calls item click function
        private void picItem_Click(object sender, EventArgs e)
        {
            btnItem_Click(null, null);
        }

        // Calls main home click function
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

        // When user clicks search box, clear it
        private void itemSearchBox_Click(object sender, EventArgs e)
        {
            if (itemSearchBox.Text == "Search")
            {
                itemSearchBox.Text = "";
            }
        }

        // When user clicks away from search box, reset it
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

        // Calls main order click function
        private void lblOrder_Click(object sender, EventArgs e)
        {
            btnOrder_Click(null, null);
        }

        // Calls main order click function
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


        // When user clicks search box, clear it
        private void orderSearchBox_Click(object sender, EventArgs e)
        {
            if (orderSearchBox.Text == "Search")
            {
                orderSearchBox.Text = "";
            }
        }

        // When user clicks away from search box, reset it
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

        // Calls main Warehouse click function
        private void picWarehouse_Click(object sender, EventArgs e)
        {
            btnWarehouse_Click(null, null);
        }

        // Calls main Warehouse click function
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
        
        // When employee button is clicked this will change to that screen and display the employee usernames, ids, emails, and access levels
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
                pnEmployeeEdit.Hide();
            }

            changeNav(EMPLOYEE_NAV_ID);

            EmployeeList();
        }

        // Calls main Employee click function
        private void picEmployee_Click(object sender, EventArgs e)
        {
            btnEmployee_Click(null, null);
        }

        // Calls main Employee click function
        private void lblEmployee_Click(object sender, EventArgs e)
        {
            btnEmployee_Click(null, null);
        }

        private void employeeViewButton_Click(object sender, EventArgs e)
        {
            employeeViewButton.BackColor = Color.Gray;
            employeeEditButton.BackColor = Color.White;
            pnEmployeeEdit.Hide();
            isInEditMode = false;
        }

        private void employeeEditButton_Click(object sender, EventArgs e)
        {
            employeeEditButton.BackColor = Color.Gray;
            employeeViewButton.BackColor = Color.White;
            pnEmployeeEdit.Show();
            isInEditMode = true;
        }

        // Sets up the employee listview
        private void EmployeeList()
        {
            lvEmployees.Clear();
            int size = (lvEmployees.Width - 4) / 4; // divide by 4 because there's 4 columns, subtract 4 to stop horizontal scroll bar from displaying
            lvEmployees.View = View.Details;
            lvEmployees.Columns.Add("ID", size, HorizontalAlignment.Center);
            lvEmployees.Columns.Add("Username", size, HorizontalAlignment.Center);
            lvEmployees.Columns.Add("EmailAddr", size, HorizontalAlignment.Center);
            lvEmployees.Columns.Add("IsAdmin", size, HorizontalAlignment.Center);
            string employees = session.getEmployees();
            List<string> stringList = employees.Split(',').ToList<string>();
            for (int i = 1; i < stringList.Count(); i+=4)
            {
                lvEmployees.Items.Add(new ListViewItem(new[] { stringList[i], stringList[i + 1], stringList[i+2], stringList[i+3] }));
            }
        }

        //keeps column width from becoming too small / not visable
        private void lvEmployees_ColumnWidthChanged(object sender, ColumnWidthChangedEventArgs e)
        {
            int maxSize = (lvEmployees.Width - 4) / 4; // divide by 4 because there's 4 columns, subtract 4 to stop horizontal scroll bar from displaying
            if (lvEmployees.Columns[e.ColumnIndex].Width < 100)
            {
                lvEmployees.Columns[e.ColumnIndex].Width = 100;
            }
            else if(lvEmployees.Columns[e.ColumnIndex].Width > maxSize)
            {
                lvEmployees.Columns[e.ColumnIndex].Width = maxSize;
            }
        }

        private void btnSubmitNewUser_Click(object sender, EventArgs e)
        {
            string user = txtUsername.Text;
            string pass = txtNewPass.Text;
            string confirmPass = txtConfirmPass.Text;
            int admin;
            if(user == "")
            {
                DisplayError("Error: A Username Must Be Entered");
            }
            else if(pass == "")
            {
                DisplayError("Error: A Password Must Be Entered");
            }
            else if(confirmPass == "")
            {
                DisplayError("Error: Please Confirm Password");
            }
            else if(pass != confirmPass)
            {
                DisplayError("Error: Passwords Do Not Match");
            }
            else
            {
                ClearError();
                admin = (cbAdmin.Checked) ? 1 : 0; // If the check box is checked the user is an admin, otherwise they're not
                if(session.AddAccount(user, pass, admin))
                {
                    MessageBox.Show("User was successfully added!");
                    EmployeeList();
                }
                else
                {
                    DisplayError("Error: User could not be added.");
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string user = txtDeleteUser.Text;
            string confirmUser = txtConfirmDelete.Text;
            if(user == "")
            {
                DisplayError("Error: A Username Must Be Entered");
            }
            else if(confirmUser == "")
            {
                DisplayError("Error: You Must Confirm The Username");
            }
            else if(user != confirmUser)
            {
                DisplayError("Error: Usernames Do Not Match");
            }
            else
            {
                ClearError();
                if (session.deleteEmployee(user))
                {
                    MessageBox.Show("User was successfully deleted!");
                    EmployeeList();
                }
                else
                {
                    DisplayError("Error: User could not be found.");
                }
            }
        }

        //*****************
        //* End Employee *
        //*****************

        //*****************
        //*     Batch     *
        //*****************

        // When batch button is clicked, this will disable multiple batch attempts and being a single process,
        // the systen will unlock once it finishes
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

        // Calls main Batch click function
        private void lblBatch_Click(object sender, EventArgs e)
        {
            btnBatch_Click(null, null);
        }

        // Calls main Batch click function
        private void picBatchNav_Click(object sender, EventArgs e)
        {
            btnBatch_Click(null, null);
        }

        // This function holds the batch process.
        // The contents are currently a placeholder for demonstration
        private void batchProcess()
        {
            BatchProcessor batch = new BatchProcessor();
            batchTestLabel.Text = "Starting...";
            Refresh();

            if(batch.run())
            {
                picBatch.Image = Resources.check;
                batchTestLabel.Text = "Finished Successfully!";
            }
            else
            {
                picBatch.Image = Resources.error;
                batchTestLabel.Text = "Errors Encountered, See Log.txt For More Information.";
            }            
        }

        //*****************
        //*   End Batch   *
        //*****************

    }
}
