/*
 * Created by SharpDevelop.
 * User: WIP00
 * Date: 6/25/2015
 * Time: 11:43 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace WIPDatabase
{
	/// <summary>
	/// Description of POTransaction.
	/// </summary>
	public class POTransaction
	{
		public POTransaction()
		{
		}
		
		public int POID { get; set; }
		public DateTime Date { get; set; }
		public decimal Amount { get; set; }
	}
}
