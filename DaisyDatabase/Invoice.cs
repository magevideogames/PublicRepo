/*
 * Created by SharpDevelop.
 * User: Mage
 * Date: 6/10/2015
 * Time: 12:45 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace WIPDatabase
{
	/// <summary>
	/// Description of Invoice.
	/// </summary>
	public class Invoice
	{
		public Invoice()
		{
		}
		
		public int ID { get; set; }
		public int ClientID { get; set; }
		public int MacsTracID { get; set; }
		public decimal Amount { get; set; }
		public DateTime Date { get; set; }
		public string PONumber { get; set; }
	}
}
