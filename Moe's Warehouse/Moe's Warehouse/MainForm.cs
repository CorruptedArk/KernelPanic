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
            btnBatch.Hide();
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
            btnBatch.Show();
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
                    // resizes item columns, to keep everything within margins
                    maxSize = (lvItem.Width - 4) / 6;
                    for (int i = 0; i < lvItem.Columns.Count; i++)
                    {
                        lvItem.Columns[i].Width = maxSize;
                    }
                    break;
                case ORDER_NAV_ID:
                    // resizes listview columns, to keep everything within margins
                    maxSize = (lvOrders.Width - 4) / 4;
                    for (int i = 0; i < lvOrders.Columns.Count; i++)
                    {
                        lvOrders.Columns[i].Width = maxSize;
                    }
                    break;
                case WAREHOUSE_NAV_ID:
                    // resizes listview columns, to keep everything within margins
                    maxSize = (lvWarehouses.Width - 4) / 3;
                    for (int i = 0; i < lvWarehouses.Columns.Count; i++)
                    {
                        lvWarehouses.Columns[i].Width = maxSize;
                    }
                    for (int i = 0; i < lvWarehouseItems.Columns.Count; i++)
                    {
                        lvWarehouseItems.Columns[i].Width = maxSize;
                    }
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
                picLogin.Image = Resources.logout;
                isInEditMode = false;
                btnItem_Click(null, null);
            }
            else
            {
                DisplayError("Error: Username/Password Combination Is Invalid!");
            }
        }

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

        //******************
        //* End log in/out *
        //******************

        //*************
        //*   Item    *
        //*************

        // Declared here for searching and fast restore
        private List<Items> items;

        // Item click function
        // Sets title, and changes background color
        private void btnItem_Click(object sender, EventArgs e)
        {
            lblCurrentScreen.Text = "ITEM";

            if(isInEditMode)
            {
                itemEditButton_Click(null, null);

            }
            else
            {
                itemViewButton_Click(null, null);
            }

            changeNav(ITEM_NAV_ID);
            btnItemRefresh.Hide();
            ItemList(false);
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
            pnEditItems.Hide();
            isInEditMode = false;
        }

        private void itemEditButton_Click(object sender, EventArgs e)
        {
            itemEditButton.BackColor = Color.Gray;
            itemViewButton.BackColor = Color.White;
            pnEditItems.Show();
            isInEditMode = true;
        }

        // When user clicks search box, clear it
        private void itemSearchBox_Click(object sender, EventArgs e)
        {
            if (itemSearchBox.Text == "Search")
            {
                itemSearchBox.Text = "";
                this.AcceptButton = itemSearchButton;
            }
        }

        // When user clicks away from search box, reset it
        private void itemSearchBox_Leave(object sender, EventArgs e)
        {
            if (itemSearchBox.Text == "")
            {
                itemSearchBox.Text = "Search";
                ItemList(false);
            }
        }

        private void btnItemRefresh_Click(object sender, EventArgs e)
        {
            ItemList(false);
            btnItemRefresh.Hide();
            itemSearchBox.Text = "Search";
        }

        private void itemSearchButton_Click(object sender, EventArgs e)
        {
            if (itemSearchBox.Text != "Search" && itemSearchBox.Text != "")
            {
                string keyword = itemSearchBox.Text;
                lvItem.Clear();
                int size = (lvItem.Width - 4) / 6; // divide by 6 because there's 6 columns, subtract 4 to stop horizontal scroll bar from displaying
                lvItem.View = View.Details;
                lvItem.Columns.Add("ID", size, HorizontalAlignment.Center);
                lvItem.Columns.Add("Item Name", size, HorizontalAlignment.Center);
                lvItem.Columns.Add("Description", size, HorizontalAlignment.Center);
                lvItem.Columns.Add("Price", size, HorizontalAlignment.Center);
                lvItem.Columns.Add("Quantity", size, HorizontalAlignment.Center);
                lvItem.Columns.Add("Vendor Codes", size, HorizontalAlignment.Center);
                for(int i = 0; i< items.Count(); i++)
                {
                    if(items[i].Name.Contains(keyword) || items[i].Desc.Contains(keyword) || items[i].Tags.Contains(keyword))
                    {
                        lvItem.Items.Add(new ListViewItem(new[] { items[i].ID.ToString(), items[i].Name,
                            items[i].Desc, items[i].Price.ToString("C"), items[i].Qty.ToString(), items[i].VenCode.ToString() }));
                    }
                }
            }
            else
            {
                DisplayError("Error: Invalid search request.");
            }
            btnItemRefresh.Show();
        }

        // Sets up the Item listview
        private void ItemList(bool DataChanged)
        {
            lvItem.Clear();
            int size = (lvItem.Width - 4) / 6; // divide by 6 because there's 6 columns, subtract 4 to stop horizontal scroll bar from displaying
            lvItem.View = View.Details;
            lvItem.Columns.Add("ID", size, HorizontalAlignment.Center);
            lvItem.Columns.Add("Item Name", size, HorizontalAlignment.Center);
            lvItem.Columns.Add("Description", size, HorizontalAlignment.Center);
            lvItem.Columns.Add("Price", size, HorizontalAlignment.Center);
            lvItem.Columns.Add("Quantity", size, HorizontalAlignment.Center);
            lvItem.Columns.Add("Vendor Code", size, HorizontalAlignment.Center);
            if(items == null || DataChanged)
            {
                items = session.getItems();
            }
            for (int i = 0; i < items.Count(); i++)
            {
                lvItem.Items.Add(new ListViewItem(new[] { items[i].ID.ToString(), items[i].Name,
                    items[i].Desc, items[i].Price.ToString("C"), items[i].Qty.ToString(), items[i].VenCode.ToString() }));
            }
        }

        private void lvItem_ColumnWidthChanged(object sender, ColumnWidthChangedEventArgs e)
        {
            int maxSize = (lvItem.Width - 4) / 6; // divide by 4 because there's 4 columns, subtract 4 to stop horizontal scroll bar from displaying
            if (lvItem.Columns[e.ColumnIndex].Width < 100)
            {
                lvItem.Columns[e.ColumnIndex].Width = 100;
            }
            else if (lvItem.Columns[e.ColumnIndex].Width > maxSize)
            {
                lvItem.Columns[e.ColumnIndex].Width = maxSize;
            }
        }

        private void btnAddItemTag_Click(object sender, EventArgs e)
        {
            string tag = txtItemTags.Text;
            if (tag == "")
            {
                DisplayError("Error: You must add a tag first.");
            }
            else
            {
                ClearError();
                lbItemTags.Items.Add(tag);
                txtItemTags.Text = "";
            }
        }

        private void btnRemoveItemTag_Click(object sender, EventArgs e)
        {
            if (lbItemTags.SelectedIndex == -1)
            {
                DisplayError("Error: You must select a tag to remove.");
            }
            else
            {
                ClearError();
                lbItemTags.Items.RemoveAt(lbItemTags.SelectedIndex);
                lbItemTags.SelectedIndex = -1;
            }
        }

        private void txtItemTags_TextChanged(object sender, EventArgs e)
        {
            this.AcceptButton = btnAddItemTag;
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            AddItem();
        }

        private void AddItem()
        {
            string name = txtItemName.Text;
            string desc = txtItemDesc.Text;
            string price = txtItemPrice.Text;
            string qty = txtItemQty.Text;
            string venCode = txtVenCode.Text;

            if (name == "" || desc == "" || price == "" || qty == "" || venCode == "")
            {
                DisplayError("Error: Please make sure all fields are filled out.");
            }
            else if (lbItemTags.Items.Count == 0)
            {
                DisplayError("Error: Please make sure tags are added.");
            }
            else if (desc.Contains(','))
            {
                DisplayError("Error: Commas are not allowed in the Description.");
            }
            else
            {
                string tags = parseTags();
                float numPrice;
                int numQty, numVenCode, newID;
                if (float.TryParse(price, out numPrice))
                {
                    if (int.TryParse(qty, out numQty))
                    {
                        if (int.TryParse(venCode, out numVenCode))
                        {
                            ClearError();
                            newID = session.AddItems(name, desc, tags, numPrice, numQty, numVenCode);
                            if (newID != -1)
                            {
                                MessageBox.Show("Item was added!");
                                ItemList(true);
                                clearItemAdd();
                            }
                            else
                            {
                                DisplayError("Error: The Item Could Not Be Added.");
                            }
                        }
                        else
                        {
                            DisplayError("Error: Issue with the Vendor Code.");
                        }
                    }
                    else
                    {
                        DisplayError("Error: Issue with the Quantity textbox.");
                    }
                }
                else
                {
                    DisplayError("Error: Issue with the Price textbox.");
                }
            }
        }

        private string parseTags()
        {
            string Tags = "";
            for (int i = 0; i < lbItemTags.Items.Count; i++)
            {
                if (i != 0)
                {
                    Tags += " | ";
                }
                Tags += lbItemTags.Items[i];
            }
            return Tags;
        }

        // Button calls function to remove items from database
        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            deleteItems();
        }

        //deletes an item from database
        private void deleteItems()
        {
            string name = txtDeleteItemName.Text;
            string confirm = txtDeleteItemNameConfirm.Text;
            string ID = txtDeleteItemID.Text;
            int numID;
            if (name == "" || confirm == "" || ID == "")
            {
                DisplayError("Error: Make sure all fields are filled out.");
            }
            else if (int.TryParse(ID, out numID))
            {
                if (name == confirm)
                {
                    if (session.DeleteItem(numID, name))
                    {
                        ClearError();
                        ItemList(true);
                        clearItemDelete();
                    }
                    else
                    {
                        DisplayError("Error: Item Could Not Be Found.");
                    }
                }
                else
                {
                    DisplayError("Error: Item Names Must Match.");
                }
            }
            else
            {
                DisplayError("Error: Check The ID And Try Again.");
            }
        }

        private void clearItemDelete()
        {
            txtDeleteItemName.Text = "";
            txtDeleteItemNameConfirm.Text = "";
            txtDeleteItemID.Text = "";
        }

        private void clearItemAdd()
        {
            txtItemName.Text = "";
            txtItemDesc.Text = "";
            txtItemTags.Text = "";
            txtItemPrice.Text = "";
            txtItemQty.Text = "";
            txtVenCode.Text = "";
            lbItemTags.Items.Clear();
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
                orderEditButton_Click(null, null);
            }
            else
            {
                orderViewButton_Click(null, null);
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
            pnEditOrder.Hide();
            gbModifyOrders.Hide();
            isInEditMode = false;
        }

        private void orderEditButton_Click(object sender, EventArgs e)
        {
            orderEditButton.BackColor = Color.Gray;
            orderViewButton.BackColor = Color.White;
            pnEditOrder.Show();
            gbModifyOrders.Hide();
            txtEditOrderNumber.Focus();
            isInEditMode = true;
        }

        private void OrderList()
        {
            lvOrders.Clear();
            int size = (lvOrders.Width - 4) / 3; // divide by 4 because there's 4 columns, subtract 4 to stop horizontal scroll bar from displaying
            lvOrders.View = View.Details;
            lvOrders.Columns.Add("ID", size, HorizontalAlignment.Center);
            lvOrders.Columns.Add("Building Name", size, HorizontalAlignment.Center);
            lvOrders.Columns.Add("Address", size, HorizontalAlignment.Center);

            // TODO: Populate the order listview here

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

        private void btnEditOrderNumber_Click(object sender, EventArgs e)
        {
            string orderNum = txtEditOrderNumber.Text;
            if (orderNum != "") // TODO: Add verification that order number exists in records
            {
                gbModifyOrders.Show();
            }
            else
            {
                gbModifyOrders.Hide();
            }
        }

        private void txtEditOrderNumber_TextChanged(object sender, EventArgs e)
        {
            this.AcceptButton = btnEditOrderNumber;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (rbOrderAdd.Checked)
            {
                // TODO: Add an order here
            }
            else if (rbOrderRemove.Checked)
            {
                // TODO: Remove an Order here
            }
            else if (rbOrderModify.Checked)
            {
                // TODO: Modify Quantity here
            }
            else
            {
                DisplayError("Error: Please Select A Radio Button.");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtOrderItem.Text = "";
            txtOrderQty.Text = "";
            rbOrderAdd.Checked = rbOrderModify.Checked = rbOrderRemove.Checked = false;
        }

        private void rbOrderRemove_CheckedChanged(object sender, EventArgs e)
        {
            lblOrderQty.Hide();
            txtOrderQty.Hide();
        }

        //*************
        //* End Order *
        //*************


        //*****************
        //*   Warehouse   *
        //*****************

        private List<Warehouses> warehouse;

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

            changeNav(WAREHOUSE_NAV_ID);
            WarehouseList(false);
        }

        // Sets up the employee listview
        private void WarehouseList(bool DataChanged)
        {
            lvWarehouses.Clear();
            int size = (lvWarehouses.Width - 4) / 3; // divide by 4 because there's 4 columns, subtract 4 to stop horizontal scroll bar from displaying
            lvWarehouses.View = View.Details;
            lvWarehouses.Columns.Add("ID", size, HorizontalAlignment.Center);
            lvWarehouses.Columns.Add("Building Name", size, HorizontalAlignment.Center);
            lvWarehouses.Columns.Add("Address", size, HorizontalAlignment.Center);

            if(warehouse == null || DataChanged)
            {
                warehouse = session.getWarehouses();
            }
            
            for (int i = 0; i < warehouse.Count(); i++)
            {
                lvWarehouses.Items.Add(new ListViewItem(new[] { warehouse[i].ID.ToString(), warehouse[i].Name,
                    warehouse[i].Street + " " + warehouse[i].City + ", " + warehouse[i].State + " " + warehouse[i].Zip.ToString() }));
            }
        }

        private void lvWarehouses_ColumnWidthChanged(object sender, ColumnWidthChangedEventArgs e)
        {
            int maxSize = (lvWarehouses.Width - 4) / 3; // divide by 3 because there's 3 columns, subtract 4 to stop horizontal scroll bar from displaying
            if (lvWarehouses.Columns[e.ColumnIndex].Width < 150)
            {
                lvWarehouses.Columns[e.ColumnIndex].Width = 150;
            }
            else if (lvWarehouses.Columns[e.ColumnIndex].Width > maxSize)
            {
                lvWarehouses.Columns[e.ColumnIndex].Width = maxSize;
            }
        }

        private void lvWarehouses_SelectedIndexChanged(object sender, EventArgs e)
        {

            int size = (lvWarehouseItems.Width - 4) / 3; // divide by 4 because there's 4 columns, subtract 4 to stop horizontal scroll bar from displaying
            lvWarehouseItems.Columns.Add("ID", size, HorizontalAlignment.Center);
            lvWarehouseItems.Columns.Add("Item Name", size, HorizontalAlignment.Center);
            lvWarehouseItems.Columns.Add("Quantity", size, HorizontalAlignment.Center);
            if (lvWarehouses.SelectedItems.Count != 0)
            {
                // TODO: Add Warehouse Quantity Information To lvWarehouseItems ListView
                MessageBox.Show(lvWarehouses.SelectedItems[0].Text);
            }
        }

        //*****************
        //* End Warehouse *
        //*****************


        //*****************
        //*    Employee   *
        //*****************

        private List<Employees> employees;

        // When employee button is clicked this will change to that screen and display the employee usernames, ids, emails, and access levels
        private void btnEmployee_Click(object sender, EventArgs e)
        {
            lblCurrentScreen.Text = "EMPLOYEE";

            if (isInEditMode)
            {
                employeeEditButton_Click(null, null);
            }
            else
            {
                employeeViewButton_Click(null, null);
            }

            changeNav(EMPLOYEE_NAV_ID);

            EmployeeList(false);
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
        private void EmployeeList(bool DataChanged)
        {
            lvEmployees.Clear();
            int size = (lvEmployees.Width - 4) / 4; // divide by 4 because there's 4 columns, subtract 4 to stop horizontal scroll bar from displaying
            lvEmployees.View = View.Details;
            lvEmployees.Columns.Add("ID", size, HorizontalAlignment.Center);
            lvEmployees.Columns.Add("Username", size, HorizontalAlignment.Center);
            lvEmployees.Columns.Add("EmailAddr", size, HorizontalAlignment.Center);
            lvEmployees.Columns.Add("IsAdmin", size, HorizontalAlignment.Center);

            if(employees == null || DataChanged)
            {
                employees = session.getEmployees();
            }

            for (int i = 0; i < employees.Count(); i++)
            {
                lvEmployees.Items.Add(new ListViewItem(new[] { employees[i].ID.ToString(), employees[i].Name, employees[i].Email, employees[i].Admin.ToString() }));
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
                    EmployeeList(true);
                    txtUsername.Text = "";
                    txtNewPass.Text = "";
                    txtConfirmPass.Text = "";
                }
                else
                {
                    DisplayError("Error: User could not be added.");
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string ID = txtDeleteEmployeeID.Text;
            string user = txtDeleteUser.Text;
            string confirmUser = txtConfirmDelete.Text;
            int numID;
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
                if(int.TryParse(ID, out numID))
                {
                    ClearError();
                    if (session.deleteEmployee(user))
                    {
                        MessageBox.Show("User was successfully deleted!");
                        EmployeeList(true);
                        txtDeleteEmployeeID.Text = "";
                        txtDeleteUser.Text = "";
                        txtConfirmDelete.Text = "";
                    }
                    else
                    {
                        DisplayError("Error: User could not be found.");
                    }
                }
                else
                {
                    DisplayError("Error: Check The ID And Try Again.");
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
            BatchProcessor batch = new BatchProcessor(session);
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
