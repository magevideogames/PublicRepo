/*
 * Created by SharpDevelop.
 * User: Mage
 * Date: 6/10/2015
 * Time: 11:13 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WIPDatabase
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void ViewClientsToolStripMenuItemClick(object sender, EventArgs e)
		{
			ClientsForm cForm = new ClientsForm();
			cForm.MdiParent = this;
			cForm.Show();
		}
		
		void CreateReportToolStripMenuItemClick(object sender, EventArgs e)
		{
			ReportsForm rForm = new ReportsForm();
			rForm.MdiParent = this;
			rForm.Show();
		}
	}
}
