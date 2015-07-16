/*
 * Created by SharpDevelop.
 * User: Mage
 * Date: 6/18/2015
 * Time: 4:17 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;
using Microsoft.Office.Interop.Excel;

namespace WIPDatabase
{
	/// <summary>
	/// Description of InvoiceDetails.
	/// </summary>
	public partial class InvoiceDetails : Form
	{
		int clientID;
		int clientMTID;
		List<Invoice> invoices;
		List<PO> pos;
		public InvoiceDetails(int tempID, int tempMTID)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			clientID = tempID;
			clientMTID = tempMTID;
			ofdInvoice.Filter = "Excel Files (.xls,.cvs,.xlsx)|*.xls;*.cvs;*.xlsx";
			LoadInvoices();
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void Enabler(bool setting)
		{
			nudAmount.Enabled = setting;
			nudInvoice.Enabled = setting;
			dtpDate.Enabled = setting;
			cbxPOs.Enabled = setting;
		}
		
		void BtnEditClick(object sender, EventArgs e)
		{
			if(btnEdit.Text == "Edit")
			{
				btnEdit.Text = "Save";
				btnDevices.Text = "Cancel";
				Enabler(true);
			}
			else
			{
				lblLoading.Text = "Updating Invoice. Please Wait.";
				lblLoading.Visible = true;
				btnEdit.Text = "Edit";
				btnDevices.Text = "Devices";
				Invoice theInvoice = invoices[lvInvoices.SelectedIndices[0]];
				theInvoice.Amount = nudAmount.Value;
				theInvoice.ClientID = clientID;
				theInvoice.Date = dtpDate.Value;
				theInvoice.MacsTracID = int.Parse(nudInvoice.Value.ToString());
				if(cbxPOs.Text != "None")
				{
					theInvoice.PONumber = cbxPOs.SelectedItem.ToString();
				}
				if (Model.UpdateInvoice(theInvoice))
				{
					invoices[lvInvoices.SelectedIndices[0]] = theInvoice;
				}
				else
				{
					MessageBox.Show("Unable to update invoice");
				}
				lblLoading.Visible = false;
				Enabler(false);
			}
		}
		
		void BtnDevicesClick(object sender, EventArgs e)
		{
			if(btnDevices.Text == "Devices")
			{
				DevicesForm dfForm = new DevicesForm(invoices[lvInvoices.SelectedIndices[0]].ID,true);
				dfForm.Enabled = true;
				dfForm.ShowDialog();
			}
			else
			{
				btnDevices.Text = "Devices";
				btnEdit.Text = "Edit";
				Enabler(false);
			}
		}
		
		void BtnAddClick(object sender, EventArgs e)
		{
			if(btnAdd.Text == "Add")
			{
				Enabler(true);
				btnAdd.Text = "Save";
				btnCancel.Visible = true;
				if(pos.Count>0)
				{
					cbxPOs.SelectedIndex = 0;
				}
			}
			else
			{
				btnCancel.Visible = false;
				lblLoading.Text = "Adding Invoice. Please Wait.";
				lblLoading.Visible = true;
				Enabler(false);
				btnAdd.Text = "Add";
				Invoice theInvoice = new Invoice();
				theInvoice.MacsTracID = int.Parse(nudInvoice.Value.ToString());
				theInvoice.Amount = nudAmount.Value;
				if(cbxPOs.SelectedIndex >= 0)
				{
					theInvoice.PONumber = cbxPOs.SelectedItem.ToString();
				}
				theInvoice.Date = dtpDate.Value;
				theInvoice.ClientID = clientID;
				Model.AddInvoice(theInvoice);
				LoadInvoices();
				lblLoading.Visible = false;
			}
		}
		
		void LoadInvoices()
		{
			invoices = Model.GetInvoices(clientID);
			invoices.Sort(delegate(Invoice x, Invoice y)
			              {
			              	return x.MacsTracID.CompareTo(y.MacsTracID);
			              });
			btnEdit.Enabled = false;
			lvInvoices.Items.Clear();
			foreach (Invoice theInvoice in invoices)
			{
				lvInvoices.Items.Add(theInvoice.MacsTracID.ToString());
			}
			LoadPOs();
		}
		
		void LoadPOs()
		{
			pos = Model.GetPOs(clientID);
			pos.Sort(delegate(PO x, PO y)
			         {
			         	return x.PONumber.CompareTo(y.PONumber);
			         });
			cbxPOs.Items.Clear();
			cbxPOs.Items.Add("None");
			foreach (PO thePO in pos)
			{
				cbxPOs.Items.Add(thePO.PONumber.ToString());
			}
		}
		
		void LvInvoicesSelectedIndexChanged(object sender, EventArgs e)
		{
			if(lvInvoices.SelectedIndices.Count>0)
			{
				btnDevices.Enabled = true;
				btnEdit.Enabled = true;
				cbxPOs.SelectedIndex = pos.FindIndex(delegate(PO thePO)
				                                     {
				                                     	return thePO.PONumber == invoices[lvInvoices.FocusedItem.Index].PONumber;
				                                     }) + 1;
				nudAmount.Value = invoices[lvInvoices.SelectedIndices[0]].Amount;
				nudInvoice.Value = invoices[lvInvoices.SelectedIndices[0]].MacsTracID;
			}
			else
			{
				btnDevices.Enabled = false;
				btnEdit.Enabled = false;
			}
		}
		
		void LvInvoicesDoubleClick(object sender, EventArgs e)
		{
			if(lvInvoices.SelectedIndices.Count>0)
			{
				DevicesForm dfForm = new DevicesForm(invoices[lvInvoices.SelectedIndices[0]].ID,true);
				dfForm.ShowDialog();
			}
		}
		
		void BtnCancelClick(object sender, EventArgs e)
		{
			btnCancel.Visible = false;
			Enabler(false);
			btnAdd.Text = "Add";
		}
	}
}
