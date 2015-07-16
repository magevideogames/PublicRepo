/*
 * Created by SharpDevelop.
 * User: Mage
 * Date: 6/23/2015
 * Time: 12:47 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using System.Collections.Generic;
using System.Linq;

namespace WIPDatabase
{
	/// <summary>
	/// Description of DevicesForm.
	/// </summary>
	public partial class DevicesForm : Form
	{
		int theID;
		bool forInvoice;
		List<Device> devices;
		public DevicesForm(int tempID,bool theType)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			theID = tempID;
			forInvoice = theType;
			ofdDevices.Filter = "Excel Files (.xls,.csv,.xlsx)|*.xls;*.csv;*.xlsx";
			if(forInvoice)
			{
				cbxType.Visible = false;
				cbxOEM.Visible = false;
				cbxNetworked.Visible = false;
				lblAssetID.Visible = false;
				tbxAssetID.Visible = false;
				lblDepartment.Visible = false;
				tbxDepartment.Visible = false;
				lblSerial.Visible = false;
				tbxSerial.Visible = false;
				lblSite.Visible = false;
				tbxSite.Visible = false;
				lblName.Visible = false;
				tbxName.Visible = false;
				lblNote.Visible = true;
				tbxNote.Visible = true;
			}
			LoadDevices();
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void LoadDevices()
		{
			if(forInvoice)
			{
				devices = Model.GetDevicesOnInvoice(theID);
			}
			else
			{
				devices = Model.GetClientDevices(theID);
			}
			devices.Sort(delegate(Device x, Device y)
			             {
			             	return x.AssetID.CompareTo(y.AssetID);
			             });
			lvDevices.Items.Clear();
			ListViewItem theItem;
			foreach (Device theDevice in devices)
			{
				theItem = new ListViewItem(theDevice.AssetID);
				theItem.SubItems.Add(theDevice.DeviceName);
				lvDevices.Items.Add(theItem);
			}
			
		}
		
		void ImportDCADevices(string fileName)
		{
			Workbook MyBook = null;
			Microsoft.Office.Interop.Excel.Application MyApp = null;
			Worksheet MySheet = null;
			MyApp = new Microsoft.Office.Interop.Excel.Application();
			MyApp.Visible = false;
			MyBook = MyApp.Workbooks.Open(ofdDevices.FileName);
			MySheet = (Worksheet)MyBook.Sheets[1];
			int lastRow = MySheet.Cells.SpecialCells(XlCellType.xlCellTypeLastCell).Row;
			Array MyValues;
			List<Device> devices = new List<Device>();
			Device theDevice;
			int mtID = Model.GetClients().Single(x => x.ID == theID).MacsTracID;
			for (int i = 2; i <= lastRow; i++)
			{
				MyValues = (Array)MySheet.get_Range("A" + i.ToString(), "P" + i.ToString()).Cells.Value;
				theDevice = new Device();
				theDevice.ClientID =  theID;
				if(MyValues.GetValue(1,16).ToString().ToLower() == "managed")
				{
					theDevice.Networked = true;
				}
				else
				{
					theDevice.Networked = false;
				}
				theDevice.CPages = int.Parse(MyValues.GetValue(1,10).ToString());
				theDevice.LastActive = DateTime.Parse(MyValues.GetValue(1,7).ToString());
				theDevice.LCEnd = int.Parse(MyValues.GetValue(1,14).ToString());
				theDevice.LCStart = int.Parse(MyValues.GetValue(1,13).ToString());
				theDevice.MPages = int.Parse(MyValues.GetValue(1,11).ToString());
				if(MyValues.GetValue(1,4) != null)
				{
					theDevice.SerialNumber = MyValues.GetValue(1,4).ToString();
				}
				else
				{
					theDevice.SerialNumber = string.Empty;
				}
				if(MyValues.GetValue(1,5) != null)
				{
					theDevice.AssetID = MyValues.GetValue(1,5).ToString();
				}
				else
				{
					if(mtID == 1434)
					{
						theDevice.AssetID = "OMxxxx";
						
					}
					else if(mtID == 3311)
					{
						theDevice.AssetID = "MVxxxx";
					}
				}
				if(theDevice.AssetID.ToUpper().Contains("HP") || theDevice.AssetID.ToUpper().Contains("OEM"))
				{
					theDevice.OEM = true;
				}
				else
				{
					theDevice.OEM = false;
				}
				theDevice.PrinterType = bool.Parse(MyValues.GetValue(1,1).ToString());
				string[] siteArray = MyValues.GetValue(1,2).ToString().Split(">".ToCharArray());
				theDevice.Site = siteArray[siteArray.Length - 1];
				theDevice.DeviceName = MyValues.GetValue(1,3).ToString();
				if(MyValues.GetValue(1,6) != null)
				{
					theDevice.Department = MyValues.GetValue(1,6).ToString();
				}
				else
				{
					theDevice.Department = string.Empty;
				}
				if(theDevice.Networked && !theDevice.Site.ToLower().Contains("dupe") && !theDevice.Site.ToLower().Contains("unmanaged") &&
				   !theDevice.AssetID.Contains("dupe"))
				{
					devices.Add(theDevice);
				}
			}
			if(Model.AddDevices(devices,theID))
			{
				LoadDevices();
			}
			else
			{
				MessageBox.Show("Unable to import devices.");
			}
		}
		
		void BtnAddClick(object sender, EventArgs e)
		{
			if(ofdDevices.ShowDialog() == DialogResult.OK)
			{
				btnAdd.Enabled = false;
				lblLoading.Text = "Adding Devices. Please Wait.";
				lblLoading.Visible = true;
				if(forInvoice)
				{
					int mtID = Model.GetClients().Single(y => y.ID == Model.GetInvoices().Single(x => x.ID == theID).ClientID).MacsTracID;
					if(mtID == 1434)
					{
						LoadOMSDInvoice(ofdDevices.FileName);
						
					}
					else if(mtID == 3311)
					{
						LoadMVUSDInvoice(ofdDevices.FileName);
					}
					
					if(Model.AddInvoiceDevices(theID,devices))
					{
						LoadDevices();
					}
					else
					{
						MessageBox.Show("Unable to import devices.");
					}
				}
				else
				{
					ImportDCADevices(ofdDevices.FileName);
				}
				lblLoading.Visible = false;
				btnAdd.Enabled = true;
			}
		}
		
		void BtnEditClick(object sender, EventArgs e)
		{
			if(btnEdit.Text == "Edit")
			{
				Enabler(true);
				btnEdit.Text = "Save";
				btnCancel.Visible = true;
			}
			else
			{
				lblLoading.Text = "Updating Device. Please Wait.";
				lblLoading.Visible = true;
				Device theDevice = new Device();
				theDevice.AssetID = tbxAssetID.Text;
				theDevice.ID = devices[lvDevices.FocusedItem.Index].ID;
				theDevice.ClientID = devices[lvDevices.FocusedItem.Index].ClientID;
				theDevice.CPages = int.Parse(nudCPages.Value.ToString());
				theDevice.Department = tbxDepartment.Text;
				theDevice.DeviceName = tbxName.Text;
				theDevice.LastActive = dtpLActive.Value;
				theDevice.LCEnd = int.Parse(nudLCEnd.Value.ToString());
				theDevice.LCStart = int.Parse(nudLCStart.Value.ToString());
				theDevice.MPages = int.Parse(nudMPages.Value.ToString());
				theDevice.Networked = cbxNetworked.Checked;
				theDevice.OEM = cbxOEM.Checked;
				theDevice.PrinterType = cbxType.Checked;
				theDevice.SerialNumber = tbxSerial.Text;
				theDevice.Site = tbxSite.Text;
				if(!forInvoice)
				{
					if(Model.UpdateClientDevice(theDevice))
					{
						LoadDevices();
					}
					else
					{
						MessageBox.Show("Unable to update");
					}
				}
				else
				{
					theDevice.Note = tbxNote.Text;
					if(Model.UpdateInvoiceDevice(theID,theDevice))
					{
						LoadDevices();
					}
					else
					{
						MessageBox.Show("Unable to update");
					}
				}
				lblLoading.Visible = false;
				btnEdit.Text = "Edit";
				btnEdit.Enabled = false;
				btnCancel.Visible = false;
				Enabler(false);
			}
		}
		
		void LvDevicesSelectedIndexChanged(object sender, EventArgs e)
		{
			if(lvDevices.SelectedIndices.Count != 0)
			{
				if(!forInvoice)
				{
					tbxAssetID.Text = devices[lvDevices.FocusedItem.Index].AssetID.ToString();
					tbxSerial.Text = devices[lvDevices.FocusedItem.Index].SerialNumber.ToString();
					tbxName.Text = devices[lvDevices.FocusedItem.Index].DeviceName;
					tbxSerial.Text = devices[lvDevices.FocusedItem.Index].SerialNumber;
					tbxDepartment.Text = devices[lvDevices.FocusedItem.Index].Department.ToString();
					cbxType.Checked = devices[lvDevices.FocusedItem.Index].PrinterType;
					cbxOEM.Checked = devices[lvDevices.FocusedItem.Index].OEM;
					cbxNetworked.Checked = devices[lvDevices.FocusedItem.Index].Networked;
					tbxSite.Text = devices[lvDevices.FocusedItem.Index].Site.ToString();
				}
				else
				{
					tbxNote.Text = devices[lvDevices.FocusedItem.Index].Note;
				}
				nudCPages.Value = devices[lvDevices.FocusedItem.Index].CPages;
				nudLCEnd.Value = devices[lvDevices.FocusedItem.Index].LCEnd;
				nudLCStart.Value = devices[lvDevices.FocusedItem.Index].LCStart;
				nudMPages.Value = devices[lvDevices.FocusedItem.Index].MPages;
				dtpLActive.Value = devices[lvDevices.FocusedItem.Index].LastActive;
				
				btnEdit.Enabled = true;
				
			}
			else
			{
				btnEdit.Enabled = false;
			}
		}
		
		void Enabler(bool setting)
		{
			tbxAssetID.Enabled = setting;
			tbxDepartment.Enabled = setting;
			tbxName.Enabled = setting;
			tbxSerial.Enabled = setting;
			tbxSite.Enabled = setting;
			nudCPages.Enabled = setting;
			nudLCEnd.Enabled = setting;
			nudLCStart.Enabled = setting;
			nudMPages.Enabled = setting;
			dtpLActive.Enabled = setting;
			tbxNote.Enabled = setting;
			cbxNetworked.Enabled = setting;
			cbxOEM.Enabled = setting;
			cbxType.Enabled = setting;
		}
		
		void BtnCancelClick(object sender, EventArgs e)
		{
			Enabler(false);
			btnCancel.Visible = false;
			btnEdit.Text = "Edit";
		}
		
		void LoadOMSDInvoice(string fileName)
		{
			Workbook MyBook = null;
			Microsoft.Office.Interop.Excel.Application MyApp = null;
			Worksheet MySheet = null;
			MyApp = new Microsoft.Office.Interop.Excel.Application();
			MyApp.Visible = false;
			MyBook = MyApp.Workbooks.Open(fileName);
			MySheet = (Worksheet)MyBook.Sheets[1];
			int lastRow = MySheet.Cells.SpecialCells(XlCellType.xlCellTypeLastCell).Row;
			Array MyValues;
			devices = new List<Device>();
			Device theDevice;
			for (int i = 3; i <= lastRow; i++)
			{
				MyValues = (Array)MySheet.get_Range("A" + i.ToString(), "S" + i.ToString()).Cells.Value;
				if(MyValues.GetValue(1,7) != null && MyValues.GetValue(1,7).ToString().ToLower() != "x")
				{
					theDevice = new Device();
					theDevice.ClientID =  theID;
					theDevice.Department = MyValues.GetValue(1,2).ToString();
					theDevice.Site = MyValues.GetValue(1,6).ToString();
					string theDate = MyValues.GetValue(1,7).ToString();
					theDevice.LastActive = DateTime.Parse(MyValues.GetValue(1,7).ToString());
					theDevice.DeviceName = MyValues.GetValue(1,3).ToString();
					if(MyValues.GetValue(1,4) != null)
					{
						theDevice.SerialNumber = MyValues.GetValue(1,4).ToString();
					}
					else
					{
						theDevice.SerialNumber = string.Empty;
					}
					theDevice.CPages = int.Parse(MyValues.GetValue(1,11).ToString());
					theDevice.LastActive = DateTime.Parse(MyValues.GetValue(1,7).ToString());
					theDevice.LCEnd = int.Parse(MyValues.GetValue(1,9).ToString());
					theDevice.LCStart = int.Parse(MyValues.GetValue(1,8).ToString());
					theDevice.MPages = int.Parse(MyValues.GetValue(1,12).ToString());
					theDevice.AssetID = MyValues.GetValue(1,5).ToString();
					if(MyValues.GetValue(1,19) != null)
					{
						theDevice.Note = MyValues.GetValue(1,19).ToString();
					}
					else
					{
						theDevice.Note = string.Empty;
					}
					devices.Add(theDevice);
				}
			}
		}
		
		void LoadMVUSDInvoice(string fileName)
		{
			Workbook MyBook = null;
			Microsoft.Office.Interop.Excel.Application MyApp = null;
			Worksheet MySheet = null;
			MyApp = new Microsoft.Office.Interop.Excel.Application();
			MyApp.Visible = false;
			MyBook = MyApp.Workbooks.Open(fileName);
			MySheet = (Worksheet)MyBook.Sheets[1];
			int lastRow = MySheet.Cells.SpecialCells(XlCellType.xlCellTypeLastCell).Row;
			Array MyValues;
			devices = new List<Device>();
			Device theDevice;
			for (int i = 3; i <= lastRow; i++)
			{
				MyValues = (Array)MySheet.get_Range("A" + i.ToString(), "W" + i.ToString()).Cells.Value;
				if(MyValues.GetValue(1,7) != null && MyValues.GetValue(1,7).ToString().ToLower() != "x")
				{
					theDevice = new Device();
					theDevice.ClientID =  theID;
					theDevice.Department = MyValues.GetValue(1,4).ToString();
					theDevice.Site = MyValues.GetValue(1,8).ToString();
					DateTime theDate;
					if(DateTime.TryParse(MyValues.GetValue(1,20).ToString(),out theDate))
					{
						theDevice.LastActive = theDate;
						theDevice.Note = string.Empty;
						theDevice.LCEnd = int.Parse(MyValues.GetValue(1,19).ToString());
						theDevice.LCStart = int.Parse(MyValues.GetValue(1,18).ToString());
					}
					else
					{
						theDevice.Note = "Invoice: " + MyValues.GetValue(1,20).ToString() + " " + MyValues.GetValue(1,23).ToString();
						theDevice.LCEnd = 0;
						theDevice.LCStart = 0;
					}
					theDevice.DeviceName = MyValues.GetValue(1,5).ToString();
					if(MyValues.GetValue(1,6) != null)
					{
						theDevice.SerialNumber = MyValues.GetValue(1,6).ToString();
					}
					else
					{
						theDevice.SerialNumber = string.Empty;
					}
					theDevice.CPages = int.Parse(MyValues.GetValue(1,9).ToString());
					theDevice.MPages = int.Parse(MyValues.GetValue(1,10).ToString());
					theDevice.AssetID = MyValues.GetValue(1,7).ToString();
					devices.Add(theDevice);
				}
			}
		}
	}
}
