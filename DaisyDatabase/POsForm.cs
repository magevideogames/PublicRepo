/*
 * Created by SharpDevelop.
 * User: Mage
 * Date: 6/24/2015
 * Time: 12:57 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace WIPDatabase
{
	/// <summary>
	/// Description of POsForm.
	/// </summary>
	public partial class POsForm : Form
	{
		int clientID;
		List<PO> pos = new List<PO>();
		public POsForm(int theID)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			clientID = theID;
			LoadPOs();
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void LoadPOs()
		{
			pos = Model.GetPOs(clientID);
			pos.Sort(delegate(PO x, PO y)
			         {
			         	return x.PONumber.CompareTo(y.PONumber);
			         });
			lbxPOs.Items.Clear();
			for (int i = 0; i<pos.Count; i++)
			{
				lbxPOs.Items.Add(pos[i].PONumber);
				pos[i].Transactions.Sort(delegate(POTransaction x, POTransaction y)
				                         {
				                         	return x.Date.CompareTo(y.Date);
				                         });
			}
		}
		
		void BtnEditPOClick(object sender, EventArgs e)
		{
			if(btnEditPO.Text == "Edit PO")
			{
				btnEditPO.Text = "Save PO";
				btnAddPO.Enabled = false;
				Enabler(true);
			}
			else
			{
				btnEditPO.Text = "Edit PO";
				btnAddPO.Enabled = true;
				PO thePO = new PO();
				thePO.Amount = nudOmount.Value;
				thePO.PONumber = tbxPO.Text;
				thePO.ID = pos[lbxPOs.SelectedIndex].ID;
				if(Model.UpdatePO(thePO))
				{
					LoadPOs();
				}
				else
				{
					MessageBox.Show("Unable to update PO");
				}
				Enabler(false);
				
			}
		}
		
		void BtnAddPOClick(object sender, EventArgs e)
		{
			if(btnAddPO.Text == "Add PO")
			{
				btnAddPO.Text = "Save PO";
				btnEditPO.Enabled = false;
				Enabler(true);
			}
			else
			{
				PO thePO = new PO();
				thePO.PONumber = tbxPO.Text;
				thePO.Amount = nudOmount.Value;
				thePO.ClientID = clientID;
				if(Model.AddPO(thePO))
				{
					LoadPOs();
					lbxPOs.SelectedIndex =0;
				}
				else
				{
					MessageBox.Show("Unable to add the PO");
				}
				btnAddPO.Text = "Add PO";
				Enabler(false);
			}
		}
		
		void UpdatePOBalance()
		{
			decimal balance = pos[lbxPOs.SelectedIndex].Amount;
			foreach (var transaction  in pos[lbxPOs.SelectedIndex].Transactions)
			{
				balance -= transaction.Amount;
			}
			nudBalance.Value = balance;
		}
		
		void UpdateTransactionsList()
		{
			lbxTDates.Enabled = true;
			lbxTDates.Items.Clear();
			foreach(POTransaction theTrasaction in pos[lbxPOs.SelectedIndex].Transactions)
			{
				lbxTDates.Items.Add(theTrasaction.Date.ToShortDateString());
			}
			lbxTDates.SelectedIndex = 0;
		}
		
		void LbxPOsSelectedIndexChanged(object sender, EventArgs e)
		{
			if(lbxPOs.SelectedIndex != -1)
			{
				btnEditPO.Enabled = true;
				tbxPO.Text = pos[lbxPOs.SelectedIndex].PONumber;
				nudOmount.Value = pos[lbxPOs.SelectedIndex].Amount;
				UpdatePOBalance();
				UpdateTransactionsList();
			}
			else
			{
				btnEditPO.Enabled = false;
				lbxTDates.Enabled = false;
			}
		}
		
		void Enabler(bool setting)
		{
			tbxPO.Enabled = setting;
			nudOmount.Enabled = setting;
		}
		
		void LbxTDatesSelectedIndexChanged(object sender, EventArgs e)
		{
			if(lbxTDates.SelectedIndex != -1)
			{
				nudTAmount.Value = pos[lbxPOs.SelectedIndex].Transactions[lbxTDates.SelectedIndex].Amount;
				btnETransaction.Enabled = true;
			}
			else
			{
				btnETransaction.Enabled = false;
			}
		}
		
		void BtnETransactionClick(object sender, EventArgs e)
		{
			if(btnETransaction.Text == "Edit Transaction")
			{
				lbxTDates.Visible = false;
				btnATransaction.Text = "Cancel";
				dtpTDate.Visible = true;
				nudTAmount.Enabled = true;
				btnETransaction.Text = "Save";
				lblTransactions.Text = "Date";
				nudOmount.Enabled = true;
			}
			else if(btnETransaction.Text == "Save")
			{
				pos[lbxPOs.SelectedIndex].Transactions[lbxTDates.SelectedIndex].Date = dtpTDate.Value;
				pos[lbxPOs.SelectedIndex].Transactions[lbxTDates.SelectedIndex].Amount = nudTAmount.Value;
				if(!Model.UpdatePOTransaction(pos[lbxPOs.SelectedIndex].Transactions[lbxTDates.SelectedIndex]))
				{
					MessageBox.Show("Unable to update PO");
				}
				dtpTDate.Visible = false;
				nudTAmount.Enabled = false;				
				lblTransactions.Text = "Transactions";
				btnETransaction.Text = "Edit Transaction";
				btnATransaction.Text = "Add Transaction";
				lbxTDates.Visible = true;
				UpdateTransactionsList();
				UpdatePOBalance();
			}
			else
			{
				dtpTDate.Visible = false;
				btnATransaction.Text = "Add Transaction";
				lblTransactions.Text = "Transactions";
				btnETransaction.Text = "Edit Transaction";
				nudTAmount.Enabled = false;
				lbxTDates.Visible = true;
				btnETransaction.Enabled = false;
				
			}
		}
		
		void BtnATransactionClick(object sender, EventArgs e)
		{
			if(btnATransaction.Text == "Add Transaction")
			{
				btnETransaction.Enabled = true;
				dtpTDate.Visible = true;
				lbxTDates.Visible = false;
				btnETransaction.Text = "Cancel";
				btnATransaction.Text = "Save";
				lblTransactions.Text = "Date";
				nudTAmount.Enabled = true;
			}
			else if(btnATransaction.Text == "Save")
			{
				dtpTDate.Visible = false;
				btnATransaction.Text = "Add Transaction";
				lblTransactions.Text = "Transactions";
				btnETransaction.Text = "Edit Transaction";
				nudTAmount.Enabled = false;
				lbxTDates.Visible = true;
				POTransaction theTrasaction = new POTransaction();
				theTrasaction.Amount = nudTAmount.Value;
				theTrasaction.Date = dtpTDate.Value;
				theTrasaction.POID = pos[lbxPOs.SelectedIndex].ID;
				pos[lbxPOs.SelectedIndex].Transactions.Add(theTrasaction);
				if(!Model.AddPOTransaction(theTrasaction))
				{
					MessageBox.Show("Unable to add PO Transaction");
				}
				UpdateTransactionsList();
				UpdatePOBalance();
			}
			else
			{
				dtpTDate.Visible = false;
				btnATransaction.Text = "Add Transaction";
				lblTransactions.Text = "Transactions";
				btnETransaction.Text = "Edit Transaction";
				nudTAmount.Enabled = false;
				lbxTDates.Visible = true;
			}
		}
	}
}
