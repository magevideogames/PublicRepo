/*
 * Created by SharpDevelop.
 * User: Mage
 * Date: 6/18/2015
 * Time: 4:17 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace WIPDatabase
{
	partial class InvoiceDetails
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.lblInvoices = new System.Windows.Forms.Label();
			this.lvInvoices = new System.Windows.Forms.ListView();
			this.chInvoice = new System.Windows.Forms.ColumnHeader();
			this.lblINumber = new System.Windows.Forms.Label();
			this.nudAmount = new System.Windows.Forms.NumericUpDown();
			this.lblAmount = new System.Windows.Forms.Label();
			this.lblDate = new System.Windows.Forms.Label();
			this.dtpDate = new System.Windows.Forms.DateTimePicker();
			this.lblPO = new System.Windows.Forms.Label();
			this.btnEdit = new System.Windows.Forms.Button();
			this.btnDevices = new System.Windows.Forms.Button();
			this.btnAdd = new System.Windows.Forms.Button();
			this.ofdInvoice = new System.Windows.Forms.OpenFileDialog();
			this.nudInvoice = new System.Windows.Forms.NumericUpDown();
			this.lblLoading = new System.Windows.Forms.Label();
			this.cbxPOs = new System.Windows.Forms.ComboBox();
			this.btnCancel = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.nudAmount)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudInvoice)).BeginInit();
			this.SuspendLayout();
			// 
			// lblInvoices
			// 
			this.lblInvoices.AutoSize = true;
			this.lblInvoices.Location = new System.Drawing.Point(12, 10);
			this.lblInvoices.Name = "lblInvoices";
			this.lblInvoices.Size = new System.Drawing.Size(50, 13);
			this.lblInvoices.TabIndex = 0;
			this.lblInvoices.Text = "Invoices:";
			// 
			// lvInvoices
			// 
			this.lvInvoices.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.chInvoice});
			this.lvInvoices.Location = new System.Drawing.Point(12, 26);
			this.lvInvoices.MultiSelect = false;
			this.lvInvoices.Name = "lvInvoices";
			this.lvInvoices.Size = new System.Drawing.Size(64, 220);
			this.lvInvoices.TabIndex = 1;
			this.lvInvoices.UseCompatibleStateImageBehavior = false;
			this.lvInvoices.View = System.Windows.Forms.View.Details;
			this.lvInvoices.SelectedIndexChanged += new System.EventHandler(this.LvInvoicesSelectedIndexChanged);
			this.lvInvoices.DoubleClick += new System.EventHandler(this.LvInvoicesDoubleClick);
			// 
			// chInvoice
			// 
			this.chInvoice.Text = "Invoice #";
			// 
			// lblINumber
			// 
			this.lblINumber.AutoSize = true;
			this.lblINumber.Location = new System.Drawing.Point(82, 26);
			this.lblINumber.Name = "lblINumber";
			this.lblINumber.Size = new System.Drawing.Size(55, 13);
			this.lblINumber.TabIndex = 2;
			this.lblINumber.Text = "Invoice #:";
			// 
			// nudAmount
			// 
			this.nudAmount.Enabled = false;
			this.nudAmount.Location = new System.Drawing.Point(143, 50);
			this.nudAmount.Maximum = new decimal(new int[] {
									999999,
									0,
									0,
									0});
			this.nudAmount.Minimum = new decimal(new int[] {
									1,
									0,
									0,
									0});
			this.nudAmount.Name = "nudAmount";
			this.nudAmount.Size = new System.Drawing.Size(100, 20);
			this.nudAmount.TabIndex = 8;
			this.nudAmount.Value = new decimal(new int[] {
									1111,
									0,
									0,
									0});
			// 
			// lblAmount
			// 
			this.lblAmount.AutoSize = true;
			this.lblAmount.Location = new System.Drawing.Point(82, 52);
			this.lblAmount.Name = "lblAmount";
			this.lblAmount.Size = new System.Drawing.Size(46, 13);
			this.lblAmount.TabIndex = 7;
			this.lblAmount.Text = "Amount:";
			// 
			// lblDate
			// 
			this.lblDate.AutoSize = true;
			this.lblDate.Location = new System.Drawing.Point(82, 80);
			this.lblDate.Name = "lblDate";
			this.lblDate.Size = new System.Drawing.Size(33, 13);
			this.lblDate.TabIndex = 9;
			this.lblDate.Text = "Date:";
			// 
			// dtpDate
			// 
			this.dtpDate.Enabled = false;
			this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpDate.Location = new System.Drawing.Point(142, 76);
			this.dtpDate.MinDate = new System.DateTime(1980, 1, 1, 0, 0, 0, 0);
			this.dtpDate.Name = "dtpDate";
			this.dtpDate.Size = new System.Drawing.Size(101, 20);
			this.dtpDate.TabIndex = 10;
			// 
			// lblPO
			// 
			this.lblPO.AutoSize = true;
			this.lblPO.Location = new System.Drawing.Point(82, 105);
			this.lblPO.Name = "lblPO";
			this.lblPO.Size = new System.Drawing.Size(35, 13);
			this.lblPO.TabIndex = 11;
			this.lblPO.Text = "PO #:";
			// 
			// btnEdit
			// 
			this.btnEdit.AutoSize = true;
			this.btnEdit.Location = new System.Drawing.Point(82, 193);
			this.btnEdit.Name = "btnEdit";
			this.btnEdit.Size = new System.Drawing.Size(75, 23);
			this.btnEdit.TabIndex = 13;
			this.btnEdit.Text = "Edit";
			this.btnEdit.UseVisualStyleBackColor = true;
			this.btnEdit.Click += new System.EventHandler(this.BtnEditClick);
			// 
			// btnDevices
			// 
			this.btnDevices.AutoSize = true;
			this.btnDevices.Enabled = false;
			this.btnDevices.Location = new System.Drawing.Point(168, 193);
			this.btnDevices.Name = "btnDevices";
			this.btnDevices.Size = new System.Drawing.Size(75, 23);
			this.btnDevices.TabIndex = 14;
			this.btnDevices.Text = "Devices";
			this.btnDevices.UseVisualStyleBackColor = true;
			this.btnDevices.Click += new System.EventHandler(this.BtnDevicesClick);
			// 
			// btnAdd
			// 
			this.btnAdd.AutoSize = true;
			this.btnAdd.Location = new System.Drawing.Point(82, 222);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(75, 23);
			this.btnAdd.TabIndex = 15;
			this.btnAdd.Text = "Add";
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += new System.EventHandler(this.BtnAddClick);
			// 
			// ofdInvoice
			// 
			this.ofdInvoice.FileName = "openFileDialog1";
			// 
			// nudInvoice
			// 
			this.nudInvoice.Enabled = false;
			this.nudInvoice.Location = new System.Drawing.Point(143, 24);
			this.nudInvoice.Maximum = new decimal(new int[] {
									999999,
									0,
									0,
									0});
			this.nudInvoice.Minimum = new decimal(new int[] {
									1111,
									0,
									0,
									0});
			this.nudInvoice.Name = "nudInvoice";
			this.nudInvoice.Size = new System.Drawing.Size(100, 20);
			this.nudInvoice.TabIndex = 16;
			this.nudInvoice.Value = new decimal(new int[] {
									1111,
									0,
									0,
									0});
			// 
			// lblLoading
			// 
			this.lblLoading.Location = new System.Drawing.Point(163, 222);
			this.lblLoading.Name = "lblLoading";
			this.lblLoading.Size = new System.Drawing.Size(87, 26);
			this.lblLoading.TabIndex = 18;
			this.lblLoading.Text = "Adding Invoice. Please Wait.";
			this.lblLoading.Visible = false;
			// 
			// cbxPOs
			// 
			this.cbxPOs.Enabled = false;
			this.cbxPOs.FormattingEnabled = true;
			this.cbxPOs.Location = new System.Drawing.Point(142, 102);
			this.cbxPOs.Name = "cbxPOs";
			this.cbxPOs.Size = new System.Drawing.Size(101, 21);
			this.cbxPOs.TabIndex = 19;
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(168, 222);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 20;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Visible = false;
			this.btnCancel.Click += new System.EventHandler(this.BtnCancelClick);
			// 
			// InvoiceDetails
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(255, 257);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.cbxPOs);
			this.Controls.Add(this.lblLoading);
			this.Controls.Add(this.nudInvoice);
			this.Controls.Add(this.btnAdd);
			this.Controls.Add(this.btnDevices);
			this.Controls.Add(this.btnEdit);
			this.Controls.Add(this.lblPO);
			this.Controls.Add(this.dtpDate);
			this.Controls.Add(this.lblDate);
			this.Controls.Add(this.nudAmount);
			this.Controls.Add(this.lblAmount);
			this.Controls.Add(this.lblINumber);
			this.Controls.Add(this.lvInvoices);
			this.Controls.Add(this.lblInvoices);
			this.Name = "InvoiceDetails";
			this.Text = "InvoiceDetails";
			((System.ComponentModel.ISupportInitialize)(this.nudAmount)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudInvoice)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.ComboBox cbxPOs;
		private System.Windows.Forms.Label lblLoading;
		private System.Windows.Forms.NumericUpDown nudInvoice;
		private System.Windows.Forms.OpenFileDialog ofdInvoice;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.Button btnDevices;
		private System.Windows.Forms.Button btnEdit;
		private System.Windows.Forms.Label lblPO;
		private System.Windows.Forms.DateTimePicker dtpDate;
		private System.Windows.Forms.Label lblDate;
		private System.Windows.Forms.Label lblAmount;
		private System.Windows.Forms.NumericUpDown nudAmount;
		private System.Windows.Forms.Label lblINumber;
		private System.Windows.Forms.ColumnHeader chInvoice;
		private System.Windows.Forms.ListView lvInvoices;
		private System.Windows.Forms.Label lblInvoices;
	}
}
