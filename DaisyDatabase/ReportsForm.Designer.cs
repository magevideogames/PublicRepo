/*
 * Created by SharpDevelop.
 * User: WIP00
 * Date: 7/2/2015
 * Time: 2:44 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace WIPDatabase
{
	partial class ReportsForm
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
			this.lvClients = new System.Windows.Forms.ListView();
			this.chMTID = new System.Windows.Forms.ColumnHeader();
			this.chName = new System.Windows.Forms.ColumnHeader();
			this.lblReports = new System.Windows.Forms.Label();
			this.lbxReports = new System.Windows.Forms.ListBox();
			this.btnCreate = new System.Windows.Forms.Button();
			this.lblStart = new System.Windows.Forms.Label();
			this.lblEnd = new System.Windows.Forms.Label();
			this.dtpStart = new System.Windows.Forms.DateTimePicker();
			this.dtpEnd = new System.Windows.Forms.DateTimePicker();
			this.lblDevices = new System.Windows.Forms.Label();
			this.lbxDevices = new System.Windows.Forms.ListBox();
			this.sfdReport = new System.Windows.Forms.SaveFileDialog();
			this.SuspendLayout();
			// 
			// lblClient
			// 
			this.lblClient.AutoSize = true;
			this.lblClient.Location = new System.Drawing.Point(12, 9);
			this.lblClient.Name = "lblClient";
			this.lblClient.Size = new System.Drawing.Size(36, 13);
			this.lblClient.TabIndex = 0;
			this.lblClient.Text = "Client:";
			// 
			// lvClients
			// 
			this.lvClients.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.chMTID,
									this.chName});
			this.lvClients.Location = new System.Drawing.Point(12, 25);
			this.lvClients.Name = "lvClients";
			this.lvClients.Size = new System.Drawing.Size(215, 225);
			this.lvClients.TabIndex = 1;
			this.lvClients.UseCompatibleStateImageBehavior = false;
			this.lvClients.View = System.Windows.Forms.View.Details;
			this.lvClients.SelectedIndexChanged += new System.EventHandler(this.LvClientsSelectedIndexChanged);
			// 
			// chMTID
			// 
			this.chMTID.Text = "Client ID";
			// 
			// chName
			// 
			this.chName.Text = "Client Name";
			this.chName.Width = 150;
			// 
			// lblReports
			// 
			this.lblReports.AutoSize = true;
			this.lblReports.Location = new System.Drawing.Point(240, 9);
			this.lblReports.Name = "lblReports";
			this.lblReports.Size = new System.Drawing.Size(47, 13);
			this.lblReports.TabIndex = 2;
			this.lblReports.Text = "Reports:";
			// 
			// lbxReports
			// 
			this.lbxReports.Enabled = false;
			this.lbxReports.FormattingEnabled = true;
			this.lbxReports.Items.AddRange(new object[] {
									"Annual Report",
									"Billing Invoice",
									"Device History",
									"Client History"});
			this.lbxReports.Location = new System.Drawing.Point(240, 25);
			this.lbxReports.Name = "lbxReports";
			this.lbxReports.Size = new System.Drawing.Size(120, 225);
			this.lbxReports.TabIndex = 3;
			this.lbxReports.SelectedIndexChanged += new System.EventHandler(this.LbxReportsSelectedIndexChanged);
			// 
			// btnCreate
			// 
			this.btnCreate.Enabled = false;
			this.btnCreate.Location = new System.Drawing.Point(366, 216);
			this.btnCreate.Name = "btnCreate";
			this.btnCreate.Size = new System.Drawing.Size(75, 34);
			this.btnCreate.TabIndex = 4;
			this.btnCreate.Text = "Create Report";
			this.btnCreate.UseVisualStyleBackColor = true;
			this.btnCreate.Click += new System.EventHandler(this.BtnCreateClick);
			// 
			// lblStart
			// 
			this.lblStart.AutoSize = true;
			this.lblStart.Location = new System.Drawing.Point(366, 135);
			this.lblStart.Name = "lblStart";
			this.lblStart.Size = new System.Drawing.Size(58, 13);
			this.lblStart.TabIndex = 5;
			this.lblStart.Text = "Start Date:";
			// 
			// lblEnd
			// 
			this.lblEnd.AutoSize = true;
			this.lblEnd.Location = new System.Drawing.Point(366, 174);
			this.lblEnd.Name = "lblEnd";
			this.lblEnd.Size = new System.Drawing.Size(55, 13);
			this.lblEnd.TabIndex = 6;
			this.lblEnd.Text = "End Date:";
			// 
			// dtpStart
			// 
			this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpStart.Location = new System.Drawing.Point(366, 151);
			this.dtpStart.MinDate = new System.DateTime(1980, 1, 1, 0, 0, 0, 0);
			this.dtpStart.Name = "dtpStart";
			this.dtpStart.Size = new System.Drawing.Size(82, 20);
			this.dtpStart.TabIndex = 7;
			this.dtpStart.Value = new System.DateTime(2015, 7, 8, 0, 0, 0, 0);
			// 
			// dtpEnd
			// 
			this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpEnd.Location = new System.Drawing.Point(366, 190);
			this.dtpEnd.MinDate = new System.DateTime(1980, 1, 1, 0, 0, 0, 0);
			this.dtpEnd.Name = "dtpEnd";
			this.dtpEnd.Size = new System.Drawing.Size(82, 20);
			this.dtpEnd.TabIndex = 8;
			this.dtpEnd.Value = new System.DateTime(2015, 7, 8, 0, 0, 0, 0);
			// 
			// lblDevices
			// 
			this.lblDevices.AutoSize = true;
			this.lblDevices.Location = new System.Drawing.Point(366, 9);
			this.lblDevices.Name = "lblDevices";
			this.lblDevices.Size = new System.Drawing.Size(49, 13);
			this.lblDevices.TabIndex = 9;
			this.lblDevices.Text = "Devices:";
			this.lblDevices.Visible = false;
			// 
			// lbxDevices
			// 
			this.lbxDevices.FormattingEnabled = true;
			this.lbxDevices.Location = new System.Drawing.Point(366, 25);
			this.lbxDevices.Name = "lbxDevices";
			this.lbxDevices.Size = new System.Drawing.Size(82, 108);
			this.lbxDevices.TabIndex = 10;
			this.lbxDevices.Visible = false;
			this.lbxDevices.SelectedIndexChanged += new System.EventHandler(this.LbxDevicesSelectedIndexChanged);
			// 
			// ReportsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(460, 262);
			this.Controls.Add(this.lbxDevices);
			this.Controls.Add(this.lblDevices);
			this.Controls.Add(this.dtpEnd);
			this.Controls.Add(this.dtpStart);
			this.Controls.Add(this.lblEnd);
			this.Controls.Add(this.lblStart);
			this.Controls.Add(this.btnCreate);
			this.Controls.Add(this.lbxReports);
			this.Controls.Add(this.lblReports);
			this.Controls.Add(this.lvClients);
			this.Controls.Add(this.lblClient);
			this.Name = "ReportsForm";
			this.Text = "ReportsForm";
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.SaveFileDialog sfdReport;
		private System.Windows.Forms.ListBox lbxDevices;
		private System.Windows.Forms.Label lblDevices;
		private System.Windows.Forms.DateTimePicker dtpEnd;
		private System.Windows.Forms.DateTimePicker dtpStart;
		private System.Windows.Forms.Label lblEnd;
		private System.Windows.Forms.Label lblStart;
		private System.Windows.Forms.Button btnCreate;
		private System.Windows.Forms.ListBox lbxReports;
		private System.Windows.Forms.Label lblReports;
		private System.Windows.Forms.ColumnHeader chName;
		private System.Windows.Forms.ColumnHeader chMTID;
		private System.Windows.Forms.ListView lvClients;
		private System.Windows.Forms.Label lblClient;
	}
}
