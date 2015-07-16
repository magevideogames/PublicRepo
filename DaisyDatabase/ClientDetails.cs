/*
 * Created by SharpDevelop.
 * User: Mage
 * Date: 6/18/2015
 * Time: 11:26 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace WIPDatabase
{
	/// <summary>
	/// Description of ClientDetails.
	/// </summary>
	public partial class ClientDetails : Form
	{
		public Client TheClient { get; set; }
		public ClientDetails(Client passedClient)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			TheClient = passedClient;
			LoadClient();
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void BtnEditClick(object sender, EventArgs e)
		{
			if(btnEdit.Text == "Edit")
			{
				btnCancel.Visible = true;
				gbxOEM.Enabled = true;
				gbxStandard.Enabled = true;
				tbxClient.Enabled = true;
				nudMTID.Enabled = true;
				btnEdit.Text = "Save";
			}
			else
			{
				btnEdit.Text = "Edit";
				btnCancel.Visible = false;
				gbxOEM.Enabled = false;
				gbxStandard.Enabled = false;
				tbxClient.Enabled = false;
				nudMTID.Enabled = false;
				TheClient.Name = tbxClient.Text;
				TheClient.MacsTracID = int.Parse(nudMTID.Value.ToString());
				TheClient.CPrice = nudCPrice.Value;
				TheClient.MoCPrice = nudMoCPrice.Value;
				TheClient.MPrice = nudMPrice.Value;
				TheClient.COEMPrice = nudCOEMPrice.Value;
				TheClient.MoCOEMPrice = nudMoCOEMPrice.Value;
				TheClient.MOEMPrice = nudMOEMPrice.Value;
				Model.UpdateClient(TheClient);
			}
		}
		
		void BtnCancelClick(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}
		
		void LoadClient()
		{
			tbxClient.Text = TheClient.Name;
			nudMTID.Value = TheClient.MacsTracID;
			nudCPrice.Value = TheClient.CPrice;
			nudMoCPrice.Value = TheClient.MoCPrice;
			nudMPrice.Value = TheClient.MPrice;
			nudCOEMPrice.Value = TheClient.COEMPrice;
			nudMoCOEMPrice.Value = TheClient.MoCOEMPrice;
			nudMOEMPrice.Value = TheClient.MOEMPrice;
		}
		
		void BtnDevicesClick(object sender, EventArgs e)
		{
			DevicesForm dfForm = new DevicesForm(TheClient.ID,false);
			dfForm.Enabled = true;
			dfForm.ShowDialog();
		}
		
		void BtnInvoicesClick(object sender, EventArgs e)
		{
			InvoiceDetails idForm = new InvoiceDetails(TheClient.ID,TheClient.MacsTracID);
			idForm.ShowDialog();
		}
		
		void BtnPOsClick(object sender, EventArgs e)
		{
			POsForm poForm = new POsForm(TheClient.ID);
			poForm.ShowDialog();
		}
	}
}
