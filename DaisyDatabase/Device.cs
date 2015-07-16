/*
 * Created by SharpDevelop.
 * User: Mage
 * Date: 6/10/2015
 * Time: 12:47 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace WIPDatabase
{
	/// <summary>
	/// Description of Device.
	/// </summary>
	public class Device
	{
		public Device()
		{
		}
		
		public int ID { get; set; }
		public int ClientID { get; set; }
		public bool OEM { get; set; }
		public bool PrinterType { get; set; }
		public bool Networked { get; set; }
		public string Site { get; set; }
		public string DeviceName { get; set; }
		public string SerialNumber { get; set; }
		public string AssetID { get; set; }
		public int CPages { get; set; }
		public int MPages { get; set; }
		public int LCStart { get; set; }
		public int LCEnd { get; set; }
		public DateTime LastActive { get; set; }
		public string Department { get; set; }
		public string Note { get; set; }
		
	}
}
