/*
 * Created by SharpDevelop.
 * User: Mage
 * Date: 6/10/2015
 * Time: 1:00 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;

namespace WIPDatabase
{
	/// <summary>
	/// Description of Model.
	/// </summary>
	public static class Model
	{
		static MySqlConnection theConnection = new MySqlConnection();
		static MySqlCommand theCommand = new MySqlCommand();
		static MySqlDataReader reader;
		static string commandString;
		//Emptied for demonstation
		static string connectionString = "";
		
		#region Get Methods
		public static List<PO> GetPOs(int clientID)
		{
			if(theConnection.ConnectionString == string.Empty)
			{
				theConnection.ConnectionString = connectionString;
			}
			List<PO> thePOs = new List<PO>();
			PO thePO;
			List<POTransaction> transactions = new List<POTransaction>();
			POTransaction theTransaction;
			try
			{
				commandString= "select * from PO_Transactions";
				theConnection.Open();
				theCommand.Connection = theConnection;
				theCommand.CommandText = commandString;
				reader = theCommand.ExecuteReader();
				while(reader.Read())
				{
					theTransaction = new POTransaction();
					theTransaction.POID = int.Parse(reader["poID"].ToString());
					theTransaction.Date = DateTime.Parse(reader["date"].ToString());
					theTransaction.Amount = decimal.Parse(reader["amount"].ToString());
					transactions.Add(theTransaction);
				}
				reader.Close();
				
				commandString = "select * from POs where clientID = " + clientID;
				theCommand.CommandText = commandString;
				reader = theCommand.ExecuteReader();
				while (reader.Read())
				{
					thePO = new PO();
					thePO.Amount = decimal.Parse(reader["amount"].ToString());
					thePO.ClientID = int.Parse(reader["clientID"].ToString());
					thePO.ID = int.Parse(reader["poID"].ToString());
					thePO.PONumber = reader["poMTNumber"].ToString();
					thePO.Transactions = new List<POTransaction>();
					foreach(POTransaction tempTransaction in transactions)
					{
						if(tempTransaction.POID == thePO.ID)
						{
							thePO.Transactions.Add(tempTransaction);
						}
					}
					
					thePOs.Add(thePO);
				}
				return thePOs;
				
			}
			catch (MySqlException ex)
			{
				return new List<PO>();
			}
			finally
			{
				theConnection.Close();
			}
		}
		
		public static List<Invoice> GetInvoices()
		{
			if(theConnection.ConnectionString == string.Empty)
			{
				theConnection.ConnectionString = connectionString;
			}
			List<Invoice> theInvoices = new List<Invoice>();
			Invoice theInvoice;
			try
			{
				commandString = "select * from Invoices";
				theConnection.Open();
				theCommand.Connection = theConnection;
				theCommand.CommandText = commandString;
				reader = theCommand.ExecuteReader();
				while (reader.Read())
				{
					theInvoice = new Invoice();
					theInvoice.Amount = decimal.Parse(reader["amount"].ToString());
					theInvoice.ClientID = int.Parse(reader["clientID"].ToString());
					theInvoice.Date = DateTime.Parse(reader["date"].ToString());
					theInvoice.ID = int.Parse(reader["invoiceID"].ToString());
					theInvoice.MacsTracID = int.Parse(reader["invoiceMTNumber"].ToString());
					if(reader["poMTNumber"] != null)
					{
						theInvoice.PONumber = reader["poMTNumber"].ToString();
					}
					theInvoices.Add(theInvoice);
				}
				return theInvoices;
				
			}
			catch (MySqlException ex)
			{
				return new List<Invoice>();
			}
			finally
			{
				theConnection.Close();
			}
		}
		
		public static List<Invoice> GetInvoices(int clientID)
		{
			if(theConnection.ConnectionString == string.Empty)
			{
				theConnection.ConnectionString = connectionString;
			}
			List<Invoice> theInvoices = new List<Invoice>();
			Invoice theInvoice;
			try
			{
				commandString = "select * from Invoices where clientID = " + clientID;
				theConnection.Open();
				theCommand.Connection = theConnection;
				theCommand.CommandText = commandString;
				reader = theCommand.ExecuteReader();
				while (reader.Read())
				{
					theInvoice = new Invoice();
					theInvoice.Amount = decimal.Parse(reader["amount"].ToString());
					theInvoice.ClientID = int.Parse(reader["clientID"].ToString());
					theInvoice.Date = DateTime.Parse(reader["date"].ToString());
					theInvoice.ID = int.Parse(reader["invoiceID"].ToString());
					theInvoice.MacsTracID = int.Parse(reader["invoiceMTNumber"].ToString());
					if(reader["poMTNumber"] != null)
					{
						theInvoice.PONumber = reader["poMTNumber"].ToString();
					}
					theInvoices.Add(theInvoice);
				}
				return theInvoices;
				
			}
			catch (MySqlException ex)
			{
				return new List<Invoice>();
			}
			finally
			{
				theConnection.Close();
			}
		}
		
		public static List<Client> GetClients()
		{
			if(theConnection.ConnectionString == string.Empty)
			{
				theConnection.ConnectionString = connectionString;
			}
			List<Client> theClients = new List<Client>();
			Client theClient;
			try
			{
				commandString = "select * from Clients";
				theCommand.Connection = theConnection;
				theCommand.CommandText = commandString;
				theConnection.Open();
				decimal number;
				reader = theCommand.ExecuteReader();
				while (reader.Read())
				{
					theClient = new Client();
					if(Decimal.TryParse(reader["cocPrice"].ToString(), out number))
					{
						theClient.CPrice = number;
					}
					if(Decimal.TryParse(reader["mocPrice"].ToString(), out number))
					{
						theClient.MoCPrice = number;
					}
					if(Decimal.TryParse(reader["monoPrice"].ToString(), out number))
					{
						theClient.MPrice = number;
					}
					if(Decimal.TryParse(reader["cocOEMPrice"].ToString(), out number))
					{
						theClient.COEMPrice = number;
					}
					if(Decimal.TryParse(reader["mocOEMPrice"].ToString(), out number))
					{
						theClient.MoCOEMPrice = number;
					}
					if(Decimal.TryParse(reader["monoOEMPrice"].ToString(), out number))
					{
						theClient.MOEMPrice = number;
					}
					theClient.ID = int.Parse(reader["clientID"].ToString());
					theClient.MacsTracID = int.Parse(reader["clientMTID"].ToString());
					theClient.Name = reader["clientName"].ToString();
					theClients.Add(theClient);
				}
				return theClients;
				
			}
			catch (MySqlException ex)
			{
				return new List<Client>();
			}
			finally
			{
				theConnection.Close();
			}
		}
		
		public static List<Device> GetClientDevices(int clientID)
		{
			if(theConnection.ConnectionString == string.Empty)
			{
				theConnection.ConnectionString = connectionString;
			}
			List<Device> devices = new List<Device>();
			Device theDevice;
			try
			{
				commandString = "select * from Devices where clientID = " + clientID;
				theConnection.Open();
				theCommand.Connection = theConnection;
				theCommand.CommandText = commandString;
				reader = theCommand.ExecuteReader();
				while (reader.Read())
				{
					theDevice = new Device();
					theDevice.AssetID = reader["assetID"].ToString();
					theDevice.Department = reader["department"].ToString();
					theDevice.ClientID = int.Parse(reader["clientID"].ToString());
					theDevice.CPages = int.Parse(reader["colorPages"].ToString());
					theDevice.DeviceName = reader["name"].ToString();
					theDevice.ID = int.Parse(reader["deviceID"].ToString());
					theDevice.LastActive = DateTime.Parse(reader["lastActive"].ToString());
					theDevice.LCEnd = int.Parse(reader["lifeCountEnd"].ToString());
					theDevice.LCStart = int.Parse(reader["lifeCountStart"].ToString());
					theDevice.MPages = int.Parse(reader["monoPages"].ToString());
					theDevice.Networked = bool.Parse(reader["netStatus"].ToString());
					theDevice.OEM = bool.Parse(reader["oem"].ToString());
					theDevice.PrinterType = bool.Parse(reader["type"].ToString());
					if(reader["serialNumber"] != null)
					{
						theDevice.SerialNumber = reader["serialNumber"].ToString();
					}
					theDevice.Site = reader["site"].ToString();
					devices.Add(theDevice);
				}
				return devices;
				
			}
			catch (MySqlException ex)
			{
				return new List<Device>();
			}
			finally
			{
				theConnection.Close();
			}
		}
		
		public static List<Device> GetDevicesOnInvoice(int invoiceID)
		{
			if(theConnection.ConnectionString == string.Empty)
			{
				theConnection.ConnectionString = connectionString;
			}
			List<Device> theDevices = new List<Device>();
			Device theDevice;
			try
			{
				commandString = "select Invoice_Devices.*,assetID,name from Invoice_Devices join Devices on " +
					"Invoice_Devices.deviceID = Devices.deviceID where invoiceID = " + invoiceID;
				theConnection.Open();
				theCommand.Connection = theConnection;
				theCommand.CommandText = commandString;
				reader = theCommand.ExecuteReader();
				while (reader.Read())
				{
					theDevice = new Device();
					theDevice.DeviceName = reader["name"].ToString();
					theDevice.AssetID = reader["assetID"].ToString();
					theDevice.CPages = int.Parse(reader["colorPages"].ToString());
					theDevice.ID = int.Parse(reader["deviceID"].ToString());
					theDevice.LastActive = DateTime.Parse(reader["lastActive"].ToString());
					theDevice.LCEnd = int.Parse(reader["lifeCountEnd"].ToString());
					theDevice.LCStart = int.Parse(reader["lifeCountStart"].ToString());
					theDevice.MPages = int.Parse(reader["monoPages"].ToString());
					theDevice.Note = reader["notes"].ToString();
					theDevices.Add(theDevice);
				}
				return theDevices;
				
			}
			catch (MySqlException ex)
			{
				return new List<Device>();
			}
			finally
			{
				theConnection.Close();
			}
		}
		
		public static Dictionary<int,Device> GetInvoicesForDevice(int deviceID)
		{
			if(theConnection.ConnectionString == string.Empty)
			{
				theConnection.ConnectionString = connectionString;
			}
			Dictionary<int,Device> deviceBillings = new Dictionary<int, Device>();
			List<Device> theDevices = new List<Device>();
			Device theDevice;
			try
			{
				commandString = "select Invoice_Devices.*,assetID from Invoice_Devices join Devices on Invoice_Devices.deviceID = " +
					"Devices.deviceID where Invoice_Devices.deviceID = " + deviceID;
				theConnection.Open();
				theCommand.Connection = theConnection;
				theCommand.CommandText = commandString;
				reader = theCommand.ExecuteReader();
				while (reader.Read())
				{
					theDevice = new Device();
					theDevice.AssetID = reader["assetID"].ToString();
					theDevice.CPages = int.Parse(reader["colorPages"].ToString());
					theDevice.ID = int.Parse(reader["deviceID"].ToString());
					theDevice.LastActive = DateTime.Parse(reader["lastActive"].ToString());
					theDevice.LCEnd = int.Parse(reader["lifeCountEnd"].ToString());
					theDevice.LCStart = int.Parse(reader["lifeCountStart"].ToString());
					theDevice.MPages = int.Parse(reader["monoPages"].ToString());
					theDevice.Note = reader["notes"].ToString();
					deviceBillings.Add(int.Parse(reader["invoiceID"].ToString()),theDevice);
				}
				return deviceBillings;
				
			}
			catch (MySqlException ex)
			{
				return new Dictionary<int,Device>();
			}
			finally
			{
				theConnection.Close();
			}
		}
		#endregion
		
		#region Add Methods
		public static bool AddPO(PO thePO)
		{
			if(theConnection.ConnectionString == string.Empty)
			{
				theConnection.ConnectionString = connectionString;
			}
			try
			{
				theConnection.Open();
				theCommand.Connection = theConnection;
				
				commandString = "insert into POs (clientID,poMTNumber,amount)" +
					"Values(@clientID,@poMTNumber,@amount)";
				theCommand.CommandText = commandString;
				theCommand.Prepare();
				theCommand.Parameters.Clear();
				theCommand.Parameters.AddWithValue("@clientID",thePO.ClientID);
				theCommand.Parameters.AddWithValue("@poMTNumber",thePO.PONumber);
				theCommand.Parameters.AddWithValue("@amount",thePO.Amount);
				theCommand.ExecuteNonQuery();
				return true;
			}
			catch(MySqlException ex)
			{
				return false;
			}
			finally
			{
				theConnection.Close();
			}
		}
		
		public static bool AddPOTransaction(POTransaction theTransaction)
		{
			if(theConnection.ConnectionString == string.Empty)
			{
				theConnection.ConnectionString = connectionString;
			}
			try
			{
				theConnection.Open();
				theCommand.Connection = theConnection;
				
				commandString = "insert into PO_Transactions (poID,amount,date) Values(@poID,@amount, @date)";
				theCommand.CommandText = commandString;
				theCommand.Prepare();
				
				theCommand.Parameters.Clear();
				theCommand.Parameters.AddWithValue("@poID",theTransaction.POID);
				theCommand.Parameters.AddWithValue("@amount",theTransaction.Amount);
				string day;
				string month;
				string date;
				if(theTransaction.Date.Day<10)
				{
					day = "0" + theTransaction.Date.Day;
				}
				else
				{
					day = theTransaction.Date.Day.ToString();
				}
				if(theTransaction.Date.Month<10)
				{
					month = "0" + theTransaction.Date.Month;
				}
				else
				{
					month = theTransaction.Date.Month.ToString();
				}
				date = theTransaction.Date.Year + "-" + month + "-" + day;
				theCommand.Parameters.AddWithValue("@date",theTransaction.Date);
				theCommand.ExecuteNonQuery();
				
				return true;
			}
			catch(MySqlException ex)
			{
				return false;
			}
			finally
			{
				theConnection.Close();
			}
		}
		
		public static bool AddInvoice(Invoice theInvoice)
		{
			if(theConnection.ConnectionString == string.Empty)
			{
				theConnection.ConnectionString = connectionString;
			}
			try
			{
				theConnection.Open();
				theCommand.Connection = theConnection;
				
				commandString = "insert into Invoices (clientID,amount,date,invoiceMTNumber,poMTNumber)" +
					"Values(@clientID,@amount,@date,@invoiceMTNumber,@poMTNumber)";
				theCommand.CommandText = commandString;
				theCommand.Prepare();
				theCommand.Parameters.Clear();
				theCommand.Parameters.AddWithValue("@clientID",1111);
				theCommand.Parameters.AddWithValue("@amount",111111.11);
				theCommand.Parameters.AddWithValue("@date",DateTime.Now.ToShortDateString());
				theCommand.Parameters.AddWithValue("@invoiceMTNumber",111111);
				theCommand.Parameters.AddWithValue("@poMTNumber","the po");
				theCommand.Parameters["@clientID"].Value = theInvoice.ClientID;
				theCommand.Parameters["@amount"].Value = theInvoice.Amount;
				string day;
				string month;
				if(theInvoice.Date.Day<10)
				{
					day = "0" + theInvoice.Date.Day;
				}
				else
				{
					day = theInvoice.Date.Day.ToString();
				}
				if(theInvoice.Date.Month<10)
				{
					month = "0" + theInvoice.Date.Month;
				}
				else
				{
					month = theInvoice.Date.Month.ToString();
				}
				string date = theInvoice.Date.Year + "-" + month + "-" + day;
				theCommand.Parameters["@date"].Value = date;
				theCommand.Parameters["@invoiceMTNumber"].Value = theInvoice.MacsTracID;
				theCommand.Parameters["@poMTNumber"].Value = theInvoice.PONumber;
				theCommand.ExecuteNonQuery();
				
				return true;
			}
			catch(MySqlException ex)
			{
				return false;
			}
			finally
			{
				theConnection.Close();
			}
		}
		
		public static bool AddInvoiceDevices(int invoiceID, List<Device> devices)
		{
			if(theConnection.ConnectionString == string.Empty)
			{
				theConnection.ConnectionString = connectionString;
			}
			try
			{
				theConnection.Open();
				theCommand.Connection = theConnection;
				List<Device> deviceIDs = new List<Device>();
				commandString = "select deviceID,name,serialNumber,assetID from Devices";
				theCommand.CommandText = commandString;
				reader = theCommand.ExecuteReader();
				Device theDevice;
				while(reader.Read())
				{
					theDevice = new Device();
					theDevice.ID = int.Parse(reader["deviceID"].ToString());
					theDevice.DeviceName = reader["name"].ToString();
					theDevice.SerialNumber = reader["serialNumber"].ToString();
					theDevice.AssetID = reader["assetID"].ToString();
					deviceIDs.Add(theDevice);
				}
				reader.Close();
				commandString = "insert into Invoice_Devices (invoiceID,deviceID,lifeCountStart,lifeCountEnd,colorPages,monoPages," +
					"lastActive,notes)" + " Values (@invoiceID,@deviceID,@lifeCountStart,@lifeCountEnd,@colorPages,@monoPages,@lastActive,@notes)";
				theCommand.CommandText = commandString;
				theCommand.Prepare();
				
				theCommand.Parameters.Clear();
				theCommand.Parameters.AddWithValue("@invoiceID",111111);
				theCommand.Parameters.AddWithValue("@notes","the notes");
				theCommand.Parameters.AddWithValue("@deviceID",111111);
				theCommand.Parameters.AddWithValue("@colorPages",111111);
				theCommand.Parameters.AddWithValue("@monoPages",111111);
				theCommand.Parameters.AddWithValue("@lifeCountStart",111111);
				theCommand.Parameters.AddWithValue("@lifeCountEnd",111111);
				theCommand.Parameters.AddWithValue("@lastActive",DateTime.Now.ToShortDateString());
				string day;
				string month;
				string date;
				for(int i = 0;i<devices.Count;i++)
				{
					theCommand.Parameters["@invoiceID"].Value = invoiceID;
					if(!deviceIDs.Exists(delegate(Device tempDevice)
					                     {
					                     	return (tempDevice.DeviceName == devices[i].DeviceName &&
					                     	        tempDevice.AssetID == devices[i].AssetID &&
					                     	        tempDevice.SerialNumber == devices[i].SerialNumber);
					                     }))
					{
						MySqlCommand com2 = new MySqlCommand();
						com2.Connection = theConnection;
						com2.CommandText = "select clientID from Invoices where invoiceID = " invoiceID;
						MySqlDataReader reader2 = com2.ExecuteReader();
						reader2.Read();
						int tempID = int.Parse(reader2["clientID"].ToString());
						reader2.Close();
						AddDevice(devices[i],tempID);
					}
					theCommand.Parameters["@deviceID"].Value = deviceIDs.Single(delegate(Device tempDevice)
					                                                            {
					                                                            	return (tempDevice.DeviceName == devices[i].DeviceName &&
					                                                            	        tempDevice.AssetID == devices[i].AssetID &&
					                                                            	        tempDevice.SerialNumber == devices[i].SerialNumber);
					                                                            }).ID;
					theCommand.Parameters["@colorPages"].Value = devices[i].CPages;
					theCommand.Parameters["@monoPages"].Value = devices[i].MPages;
					theCommand.Parameters["@lifeCountStart"].Value = devices[i].LCStart;
					theCommand.Parameters["@lifeCountEnd"].Value = devices[i].LCEnd;
					if(devices[i].LastActive.Date.Day<10)
					{
						day = "0" + devices[i].LastActive.Day;
					}
					else
					{
						day = devices[i].LastActive.Day.ToString();
					}
					if(devices[i].LastActive.Date.Month<10)
					{
						month = "0" + devices[i].LastActive.Month;
					}
					else
					{
						month = devices[i].LastActive.Month.ToString();
					}
					date = devices[i].LastActive.Date.Year + "-" + month + "-" + day;
					theCommand.Parameters["@lastActive"].Value = date;
					theCommand.Parameters["@notes"].Value = devices[i].Note;
					theCommand.ExecuteNonQuery();
				}
				return true;
			}
			catch(MySqlException ex)
			{
				return false;
			}
			finally
			{
				theConnection.Close();
			}
		}
		
		public static bool AddDevices(List<Device> devices, int clientID)
		{
			foreach (var theDevice in devices)
			{
				if(!AddDevice(theDevice,clientID))
				{
					return false;
				}
			}
			return true;
		}
		
		public static bool AddDevice(Device theDevice, int clientID)
		{
			if(theConnection.ConnectionString == string.Empty)
			{
				theConnection.ConnectionString = connectionString;
			}
			try
			{
				theConnection.Open();
				theCommand.Connection = theConnection;
				commandString = "insert into Devices (clientID,oem,type,netStatus,site,name,serialNumber,assetID,colorPages,monoPages," +
					"lifeCountStart,lifeCountEnd,lastActive,department) " + "Values(@clientID,@oem,@type,@netStatus,@site,@name,@serialNumber," +
					"@assetID,@colorPages,@monoPages,@lifeCountStart,@lifeCountEnd,@lastActive,@department)";
				theCommand.CommandText = commandString;
				theCommand.Prepare();
				
				theCommand.Parameters.Clear();
				theCommand.Parameters.AddWithValue("@clientID",111111);
				theCommand.Parameters.AddWithValue("@oem",true);
				theCommand.Parameters.AddWithValue("@type",true);
				theCommand.Parameters.AddWithValue("@netStatus",true);
				theCommand.Parameters.AddWithValue("@site","the site");
				theCommand.Parameters.AddWithValue("@name","the name");
				theCommand.Parameters.AddWithValue("@serialNumber","the serial number");
				theCommand.Parameters.AddWithValue("@assetID","the asset ID");
				theCommand.Parameters.AddWithValue("@colorPages",111111);
				theCommand.Parameters.AddWithValue("@monoPages",111111);
				theCommand.Parameters.AddWithValue("@lifeCountStart",111111);
				theCommand.Parameters.AddWithValue("@lifeCountEnd",111111);
				theCommand.Parameters.AddWithValue("@lastActive",DateTime.Now.ToShortDateString());
				theCommand.Parameters.AddWithValue("@department","the department");
				theCommand.Parameters["@clientID"].Value = theDevice.ClientID;
				theCommand.Parameters["@oem"].Value = theDevice.OEM;
				theCommand.Parameters["@type"].Value = theDevice.PrinterType;
				theCommand.Parameters["@netStatus"].Value = theDevice.Networked;
				theCommand.Parameters["@site"].Value = theDevice.Site;
				theCommand.Parameters["@name"].Value = theDevice.DeviceName;
				theCommand.Parameters["@serialNumber"].Value = theDevice.SerialNumber;
				theCommand.Parameters["@assetID"].Value = theDevice.AssetID;
				theCommand.Parameters["@colorPages"].Value = theDevice.CPages;
				theCommand.Parameters["@monoPages"].Value = theDevice.MPages;
				theCommand.Parameters["@lifeCountStart"].Value = theDevice.LCStart;
				theCommand.Parameters["@lifeCountEnd"].Value = theDevice.LCEnd;
				string day;
				string month;
				if(theDevice.LastActive.Date.Day<10)
				{
					day = "0" + theDevice.LastActive.Day;
				}
				else
				{
					day = theDevice.LastActive.Day.ToString();
				}
				if(theDevice.LastActive.Date.Month<10)
				{
					month = "0" + theDevice.LastActive.Month;
				}
				else
				{
					month = theDevice.LastActive.Month.ToString();
				}
				string date = theDevice.LastActive.Date.Year + "-" + month + "-" + day;
				theCommand.Parameters["@lastActive"].Value = date;
				theCommand.Parameters["@department"].Value = theDevice.Department;
				theCommand.ExecuteNonQuery();
				return true;
			}
			catch(MySqlException ex)
			{
				return false;
			}
			finally
			{
				theConnection.Close();
			}
		}
		
		public static bool AddClients(List<Client> clients)
		{
			foreach (var theClient in clients)
			{
				if(!AddClient(theClient))
				{
					return false;
				}
			}
			return true;
		}
		
		public static bool AddClient(Client theClient)
		{
			if(theConnection.ConnectionString == string.Empty)
			{
				theConnection.ConnectionString = connectionString;
			}
			try
			{
				int theID = theClient.MacsTracID;
				theConnection.Open();
				theCommand.Connection = theConnection;
				commandString = "insert into Clients (clientName,clientMTID,cocPrice,mocPrice,monoPrice," +
					"cocOEMPrice,mocOEMPrice,monoOEMPrice) Values(@name,@MTID,@cocPrice,@mocPrice,@monoPrice,@cocOEMPrice,@mocOEMPrice,@monoOEMPrice)";
				theCommand.CommandText = commandString;
				theCommand.Prepare();
				
				theCommand.Parameters.Clear();
				theCommand.Parameters.AddWithValue("@name","client name");
				theCommand.Parameters.AddWithValue("@MTID",1);
				theCommand.Parameters.AddWithValue("@cocPrice",0.0000);
				theCommand.Parameters.AddWithValue("@mocPrice",0.0000);
				theCommand.Parameters.AddWithValue("@monoPrice",0.0000);
				theCommand.Parameters.AddWithValue("@cocOEMPrice",0.0000);
				theCommand.Parameters.AddWithValue("@mocOEMPrice",0.0000);
				theCommand.Parameters.AddWithValue("@monoOEMPrice",0.0000);
				
				theCommand.Parameters["@name"].Value = theClient.Name;
				theCommand.Parameters["@MTID"].Value = theClient.MacsTracID;
				theCommand.Parameters["@cocPrice"].Value = theClient.CPrice;
				theCommand.Parameters["@mocPrice"].Value = theClient.MoCPrice;
				theCommand.Parameters["@monoPrice"].Value = theClient.MPrice;
				theCommand.Parameters["@cocOEMPrice"].Value = theClient.COEMPrice;
				theCommand.Parameters["@mocOEMPrice"].Value = theClient.MoCOEMPrice;
				theCommand.Parameters["@monoOEMPrice"].Value = theClient.MOEMPrice;
				theCommand.ExecuteNonQuery();
				return true;
			}
			catch(MySqlException ex)
			{
				return false;
			}
			finally
			{
				theConnection.Close();
			}
		}
		#endregion
		
		#region Update Methods
		public static bool UpdateInvoice(Invoice theInvoice)
		{
			if(theConnection.ConnectionString == string.Empty)
			{
				theConnection.ConnectionString = connectionString;
			}
			try
			{
				theConnection.Open();
				theCommand.Connection = theConnection;
				
				commandString = "update Invoices set clientID = @clientID,amount = @amount,date = @date,invoiceMTNumber = @invoiceMTNumber," +
					"poMTNumber = @poMTNumber where invoiceID = " + theInvoice.ID;
				theCommand.CommandText = commandString;
				theCommand.Prepare();
				
				theCommand.Parameters.Clear();
				theCommand.Parameters.AddWithValue("@clientID",1111);
				theCommand.Parameters.AddWithValue("@amount",111111.11);
				theCommand.Parameters.AddWithValue("@date",DateTime.Now.ToShortDateString());
				theCommand.Parameters.AddWithValue("@invoiceMTNumber",111111);
				theCommand.Parameters.AddWithValue("@poMTNumber","the po");
				theCommand.Parameters["@clientID"].Value = theInvoice.ClientID;
				theCommand.Parameters["@amount"].Value = theInvoice.Amount;
				string day;
				string month;
				if(theInvoice.Date.Day<10)
				{
					day = "0" + theInvoice.Date.Day;
				}
				else
				{
					day = theInvoice.Date.Day.ToString();
				}
				if(theInvoice.Date.Month<10)
				{
					month = "0" + theInvoice.Date.Month;
				}
				else
				{
					month = theInvoice.Date.Month.ToString();
				}
				string date = theInvoice.Date.Year + "-" + month + "-" + day;
				theCommand.Parameters["@date"].Value = date;
				theCommand.Parameters["@invoiceMTNumber"].Value = theInvoice.MacsTracID;
				theCommand.Parameters["@poMTNumber"].Value = theInvoice.PONumber;
				theCommand.ExecuteNonQuery();
				
				return true;
			}
			catch(MySqlException ex)
			{
				return false;
			}
			finally
			{
				theConnection.Close();
			}
		}
		
		public static bool UpdateInvoiceDevice(int invoiceID,Device theDevice)
		{
			if(theConnection.ConnectionString == string.Empty)
			{
				theConnection.ConnectionString = connectionString;
			}
			try
			{
				theConnection.Open();
				theCommand.Connection = theConnection;
				commandString = "update Invoice_Devices set lifeCountStart = @lifeCountStart, lifeCountEnd = @lifeCountEnd," +
					"colorPages = @colorPages,monoPages = @monoPages, lastActive = @lastActive, notes = @notes where deviceID = " + theDevice.ID + " and invoiceID = " + invoiceID;
				theCommand.CommandText = commandString;
				theCommand.Prepare();
				
				theCommand.Parameters.Clear();
				theCommand.Parameters.AddWithValue("@colorPages",111111);
				theCommand.Parameters.AddWithValue("@monoPages",111111);
				theCommand.Parameters.AddWithValue("@lifeCountStart",111111);
				theCommand.Parameters.AddWithValue("@lifeCountEnd",111111);
				theCommand.Parameters.AddWithValue("@lastActive",DateTime.Now.ToShortDateString());
				theCommand.Parameters.AddWithValue("@notes","the notes");
				theCommand.Parameters["@colorPages"].Value = theDevice.CPages;
				theCommand.Parameters["@monoPages"].Value = theDevice.MPages;
				theCommand.Parameters["@lifeCountStart"].Value = theDevice.LCStart;
				theCommand.Parameters["@lifeCountEnd"].Value = theDevice.LCEnd;
				string day;
				string month;
				if(theDevice.LastActive.Date.Day<10)
				{
					day = "0" + theDevice.LastActive.Day;
				}
				else
				{
					day = theDevice.LastActive.Day.ToString();
				}
				if(theDevice.LastActive.Date.Month<10)
				{
					month = "0" + theDevice.LastActive.Month;
				}
				else
				{
					month = theDevice.LastActive.Month.ToString();
				}
				string date = theDevice.LastActive.Date.Year + "-" + month + "-" + day;
				theCommand.Parameters["@lastActive"].Value = date;
				theCommand.Parameters["@notes"].Value = theDevice.Note;
				theCommand.ExecuteNonQuery();
				return true;
			}
			catch(MySqlException ex)
			{
				return false;
			}
			finally
			{
				theConnection.Close();
			}
		}
		
		public static bool UpdateClientDevice(Device theDevice)
		{
			if(theConnection.ConnectionString == string.Empty)
			{
				theConnection.ConnectionString = connectionString;
			}
			try
			{
				theConnection.Open();
				theCommand.Connection = theConnection;
				commandString = "update Devices set clientID = @clientID,oem = @oem,type = @type,netStatus = @netStatus," +
					"site = @site,name = @name,serialNumber = @serialNumber,assetID = @assetID,colorPages = @colorPages,"+
					"monoPages = @monoPages where deviceID = " + theDevice.ID;
				theCommand.CommandText = commandString;
				theCommand.Prepare();
				
				theCommand.Parameters.Clear();
				theCommand.Parameters.AddWithValue("@clientID",111111);
				theCommand.Parameters.AddWithValue("@oem",true);
				theCommand.Parameters.AddWithValue("@type",true);
				theCommand.Parameters.AddWithValue("@netStatus",true);
				theCommand.Parameters.AddWithValue("@site","the site");
				theCommand.Parameters.AddWithValue("@name","the name");
				theCommand.Parameters.AddWithValue("@serialNumber","the serial number");
				theCommand.Parameters.AddWithValue("@assetID","the asset ID");
				theCommand.Parameters.AddWithValue("@colorPages",111111);
				theCommand.Parameters.AddWithValue("@monoPages",111111);
				theCommand.Parameters.AddWithValue("@lifeCountStart",111111);
				theCommand.Parameters.AddWithValue("@lifeCountEnd",111111);
				theCommand.Parameters.AddWithValue("@lastActive",DateTime.Now.ToShortDateString());
				theCommand.Parameters.AddWithValue("@department","the department");
				theCommand.Parameters["@clientID"].Value = theDevice.ClientID;
				theCommand.Parameters["@oem"].Value = theDevice.OEM;
				theCommand.Parameters["@type"].Value = theDevice.PrinterType;
				theCommand.Parameters["@netStatus"].Value = theDevice.Networked;
				theCommand.Parameters["@site"].Value = theDevice.Site;
				theCommand.Parameters["@name"].Value = theDevice.DeviceName;
				theCommand.Parameters["@serialNumber"].Value = theDevice.SerialNumber;
				theCommand.Parameters["@assetID"].Value = theDevice.AssetID;
				theCommand.Parameters["@colorPages"].Value = theDevice.CPages;
				theCommand.Parameters["@monoPages"].Value = theDevice.MPages;
				theCommand.Parameters["@lifeCountStart"].Value = theDevice.LCStart;
				theCommand.Parameters["@lifeCountEnd"].Value = theDevice.LCEnd;
				string day;
				string month;
				if(theDevice.LastActive.Date.Day<10)
				{
					day = "0" + theDevice.LastActive.Day;
				}
				else
				{
					day = theDevice.LastActive.Day.ToString();
				}
				if(theDevice.LastActive.Date.Month<10)
				{
					month = "0" + theDevice.LastActive.Month;
				}
				else
				{
					month = theDevice.LastActive.Month.ToString();
				}
				string date = theDevice.LastActive.Date.Year + "-" + month + "-" + day;
				theCommand.Parameters["@lastActive"].Value = date;
				theCommand.Parameters["@department"].Value = theDevice.Department;
				theCommand.ExecuteNonQuery();
				return true;
			}
			catch(MySqlException ex)
			{
				return false;
			}
			finally
			{
				theConnection.Close();
			}
		}
		
		public static bool UpdateClient(Client theClient)
		{
			if(theConnection.ConnectionString == string.Empty)
			{
				theConnection.ConnectionString = connectionString;
			}
			try
			{
				int theID = theClient.MacsTracID;
				theConnection.Open();
				theCommand.Connection = theConnection;
				commandString = "update Clients set clientName = @name,clientMTID = @MTID,cocPrice = @cocPrice,mocPrice = @mocPrice,monoPrice = @monoPrice," +
					"cocOEMPrice = @cocOEMPrice,mocOEMPrice = @mocOEMPrice,monoOEMPrice = @monoOEMPrice where clientMTID = " + theID;
				theCommand.CommandText = commandString;
				theCommand.Prepare();
				
				theCommand.Parameters.Clear();
				theCommand.Parameters.AddWithValue("@name","client name");
				theCommand.Parameters.AddWithValue("@MTID",1);
				theCommand.Parameters.AddWithValue("@cocPrice",0.0000);
				theCommand.Parameters.AddWithValue("@mocPrice",0.0000);
				theCommand.Parameters.AddWithValue("@monoPrice",0.0000);
				theCommand.Parameters.AddWithValue("@cocOEMPrice",0.0000);
				theCommand.Parameters.AddWithValue("@mocOEMPrice",0.0000);
				theCommand.Parameters.AddWithValue("@monoOEMPrice",0.0000);
				
				theCommand.Parameters["@name"].Value = theClient.Name;
				theCommand.Parameters["@MTID"].Value = theClient.MacsTracID;
				theCommand.Parameters["@cocPrice"].Value = theClient.CPrice;
				theCommand.Parameters["@mocPrice"].Value = theClient.MoCPrice;
				theCommand.Parameters["@monoPrice"].Value = theClient.MPrice;
				theCommand.Parameters["@cocOEMPrice"].Value = theClient.COEMPrice;
				theCommand.Parameters["@mocOEMPrice"].Value = theClient.MoCOEMPrice;
				theCommand.Parameters["@monoOEMPrice"].Value = theClient.MOEMPrice;
				theCommand.ExecuteNonQuery();
				return true;
			}
			catch(MySqlException ex)
			{
				return false;
			}
			finally
			{
				theConnection.Close();
			}
		}
		
		public static bool UpdatePO(PO thePO)
		{
			if(theConnection.ConnectionString == string.Empty)
			{
				theConnection.ConnectionString = connectionString;
			}
			try
			{
				theConnection.Open();
				theCommand.Connection = theConnection;
				commandString = "update POs set poMTNumber = @poMTNumber,amount = @amount where poID = " + thePO.ID;
				theCommand.CommandText = commandString;
				theCommand.Prepare();
				
				theCommand.Parameters.Clear();
				theCommand.Parameters.AddWithValue("@poMTNumber",thePO.PONumber);
				theCommand.Parameters.AddWithValue("@amount",thePO.Amount);
				theCommand.ExecuteNonQuery();
				return true;
			}
			catch(MySqlException ex)
			{
				return false;
			}
			finally
			{
				theConnection.Close();
			}
		}
		
		public static bool UpdatePOTransaction(POTransaction theTransaction)
		{
			if(theConnection.ConnectionString == string.Empty)
			{
				theConnection.ConnectionString = connectionString;
			}
			try
			{
				theConnection.Open();
				theCommand.Connection = theConnection;
				commandString = "update PO_Transactions set amount = @amount,date = @date where poID = " + theTransaction.POID;
				theCommand.CommandText = commandString;
				theCommand.Prepare();
				
				theCommand.Parameters.Clear();
				theCommand.Parameters.AddWithValue("@date",theTransaction.Date);
				theCommand.Parameters.AddWithValue("@amount",theTransaction.Amount);
				theCommand.ExecuteNonQuery();
				return true;
			}
			catch(MySqlException ex)
			{
				return false;
			}
			finally
			{
				theConnection.Close();
			}
		}
		#endregion
	}
}
