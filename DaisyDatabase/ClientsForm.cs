/*
 * Created by SharpDevelop.
 * User: Mage
 * Date: 6/10/2015
 * Time: 12:43 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using System.Collections.Generic;

namespace WIPDatabase
{
	/// <summary>
	/// Description of Clients.
	/// </summary>
	public partial class ClientsForm : Form
	{
		List<Client> clients;
		public ClientsForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			ofdFile.Filter = "Excel Files (.xls,.cvs,.xlsx)|*.xls;*.cvs;*.xlsx";
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void ClientsFormLoad(object sender, EventArgs e)
		{			
			ReloadClients();
		}

		void ReloadClients()
		{
			clients = Model.GetClients();
			clients.Sort(delegate(Client x,Client y)
			             {
			             	return x.Name.CompareTo(y.Name);
			             });
			lbxClients.Items.Clear();
			foreach (Client theClient in clients)
			{
				lbxClients.Items.Add(theClient.Name);
			}
		}
		
		void LbxClientsSelectedIndexChanged(object sender, EventArgs e)
		{
			if(lbxClients.SelectedIndex != -1)
			{
				btnView.Enabled = true;
			}
			else
			{
				btnView.Enabled = false;
			}
		}
		
		void BtnAddClick(object sender, EventArgs e)
		{
			if(ofdFile.ShowDialog() == DialogResult.OK)
			{
				btnAdd.Enabled = false;
				lblLoading.Visible = true;
				Workbook MyBook = null;
				Microsoft.Office.Interop.Excel.Application MyApp = null;
				Worksheet MySheet = null;
				MyApp = new Microsoft.Office.Interop.Excel.Application();
				MyApp.Visible = false;
				MyBook = MyApp.Workbooks.Open(ofdFile.FileName);
				MySheet = (Worksheet)MyBook.Sheets[1];
				int lastRow = MySheet.Cells.SpecialCells(XlCellType.xlCellTypeLastCell).Row;
				Array MyValues;
				List<Client> newClients = new List<Client>();
				Client theClient;
				for (int i = 2; i <= lastRow; i++)
				{
					MyValues = (Array)MySheet.get_Range("A" + i.ToString(), "D" + i.ToString()).Cells.Value;
					theClient = new Client();
					theClient.MacsTracID = int.Parse(MyValues.GetValue(1,1).ToString());
					theClient.Name = MyValues.GetValue(1,4).ToString();
					newClients.Add(theClient);
				}
				MyApp.Quit();
				List<Client> duplicateClients = new List<Client>();
				foreach (Client tempClient in newClients)
				{
					foreach (Client knownClient in clients)
					{
						if(tempClient.Name == knownClient.Name)
						{
							duplicateClients.Add(tempClient);
						}
					}
				}
				foreach (Client tempClient in duplicateClients)
				{
					for (int i = 0; i < newClients.Count; i++)
					{
						if(tempClient.Name == newClients[i].Name)
						{
							newClients.Remove(newClients[i]);
						}
					}
				}
				if(duplicateClients.Count>0)
				{
					
					MessageBox.Show("Some clients were already in the database. They have not been added from the spreadsheet");
				}
				Model.AddClients(newClients);
				clients = Model.GetClients();
				ReloadClients();
				lblLoading.Visible = false;
				btnAdd.Enabled = true;
			}
		}
		
		void BtnViewClick(object sender, EventArgs e)
		{
			ClientDetails cdForm = new ClientDetails(clients[lbxClients.SelectedIndex]);
			cdForm.ShowDialog();
			ReloadClients();			
			btnView.Enabled = false;
		}
		
		void LbxClientsDoubleClick(object sender, EventArgs e)
		{
			if(lbxClients.SelectedIndex != -1)
			{
				BtnViewClick(sender,e);
			}
		}
	}
}
