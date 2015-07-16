/*
 * Created by SharpDevelop.
 * User: Mage
 * Date: 6/10/2015
 * Time: 12:43 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace WIPDatabase
{
	partial class ClientsForm
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
			this.lblClients = new System.Windows.Forms.Label();
			this.lbxClients = new System.Windows.Forms.ListBox();
			this.btnAdd = new System.Windows.Forms.Button();
			this.btnView = new System.Windows.Forms.Button();
			this.ofdFile = new System.Windows.Forms.OpenFileDialog();
			this.lblLoading = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// lblClients
			// 
			this.lblClients.AutoSize = true;
			this.lblClients.Location = new System.Drawing.Point(13, 13);
			this.lblClients.Name = "lblClients";
			this.lblClients.Size = new System.Drawing.Size(41, 13);
			this.lblClients.TabIndex = 0;
			this.lblClients.Text = "Clients:";
			// 
			// lbxClients
			// 
			this.lbxClients.FormattingEnabled = true;
			this.lbxClients.Location = new System.Drawing.Point(61, 13);
			this.lbxClients.Name = "lbxClients";
			this.lbxClients.Size = new System.Drawing.Size(200, 238);
			this.lbxClients.TabIndex = 1;
			this.lbxClients.SelectedIndexChanged += new System.EventHandler(this.LbxClientsSelectedIndexChanged);
			this.lbxClients.DoubleClick += new System.EventHandler(this.LbxClientsDoubleClick);
			// 
			// btnAdd
			// 
			this.btnAdd.AutoSize = true;
			this.btnAdd.Location = new System.Drawing.Point(268, 13);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(75, 23);
			this.btnAdd.TabIndex = 2;
			this.btnAdd.Text = "Add Client";
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += new System.EventHandler(this.BtnAddClick);
			// 
			// btnView
			// 
			this.btnView.AutoSize = true;
			this.btnView.Enabled = false;
			this.btnView.Location = new System.Drawing.Point(267, 42);
			this.btnView.Name = "btnView";
			this.btnView.Size = new System.Drawing.Size(75, 23);
			this.btnView.TabIndex = 4;
			this.btnView.Text = "View Details";
			this.btnView.UseVisualStyleBackColor = true;
			this.btnView.Click += new System.EventHandler(this.BtnViewClick);
			// 
			// ofdFile
			// 
			this.ofdFile.FileName = "openFileDialog1";
			// 
			// lblLoading
			// 
			this.lblLoading.Location = new System.Drawing.Point(268, 87);
			this.lblLoading.Name = "lblLoading";
			this.lblLoading.Size = new System.Drawing.Size(83, 31);
			this.lblLoading.TabIndex = 5;
			this.lblLoading.Text = "Loading Clients. Please Wait.";
			this.lblLoading.Visible = false;
			// 
			// ClientsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(355, 262);
			this.Controls.Add(this.lblLoading);
			this.Controls.Add(this.btnView);
			this.Controls.Add(this.btnAdd);
			this.Controls.Add(this.lbxClients);
			this.Controls.Add(this.lblClients);
			this.Name = "ClientsForm";
			this.Text = "ClientsForm";
			this.Load += new System.EventHandler(this.ClientsFormLoad);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Label lblLoading;
		private System.Windows.Forms.OpenFileDialog ofdFile;
		private System.Windows.Forms.Button btnView;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.ListBox lbxClients;
		private System.Windows.Forms.Label lblClients;
	}
}
