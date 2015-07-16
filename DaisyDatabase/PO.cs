/*
 * Created by SharpDevelop.
 * User: Mage
 * Date: 6/10/2015
 * Time: 12:46 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace WIPDatabase
{
	/// <summary>
	/// Description of PO.
	/// </summary>
	public class PO
	{
		public PO()
		{
		}
		
		public int ID { get; set; }
		public int ClientID { get; set; }
		public string PONumber { get; set; }
		public decimal Amount { get; set; }
		public List<POTransaction> Transactions { get; set; }
	}
}
