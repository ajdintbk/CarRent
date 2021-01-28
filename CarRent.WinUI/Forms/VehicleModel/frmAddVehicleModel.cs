using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRent.WinUI.Forms.VehicleModel
{
    public partial class frmAddVehicleModel : Form
    {
        protected APIService _serviceVehicleModel = new APIService("VehicleModel");
        private Task<List<Model.VehicleModel>> modelList;
        public frmAddVehicleModel()
        {
            InitializeComponent();
            modelList = _serviceVehicleModel.Get<List<Model.VehicleModel>>();
        }
        Model.Requests.VehicleModel.VehicleModelInsert req = new Model.Requests.VehicleModel.VehicleModelInsert();
        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtName.Text))
            {
                foreach (var item in modelList.Result)
                {
                    if(item.Name.ToLowerInvariant() == txtName.Text.ToLowerInvariant())
                    {
                        MessageBox.Show("Vehicle model already exists!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                req.Name = txtName.Text;
                await _serviceVehicleModel.Insert<Model.VehicleModel>(req);
                var msg = MessageBox.Show("Vehicle model sucessfully added!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if(msg == DialogResult.OK)
                {
                    this.Close();
                }

            }
        }
    }
}
