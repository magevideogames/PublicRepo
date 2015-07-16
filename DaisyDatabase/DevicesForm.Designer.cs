/*
 * Created by SharpDevelop.
 * User: Mage
 * Date: 6/23/2015
 * Time: 12:47 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace WIPDatabase
{
	partial class DevicesForm
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
			this.lblDevices = new System.Windows.Forms.Label();
			this.lvDevices = new System.Windows.Forms.ListView();
			this.chAssetID = new System.Windows.Forms.ColumnHeader();
			this.chName = new System.Windows.Forms.ColumnHeader();
			this.btnAdd = new System.Windows.Forms.Button();
			this.cbxOEM = new System.Windows.Forms.CheckBox();
			this.cbxType = new System.Windows.Forms.CheckBox();
			this.cbxNetworked = new System.Windows.Forms.CheckBox();
			this.lblSite = new System.Windows.Forms.Label();
			this.tbxSite = new System.Windows.Forms.TextBox();
			this.tbxSerial = new System.Windows.Forms.TextBox();
			this.lblSerial = new System.Windows.Forms.Label();
			this.tbxAssetID = new System.Windows.Forms.TextBox();
			this.lblAssetID = new System.Windows.Forms.Label();
			this.nudCPages = new System.Windows.Forms.NumericUpDown();
			this.lblCPages = new System.Windows.Forms.Label();
			this.nudMPages = new System.Windows.Forms.NumericUpDown();
			this.lblMPages = new System.Windows.Forms.Label();
			this.nudLCStart = new System.Windows.Forms.NumericUpDown();
			this.lblLCStart = new System.Windows.Forms.Label();
			this.nudLCEnd = new System.Windows.Forms.NumericUpDown();
			this.lblLCEnd = new System.Windows.Forms.Label();
			this.lblLActive = new System.Windows.Forms.Label();
			this.dtpLActive = new System.Windows.Forms.DateTimePicker();
			this.tbxDepartment = new System.Windows.Forms.TextBox();
			this.lblDepartment = new System.Windows.Forms.Label();
			this.btnEdit = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.lblName = new System.Windows.Forms.Label();
			this.tbxName = new System.Windows.Forms.TextBox();
			this.lblNote = new System.Windows.Forms.Label();
			this.tbxNote = new System.Windows.Forms.TextBox();
			this.ofdDevices = new System.Windows.Forms.OpenFileDialog();
			this.lblLoading = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.nudCPages)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudMPages)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudLCStart)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudLCEnd)).BeginInit();
			this.SuspendLayout();
			// 
			// lblDevices
			// 
			this.lblDevices.AutoSize = true;
			this.lblDevices.Location = new System.Drawing.Point(12, 9);
			this.lblDevices.Name = "lblDevices";
			this.lblDevices.Size = new System.Drawing.Size(49, 13);
			this.lblDevices.TabIndex = 0;
			this.lblDevices.Text = "Devices:";
			// 
			// lvDevices
			// 
			this.lvDevices.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.chAssetID,
									this.chName});
			this.lvDevices.Location = new System.Drawing.Point(12, 25);
			this.lvDevices.MultiSelect = false;
			this.lvDevices.Name = "lvDevices";
			this.lvDevices.Size = new System.Drawing.Size(160, 225);
			this.lvDevices.TabIndex = 1;
			this.lvDevices.UseCompatibleStateImageBehavior = false;
			this.lvDevices.View = System.Windows.Forms.View.Details;
			this.lvDevices.SelectedIndexChanged += new System.EventHandler(this.LvDevicesSelectedIndexChanged);
			// 
			// chAssetID
			// 
			this.chAssetID.Text = "Asset ID";
			this.chAssetID.Width = 52;
			// 
			// chName
			// 
			this.chName.Text = "Name";
			this.chName.Width = 104;
			// 
			// btnAdd
			// 
			this.btnAdd.Location = new System.Drawing.Point(435, 227);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(75, 23);
			this.btnAdd.TabIndex = 2;
			this.btnAdd.Text = "Add";
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += new System.EventHandler(this.BtnAddClick);
			// 
			// cbxOEM
			// 
			this.cbxOEM.AutoSize = true;
			this.cbxOEM.Enabled = false;
			this.cbxOEM.Location = new System.Drawing.Point(178, 26);
			this.cbxOEM.Name = "cbxOEM";
			this.cbxOEM.Size = new System.Drawing.Size(67, 17);
			this.cbxOEM.TabIndex = 5;
			this.cbxOEM.Text = "Is OEM?";
			this.cbxOEM.UseVisualStyleBackColor = true;
			// 
			// cbxType
			// 
			this.cbxType.AutoSize = true;
			this.cbxType.Enabled = false;
			this.cbxType.Location = new System.Drawing.Point(178, 47);
			this.cbxType.Name = "cbxType";
			this.cbxType.Size = new System.Drawing.Size(67, 17);
			this.cbxType.TabIndex = 6;
			this.cbxType.Text = "Is Color?";
			this.cbxType.UseVisualStyleBackColor = true;
			// 
			// cbxNetworked
			// 
			this.cbxNetworked.AutoSize = true;
			this.cbxNetworked.Enabled = false;
			this.cbxNetworked.Location = new System.Drawing.Point(178, 72);
			this.cbxNetworked.Name = "cbxNetworked";
			this.cbxNetworked.Size = new System.Drawing.Size(95, 17);
			this.cbxNetworked.TabIndex = 7;
			this.cbxNetworked.Text = "Is Networked?";
			this.cbxNetworked.UseVisualStyleBackColor = true;
			// 
			// lblSite
			// 
			this.lblSite.AutoSize = true;
			this.lblSite.Location = new System.Drawing.Point(178, 92);
			this.lblSite.Name = "lblSite";
			this.lblSite.Size = new System.Drawing.Size(28, 13);
			this.lblSite.TabIndex = 8;
			this.lblSite.Text = "Site:";
			// 
			// tbxSite
			// 
			this.tbxSite.Enabled = false;
			this.tbxSite.Location = new System.Drawing.Point(249, 89);
			this.tbxSite.Name = "tbxSite";
			this.tbxSite.Size = new System.Drawing.Size(100, 20);
			this.tbxSite.TabIndex = 9;
			// 
			// tbxSerial
			// 
			this.tbxSerial.Enabled = false;
			this.tbxSerial.Location = new System.Drawing.Point(394, 164);
			this.tbxSerial.Name = "tbxSerial";
			this.tbxSerial.Size = new System.Drawing.Size(118, 20);
			this.tbxSerial.TabIndex = 11;
			// 
			// lblSerial
			// 
			this.lblSerial.AutoSize = true;
			this.lblSerial.Location = new System.Drawing.Point(352, 167);
			this.lblSerial.Name = "lblSerial";
			this.lblSerial.Size = new System.Drawing.Size(36, 13);
			this.lblSerial.TabIndex = 10;
			this.lblSerial.Text = "Serial:";
			// 
			// tbxAssetID
			// 
			this.tbxAssetID.Enabled = false;
			this.tbxAssetID.Location = new System.Drawing.Point(249, 141);
			this.tbxAssetID.Name = "tbxAssetID";
			this.tbxAssetID.Size = new System.Drawing.Size(100, 20);
			this.tbxAssetID.TabIndex = 13;
			// 
			// lblAssetID
			// 
			this.lblAssetID.AutoSize = true;
			this.lblAssetID.Location = new System.Drawing.Point(178, 144);
			this.lblAssetID.Name = "lblAssetID";
			this.lblAssetID.Size = new System.Drawing.Size(50, 13);
			this.lblAssetID.TabIndex = 12;
			this.lblAssetID.Text = "Asset ID:";
			// 
			// nudCPages
			// 
			this.nudCPages.Enabled = false;
			this.nudCPages.Location = new System.Drawing.Point(441, 23);
			this.nudCPages.Maximum = new decimal(new int[] {
									999999,
									0,
									0,
									0});
			this.nudCPages.Name = "nudCPages";
			this.nudCPages.Size = new System.Drawing.Size(71, 20);
			this.nudCPages.TabIndex = 15;
			this.nudCPages.Value = new decimal(new int[] {
									1111,
									0,
									0,
									0});
			// 
			// lblCPages
			// 
			this.lblCPages.AutoSize = true;
			this.lblCPages.Location = new System.Drawing.Point(352, 25);
			this.lblCPages.Name = "lblCPages";
			this.lblCPages.Size = new System.Drawing.Size(67, 13);
			this.lblCPages.TabIndex = 14;
			this.lblCPages.Text = "Color Pages:";
			// 
			// nudMPages
			// 
			this.nudMPages.Enabled = false;
			this.nudMPages.Location = new System.Drawing.Point(441, 49);
			this.nudMPages.Maximum = new decimal(new int[] {
									999999,
									0,
									0,
									0});
			this.nudMPages.Name = "nudMPages";
			this.nudMPages.Size = new System.Drawing.Size(71, 20);
			this.nudMPages.TabIndex = 17;
			this.nudMPages.Value = new decimal(new int[] {
									1111,
									0,
									0,
									0});
			// 
			// lblMPages
			// 
			this.lblMPages.AutoSize = true;
			this.lblMPages.Location = new System.Drawing.Point(352, 51);
			this.lblMPages.Name = "lblMPages";
			this.lblMPages.Size = new System.Drawing.Size(70, 13);
			this.lblMPages.TabIndex = 16;
			this.lblMPages.Text = "Mono Pages:";
			// 
			// nudLCStart
			// 
			this.nudLCStart.Enabled = false;
			this.nudLCStart.Location = new System.Drawing.Point(441, 89);
			this.nudLCStart.Maximum = new decimal(new int[] {
									999999,
									0,
									0,
									0});
			this.nudLCStart.Name = "nudLCStart";
			this.nudLCStart.Size = new System.Drawing.Size(71, 20);
			this.nudLCStart.TabIndex = 19;
			this.nudLCStart.Value = new decimal(new int[] {
									1111,
									0,
									0,
									0});
			// 
			// lblLCStart
			// 
			this.lblLCStart.AutoSize = true;
			this.lblLCStart.Location = new System.Drawing.Point(352, 91);
			this.lblLCStart.Name = "lblLCStart";
			this.lblLCStart.Size = new System.Drawing.Size(83, 13);
			this.lblLCStart.TabIndex = 18;
			this.lblLCStart.Text = "Life Count Start:";
			// 
			// nudLCEnd
			// 
			this.nudLCEnd.Enabled = false;
			this.nudLCEnd.Location = new System.Drawing.Point(441, 115);
			this.nudLCEnd.Maximum = new decimal(new int[] {
									999999,
									0,
									0,
									0});
			this.nudLCEnd.Minimum = new decimal(new int[] {
									1,
									0,
									0,
									0});
			this.nudLCEnd.Name = "nudLCEnd";
			this.nudLCEnd.Size = new System.Drawing.Size(71, 20);
			this.nudLCEnd.TabIndex = 21;
			this.nudLCEnd.Value = new decimal(new int[] {
									1111,
									0,
									0,
									0});
			// 
			// lblLCEnd
			// 
			this.lblLCEnd.AutoSize = true;
			this.lblLCEnd.Location = new System.Drawing.Point(352, 118);
			this.lblLCEnd.Name = "lblLCEnd";
			this.lblLCEnd.Size = new System.Drawing.Size(80, 13);
			this.lblLCEnd.TabIndex = 20;
			this.lblLCEnd.Text = "Life Count End:";
			// 
			// lblLActive
			// 
			this.lblLActive.AutoSize = true;
			this.lblLActive.Location = new System.Drawing.Point(352, 144);
			this.lblLActive.Name = "lblLActive";
			this.lblLActive.Size = new System.Drawing.Size(63, 13);
			this.lblLActive.TabIndex = 22;
			this.lblLActive.Text = "Last Active:";
			// 
			// dtpLActive
			// 
			this.dtpLActive.Enabled = false;
			this.dtpLActive.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpLActive.Location = new System.Drawing.Point(425, 141);
			this.dtpLActive.MinDate = new System.DateTime(1980, 1, 1, 0, 0, 0, 0);
			this.dtpLActive.Name = "dtpLActive";
			this.dtpLActive.Size = new System.Drawing.Size(87, 20);
			this.dtpLActive.TabIndex = 23;
			// 
			// tbxDepartment
			// 
			this.tbxDepartment.Enabled = false;
			this.tbxDepartment.Location = new System.Drawing.Point(249, 115);
			this.tbxDepartment.Name = "tbxDepartment";
			this.tbxDepartment.Size = new System.Drawing.Size(100, 20);
			this.tbxDepartment.TabIndex = 25;
			// 
			// lblDepartment
			// 
			this.lblDepartment.AutoSize = true;
			this.lblDepartment.Location = new System.Drawing.Point(178, 118);
			this.lblDepartment.Name = "lblDepartment";
			this.lblDepartment.Size = new System.Drawing.Size(65, 13);
			this.lblDepartment.TabIndex = 24;
			this.lblDepartment.Text = "Department:";
			// 
			// btnEdit
			// 
			this.btnEdit.AutoSize = true;
			this.btnEdit.Enabled = false;
			this.btnEdit.Location = new System.Drawing.Point(178, 227);
			this.btnEdit.Name = "btnEdit";
			this.btnEdit.Size = new System.Drawing.Size(75, 23);
			this.btnEdit.TabIndex = 26;
			this.btnEdit.Text = "Edit";
			this.btnEdit.UseVisualStyleBackColor = true;
			this.btnEdit.Click += new System.EventHandler(this.BtnEditClick);
			// 
			// btnCancel
			// 
			this.btnCancel.AutoSize = true;
			this.btnCancel.Location = new System.Drawing.Point(259, 227);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 27;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Visible = false;
			this.btnCancel.Click += new System.EventHandler(this.BtnCancelClick);
			// 
			// lblName
			// 
			this.lblName.AutoSize = true;
			this.lblName.Location = new System.Drawing.Point(178, 167);
			this.lblName.Name = "lblName";
			this.lblName.Size = new System.Drawing.Size(38, 13);
			this.lblName.TabIndex = 28;
			this.lblName.Text = "Name:";
			// 
			// tbxName
			// 
			this.tbxName.Enabled = false;
			this.tbxName.Location = new System.Drawing.Point(249, 164);
			this.tbxName.Name = "tbxName";
			this.tbxName.Size = new System.Drawing.Size(100, 20);
			this.tbxName.TabIndex = 29;
			// 
			// lblNote
			// 
			this.lblNote.AutoSize = true;
			this.lblNote.Location = new System.Drawing.Point(178, 193);
			this.lblNote.Name = "lblNote";
			this.lblNote.Size = new System.Drawing.Size(33, 13);
			this.lblNote.TabIndex = 30;
			this.lblNote.Text = "Note:";
			this.lblNote.Visible = false;
			// 
			// tbxNote
			// 
			this.tbxNote.Enabled = false;
			this.tbxNote.Location = new System.Drawing.Point(251, 190);
			this.tbxNote.Name = "tbxNote";
			this.tbxNote.Size = new System.Drawing.Size(261, 20);
			this.tbxNote.TabIndex = 31;
			this.tbxNote.Visible = false;
			// 
			// ofdDevices
			// 
			this.ofdDevices.FileName = "openFileDialog1";
			// 
			// lblLoading
			// 
			this.lblLoading.BackColor = System.Drawing.SystemColors.Control;
			this.lblLoading.Location = new System.Drawing.Point(339, 216);
			this.lblLoading.Name = "lblLoading";
			this.lblLoading.Size = new System.Drawing.Size(92, 37);
			this.lblLoading.TabIndex = 32;
			this.lblLoading.Text = "Loading Devices. Please Wait.";
			this.lblLoading.Visible = false;
			// 
			// DevicesForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(522, 262);
			this.Controls.Add(this.lblLoading);
			this.Controls.Add(this.tbxNote);
			this.Controls.Add(this.lblNote);
			this.Controls.Add(this.tbxName);
			this.Controls.Add(this.lblName);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnEdit);
			this.Controls.Add(this.tbxDepartment);
			this.Controls.Add(this.lblDepartment);
			this.Controls.Add(this.dtpLActive);
			this.Controls.Add(this.lblLActive);
			this.Controls.Add(this.nudLCEnd);
			this.Controls.Add(this.lblLCEnd);
			this.Controls.Add(this.nudLCStart);
			this.Controls.Add(this.lblLCStart);
			this.Controls.Add(this.nudMPages);
			this.Controls.Add(this.lblMPages);
			this.Controls.Add(this.nudCPages);
			this.Controls.Add(this.lblCPages);
			this.Controls.Add(this.tbxAssetID);
			this.Controls.Add(this.lblAssetID);
			this.Controls.Add(this.tbxSerial);
			this.Controls.Add(this.lblSerial);
			this.Controls.Add(this.tbxSite);
			this.Controls.Add(this.lblSite);
			this.Controls.Add(this.cbxNetworked);
			this.Controls.Add(this.cbxType);
			this.Controls.Add(this.cbxOEM);
			this.Controls.Add(this.btnAdd);
			this.Controls.Add(this.lvDevices);
			this.Controls.Add(this.lblDevices);
			this.Enabled = false;
			this.Name = "DevicesForm";
			this.Text = "DevicesForm";
			((System.ComponentModel.ISupportInitialize)(this.nudCPages)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudMPages)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudLCStart)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudLCEnd)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Label lblLoading;
		private System.Windows.Forms.OpenFileDialog ofdDevices;
		private System.Windows.Forms.TextBox tbxNote;
		private System.Windows.Forms.Label lblNote;
		private System.Windows.Forms.TextBox tbxName;
		private System.Windows.Forms.Label lblName;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnEdit;
		private System.Windows.Forms.Label lblDepartment;
		private System.Windows.Forms.TextBox tbxDepartment;
		private System.Windows.Forms.DateTimePicker dtpLActive;
		private System.Windows.Forms.Label lblLActive;
		private System.Windows.Forms.Label lblLCEnd;
		private System.Windows.Forms.NumericUpDown nudLCEnd;
		private System.Windows.Forms.Label lblLCStart;
		private System.Windows.Forms.NumericUpDown nudLCStart;
		private System.Windows.Forms.Label lblMPages;
		private System.Windows.Forms.NumericUpDown nudMPages;
		private System.Windows.Forms.Label lblCPages;
		private System.Windows.Forms.NumericUpDown nudCPages;
		private System.Windows.Forms.Label lblAssetID;
		private System.Windows.Forms.TextBox tbxAssetID;
		private System.Windows.Forms.Label lblSerial;
		private System.Windows.Forms.TextBox tbxSerial;
		private System.Windows.Forms.TextBox tbxSite;
		private System.Windows.Forms.Label lblSite;
		private System.Windows.Forms.CheckBox cbxNetworked;
		private System.Windows.Forms.CheckBox cbxType;
		private System.Windows.Forms.CheckBox cbxOEM;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.ColumnHeader chName;
		private System.Windows.Forms.ColumnHeader chAssetID;
		private System.Windows.Forms.ListView lvDevices;
		private System.Windows.Forms.Label lblDevices;
	}
}
