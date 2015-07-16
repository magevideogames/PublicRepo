/*
 * Created by SharpDevelop.
 * User: WIP00
 * Date: 7/2/2015
 * Time: 2:44 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using Excel = Microsoft.Office.Interop.Excel;
using System.Linq;

namespace WIPDatabase
{
	/// <summary>
	/// Description of ReportsForm.
	/// </summary>
	public partial class ReportsForm : Form
	{
		List<Client> clients;
		List<Device> devices;
		
		public ReportsForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			sfdReport.Filter = "Excel File (.xls)|*.xls";
			dtpStart.Value = dtpStart.Value.AddMonths(-1);
			dtpEnd.Value = DateTime.Now;
			clients = Model.GetClients();
			clients.Sort(delegate(Client x, Client y)
			             {
			             	return x.Name.CompareTo(y.Name);
			             });
			LoadClients();
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void LvClientsSelectedIndexChanged(object sender, EventArgs e)
		{
			if(lvClients.SelectedIndices.Count != 0)
			{
				lbxReports.Enabled = true;
			}
			else
			{
				lbxReports.Enabled = false;
			}
		}
		
		void LoadClients()
		{
			ListViewItem theItem;
			foreach(var theClient in clients)
			{
				theItem = new ListViewItem(theClient.MacsTracID.ToString());
				theItem.SubItems.Add(theClient.Name);
				lvClients.Items.Add(theItem);
			}
		}
		
		void LoadDevices()
		{
			devices = Model.GetClientDevices(clients[lvClients.FocusedItem.Index].ID);
			foreach(var device in devices)
			{
				lbxDevices.Items.Add(device.AssetID);
			}
		}
		
		void LbxReportsSelectedIndexChanged(object sender, EventArgs e)
		{
			if(lbxReports.SelectedIndex != -1)
			{
				if(lbxReports.SelectedItem.ToString() == "Device History")
				{
					lblDevices.Visible = true;
					lbxDevices.Visible = true;
					btnCreate.Enabled = false;
					LoadDevices();
				}
				else if(lbxReports.SelectedItem.ToString() == "Client History")
				{
					lblDevices.Visible = false;
					lbxDevices.Visible = false;
					btnCreate.Enabled = true;
				}
				if(lbxReports.SelectedItem.ToString() == "Billing Invoice")
				{
					lblDevices.Visible = false;
					lbxDevices.Visible = false;
					btnCreate.Enabled = true;
				}
				if(lbxReports.SelectedItem.ToString() == "Annual Report")
				{
					lblDevices.Visible = false;
					lbxDevices.Visible = false;
					btnCreate.Enabled = true;
				}
			}
		}
		
		void LbxDevicesSelectedIndexChanged(object sender, EventArgs e)
		{
			if(lbxDevices.SelectedIndex != -1)
			{
				btnCreate.Enabled = true;
			}
		}
		
		void BtnCreateClick(object sender, EventArgs e)
		{
			this.Enabled = false;
			btnCreate.Text = "Generating Report.";
			if(lbxReports.SelectedItem.ToString() == "Device History")
			{
				CreateDeviceHistoryReport();
			}
			else if(lbxReports.SelectedItem.ToString() == "Client History")
			{
				CreateClientHistoryReport();
			}
			if(lbxReports.SelectedItem.ToString() == "Billing Invoice")
			{
				CreateBillingInvoiceReport();
			}
			if(lbxReports.SelectedItem.ToString() == "Annual Report")
			{
				CreateAnnualReport();
			}
			btnCreate.Text = "Create Report";
			this.Enabled = true;
		}
		
		void CreateDeviceHistoryReport()
		{
			object misValue = System.Reflection.Missing.Value;
			if(sfdReport.ShowDialog() == DialogResult.OK)
			{
				List<Invoice> theInvoices = Model.GetInvoices();
				Excel.Application excelApp = new Excel.Application();
				excelApp.SheetsInNewWorkbook = 1;
				excelApp.Visible = false;
				Excel.Workbook workbook = excelApp.Workbooks.Add(misValue);
				Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Sheets.Add();
				worksheet.Name = devices[lbxDevices.SelectedIndex].AssetID + " Billing History";
				worksheet.Cells[1, "A"] = "Invoice";
				worksheet.Cells[1, "B"] = "Life Count Start";
				worksheet.Cells[1, "C"] = "Life Count End";
				worksheet.Cells[1, "D"] = "Color Pages";
				worksheet.Cells[1, "E"] = "Mono Pages";
				worksheet.Cells[1, "F"] = "Last Active";
				worksheet.Cells[1, "G"] = "Notes";
				Dictionary<int,Device> theDevices = Model.GetInvoicesForDevice(devices[lbxDevices.SelectedIndex].ID);
				int z= 2;
				for(int i = 0; i < theDevices.Count;i++)
				{
					var theInvoice = theInvoices.Single(tempInvoice => tempInvoice.ID == theDevices.ElementAt(i).Key);
					if(theInvoice.Date.CompareTo(dtpStart.Value) >= 0 && theInvoice.Date.CompareTo(dtpEnd.Value) <= 0)
					{
						worksheet.Cells[z, "A"] = theInvoice.MacsTracID;
						worksheet.Cells[z, "B"] = theDevices.ElementAt(i).Value.LCStart;
						worksheet.Cells[z, "C"] = theDevices.ElementAt(i).Value.LCEnd;
						worksheet.Cells[z, "D"] = theDevices.ElementAt(i).Value.CPages;
						worksheet.Cells[z, "E"] = theDevices.ElementAt(i).Value.MPages;
						worksheet.Cells[z, "F"] = theDevices.ElementAt(i).Value.LastActive;
						worksheet.Cells[z, "G"] = theDevices.ElementAt(i).Value.Note;
						z++;
					}
				}
				workbook.SaveAs(sfdReport.FileName, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue,
				                misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
				MessageBox.Show("Report Created");
				workbook.Close(true);
				excelApp.Quit();
			}
		}
		
		void CreateClientHistoryReport()
		{
			object misValue = System.Reflection.Missing.Value;
			if(sfdReport.ShowDialog() == DialogResult.OK)
			{
				List<Invoice> theInvoices = Model.GetInvoices(clients[lvClients.FocusedItem.Index].ID);
				Excel.Application excelApp = new Excel.Application();
				excelApp.SheetsInNewWorkbook = 1;
				excelApp.Visible = false;
				Excel.Workbook workbook = excelApp.Workbooks.Add(misValue);
				Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Sheets.Add();
				worksheet.Name = clients[lvClients.FocusedItem.Index].MacsTracID + "  History";
				worksheet.Cells[1, "A"] = "Invoice";
				worksheet.Cells[1, "B"] = "Amount";
				worksheet.Cells[1, "C"] = "Date";
				worksheet.Cells[1, "D"] = "PO";
				int z = 2;
				for(int i = 0; i < theInvoices.Count; i++)
				{
					if(theInvoices[i].Date.CompareTo(dtpStart.Value) >= 0 && theInvoices[i].Date.CompareTo(dtpEnd.Value) <= 0)
					{
						worksheet.Cells[z, "A"] = theInvoices[i].MacsTracID;
						worksheet.Cells[z, "B"] = theInvoices[i].Amount;
						((Excel.Range)worksheet.Cells[z, "B"]).NumberFormat = @"_($* #,##0.00_);_($* (#,##0.00);_($* ""-""??_);_(@_)";
						worksheet.Cells[z, "C"] = theInvoices[i].Date.ToShortDateString();
						((Excel.Range)worksheet.Cells[z, "C"]).NumberFormat = "m/d/yyyy";
						worksheet.Cells[z, "D"] = theInvoices[i].PONumber;
						z++;
					}
				}
				workbook.SaveAs(sfdReport.FileName, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue,
				                misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
				MessageBox.Show("Report Created");
				workbook.Close(true);
				excelApp.Quit();
			}
		}
		
		void CreateBillingInvoiceReport()
		{
			decimal cPrice;
			decimal mPrice;
			decimal cTotal;
			decimal mTotal;
			decimal tPrice;
			object misValue = System.Reflection.Missing.Value;
			if(sfdReport.ShowDialog() == DialogResult.OK)
			{
				List<Device> theDevices = Model.GetClientDevices(clients[lvClients.FocusedItem.Index].ID).OrderBy(x => x.Site).ThenBy(x => x.AssetID).ToList();
				Excel.Application excelApp = new Excel.Application();
				excelApp.SheetsInNewWorkbook = 1;
				excelApp.Visible = false;
				Excel.Workbook workbook = excelApp.Workbooks.Add(misValue);
				Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Sheets.Add();
				worksheet.Name = clients[lvClients.FocusedItem.Index].MacsTracID + "  Invoice";
				#region Headers
				worksheet.Cells[1, "A"] = "OEM";
				worksheet.Cells[1, "B"] = "Blk or Color";
				worksheet.Cells[1, "C"] = "Net or Loc";
				worksheet.Cells[1, "D"] = "PO# and Site/Dept";
				worksheet.Cells[1, "E"] = "Device";
				worksheet.Cells[1, "F"] = "Serial Number";
				worksheet.Cells[1, "G"] = "Asset Number";
				worksheet.Cells[1, "H"] = "Location/School Site";
				worksheet.Cells[1, "I"] = "Total Color pages printed";
				worksheet.Cells[1, "J"] = "Total Mono Pages Printed";
				worksheet.Cells[1, "K"] = "Total Pages Printed  (per DCA)";
				worksheet.Cells[1, "L"] = "total Pages FORMULA s/b 0";
				worksheet.Cells[1, "M"] = "CPP rate color prints .06525 .0725";
				worksheet.Cells[1, "N"] = "CPP rate mono prints .00801 .0089   .01494 .0166";
				worksheet.Cells[1, "O"] = "CPC Total Color";
				worksheet.Cells[1, "P"] = "CPP Total Mono";
				worksheet.Cells[1, "Q"] = "Total Cost by Device";
				worksheet.Cells[1, "R"] = "Life Count Start";
				worksheet.Cells[1, "S"] = "Life Count End";
				worksheet.Cells[1, "T"] = "Last Active Date or Invoice #";
				worksheet.Cells[1, "U"] = "Page Count Total";
				worksheet.Cells[1, "V"] = "cross check";
				worksheet.Cells[1, "W"] = "toner delivered on Locals or other information";
				#endregion
				int z = 2;
				for(int i = 0; i < theDevices.Count; i++)
				{
					if(theDevices[i].LastActive.CompareTo(dtpStart.Value) >= 0 && theDevices[i].LastActive.CompareTo(dtpEnd.Value) <= 0)
					{
						if(theDevices[i].OEM)
						{
							worksheet.Cells[z, "A"] = "yes";
							if(theDevices[i].PrinterType)
							{
								worksheet.Cells[z, "B"] = "color";
								cPrice = clients[lvClients.FocusedItem.Index].COEMPrice;
								mPrice = clients[lvClients.FocusedItem.Index].MOEMPrice;
								cTotal = cPrice * theDevices[i].CPages;
								mTotal = mPrice * theDevices[i].MPages;
								tPrice = cTotal + mTotal;
							}
							else
							{
								worksheet.Cells[z, "B"] = "mono";
								cPrice = 0;
								mPrice = clients[lvClients.FocusedItem.Index].MOEMPrice;
								cTotal = 0;
								mTotal = mPrice * theDevices[i].MPages;
								tPrice = cTotal + mTotal;
							}
						}
						else
						{
							worksheet.Cells[z, "A"] = "no";
							if(theDevices[i].PrinterType)
							{
								worksheet.Cells[z, "B"] = "color";
								cPrice = clients[lvClients.FocusedItem.Index].CPrice;
								mPrice = clients[lvClients.FocusedItem.Index].MPrice;
								cTotal = cPrice * theDevices[i].CPages;
								mTotal = mPrice * theDevices[i].MPages;
								tPrice = cTotal + mTotal;
							}
							else
							{
								worksheet.Cells[z, "B"] = "mono";
								cPrice = 0;
								mPrice = clients[lvClients.FocusedItem.Index].MOEMPrice;
								cTotal = 0;
								mTotal = mPrice * theDevices[i].MPages;
								tPrice = cTotal + mTotal;
							}
						}
						if(theDevices[i].Networked)
						{
							worksheet.Cells[z, "C"] = "network";
						}
						else
						{
							worksheet.Cells[z, "C"] = "local";
						}
						worksheet.Cells[z, "D"] = theDevices[i].Site;
						worksheet.Cells[z, "E"] = theDevices[i].DeviceName;
						worksheet.Cells[z, "F"] = theDevices[i].SerialNumber;
						worksheet.Cells[z, "G"] = theDevices[i].AssetID;
						worksheet.Cells[z, "H"] = theDevices[i].Department;
						worksheet.Cells[z, "I"] = theDevices[i].CPages;
						worksheet.Cells[z, "J"] = theDevices[i].MPages;
						int tPages = theDevices[i].CPages + theDevices[i].MPages;
						worksheet.Cells[z, "K"] = tPages;
						worksheet.Cells[z, "L"] = "total Pages FORMULA s/b 0";
						worksheet.Cells[z, "M"] = cPrice;
						worksheet.Cells[z, "N"] = mPrice;
						((Excel.Range)worksheet.Cells[z, "M"]).NumberFormat = "#.####";
						((Excel.Range)worksheet.Cells[z, "N"]).NumberFormat = "#.####";
						worksheet.Cells[z, "O"] = cTotal;
						worksheet.Cells[z, "P"] = mTotal;
						worksheet.Cells[z, "Q"] = tPrice;
						worksheet.Cells[z, "R"] = theDevices[i].LCStart;
						worksheet.Cells[z, "S"] = theDevices[i].LCEnd;
						if(theDevices[i].Note != null)
						{
							worksheet.Cells[z, "T"] = "Invoice Number";
						}
						else
						{
							worksheet.Cells[z, "T"] = theDevices[i].LastActive;
						}
						int dPages = theDevices[i].LCEnd - theDevices[i].LCStart;
						worksheet.Cells[z, "U"] =  dPages;
						if(tPages < dPages)
						{
							worksheet.Cells[z, "V"] = "Printed Count less than End Count";
						}
						else if(tPages > dPages)
						{
							worksheet.Cells[z, "V"] = "End Count less than Printed Count";
						}
						else if(dPages < 0)
						{
							worksheet.Cells[z, "V"] = "Negative Ending Count";
						}
						worksheet.Cells[z, "W"] = theDevices[i].Note;
						z++;
					}
				}
				workbook.SaveAs(sfdReport.FileName, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue,
				                misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
				MessageBox.Show("Report Created");
				workbook.Close(true);
				excelApp.Quit();
			}
		}
		
		void CreateAnnualReport()
		{
			if(sfdReport.ShowDialog() == DialogResult.OK)
			{
				List<Invoice> invoices = Model.GetInvoices(clients[lvClients.FocusedItem.Index].ID).OrderBy(x => x.Date).ToList();
				object misValue = System.Reflection.Missing.Value;
				Excel.Application excelApp = new Excel.Application();
				excelApp.SheetsInNewWorkbook = 1;
				excelApp.Visible = false;
				Excel.Workbook workbook = excelApp.Workbooks.Add(misValue);
				Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Sheets.Add();
				worksheet.Name = clients[lvClients.FocusedItem.Index].MacsTracID + "  Annual Report " + DateTime.Now.Year;
				worksheet.Cells[1, "A"] = "Invoice ID";
				worksheet.Cells[1, "B"] = "PO Number";
				worksheet.Cells[1, "C"] = "Amount";
				worksheet.Cells[1, "D"] = "Invoice Date";
				worksheet.Cells[1, "E"] = "Mono Pages";
				worksheet.Cells[1, "F"] = "Color Pages";
				worksheet.Cells[1, "G"] = "Total Pages";
				int z = 2;
				foreach (var theInvoice in invoices)
				{
					worksheet.Cells[z, "A"] = theInvoice.MacsTracID;
					worksheet.Cells[z, "B"] = theInvoice.PONumber;
					worksheet.Cells[z, "C"] = theInvoice.Amount;
					((Excel.Range)worksheet.Cells[z, "C"]).NumberFormat = @"_($* #,##0.00_);_($* (#,##0.00);_($* ""-""??_);_(@_)";
					worksheet.Cells[z, "D"] = theInvoice.Date;
					((Excel.Range)worksheet.Cells[z, "D"]).NumberFormat = "m/d/yyyy";
					int totalPages = 0;
					int cPages = 0;
					int mPages = 0;
					foreach (var theDevice in Model.GetDevicesOnInvoice(theInvoice.ID))
					{
						cPages += theDevice.CPages;
						mPages += theDevice.MPages;
						totalPages += theDevice.CPages + theDevice.MPages;
					}
					worksheet.Cells[z, "E"] = mPages;
					worksheet.Cells[z, "F"] = cPages;
					worksheet.Cells[z, "G"] = totalPages;
					z++;
				}
				workbook.SaveAs(sfdReport.FileName, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue,
				                misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
				MessageBox.Show("Report Created");
				workbook.Close(true);
				excelApp.Quit();
			}
		}
	}


}
