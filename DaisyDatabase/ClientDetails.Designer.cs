/*
 * Created by SharpDevelop.
 * User: Mage
 * Date: 6/18/2015
 * Time: 11:26 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace WIPDatabase
{
	partial class ClientDetails
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
			this.lblClient = new System.Windows.Forms.Label();
			this.tbxClient = new System.Windows.Forms.TextBox();
			this.lblMTID = new System.Windows.Forms.Label();
			this.nudMTID = new System.Windows.Forms.NumericUpDown();
			this.lblCPrice = new System.Windows.Forms.Label();
			this.nudCPrice = new System.Windows.Forms.NumericUpDown();
			this.nudMoCPrice = new System.Windows.Forms.NumericUpDown();
			this.lblMoCPrice = new System.Windows.Forms.Label();
			this.nudMPrice = new System.Windows.Forms.NumericUpDown();
			this.lblMPrice = new System.Windows.Forms.Label();
			this.gbxStandard = new System.Windows.Forms.GroupBox();
			this.gbxOEM = new System.Windows.Forms.GroupBox();
			this.lblCOEMPrice = new System.Windows.Forms.Label();
			this.nudMOEMPrice = new System.Windows.Forms.NumericUpDown();
			this.nudCOEMPrice = new System.Windows.Forms.NumericUpDown();
			this.lblMOEMPrice = new System.Windows.Forms.Label();
			this.lblMoCOEMPrice = new System.Windows.Forms.Label();
			this.nudMoCOEMPrice = new System.Windows.Forms.NumericUpDown();
			this.btnEdit = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnDevices = new System.Windows.Forms.Button();
			this.btnInvoices = new System.Windows.Forms.Button();
			this.btnPOs = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.nudMTID)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudCPrice)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudMoCPrice)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudMPrice)).BeginInit();
			this.gbxStandard.SuspendLayout();
			this.gbxOEM.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudMOEMPrice)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudCOEMPrice)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudMoCOEMPrice)).BeginInit();
			this.SuspendLayout();
			// 
			// lblClient
			// 
			this.lblClient.AutoSize = true;
			this.lblClient.Location = new System.Drawing.Point(8, 9);
			this.lblClient.Name = "lblClient";
			this.lblClient.Size = new System.Drawing.Size(67, 13);
			this.lblClient.TabIndex = 0;
			this.lblClient.Text = "Client Name:";
			// 
			// tbxClient
			// 
			this.tbxClient.Enabled = false;
			this.tbxClient.Location = new System.Drawing.Point(81, 6);
			this.tbxClient.Name = "tbxClient";
			this.tbxClient.Size = new System.Drawing.Size(302, 20);
			this.tbxClient.TabIndex = 1;
			// 
			// lblMTID
			// 
			this.lblMTID.AutoSize = true;
			this.lblMTID.Location = new System.Drawing.Point(8, 45);
			this.lblMTID.Name = "lblMTID";
			this.lblMTID.Size = new System.Drawing.Size(72, 13);
			this.lblMTID.TabIndex = 2;
			this.lblMTID.Text = "MacsTrac ID:";
			// 
			// nudMTID
			// 
			this.nudMTID.Enabled = false;
			this.nudMTID.Location = new System.Drawing.Point(86, 43);
			this.nudMTID.Maximum = new decimal(new int[] {
									9999,
									0,
									0,
									0});
			this.nudMTID.Minimum = new decimal(new int[] {
									1,
									0,
									0,
									0});
			this.nudMTID.Name = "nudMTID";
			this.nudMTID.Size = new System.Drawing.Size(61, 20);
			this.nudMTID.TabIndex = 3;
			this.nudMTID.Value = new decimal(new int[] {
									1,
									0,
									0,
									0});
			// 
			// lblCPrice
			// 
			this.lblCPrice.AutoSize = true;
			this.lblCPrice.Location = new System.Drawing.Point(6, 16);
			this.lblCPrice.Name = "lblCPrice";
			this.lblCPrice.Size = new System.Drawing.Size(60, 13);
			this.lblCPrice.TabIndex = 4;
			this.lblCPrice.Text = "Color PPM:";
			// 
			// nudCPrice
			// 
			this.nudCPrice.DecimalPlaces = 4;
			this.nudCPrice.Increment = new decimal(new int[] {
									1,
									0,
									0,
									262144});
			this.nudCPrice.Location = new System.Drawing.Point(119, 14);
			this.nudCPrice.Maximum = new decimal(new int[] {
									9999,
									0,
									0,
									262144});
			this.nudCPrice.Name = "nudCPrice";
			this.nudCPrice.Size = new System.Drawing.Size(58, 20);
			this.nudCPrice.TabIndex = 5;
			this.nudCPrice.Value = new decimal(new int[] {
									1,
									0,
									0,
									262144});
			// 
			// nudMoCPrice
			// 
			this.nudMoCPrice.DecimalPlaces = 4;
			this.nudMoCPrice.Increment = new decimal(new int[] {
									1,
									0,
									0,
									262144});
			this.nudMoCPrice.Location = new System.Drawing.Point(119, 44);
			this.nudMoCPrice.Maximum = new decimal(new int[] {
									9999,
									0,
									0,
									262144});
			this.nudMoCPrice.Name = "nudMoCPrice";
			this.nudMoCPrice.Size = new System.Drawing.Size(58, 20);
			this.nudMoCPrice.TabIndex = 7;
			this.nudMoCPrice.Value = new decimal(new int[] {
									1,
									0,
									0,
									262144});
			// 
			// lblMoCPrice
			// 
			this.lblMoCPrice.AutoSize = true;
			this.lblMoCPrice.Location = new System.Drawing.Point(6, 46);
			this.lblMoCPrice.Name = "lblMoCPrice";
			this.lblMoCPrice.Size = new System.Drawing.Size(107, 13);
			this.lblMoCPrice.TabIndex = 6;
			this.lblMoCPrice.Text = "Mono On Color PPM:";
			// 
			// nudMPrice
			// 
			this.nudMPrice.DecimalPlaces = 4;
			this.nudMPrice.Increment = new decimal(new int[] {
									1,
									0,
									0,
									262144});
			this.nudMPrice.Location = new System.Drawing.Point(119, 75);
			this.nudMPrice.Maximum = new decimal(new int[] {
									9999,
									0,
									0,
									262144});
			this.nudMPrice.Name = "nudMPrice";
			this.nudMPrice.Size = new System.Drawing.Size(58, 20);
			this.nudMPrice.TabIndex = 9;
			this.nudMPrice.Value = new decimal(new int[] {
									1,
									0,
									0,
									262144});
			// 
			// lblMPrice
			// 
			this.lblMPrice.AutoSize = true;
			this.lblMPrice.Location = new System.Drawing.Point(6, 77);
			this.lblMPrice.Name = "lblMPrice";
			this.lblMPrice.Size = new System.Drawing.Size(63, 13);
			this.lblMPrice.TabIndex = 8;
			this.lblMPrice.Text = "Mono PPM:";
			// 
			// gbxStandard
			// 
			this.gbxStandard.Controls.Add(this.lblCPrice);
			this.gbxStandard.Controls.Add(this.nudMPrice);
			this.gbxStandard.Controls.Add(this.nudCPrice);
			this.gbxStandard.Controls.Add(this.lblMPrice);
			this.gbxStandard.Controls.Add(this.lblMoCPrice);
			this.gbxStandard.Controls.Add(this.nudMoCPrice);
			this.gbxStandard.Enabled = false;
			this.gbxStandard.Location = new System.Drawing.Point(8, 69);
			this.gbxStandard.Name = "gbxStandard";
			this.gbxStandard.Size = new System.Drawing.Size(188, 100);
			this.gbxStandard.TabIndex = 10;
			this.gbxStandard.TabStop = false;
			this.gbxStandard.Text = "Standard Pricing";
			// 
			// gbxOEM
			// 
			this.gbxOEM.Controls.Add(this.lblCOEMPrice);
			this.gbxOEM.Controls.Add(this.nudMOEMPrice);
			this.gbxOEM.Controls.Add(this.nudCOEMPrice);
			this.gbxOEM.Controls.Add(this.lblMOEMPrice);
			this.gbxOEM.Controls.Add(this.lblMoCOEMPrice);
			this.gbxOEM.Controls.Add(this.nudMoCOEMPrice);
			this.gbxOEM.Enabled = false;
			this.gbxOEM.Location = new System.Drawing.Point(202, 69);
			this.gbxOEM.Name = "gbxOEM";
			this.gbxOEM.Size = new System.Drawing.Size(188, 100);
			this.gbxOEM.TabIndex = 11;
			this.gbxOEM.TabStop = false;
			this.gbxOEM.Text = "OEM Pricing";
			// 
			// lblCOEMPrice
			// 
			this.lblCOEMPrice.AutoSize = true;
			this.lblCOEMPrice.Location = new System.Drawing.Point(6, 16);
			this.lblCOEMPrice.Name = "lblCOEMPrice";
			this.lblCOEMPrice.Size = new System.Drawing.Size(60, 13);
			this.lblCOEMPrice.TabIndex = 4;
			this.lblCOEMPrice.Text = "Color PPM:";
			// 
			// nudMOEMPrice
			// 
			this.nudMOEMPrice.DecimalPlaces = 4;
			this.nudMOEMPrice.Increment = new decimal(new int[] {
									1,
									0,
									0,
									262144});
			this.nudMOEMPrice.Location = new System.Drawing.Point(119, 75);
			this.nudMOEMPrice.Maximum = new decimal(new int[] {
									9999,
									0,
									0,
									262144});
			this.nudMOEMPrice.Name = "nudMOEMPrice";
			this.nudMOEMPrice.Size = new System.Drawing.Size(58, 20);
			this.nudMOEMPrice.TabIndex = 9;
			this.nudMOEMPrice.Value = new decimal(new int[] {
									1,
									0,
									0,
									262144});
			// 
			// nudCOEMPrice
			// 
			this.nudCOEMPrice.DecimalPlaces = 4;
			this.nudCOEMPrice.Increment = new decimal(new int[] {
									1,
									0,
									0,
									262144});
			this.nudCOEMPrice.Location = new System.Drawing.Point(119, 14);
			this.nudCOEMPrice.Maximum = new decimal(new int[] {
									9999,
									0,
									0,
									262144});
			this.nudCOEMPrice.Name = "nudCOEMPrice";
			this.nudCOEMPrice.Size = new System.Drawing.Size(58, 20);
			this.nudCOEMPrice.TabIndex = 5;
			this.nudCOEMPrice.Value = new decimal(new int[] {
									1,
									0,
									0,
									262144});
			// 
			// lblMOEMPrice
			// 
			this.lblMOEMPrice.AutoSize = true;
			this.lblMOEMPrice.Location = new System.Drawing.Point(6, 77);
			this.lblMOEMPrice.Name = "lblMOEMPrice";
			this.lblMOEMPrice.Size = new System.Drawing.Size(63, 13);
			this.lblMOEMPrice.TabIndex = 8;
			this.lblMOEMPrice.Text = "Mono PPM:";
			// 
			// lblMoCOEMPrice
			// 
			this.lblMoCOEMPrice.AutoSize = true;
			this.lblMoCOEMPrice.Location = new System.Drawing.Point(6, 46);
			this.lblMoCOEMPrice.Name = "lblMoCOEMPrice";
			this.lblMoCOEMPrice.Size = new System.Drawing.Size(107, 13);
			this.lblMoCOEMPrice.TabIndex = 6;
			this.lblMoCOEMPrice.Text = "Mono On Color PPM:";
			// 
			// nudMoCOEMPrice
			// 
			this.nudMoCOEMPrice.DecimalPlaces = 4;
			this.nudMoCOEMPrice.Increment = new decimal(new int[] {
									1,
									0,
									0,
									262144});
			this.nudMoCOEMPrice.Location = new System.Drawing.Point(119, 44);
			this.nudMoCOEMPrice.Maximum = new decimal(new int[] {
									9999,
									0,
									0,
									262144});
			this.nudMoCOEMPrice.Name = "nudMoCOEMPrice";
			this.nudMoCOEMPrice.Size = new System.Drawing.Size(58, 20);
			this.nudMoCOEMPrice.TabIndex = 7;
			this.nudMoCOEMPrice.Value = new decimal(new int[] {
									1,
									0,
									0,
									262144});
			// 
			// btnEdit
			// 
			this.btnEdit.AutoSize = true;
			this.btnEdit.Location = new System.Drawing.Point(8, 175);
			this.btnEdit.Name = "btnEdit";
			this.btnEdit.Size = new System.Drawing.Size(75, 23);
			this.btnEdit.TabIndex = 13;
			this.btnEdit.Text = "Edit";
			this.btnEdit.UseVisualStyleBackColor = true;
			this.btnEdit.Click += new System.EventHandler(this.BtnEditClick);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(308, 175);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 14;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Visible = false;
			this.btnCancel.Click += new System.EventHandler(this.BtnCancelClick);
			// 
			// btnDevices
			// 
			this.btnDevices.AutoSize = true;
			this.btnDevices.Location = new System.Drawing.Point(86, 175);
			this.btnDevices.Name = "btnDevices";
			this.btnDevices.Size = new System.Drawing.Size(75, 23);
			this.btnDevices.TabIndex = 15;
			this.btnDevices.Text = "Devices";
			this.btnDevices.UseVisualStyleBackColor = true;
			this.btnDevices.Click += new System.EventHandler(this.BtnDevicesClick);
			// 
			// btnInvoices
			// 
			this.btnInvoices.AutoSize = true;
			this.btnInvoices.Location = new System.Drawing.Point(227, 175);
			this.btnInvoices.Name = "btnInvoices";
			this.btnInvoices.Size = new System.Drawing.Size(75, 23);
			this.btnInvoices.TabIndex = 16;
			this.btnInvoices.Text = "Invoices";
			this.btnInvoices.UseVisualStyleBackColor = true;
			this.btnInvoices.Click += new System.EventHandler(this.BtnInvoicesClick);
			// 
			// btnPOs
			// 
			this.btnPOs.AutoSize = true;
			this.btnPOs.Location = new System.Drawing.Point(167, 175);
			this.btnPOs.Name = "btnPOs";
			this.btnPOs.Size = new System.Drawing.Size(54, 23);
			this.btnPOs.TabIndex = 17;
			this.btnPOs.Text = "POs";
			this.btnPOs.UseVisualStyleBackColor = true;
			this.btnPOs.Click += new System.EventHandler(this.BtnPOsClick);
			// 
			// ClientDetails
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(399, 205);
			this.Controls.Add(this.btnPOs);
			this.Controls.Add(this.btnInvoices);
			this.Controls.Add(this.btnDevices);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnEdit);
			this.Controls.Add(this.gbxOEM);
			this.Controls.Add(this.gbxStandard);
			this.Controls.Add(this.nudMTID);
			this.Controls.Add(this.lblMTID);
			this.Controls.Add(this.tbxClient);
			this.Controls.Add(this.lblClient);
			this.Name = "ClientDetails";
			this.Text = "ClientDetails";
			((System.ComponentModel.ISupportInitialize)(this.nudMTID)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudCPrice)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudMoCPrice)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudMPrice)).EndInit();
			this.gbxStandard.ResumeLayout(false);
			this.gbxStandard.PerformLayout();
			this.gbxOEM.ResumeLayout(false);
			this.gbxOEM.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudMOEMPrice)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudCOEMPrice)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudMoCOEMPrice)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Button btnPOs;
		private System.Windows.Forms.Button btnInvoices;
		private System.Windows.Forms.Button btnDevices;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnEdit;
		private System.Windows.Forms.NumericUpDown nudMoCOEMPrice;
		private System.Windows.Forms.Label lblMoCOEMPrice;
		private System.Windows.Forms.Label lblMOEMPrice;
		private System.Windows.Forms.NumericUpDown nudCOEMPrice;
		private System.Windows.Forms.NumericUpDown nudMOEMPrice;
		private System.Windows.Forms.Label lblCOEMPrice;
		private System.Windows.Forms.GroupBox gbxOEM;
		private System.Windows.Forms.GroupBox gbxStandard;
		private System.Windows.Forms.Label lblMPrice;
		private System.Windows.Forms.NumericUpDown nudMPrice;
		private System.Windows.Forms.Label lblMoCPrice;
		private System.Windows.Forms.NumericUpDown nudMoCPrice;
		private System.Windows.Forms.NumericUpDown nudCPrice;
		private System.Windows.Forms.Label lblCPrice;
		private System.Windows.Forms.NumericUpDown nudMTID;
		private System.Windows.Forms.Label lblMTID;
		private System.Windows.Forms.TextBox tbxClient;
		private System.Windows.Forms.Label lblClient;
	}
}
