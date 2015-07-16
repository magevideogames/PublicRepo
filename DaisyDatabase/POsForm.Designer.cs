/*
 * Created by SharpDevelop.
 * User: Mage
 * Date: 6/24/2015
 * Time: 12:57 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace WIPDatabase
{
	partial class POsForm
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
			this.lblPOs = new System.Windows.Forms.Label();
			this.lbxPOs = new System.Windows.Forms.ListBox();
			this.lblPONum = new System.Windows.Forms.Label();
			this.tbxPO = new System.Windows.Forms.TextBox();
			this.lblOAmount = new System.Windows.Forms.Label();
			this.nudOmount = new System.Windows.Forms.NumericUpDown();
			this.btnAddPO = new System.Windows.Forms.Button();
			this.btnEditPO = new System.Windows.Forms.Button();
			this.lblTransactions = new System.Windows.Forms.Label();
			this.lbxTDates = new System.Windows.Forms.ListBox();
			this.lblTAmount = new System.Windows.Forms.Label();
			this.nudTAmount = new System.Windows.Forms.NumericUpDown();
			this.btnETransaction = new System.Windows.Forms.Button();
			this.btnATransaction = new System.Windows.Forms.Button();
			this.dtpTDate = new System.Windows.Forms.DateTimePicker();
			this.nudBalance = new System.Windows.Forms.NumericUpDown();
			this.lblBalance = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.nudOmount)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudTAmount)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudBalance)).BeginInit();
			this.SuspendLayout();
			// 
			// lblPOs
			// 
			this.lblPOs.AutoSize = true;
			this.lblPOs.Location = new System.Drawing.Point(10, 11);
			this.lblPOs.Name = "lblPOs";
			this.lblPOs.Size = new System.Drawing.Size(30, 13);
			this.lblPOs.TabIndex = 0;
			this.lblPOs.Text = "POs:";
			// 
			// lbxPOs
			// 
			this.lbxPOs.FormattingEnabled = true;
			this.lbxPOs.Location = new System.Drawing.Point(10, 27);
			this.lbxPOs.Name = "lbxPOs";
			this.lbxPOs.Size = new System.Drawing.Size(70, 251);
			this.lbxPOs.TabIndex = 1;
			this.lbxPOs.SelectedIndexChanged += new System.EventHandler(this.LbxPOsSelectedIndexChanged);
			// 
			// lblPONum
			// 
			this.lblPONum.AutoSize = true;
			this.lblPONum.Location = new System.Drawing.Point(86, 27);
			this.lblPONum.Name = "lblPONum";
			this.lblPONum.Size = new System.Drawing.Size(35, 13);
			this.lblPONum.TabIndex = 2;
			this.lblPONum.Text = "PO #:";
			// 
			// tbxPO
			// 
			this.tbxPO.Enabled = false;
			this.tbxPO.Location = new System.Drawing.Point(171, 25);
			this.tbxPO.Name = "tbxPO";
			this.tbxPO.Size = new System.Drawing.Size(100, 20);
			this.tbxPO.TabIndex = 3;
			// 
			// lblOAmount
			// 
			this.lblOAmount.AutoSize = true;
			this.lblOAmount.Location = new System.Drawing.Point(86, 53);
			this.lblOAmount.Name = "lblOAmount";
			this.lblOAmount.Size = new System.Drawing.Size(84, 13);
			this.lblOAmount.TabIndex = 4;
			this.lblOAmount.Text = "Original Amount:";
			// 
			// nudOmount
			// 
			this.nudOmount.Enabled = false;
			this.nudOmount.Location = new System.Drawing.Point(171, 51);
			this.nudOmount.Maximum = new decimal(new int[] {
									999999,
									0,
									0,
									0});
			this.nudOmount.Minimum = new decimal(new int[] {
									999999,
									0,
									0,
									-2147483648});
			this.nudOmount.Name = "nudOmount";
			this.nudOmount.Size = new System.Drawing.Size(100, 20);
			this.nudOmount.TabIndex = 5;
			this.nudOmount.Value = new decimal(new int[] {
									1,
									0,
									0,
									0});
			// 
			// btnAddPO
			// 
			this.btnAddPO.Location = new System.Drawing.Point(86, 255);
			this.btnAddPO.Name = "btnAddPO";
			this.btnAddPO.Size = new System.Drawing.Size(75, 23);
			this.btnAddPO.TabIndex = 6;
			this.btnAddPO.Text = "Add PO";
			this.btnAddPO.UseVisualStyleBackColor = true;
			this.btnAddPO.Click += new System.EventHandler(this.BtnAddPOClick);
			// 
			// btnEditPO
			// 
			this.btnEditPO.Enabled = false;
			this.btnEditPO.Location = new System.Drawing.Point(191, 255);
			this.btnEditPO.Name = "btnEditPO";
			this.btnEditPO.Size = new System.Drawing.Size(75, 23);
			this.btnEditPO.TabIndex = 7;
			this.btnEditPO.Text = "Edit PO";
			this.btnEditPO.UseVisualStyleBackColor = true;
			this.btnEditPO.Click += new System.EventHandler(this.BtnEditPOClick);
			// 
			// lblTransactions
			// 
			this.lblTransactions.AutoSize = true;
			this.lblTransactions.Location = new System.Drawing.Point(86, 113);
			this.lblTransactions.Name = "lblTransactions";
			this.lblTransactions.Size = new System.Drawing.Size(71, 13);
			this.lblTransactions.TabIndex = 8;
			this.lblTransactions.Text = "Transactions:";
			// 
			// lbxTDates
			// 
			this.lbxTDates.Enabled = false;
			this.lbxTDates.FormattingEnabled = true;
			this.lbxTDates.Location = new System.Drawing.Point(86, 129);
			this.lbxTDates.Name = "lbxTDates";
			this.lbxTDates.Size = new System.Drawing.Size(71, 121);
			this.lbxTDates.TabIndex = 9;
			this.lbxTDates.SelectedIndexChanged += new System.EventHandler(this.LbxTDatesSelectedIndexChanged);
			// 
			// lblTAmount
			// 
			this.lblTAmount.AutoSize = true;
			this.lblTAmount.Location = new System.Drawing.Point(209, 113);
			this.lblTAmount.Name = "lblTAmount";
			this.lblTAmount.Size = new System.Drawing.Size(46, 13);
			this.lblTAmount.TabIndex = 10;
			this.lblTAmount.Text = "Amount:";
			// 
			// nudTAmount
			// 
			this.nudTAmount.Enabled = false;
			this.nudTAmount.Location = new System.Drawing.Point(199, 129);
			this.nudTAmount.Maximum = new decimal(new int[] {
									999999,
									0,
									0,
									0});
			this.nudTAmount.Minimum = new decimal(new int[] {
									999999,
									0,
									0,
									-2147483648});
			this.nudTAmount.Name = "nudTAmount";
			this.nudTAmount.Size = new System.Drawing.Size(67, 20);
			this.nudTAmount.TabIndex = 11;
			// 
			// btnETransaction
			// 
			this.btnETransaction.Enabled = false;
			this.btnETransaction.Location = new System.Drawing.Point(191, 155);
			this.btnETransaction.Name = "btnETransaction";
			this.btnETransaction.Size = new System.Drawing.Size(75, 37);
			this.btnETransaction.TabIndex = 12;
			this.btnETransaction.Text = "Edit Transaction";
			this.btnETransaction.UseVisualStyleBackColor = true;
			this.btnETransaction.Click += new System.EventHandler(this.BtnETransactionClick);
			// 
			// btnATransaction
			// 
			this.btnATransaction.Location = new System.Drawing.Point(191, 198);
			this.btnATransaction.Name = "btnATransaction";
			this.btnATransaction.Size = new System.Drawing.Size(75, 34);
			this.btnATransaction.TabIndex = 13;
			this.btnATransaction.Text = "Add Transaction";
			this.btnATransaction.UseVisualStyleBackColor = true;
			this.btnATransaction.Click += new System.EventHandler(this.BtnATransactionClick);
			// 
			// dtpTDate
			// 
			this.dtpTDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpTDate.Location = new System.Drawing.Point(86, 129);
			this.dtpTDate.Name = "dtpTDate";
			this.dtpTDate.Size = new System.Drawing.Size(78, 20);
			this.dtpTDate.TabIndex = 14;
			this.dtpTDate.Visible = false;
			// 
			// nudBalance
			// 
			this.nudBalance.Enabled = false;
			this.nudBalance.Location = new System.Drawing.Point(171, 77);
			this.nudBalance.Maximum = new decimal(new int[] {
									999999,
									0,
									0,
									0});
			this.nudBalance.Minimum = new decimal(new int[] {
									999999,
									0,
									0,
									-2147483648});
			this.nudBalance.Name = "nudBalance";
			this.nudBalance.Size = new System.Drawing.Size(100, 20);
			this.nudBalance.TabIndex = 16;
			this.nudBalance.Value = new decimal(new int[] {
									1,
									0,
									0,
									0});
			// 
			// lblBalance
			// 
			this.lblBalance.AutoSize = true;
			this.lblBalance.Location = new System.Drawing.Point(86, 79);
			this.lblBalance.Name = "lblBalance";
			this.lblBalance.Size = new System.Drawing.Size(49, 13);
			this.lblBalance.TabIndex = 15;
			this.lblBalance.Text = "Balance:";
			// 
			// POsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(280, 284);
			this.Controls.Add(this.nudBalance);
			this.Controls.Add(this.lblBalance);
			this.Controls.Add(this.dtpTDate);
			this.Controls.Add(this.btnATransaction);
			this.Controls.Add(this.btnETransaction);
			this.Controls.Add(this.nudTAmount);
			this.Controls.Add(this.lblTAmount);
			this.Controls.Add(this.lbxTDates);
			this.Controls.Add(this.lblTransactions);
			this.Controls.Add(this.btnEditPO);
			this.Controls.Add(this.btnAddPO);
			this.Controls.Add(this.nudOmount);
			this.Controls.Add(this.lblOAmount);
			this.Controls.Add(this.tbxPO);
			this.Controls.Add(this.lblPONum);
			this.Controls.Add(this.lbxPOs);
			this.Controls.Add(this.lblPOs);
			this.Name = "POsForm";
			this.Text = "POsForm";
			((System.ComponentModel.ISupportInitialize)(this.nudOmount)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudTAmount)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudBalance)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Label lblBalance;
		private System.Windows.Forms.NumericUpDown nudBalance;
		private System.Windows.Forms.DateTimePicker dtpTDate;
		private System.Windows.Forms.Button btnATransaction;
		private System.Windows.Forms.Button btnETransaction;
		private System.Windows.Forms.NumericUpDown nudTAmount;
		private System.Windows.Forms.Label lblTAmount;
		private System.Windows.Forms.ListBox lbxTDates;
		private System.Windows.Forms.Label lblTransactions;
		private System.Windows.Forms.Button btnEditPO;
		private System.Windows.Forms.Button btnAddPO;
		private System.Windows.Forms.NumericUpDown nudOmount;
		private System.Windows.Forms.Label lblOAmount;
		private System.Windows.Forms.TextBox tbxPO;
		private System.Windows.Forms.Label lblPONum;
		private System.Windows.Forms.ListBox lbxPOs;
		private System.Windows.Forms.Label lblPOs;
	}
}
