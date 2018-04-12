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
            this.lblStaticCompanyName = new System.Windows.Forms.Label();
            this.pnNav = new System.Windows.Forms.Panel();
            this.btnWarehouse = new System.Windows.Forms.Panel();
            this.lblWarehouse = new System.Windows.Forms.Label();
            this.btnOrder = new System.Windows.Forms.Panel();
            this.lblOrder = new System.Windows.Forms.Label();
            this.btnItem = new System.Windows.Forms.Panel();
            this.lblItem = new System.Windows.Forms.Label();
            this.pnStatus = new System.Windows.Forms.Panel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Panel();
            this.lblLogin = new System.Windows.Forms.Label();
            this.picLogin = new System.Windows.Forms.PictureBox();
            this.picWarehouse = new System.Windows.Forms.PictureBox();
            this.picItem = new System.Windows.Forms.PictureBox();
            this.picOrder = new System.Windows.Forms.PictureBox();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.pnBanner.SuspendLayout();
            this.pnCompName.SuspendLayout();
            this.pnNav.SuspendLayout();
            this.btnWarehouse.SuspendLayout();
            this.btnOrder.SuspendLayout();
            this.btnItem.SuspendLayout();
            this.pnStatus.SuspendLayout();
            this.btnLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWarehouse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // pnBanner
            // 
            this.pnBanner.Controls.Add(this.lblCurrentScreen);
            this.pnBanner.Controls.Add(this.pnCompName);
            this.pnBanner.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnBanner.Location = new System.Drawing.Point(0, 0);
            this.pnBanner.Margin = new System.Windows.Forms.Padding(4);
            this.pnBanner.Name = "pnBanner";
            this.pnBanner.Size = new System.Drawing.Size(1371, 123);
            this.pnBanner.TabIndex = 0;
            // 
            // lblCurrentScreen
            // 
            this.lblCurrentScreen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblCurrentScreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCurrentScreen.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentScreen.ForeColor = System.Drawing.Color.White;
            this.lblCurrentScreen.Location = new System.Drawing.Point(361, 0);
            this.lblCurrentScreen.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCurrentScreen.Name = "lblCurrentScreen";
            this.lblCurrentScreen.Size = new System.Drawing.Size(1010, 123);
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
            this.pnCompName.Margin = new System.Windows.Forms.Padding(4);
            this.pnCompName.Name = "pnCompName";
            this.pnCompName.Size = new System.Drawing.Size(361, 123);
            this.pnCompName.TabIndex = 2;
            // 
            // lblStaticCompanyName
            // 
            this.lblStaticCompanyName.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblStaticCompanyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStaticCompanyName.ForeColor = System.Drawing.Color.White;
            this.lblStaticCompanyName.Location = new System.Drawing.Point(120, 0);
            this.lblStaticCompanyName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStaticCompanyName.Name = "lblStaticCompanyName";
            this.lblStaticCompanyName.Size = new System.Drawing.Size(241, 123);
            this.lblStaticCompanyName.TabIndex = 3;
            this.lblStaticCompanyName.Text = "Moe\'s Warehouse";
            this.lblStaticCompanyName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnNav
            // 
            this.pnNav.AutoScroll = true;
            this.pnNav.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnNav.Controls.Add(this.btnWarehouse);
            this.pnNav.Controls.Add(this.btnOrder);
            this.pnNav.Controls.Add(this.btnItem);
            this.pnNav.Controls.Add(this.btnLogin);
            this.pnNav.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnNav.Location = new System.Drawing.Point(0, 123);
            this.pnNav.Margin = new System.Windows.Forms.Padding(4);
            this.pnNav.Name = "pnNav";
            this.pnNav.Size = new System.Drawing.Size(361, 627);
            this.pnNav.TabIndex = 1;
            // 
            // btnWarehouse
            // 
            this.btnWarehouse.Controls.Add(this.picWarehouse);
            this.btnWarehouse.Controls.Add(this.lblWarehouse);
            this.btnWarehouse.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnWarehouse.Location = new System.Drawing.Point(0, 321);
            this.btnWarehouse.Margin = new System.Windows.Forms.Padding(4);
            this.btnWarehouse.Name = "btnWarehouse";
            this.btnWarehouse.Size = new System.Drawing.Size(361, 107);
            this.btnWarehouse.TabIndex = 5;
            this.btnWarehouse.Click += new System.EventHandler(this.btnWarehouse_Click);
            // 
            // lblWarehouse
            // 
            this.lblWarehouse.BackColor = System.Drawing.Color.Transparent;
            this.lblWarehouse.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblWarehouse.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWarehouse.ForeColor = System.Drawing.Color.White;
            this.lblWarehouse.Location = new System.Drawing.Point(119, 0);
            this.lblWarehouse.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWarehouse.Name = "lblWarehouse";
            this.lblWarehouse.Size = new System.Drawing.Size(242, 107);
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
            this.btnOrder.Location = new System.Drawing.Point(0, 214);
            this.btnOrder.Margin = new System.Windows.Forms.Padding(4);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(361, 107);
            this.btnOrder.TabIndex = 4;
            this.btnOrder.Click += new System.EventHandler(this.btnOrder_Click);
            // 
            // lblOrder
            // 
            this.lblOrder.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrder.ForeColor = System.Drawing.Color.White;
            this.lblOrder.Location = new System.Drawing.Point(119, 0);
            this.lblOrder.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOrder.Name = "lblOrder";
            this.lblOrder.Size = new System.Drawing.Size(242, 107);
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
            this.btnItem.Location = new System.Drawing.Point(0, 107);
            this.btnItem.Margin = new System.Windows.Forms.Padding(4);
            this.btnItem.Name = "btnItem";
            this.btnItem.Size = new System.Drawing.Size(361, 107);
            this.btnItem.TabIndex = 3;
            this.btnItem.Click += new System.EventHandler(this.btnItem_Click);
            // 
            // lblItem
            // 
            this.lblItem.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItem.ForeColor = System.Drawing.Color.White;
            this.lblItem.Location = new System.Drawing.Point(119, 0);
            this.lblItem.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblItem.Name = "lblItem";
            this.lblItem.Size = new System.Drawing.Size(242, 107);
            this.lblItem.TabIndex = 3;
            this.lblItem.Text = "Item";
            this.lblItem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblItem.UseCompatibleTextRendering = true;
            this.lblItem.Click += new System.EventHandler(this.lblItem_Click);
            // 
            // pnStatus
            // 
            this.pnStatus.Controls.Add(this.lblStatus);
            this.pnStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnStatus.Location = new System.Drawing.Point(361, 719);
            this.pnStatus.Margin = new System.Windows.Forms.Padding(4);
            this.pnStatus.Name = "pnStatus";
            this.pnStatus.Size = new System.Drawing.Size(1010, 31);
            this.pnStatus.TabIndex = 2;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.Red;
            this.lblStatus.Location = new System.Drawing.Point(0, 0);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(195, 17);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.Text = "[Error or Status Message]";
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.Gray;
            this.btnLogin.Controls.Add(this.picLogin);
            this.btnLogin.Controls.Add(this.lblLogin);
            this.btnLogin.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnLogin.Location = new System.Drawing.Point(0, 0);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(4);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(361, 107);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // lblLogin
            // 
            this.lblLogin.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogin.ForeColor = System.Drawing.Color.White;
            this.lblLogin.Location = new System.Drawing.Point(119, 0);
            this.lblLogin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(242, 107);
            this.lblLogin.TabIndex = 3;
            this.lblLogin.Text = "Login";
            this.lblLogin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblLogin.UseCompatibleTextRendering = true;
            this.lblLogin.Click += new System.EventHandler(this.lblLogin_Click);
            // 
            // picLogin
            // 
            this.picLogin.Dock = System.Windows.Forms.DockStyle.Left;
            this.picLogin.Image = global::KernalPanic.Properties.Resources.login;
            this.picLogin.Location = new System.Drawing.Point(0, 0);
            this.picLogin.Margin = new System.Windows.Forms.Padding(4);
            this.picLogin.Name = "picLogin";
            this.picLogin.Size = new System.Drawing.Size(120, 107);
            this.picLogin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picLogin.TabIndex = 0;
            this.picLogin.TabStop = false;
            this.picLogin.Click += new System.EventHandler(this.picLogin_Click);
            // 
            // picWarehouse
            // 
            this.picWarehouse.Dock = System.Windows.Forms.DockStyle.Left;
            this.picWarehouse.Image = global::KernalPanic.Properties.Resources.warehouse;
            this.picWarehouse.Location = new System.Drawing.Point(0, 0);
            this.picWarehouse.Margin = new System.Windows.Forms.Padding(4);
            this.picWarehouse.Name = "picWarehouse";
            this.picWarehouse.Size = new System.Drawing.Size(120, 107);
            this.picWarehouse.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picWarehouse.TabIndex = 0;
            this.picWarehouse.TabStop = false;
            // 
            // picItem
            // 
            this.picItem.Dock = System.Windows.Forms.DockStyle.Left;
            this.picItem.Image = global::KernalPanic.Properties.Resources.item;
            this.picItem.Location = new System.Drawing.Point(0, 0);
            this.picItem.Margin = new System.Windows.Forms.Padding(4);
            this.picItem.Name = "picItem";
            this.picItem.Size = new System.Drawing.Size(120, 107);
            this.picItem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picItem.TabIndex = 0;
            this.picItem.TabStop = false;
            this.picItem.Click += new System.EventHandler(this.picItem_Click);
            // 
            // picOrder
            // 
            this.picOrder.Dock = System.Windows.Forms.DockStyle.Left;
            this.picOrder.Image = global::KernalPanic.Properties.Resources.order;
            this.picOrder.Location = new System.Drawing.Point(0, 0);
            this.picOrder.Margin = new System.Windows.Forms.Padding(4);
            this.picOrder.Name = "picOrder";
            this.picOrder.Size = new System.Drawing.Size(120, 107);
            this.picOrder.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picOrder.TabIndex = 0;
            this.picOrder.TabStop = false;
            this.picOrder.Click += new System.EventHandler(this.picOrder_Click);
            // 
            // picLogo
            // 
            this.picLogo.Dock = System.Windows.Forms.DockStyle.Left;
            this.picLogo.Image = global::KernalPanic.Properties.Resources.Company_Logo___White;
            this.picLogo.Location = new System.Drawing.Point(0, 0);
            this.picLogo.Margin = new System.Windows.Forms.Padding(4);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(120, 123);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picLogo.TabIndex = 0;
            this.picLogo.TabStop = false;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1371, 750);
            this.Controls.Add(this.pnStatus);
            this.Controls.Add(this.pnNav);
            this.Controls.Add(this.pnBanner);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1194, 724);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Moe\'s Warehouse";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.pnBanner.ResumeLayout(false);
            this.pnCompName.ResumeLayout(false);
            this.pnNav.ResumeLayout(false);
            this.btnWarehouse.ResumeLayout(false);
            this.btnOrder.ResumeLayout(false);
            this.btnItem.ResumeLayout(false);
            this.pnStatus.ResumeLayout(false);
            this.pnStatus.PerformLayout();
            this.btnLogin.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWarehouse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
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
    }
}

