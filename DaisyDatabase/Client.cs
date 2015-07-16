/*
 * Created by SharpDevelop.
 * User: Mage
 * Date: 6/10/2015
 * Time: 12:43 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace WIPDatabase
{
	/// <summary>
	/// Description of Client.
	/// </summary>
	public class Client
	{
		public Client()
		{
		}
		public string Name { get; set; }
		public int ID { get; set; }
		public int MacsTracID { get; set; }
		public decimal CPrice { get; set; }
		public decimal MoCPrice { get; set; }
		public decimal MPrice { get; set; }
		public decimal COEMPrice { get; set; }
		public decimal MoCOEMPrice { get; set; }
		public decimal MOEMPrice { get; set; }
	}
}
