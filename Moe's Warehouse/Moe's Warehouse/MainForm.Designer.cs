namespace WindowsFormsApplication1
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.pnBanner = new System.Windows.Forms.Panel();
            this.lblCurrentScreen = new System.Windows.Forms.Label();
            this.pnCompName = new System.Windows.Forms.Panel();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.lblStaticCompanyName = new System.Windows.Forms.Label();
            this.pnNav = new System.Windows.Forms.Panel();
            this.btnBatch = new System.Windows.Forms.Button();
            this.btnEmployee = new System.Windows.Forms.Panel();
            this.picEmployee = new System.Windows.Forms.PictureBox();
            this.lblEmployee = new System.Windows.Forms.Label();
            this.btnWarehouse = new System.Windows.Forms.Panel();
            this.picWarehouse = new System.Windows.Forms.PictureBox();
            this.lblWarehouse = new System.Windows.Forms.Label();
            this.btnOrder = new System.Windows.Forms.Panel();
            this.picOrder = new System.Windows.Forms.PictureBox();
            this.lblOrder = new System.Windows.Forms.Label();
            this.btnItem = new System.Windows.Forms.Panel();
            this.picItem = new System.Windows.Forms.PictureBox();
            this.lblItem = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Panel();
            this.picLogin = new System.Windows.Forms.PictureBox();
            this.lblLogin = new System.Windows.Forms.Label();
            this.pnStatus = new System.Windows.Forms.Panel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.loginPanel = new System.Windows.Forms.Panel();
            this.loginResetButton = new System.Windows.Forms.Button();
            this.userNameBox = new System.Windows.Forms.TextBox();
            this.userLabel = new System.Windows.Forms.Label();
            this.loginEnterButton = new System.Windows.Forms.Button();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.itemPanel = new System.Windows.Forms.Panel();
            this.itemViewButton = new System.Windows.Forms.Button();
            this.itemEditButton = new System.Windows.Forms.Button();
            this.itemSearchButton = new System.Windows.Forms.Button();
            this.itemSearchBox = new System.Windows.Forms.TextBox();
            this.orderPanel = new System.Windows.Forms.Panel();
            this.orderSearchButton = new System.Windows.Forms.Button();
            this.orderSearchBox = new System.Windows.Forms.TextBox();
            this.orderEditButton = new System.Windows.Forms.Button();
            this.orderViewButton = new System.Windows.Forms.Button();
            this.warehousePanel = new System.Windows.Forms.Panel();
            this.warehouseViewButton = new System.Windows.Forms.Button();
            this.warehouseEditButton = new System.Windows.Forms.Button();
            this.employeePanel = new System.Windows.Forms.Panel();
            this.employeeViewButton = new System.Windows.Forms.Button();
            this.employeeEditButton = new System.Windows.Forms.Button();
            this.batchPanel = new System.Windows.Forms.Panel();
            this.batchTestLabel = new System.Windows.Forms.Label();
            this.pnBanner.SuspendLayout();
            this.pnCompName.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.pnNav.SuspendLayout();
            this.btnEmployee.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picEmployee)).BeginInit();
            this.btnWarehouse.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picWarehouse)).BeginInit();
            this.btnOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picOrder)).BeginInit();
            this.btnItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picItem)).BeginInit();
            this.btnLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogin)).BeginInit();
            this.pnStatus.SuspendLayout();
            this.loginPanel.SuspendLayout();
            this.itemPanel.SuspendLayout();
            this.orderPanel.SuspendLayout();
            this.warehousePanel.SuspendLayout();
            this.employeePanel.SuspendLayout();
            this.batchPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnBanner
            // 
            this.pnBanner.Controls.Add(this.lblCurrentScreen);
            this.pnBanner.Controls.Add(this.pnCompName);
            this.pnBanner.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnBanner.Location = new System.Drawing.Point(0, 0);
            this.pnBanner.Name = "pnBanner";
            this.pnBanner.Size = new System.Drawing.Size(1028, 100);
            this.pnBanner.TabIndex = 0;
            // 
            // lblCurrentScreen
            // 
            this.lblCurrentScreen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblCurrentScreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCurrentScreen.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentScreen.ForeColor = System.Drawing.Color.White;
            this.lblCurrentScreen.Location = new System.Drawing.Point(271, 0);
            this.lblCurrentScreen.Name = "lblCurrentScreen";
            this.lblCurrentScreen.Size = new System.Drawing.Size(757, 100);
            this.lblCurrentScreen.TabIndex = 3;
            this.lblCurrentScreen.Text = "[Current Screen Name]";
            this.lblCurrentScreen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnCompName
            // 
            this.pnCompName.BackColor = System.Drawing.SystemColors.Highlight;
            this.pnCompName.Controls.Add(this.picLogo);
            this.pnCompName.Controls.Add(this.lblStaticCompanyName);
            this.pnCompName.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnCompName.Location = new System.Drawing.Point(0, 0);
            this.pnCompName.Name = "pnCompName";
            this.pnCompName.Size = new System.Drawing.Size(271, 100);
            this.pnCompName.TabIndex = 2;
            // 
            // picLogo
            // 
            this.picLogo.Dock = System.Windows.Forms.DockStyle.Left;
            this.picLogo.Image = global::KernalPanic.Properties.Resources.Company_Logo___White;
            this.picLogo.Location = new System.Drawing.Point(0, 0);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(90, 100);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picLogo.TabIndex = 0;
            this.picLogo.TabStop = false;
            // 
            // lblStaticCompanyName
            // 
            this.lblStaticCompanyName.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblStaticCompanyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStaticCompanyName.ForeColor = System.Drawing.Color.White;
            this.lblStaticCompanyName.Location = new System.Drawing.Point(90, 0);
            this.lblStaticCompanyName.Name = "lblStaticCompanyName";
            this.lblStaticCompanyName.Size = new System.Drawing.Size(181, 100);
            this.lblStaticCompanyName.TabIndex = 3;
            this.lblStaticCompanyName.Text = "Moe\'s Warehouse";
            this.lblStaticCompanyName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnNav
            // 
            this.pnNav.AutoScroll = true;
            this.pnNav.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnNav.Controls.Add(this.btnBatch);
            this.pnNav.Controls.Add(this.btnEmployee);
            this.pnNav.Controls.Add(this.btnWarehouse);
            this.pnNav.Controls.Add(this.btnOrder);
            this.pnNav.Controls.Add(this.btnItem);
            this.pnNav.Controls.Add(this.btnLogin);
            this.pnNav.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnNav.Location = new System.Drawing.Point(0, 100);
            this.pnNav.Name = "pnNav";
            this.pnNav.Size = new System.Drawing.Size(271, 509);
            this.pnNav.TabIndex = 1;
            // 
            // btnBatch
            // 
            this.btnBatch.Location = new System.Drawing.Point(38, 462);
            this.btnBatch.Name = "btnBatch";
            this.btnBatch.Size = new System.Drawing.Size(194, 34);
            this.btnBatch.TabIndex = 7;
            this.btnBatch.Text = "Start Batch";
            this.btnBatch.UseVisualStyleBackColor = true;
            this.btnBatch.Click += new System.EventHandler(this.btnBatch_Click);
            // 
            // btnEmployee
            // 
            this.btnEmployee.Controls.Add(this.picEmployee);
            this.btnEmployee.Controls.Add(this.lblEmployee);
            this.btnEmployee.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEmployee.Location = new System.Drawing.Point(0, 348);
            this.btnEmployee.Name = "btnEmployee";
            this.btnEmployee.Size = new System.Drawing.Size(271, 87);
            this.btnEmployee.TabIndex = 6;
            this.btnEmployee.Click += new System.EventHandler(this.btnEmployee_Click);
            // 
            // picEmployee
            // 
            this.picEmployee.Dock = System.Windows.Forms.DockStyle.Left;
            this.picEmployee.Image = global::KernalPanic.Properties.Resources.Employee;
            this.picEmployee.Location = new System.Drawing.Point(0, 0);
            this.picEmployee.Name = "picEmployee";
            this.picEmployee.Size = new System.Drawing.Size(90, 87);
            this.picEmployee.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picEmployee.TabIndex = 0;
            this.picEmployee.TabStop = false;
            this.picEmployee.Click += new System.EventHandler(this.picEmployee_Click);
            // 
            // lblEmployee
            // 
            this.lblEmployee.BackColor = System.Drawing.Color.Transparent;
            this.lblEmployee.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmployee.ForeColor = System.Drawing.Color.White;
            this.lblEmployee.Location = new System.Drawing.Point(89, 0);
            this.lblEmployee.Name = "lblEmployee";
            this.lblEmployee.Size = new System.Drawing.Size(182, 87);
            this.lblEmployee.TabIndex = 1;
            this.lblEmployee.Text = "Employee";
            this.lblEmployee.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblEmployee.Click += new System.EventHandler(this.lblEmployee_Click);
            // 
            // btnWarehouse
            // 
            this.btnWarehouse.Controls.Add(this.picWarehouse);
            this.btnWarehouse.Controls.Add(this.lblWarehouse);
            this.btnWarehouse.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnWarehouse.Location = new System.Drawing.Point(0, 261);
            this.btnWarehouse.Name = "btnWarehouse";
            this.btnWarehouse.Size = new System.Drawing.Size(271, 87);
            this.btnWarehouse.TabIndex = 5;
            this.btnWarehouse.Click += new System.EventHandler(this.btnWarehouse_Click);
            // 
            // picWarehouse
            // 
            this.picWarehouse.Dock = System.Windows.Forms.DockStyle.Left;
            this.picWarehouse.Image = global::KernalPanic.Properties.Resources.warehouse;
            this.picWarehouse.Location = new System.Drawing.Point(0, 0);
            this.picWarehouse.Name = "picWarehouse";
            this.picWarehouse.Size = new System.Drawing.Size(90, 87);
            this.picWarehouse.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picWarehouse.TabIndex = 0;
            this.picWarehouse.TabStop = false;
            // 
            // lblWarehouse
            // 
            this.lblWarehouse.BackColor = System.Drawing.Color.Transparent;
            this.lblWarehouse.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblWarehouse.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWarehouse.ForeColor = System.Drawing.Color.White;
            this.lblWarehouse.Location = new System.Drawing.Point(89, 0);
            this.lblWarehouse.Name = "lblWarehouse";
            this.lblWarehouse.Size = new System.Drawing.Size(182, 87);
            this.lblWarehouse.TabIndex = 1;
            this.lblWarehouse.Text = "Warehouse";
            this.lblWarehouse.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblWarehouse.Click += new System.EventHandler(this.lblWarehouse_Click);
            // 
            // btnOrder
            // 
            this.btnOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnOrder.Controls.Add(this.picOrder);
            this.btnOrder.Controls.Add(this.lblOrder);
            this.btnOrder.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnOrder.Location = new System.Drawing.Point(0, 174);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(271, 87);
            this.btnOrder.TabIndex = 4;
            this.btnOrder.Click += new System.EventHandler(this.btnOrder_Click);
            // 
            // picOrder
            // 
            this.picOrder.Dock = System.Windows.Forms.DockStyle.Left;
            this.picOrder.Image = global::KernalPanic.Properties.Resources.order;
            this.picOrder.Location = new System.Drawing.Point(0, 0);
            this.picOrder.Name = "picOrder";
            this.picOrder.Size = new System.Drawing.Size(90, 87);
            this.picOrder.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picOrder.TabIndex = 0;
            this.picOrder.TabStop = false;
            this.picOrder.Click += new System.EventHandler(this.picOrder_Click);
            // 
            // lblOrder
            // 
            this.lblOrder.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrder.ForeColor = System.Drawing.Color.White;
            this.lblOrder.Location = new System.Drawing.Point(89, 0);
            this.lblOrder.Name = "lblOrder";
            this.lblOrder.Size = new System.Drawing.Size(182, 87);
            this.lblOrder.TabIndex = 3;
            this.lblOrder.Text = "Order";
            this.lblOrder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblOrder.Click += new System.EventHandler(this.lblOrder_Click);
            // 
            // btnItem
            // 
            this.btnItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnItem.Controls.Add(this.picItem);
            this.btnItem.Controls.Add(this.lblItem);
            this.btnItem.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnItem.Location = new System.Drawing.Point(0, 87);
            this.btnItem.Name = "btnItem";
            this.btnItem.Size = new System.Drawing.Size(271, 87);
            this.btnItem.TabIndex = 3;
            this.btnItem.Click += new System.EventHandler(this.btnItem_Click);
            // 
            // picItem
            // 
            this.picItem.Dock = System.Windows.Forms.DockStyle.Left;
            this.picItem.Image = global::KernalPanic.Properties.Resources.item;
            this.picItem.Location = new System.Drawing.Point(0, 0);
            this.picItem.Name = "picItem";
            this.picItem.Size = new System.Drawing.Size(90, 87);
            this.picItem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picItem.TabIndex = 0;
            this.picItem.TabStop = false;
            this.picItem.Click += new System.EventHandler(this.picItem_Click);
            // 
            // lblItem
            // 
            this.lblItem.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItem.ForeColor = System.Drawing.Color.White;
            this.lblItem.Location = new System.Drawing.Point(89, 0);
            this.lblItem.Name = "lblItem";
            this.lblItem.Size = new System.Drawing.Size(182, 87);
            this.lblItem.TabIndex = 3;
            this.lblItem.Text = "Item";
            this.lblItem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblItem.UseCompatibleTextRendering = true;
            this.lblItem.Click += new System.EventHandler(this.lblItem_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.Gray;
            this.btnLogin.Controls.Add(this.picLogin);
            this.btnLogin.Controls.Add(this.lblLogin);
            this.btnLogin.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnLogin.Location = new System.Drawing.Point(0, 0);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(271, 87);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // picLogin
            // 
            this.picLogin.Dock = System.Windows.Forms.DockStyle.Left;
            this.picLogin.Image = global::KernalPanic.Properties.Resources.login;
            this.picLogin.Location = new System.Drawing.Point(0, 0);
            this.picLogin.Name = "picLogin";
            this.picLogin.Size = new System.Drawing.Size(90, 87);
            this.picLogin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picLogin.TabIndex = 0;
            this.picLogin.TabStop = false;
            this.picLogin.Click += new System.EventHandler(this.picLogin_Click);
            // 
            // lblLogin
            // 
            this.lblLogin.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogin.ForeColor = System.Drawing.Color.White;
            this.lblLogin.Location = new System.Drawing.Point(89, 0);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(182, 87);
            this.lblLogin.TabIndex = 3;
            this.lblLogin.Text = "Login";
            this.lblLogin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblLogin.UseCompatibleTextRendering = true;
            this.lblLogin.Click += new System.EventHandler(this.lblLogin_Click);
            // 
            // pnStatus
            // 
            this.pnStatus.BackColor = System.Drawing.Color.Red;
            this.pnStatus.Controls.Add(this.lblStatus);
            this.pnStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnStatus.Location = new System.Drawing.Point(271, 584);
            this.pnStatus.Name = "pnStatus";
            this.pnStatus.Size = new System.Drawing.Size(757, 25);
            this.pnStatus.TabIndex = 2;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.White;
            this.lblStatus.Location = new System.Drawing.Point(0, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(215, 20);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.Text = "[Error or Status Message]";
            // 
            // loginPanel
            // 
            this.loginPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.loginPanel.Controls.Add(this.loginResetButton);
            this.loginPanel.Controls.Add(this.userNameBox);
            this.loginPanel.Controls.Add(this.userLabel);
            this.loginPanel.Controls.Add(this.loginEnterButton);
            this.loginPanel.Controls.Add(this.passwordLabel);
            this.loginPanel.Controls.Add(this.passwordBox);
            this.loginPanel.Location = new System.Drawing.Point(272, 100);
            this.loginPanel.Name = "loginPanel";
            this.loginPanel.Size = new System.Drawing.Size(756, 481);
            this.loginPanel.TabIndex = 3;
            // 
            // loginResetButton
            // 
            this.loginResetButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.loginResetButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginResetButton.Location = new System.Drawing.Point(256, 270);
            this.loginResetButton.Name = "loginResetButton";
            this.loginResetButton.Size = new System.Drawing.Size(154, 38);
            this.loginResetButton.TabIndex = 5;
            this.loginResetButton.Text = "Reset";
            this.loginResetButton.UseVisualStyleBackColor = true;
            this.loginResetButton.Click += new System.EventHandler(this.loginResetButton_Click);
            // 
            // userNameBox
            // 
            this.userNameBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userNameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userNameBox.Location = new System.Drawing.Point(256, 167);
            this.userNameBox.Name = "userNameBox";
            this.userNameBox.Size = new System.Drawing.Size(358, 29);
            this.userNameBox.TabIndex = 0;
            // 
            // userLabel
            // 
            this.userLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userLabel.AutoSize = true;
            this.userLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userLabel.Location = new System.Drawing.Point(149, 169);
            this.userLabel.Name = "userLabel";
            this.userLabel.Size = new System.Drawing.Size(102, 24);
            this.userLabel.TabIndex = 2;
            this.userLabel.Text = "Username:";
            // 
            // loginEnterButton
            // 
            this.loginEnterButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.loginEnterButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginEnterButton.Location = new System.Drawing.Point(447, 270);
            this.loginEnterButton.Name = "loginEnterButton";
            this.loginEnterButton.Size = new System.Drawing.Size(168, 38);
            this.loginEnterButton.TabIndex = 4;
            this.loginEnterButton.Text = "Login";
            this.loginEnterButton.UseVisualStyleBackColor = true;
            this.loginEnterButton.Click += new System.EventHandler(this.loginEnterButton_Click);
            // 
            // passwordLabel
            // 
            this.passwordLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordLabel.Location = new System.Drawing.Point(154, 219);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(97, 24);
            this.passwordLabel.TabIndex = 3;
            this.passwordLabel.Text = "Password:";
            // 
            // passwordBox
            // 
            this.passwordBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.passwordBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordBox.Location = new System.Drawing.Point(256, 216);
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.Size = new System.Drawing.Size(358, 29);
            this.passwordBox.TabIndex = 1;
            this.passwordBox.UseSystemPasswordChar = true;
            // 
            // itemPanel
            // 
            this.itemPanel.Controls.Add(this.itemViewButton);
            this.itemPanel.Controls.Add(this.itemEditButton);
            this.itemPanel.Controls.Add(this.itemSearchButton);
            this.itemPanel.Controls.Add(this.itemSearchBox);
            this.itemPanel.Location = new System.Drawing.Point(271, 100);
            this.itemPanel.Name = "itemPanel";
            this.itemPanel.Size = new System.Drawing.Size(756, 479);
            this.itemPanel.TabIndex = 0;
            // 
            // itemViewButton
            // 
            this.itemViewButton.BackColor = System.Drawing.Color.Gray;
            this.itemViewButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.itemViewButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemViewButton.Location = new System.Drawing.Point(0, 0);
            this.itemViewButton.Name = "itemViewButton";
            this.itemViewButton.Size = new System.Drawing.Size(121, 43);
            this.itemViewButton.TabIndex = 1;
            this.itemViewButton.Text = "View";
            this.itemViewButton.UseVisualStyleBackColor = false;
            this.itemViewButton.Click += new System.EventHandler(this.itemViewButton_Click);
            // 
            // itemEditButton
            // 
            this.itemEditButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.itemEditButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemEditButton.Location = new System.Drawing.Point(121, 0);
            this.itemEditButton.Name = "itemEditButton";
            this.itemEditButton.Size = new System.Drawing.Size(121, 43);
            this.itemEditButton.TabIndex = 2;
            this.itemEditButton.Text = "Edit";
            this.itemEditButton.UseVisualStyleBackColor = true;
            this.itemEditButton.Click += new System.EventHandler(this.itemEditButton_Click);
            // 
            // itemSearchButton
            // 
            this.itemSearchButton.Location = new System.Drawing.Point(667, 19);
            this.itemSearchButton.Name = "itemSearchButton";
            this.itemSearchButton.Size = new System.Drawing.Size(63, 24);
            this.itemSearchButton.TabIndex = 3;
            this.itemSearchButton.Text = "Enter";
            this.itemSearchButton.UseVisualStyleBackColor = true;
            this.itemSearchButton.Click += new System.EventHandler(this.itemSearchButton_Click);
            // 
            // itemSearchBox
            // 
            this.itemSearchBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemSearchBox.Location = new System.Drawing.Point(509, 19);
            this.itemSearchBox.Name = "itemSearchBox";
            this.itemSearchBox.Size = new System.Drawing.Size(152, 24);
            this.itemSearchBox.TabIndex = 0;
            this.itemSearchBox.Text = "Search";
            this.itemSearchBox.Click += new System.EventHandler(this.itemSearchBox_Click);
            this.itemSearchBox.Leave += new System.EventHandler(this.itemSearchBox_Leave);
            // 
            // orderPanel
            // 
            this.orderPanel.Controls.Add(this.orderSearchButton);
            this.orderPanel.Controls.Add(this.orderSearchBox);
            this.orderPanel.Controls.Add(this.orderEditButton);
            this.orderPanel.Controls.Add(this.orderViewButton);
            this.orderPanel.Location = new System.Drawing.Point(271, 100);
            this.orderPanel.Name = "orderPanel";
            this.orderPanel.Size = new System.Drawing.Size(757, 481);
            this.orderPanel.TabIndex = 0;
            // 
            // orderSearchButton
            // 
            this.orderSearchButton.Location = new System.Drawing.Point(667, 19);
            this.orderSearchButton.Name = "orderSearchButton";
            this.orderSearchButton.Size = new System.Drawing.Size(63, 24);
            this.orderSearchButton.TabIndex = 3;
            this.orderSearchButton.Text = "Enter";
            this.orderSearchButton.UseVisualStyleBackColor = true;
            // 
            // orderSearchBox
            // 
            this.orderSearchBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.orderSearchBox.Location = new System.Drawing.Point(509, 19);
            this.orderSearchBox.Name = "orderSearchBox";
            this.orderSearchBox.Size = new System.Drawing.Size(152, 24);
            this.orderSearchBox.TabIndex = 2;
            this.orderSearchBox.Text = "Search";
            this.orderSearchBox.Click += new System.EventHandler(this.orderSearchBox_Click);
            this.orderSearchBox.Leave += new System.EventHandler(this.orderSearchBox_Leave);
            // 
            // orderEditButton
            // 
            this.orderEditButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.orderEditButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.orderEditButton.Location = new System.Drawing.Point(121, 0);
            this.orderEditButton.Name = "orderEditButton";
            this.orderEditButton.Size = new System.Drawing.Size(121, 43);
            this.orderEditButton.TabIndex = 1;
            this.orderEditButton.Text = "Edit";
            this.orderEditButton.UseVisualStyleBackColor = true;
            this.orderEditButton.Click += new System.EventHandler(this.orderEditButton_Click);
            // 
            // orderViewButton
            // 
            this.orderViewButton.BackColor = System.Drawing.Color.Gray;
            this.orderViewButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.orderViewButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.orderViewButton.Location = new System.Drawing.Point(0, 0);
            this.orderViewButton.Name = "orderViewButton";
            this.orderViewButton.Size = new System.Drawing.Size(121, 43);
            this.orderViewButton.TabIndex = 0;
            this.orderViewButton.Text = "View";
            this.orderViewButton.UseVisualStyleBackColor = false;
            this.orderViewButton.Click += new System.EventHandler(this.orderViewButton_Click);
            // 
            // warehousePanel
            // 
            this.warehousePanel.Controls.Add(this.warehouseViewButton);
            this.warehousePanel.Controls.Add(this.warehouseEditButton);
            this.warehousePanel.Location = new System.Drawing.Point(271, 100);
            this.warehousePanel.Name = "warehousePanel";
            this.warehousePanel.Size = new System.Drawing.Size(757, 481);
            this.warehousePanel.TabIndex = 4;
            // 
            // warehouseViewButton
            // 
            this.warehouseViewButton.BackColor = System.Drawing.Color.Gray;
            this.warehouseViewButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.warehouseViewButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.warehouseViewButton.Location = new System.Drawing.Point(0, 0);
            this.warehouseViewButton.Name = "warehouseViewButton";
            this.warehouseViewButton.Size = new System.Drawing.Size(121, 43);
            this.warehouseViewButton.TabIndex = 0;
            this.warehouseViewButton.Text = "View";
            this.warehouseViewButton.UseVisualStyleBackColor = false;
            this.warehouseViewButton.Click += new System.EventHandler(this.warehouseViewButton_Click);
            // 
            // warehouseEditButton
            // 
            this.warehouseEditButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.warehouseEditButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.warehouseEditButton.Location = new System.Drawing.Point(121, 0);
            this.warehouseEditButton.Name = "warehouseEditButton";
            this.warehouseEditButton.Size = new System.Drawing.Size(121, 43);
            this.warehouseEditButton.TabIndex = 1;
            this.warehouseEditButton.Text = "Edit";
            this.warehouseEditButton.UseVisualStyleBackColor = true;
            this.warehouseEditButton.Click += new System.EventHandler(this.warehouseEditButton_Click);
            // 
            // employeePanel
            // 
            this.employeePanel.Controls.Add(this.employeeViewButton);
            this.employeePanel.Controls.Add(this.employeeEditButton);
            this.employeePanel.Location = new System.Drawing.Point(271, 100);
            this.employeePanel.Name = "employeePanel";
            this.employeePanel.Size = new System.Drawing.Size(756, 481);
            this.employeePanel.TabIndex = 1;
            // 
            // employeeViewButton
            // 
            this.employeeViewButton.BackColor = System.Drawing.Color.Gray;
            this.employeeViewButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.employeeViewButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.employeeViewButton.Location = new System.Drawing.Point(0, 0);
            this.employeeViewButton.Name = "employeeViewButton";
            this.employeeViewButton.Size = new System.Drawing.Size(121, 43);
            this.employeeViewButton.TabIndex = 0;
            this.employeeViewButton.Text = "View";
            this.employeeViewButton.UseVisualStyleBackColor = false;
            this.employeeViewButton.Click += new System.EventHandler(this.employeeViewButton_Click);
            // 
            // employeeEditButton
            // 
            this.employeeEditButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.employeeEditButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.employeeEditButton.Location = new System.Drawing.Point(121, 0);
            this.employeeEditButton.Name = "employeeEditButton";
            this.employeeEditButton.Size = new System.Drawing.Size(121, 43);
            this.employeeEditButton.TabIndex = 1;
            this.employeeEditButton.Text = "Edit";
            this.employeeEditButton.UseVisualStyleBackColor = true;
            this.employeeEditButton.Click += new System.EventHandler(this.employeeEditButton_Click);
            // 
            // batchPanel
            // 
            this.batchPanel.Controls.Add(this.batchTestLabel);
            this.batchPanel.Location = new System.Drawing.Point(271, 100);
            this.batchPanel.Name = "batchPanel";
            this.batchPanel.Size = new System.Drawing.Size(756, 481);
            this.batchPanel.TabIndex = 1;
            // 
            // batchTestLabel
            // 
            this.batchTestLabel.AutoSize = true;
            this.batchTestLabel.Location = new System.Drawing.Point(5, 4);
            this.batchTestLabel.Name = "batchTestLabel";
            this.batchTestLabel.Size = new System.Drawing.Size(35, 13);
            this.batchTestLabel.TabIndex = 0;
            this.batchTestLabel.Text = "Batch";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1028, 609);
            this.Controls.Add(this.pnStatus);
            this.Controls.Add(this.pnNav);
            this.Controls.Add(this.pnBanner);
            this.Controls.Add(this.warehousePanel);
            this.Controls.Add(this.itemPanel);
            this.Controls.Add(this.orderPanel);
            this.Controls.Add(this.loginPanel);
            this.Controls.Add(this.batchPanel);
            this.Controls.Add(this.employeePanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(900, 595);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Moe\'s Warehouse";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.pnBanner.ResumeLayout(false);
            this.pnCompName.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.pnNav.ResumeLayout(false);
            this.btnEmployee.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picEmployee)).EndInit();
            this.btnWarehouse.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picWarehouse)).EndInit();
            this.btnOrder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picOrder)).EndInit();
            this.btnItem.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picItem)).EndInit();
            this.btnLogin.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogin)).EndInit();
            this.pnStatus.ResumeLayout(false);
            this.pnStatus.PerformLayout();
            this.loginPanel.ResumeLayout(false);
            this.loginPanel.PerformLayout();
            this.itemPanel.ResumeLayout(false);
            this.itemPanel.PerformLayout();
            this.orderPanel.ResumeLayout(false);
            this.orderPanel.PerformLayout();
            this.warehousePanel.ResumeLayout(false);
            this.employeePanel.ResumeLayout(false);
            this.batchPanel.ResumeLayout(false);
            this.batchPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnBanner;
        private System.Windows.Forms.Label lblCurrentScreen;
        private System.Windows.Forms.Panel pnCompName;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label lblStaticCompanyName;
        private System.Windows.Forms.Panel pnNav;
        private System.Windows.Forms.Panel pnStatus;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Panel btnItem;
        private System.Windows.Forms.PictureBox picItem;
        private System.Windows.Forms.Label lblItem;
        private System.Windows.Forms.Panel btnOrder;
        private System.Windows.Forms.PictureBox picOrder;
        private System.Windows.Forms.Label lblOrder;
        private System.Windows.Forms.Panel btnWarehouse;
        private System.Windows.Forms.PictureBox picWarehouse;
        private System.Windows.Forms.Label lblWarehouse;
        private System.Windows.Forms.Panel btnLogin;
        private System.Windows.Forms.PictureBox picLogin;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.Panel loginPanel;
        private System.Windows.Forms.Panel itemPanel;
        private System.Windows.Forms.Panel orderPanel;
        private System.Windows.Forms.Panel warehousePanel;
        private System.Windows.Forms.TextBox passwordBox;
        private System.Windows.Forms.TextBox userNameBox;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Label userLabel;
        private System.Windows.Forms.Button loginEnterButton;
        private System.Windows.Forms.Panel btnEmployee;
        private System.Windows.Forms.PictureBox picEmployee;
        private System.Windows.Forms.Label lblEmployee;
        private System.Windows.Forms.Panel employeePanel;
        private System.Windows.Forms.Button btnBatch;
        private System.Windows.Forms.Panel batchPanel;
        private System.Windows.Forms.Label batchTestLabel;
        private System.Windows.Forms.Button loginResetButton;
        private System.Windows.Forms.Button itemViewButton;
        private System.Windows.Forms.TextBox itemSearchBox;
        private System.Windows.Forms.Button itemEditButton;
        private System.Windows.Forms.Button itemSearchButton;
        private System.Windows.Forms.Button orderViewButton;
        private System.Windows.Forms.Button orderEditButton;
        private System.Windows.Forms.Button orderSearchButton;
        private System.Windows.Forms.TextBox orderSearchBox;
        private System.Windows.Forms.Button warehouseViewButton;
        private System.Windows.Forms.Button warehouseEditButton;
        private System.Windows.Forms.Button employeeEditButton;
        private System.Windows.Forms.Button employeeViewButton;
    }
}

