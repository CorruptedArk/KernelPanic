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
            this.btnOrder = new System.Windows.Forms.Panel();
            this.picOrder = new System.Windows.Forms.PictureBox();
            this.lblOrder = new System.Windows.Forms.Label();
            this.btnHome = new System.Windows.Forms.Panel();
            this.picHome = new System.Windows.Forms.PictureBox();
            this.lblHome = new System.Windows.Forms.Label();
            this.pnStatus = new System.Windows.Forms.Panel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.pnBanner.SuspendLayout();
            this.pnCompName.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.pnNav.SuspendLayout();
            this.btnOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picOrder)).BeginInit();
            this.btnHome.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHome)).BeginInit();
            this.pnStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnBanner
            // 
            this.pnBanner.Controls.Add(this.lblCurrentScreen);
            this.pnBanner.Controls.Add(this.pnCompName);
            this.pnBanner.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnBanner.Location = new System.Drawing.Point(0, 0);
            this.pnBanner.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnBanner.Name = "pnBanner";
            this.pnBanner.Size = new System.Drawing.Size(1553, 123);
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
            this.lblCurrentScreen.Size = new System.Drawing.Size(1192, 123);
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
            this.pnCompName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnCompName.Name = "pnCompName";
            this.pnCompName.Size = new System.Drawing.Size(361, 123);
            this.pnCompName.TabIndex = 2;
            // 
            // picLogo
            // 
            this.picLogo.Dock = System.Windows.Forms.DockStyle.Left;
            this.picLogo.Image = global::KernalPanic.Properties.Resources.Company_Logo___White;
            this.picLogo.Location = new System.Drawing.Point(0, 0);
            this.picLogo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(120, 123);
            this.picLogo.TabIndex = 0;
            this.picLogo.TabStop = false;
            // 
            // lblStaticCompanyName
            // 
            this.lblStaticCompanyName.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblStaticCompanyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStaticCompanyName.ForeColor = System.Drawing.Color.White;
            this.lblStaticCompanyName.Location = new System.Drawing.Point(128, 0);
            this.lblStaticCompanyName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStaticCompanyName.Name = "lblStaticCompanyName";
            this.lblStaticCompanyName.Size = new System.Drawing.Size(233, 123);
            this.lblStaticCompanyName.TabIndex = 3;
            this.lblStaticCompanyName.Text = "Moe\'s Warehouse";
            this.lblStaticCompanyName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnNav
            // 
            this.pnNav.AutoScroll = true;
            this.pnNav.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnNav.Controls.Add(this.btnOrder);
            this.pnNav.Controls.Add(this.btnHome);
            this.pnNav.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnNav.Location = new System.Drawing.Point(0, 123);
            this.pnNav.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnNav.Name = "pnNav";
            this.pnNav.Size = new System.Drawing.Size(361, 885);
            this.pnNav.TabIndex = 1;
            // 
            // btnOrder
            // 
            this.btnOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnOrder.Controls.Add(this.picOrder);
            this.btnOrder.Controls.Add(this.lblOrder);
            this.btnOrder.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnOrder.Location = new System.Drawing.Point(0, 107);
            this.btnOrder.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(361, 107);
            this.btnOrder.TabIndex = 4;
            this.btnOrder.Click += new System.EventHandler(this.btnOrder_Click);
            // 
            // picOrder
            // 
            this.picOrder.Dock = System.Windows.Forms.DockStyle.Top;
            this.picOrder.Image = global::KernalPanic.Properties.Resources.order;
            this.picOrder.Location = new System.Drawing.Point(0, 0);
            this.picOrder.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.picOrder.Name = "picOrder";
            this.picOrder.Size = new System.Drawing.Size(361, 70);
            this.picOrder.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picOrder.TabIndex = 0;
            this.picOrder.TabStop = false;
            this.picOrder.Click += new System.EventHandler(this.picOrder_Click);
            // 
            // lblOrder
            // 
            this.lblOrder.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrder.ForeColor = System.Drawing.Color.White;
            this.lblOrder.Location = new System.Drawing.Point(0, 70);
            this.lblOrder.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOrder.Name = "lblOrder";
            this.lblOrder.Size = new System.Drawing.Size(361, 37);
            this.lblOrder.TabIndex = 3;
            this.lblOrder.Text = "Order";
            this.lblOrder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblOrder.Click += new System.EventHandler(this.lblOrder_Click);
            // 
            // btnHome
            // 
            this.btnHome.BackColor = System.Drawing.Color.Gray;
            this.btnHome.Controls.Add(this.picHome);
            this.btnHome.Controls.Add(this.lblHome);
            this.btnHome.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnHome.Location = new System.Drawing.Point(0, 0);
            this.btnHome.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(361, 107);
            this.btnHome.TabIndex = 3;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // picHome
            // 
            this.picHome.Dock = System.Windows.Forms.DockStyle.Top;
            this.picHome.Image = global::KernalPanic.Properties.Resources.home;
            this.picHome.Location = new System.Drawing.Point(0, 0);
            this.picHome.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.picHome.Name = "picHome";
            this.picHome.Size = new System.Drawing.Size(361, 70);
            this.picHome.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picHome.TabIndex = 0;
            this.picHome.TabStop = false;
            this.picHome.Click += new System.EventHandler(this.picHome_Click);
            // 
            // lblHome
            // 
            this.lblHome.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblHome.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHome.ForeColor = System.Drawing.Color.White;
            this.lblHome.Location = new System.Drawing.Point(0, 70);
            this.lblHome.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHome.Name = "lblHome";
            this.lblHome.Size = new System.Drawing.Size(361, 37);
            this.lblHome.TabIndex = 3;
            this.lblHome.Text = "Home";
            this.lblHome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblHome.Click += new System.EventHandler(this.lblHome_Click);
            // 
            // pnStatus
            // 
            this.pnStatus.Controls.Add(this.lblStatus);
            this.pnStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnStatus.Location = new System.Drawing.Point(361, 977);
            this.pnStatus.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnStatus.Name = "pnStatus";
            this.pnStatus.Size = new System.Drawing.Size(1192, 31);
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
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1553, 1008);
            this.Controls.Add(this.pnStatus);
            this.Controls.Add(this.pnNav);
            this.Controls.Add(this.pnBanner);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MinimumSize = new System.Drawing.Size(1194, 728);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Moe\'s Warehouse";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.pnBanner.ResumeLayout(false);
            this.pnCompName.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.pnNav.ResumeLayout(false);
            this.btnOrder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picOrder)).EndInit();
            this.btnHome.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picHome)).EndInit();
            this.pnStatus.ResumeLayout(false);
            this.pnStatus.PerformLayout();
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
        private System.Windows.Forms.Panel btnHome;
        private System.Windows.Forms.PictureBox picHome;
        private System.Windows.Forms.Label lblHome;
        private System.Windows.Forms.Panel btnOrder;
        private System.Windows.Forms.PictureBox picOrder;
        private System.Windows.Forms.Label lblOrder;
    }
}

