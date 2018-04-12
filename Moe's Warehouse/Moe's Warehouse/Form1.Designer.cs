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
            this.btnWarehouse = new System.Windows.Forms.Panel();
            this.picWarehouse = new System.Windows.Forms.PictureBox();
            this.btnOrder = new System.Windows.Forms.Panel();
            this.picOrder = new System.Windows.Forms.PictureBox();
            this.lblOrder = new System.Windows.Forms.Label();
            this.btnItem = new System.Windows.Forms.Panel();
            this.picItem = new System.Windows.Forms.PictureBox();
            this.lblItem = new System.Windows.Forms.Label();
            this.pnStatus = new System.Windows.Forms.Panel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblWarehouse = new System.Windows.Forms.Label();
            this.pnBanner.SuspendLayout();
            this.pnCompName.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.pnNav.SuspendLayout();
            this.btnWarehouse.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picWarehouse)).BeginInit();
            this.btnOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picOrder)).BeginInit();
            this.btnItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picItem)).BeginInit();
            this.pnStatus.SuspendLayout();
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
            this.picLogo.TabIndex = 0;
            this.picLogo.TabStop = false;
            // 
            // lblStaticCompanyName
            // 
            this.lblStaticCompanyName.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblStaticCompanyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStaticCompanyName.ForeColor = System.Drawing.Color.White;
            this.lblStaticCompanyName.Location = new System.Drawing.Point(96, 0);
            this.lblStaticCompanyName.Name = "lblStaticCompanyName";
            this.lblStaticCompanyName.Size = new System.Drawing.Size(175, 100);
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
            this.pnNav.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnNav.Location = new System.Drawing.Point(0, 100);
            this.pnNav.Name = "pnNav";
            this.pnNav.Size = new System.Drawing.Size(271, 509);
            this.pnNav.TabIndex = 1;
            // 
            // btnWarehouse
            // 
            this.btnWarehouse.Controls.Add(this.picWarehouse);
            this.btnWarehouse.Controls.Add(this.lblWarehouse);
            this.btnWarehouse.Location = new System.Drawing.Point(0, 177);
            this.btnWarehouse.Name = "btnWarehouse";
            this.btnWarehouse.Size = new System.Drawing.Size(271, 87);
            this.btnWarehouse.TabIndex = 5;
            // 
            // picWarehouse
            // 
            this.picWarehouse.Dock = System.Windows.Forms.DockStyle.Left;
            this.picWarehouse.Location = new System.Drawing.Point(0, 0);
            this.picWarehouse.Name = "picWarehouse";
            this.picWarehouse.Size = new System.Drawing.Size(90, 87);
            this.picWarehouse.TabIndex = 0;
            this.picWarehouse.TabStop = false;
            // 
            // btnOrder
            // 
            this.btnOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnOrder.Controls.Add(this.picOrder);
            this.btnOrder.Controls.Add(this.lblOrder);
            this.btnOrder.Location = new System.Drawing.Point(0, 87);
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
            this.lblOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrder.ForeColor = System.Drawing.Color.White;
            this.lblOrder.Location = new System.Drawing.Point(0, 0);
            this.lblOrder.Name = "lblOrder";
            this.lblOrder.Size = new System.Drawing.Size(271, 87);
            this.lblOrder.TabIndex = 3;
            this.lblOrder.Text = "Order";
            this.lblOrder.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblOrder.Click += new System.EventHandler(this.lblOrder_Click);
            // 
            // btnItem
            // 
            this.btnItem.BackColor = System.Drawing.Color.Gray;
            this.btnItem.Controls.Add(this.picItem);
            this.btnItem.Controls.Add(this.lblItem);
            this.btnItem.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnItem.Location = new System.Drawing.Point(0, 0);
            this.btnItem.Name = "btnItem";
            this.btnItem.Size = new System.Drawing.Size(271, 87);
            this.btnItem.TabIndex = 3;
            this.btnItem.Click += new System.EventHandler(this.btnItem_Click);
            // 
            // picItem
            // 
            this.picItem.Dock = System.Windows.Forms.DockStyle.Left;
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
            this.lblItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItem.ForeColor = System.Drawing.Color.White;
            this.lblItem.Location = new System.Drawing.Point(0, 0);
            this.lblItem.Name = "lblItem";
            this.lblItem.Size = new System.Drawing.Size(271, 87);
            this.lblItem.TabIndex = 3;
            this.lblItem.Text = "Item";
            this.lblItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblItem.UseCompatibleTextRendering = true;
            this.lblItem.Click += new System.EventHandler(this.lblItem_Click);
            // 
            // pnStatus
            // 
            this.pnStatus.Controls.Add(this.lblStatus);
            this.pnStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnStatus.Location = new System.Drawing.Point(271, 584);
            this.pnStatus.Name = "pnStatus";
            this.pnStatus.Size = new System.Drawing.Size(757, 25);
            this.pnStatus.TabIndex = 2;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.Red;
            this.lblStatus.Location = new System.Drawing.Point(0, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(151, 13);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.Text = "[Error or Status Message]";
            // 
            // lblWarehouse
            // 
            this.lblWarehouse.BackColor = System.Drawing.Color.Transparent;
            this.lblWarehouse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblWarehouse.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWarehouse.ForeColor = System.Drawing.Color.White;
            this.lblWarehouse.Location = new System.Drawing.Point(0, 0);
            this.lblWarehouse.Name = "lblWarehouse";
            this.lblWarehouse.Size = new System.Drawing.Size(271, 87);
            this.lblWarehouse.TabIndex = 1;
            this.lblWarehouse.Text = "Warehouse";
            this.lblWarehouse.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(900, 597);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Moe\'s Warehouse";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.pnBanner.ResumeLayout(false);
            this.pnCompName.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.pnNav.ResumeLayout(false);
            this.btnWarehouse.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picWarehouse)).EndInit();
            this.btnOrder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picOrder)).EndInit();
            this.btnItem.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picItem)).EndInit();
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
        private System.Windows.Forms.Panel btnItem;
        private System.Windows.Forms.PictureBox picItem;
        private System.Windows.Forms.Label lblItem;
        private System.Windows.Forms.Panel btnOrder;
        private System.Windows.Forms.PictureBox picOrder;
        private System.Windows.Forms.Label lblOrder;
        private System.Windows.Forms.Panel btnWarehouse;
        private System.Windows.Forms.PictureBox picWarehouse;
        private System.Windows.Forms.Label lblWarehouse;
    }
}

