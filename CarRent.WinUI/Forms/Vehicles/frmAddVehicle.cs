using CarRent.WinUI.Forms.Rents;
using CarRent.WinUI.Forms.VehicleModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRent.WinUI.Forms.Vehicles
{
    public partial class frmAddVehicle : Form
    {
        protected APIService _serviceFuelType = new APIService("Fuel");
        protected APIService _serviceVehicleModel= new APIService("VehicleModel");
        protected APIService _serviceBrand = new APIService("Brand");
        protected APIService _serviceVehicle = new APIService("Vehicle");
        protected readonly int EditId = 0;
        protected Model.Vehicle editVehicle = new Model.Vehicle();

        public frmAddVehicle()
        {
            InitializeComponent();
        }

        public frmAddVehicle(int id) : this()
        {
            this.EditId = id;
        }

        private async Task GetFuel()
        {
            var list = await _serviceFuelType.Get<List<Model.Fuel>>();
            list.Insert(0, new Model.Fuel()
            {
                Name = "Choose fuel"
            });
            cmbFuel.ValueMember = "Id";
            cmbFuel.DisplayMember = "Name";

            cmbFuel.DataSource = list;
        }

        private async Task GetBrand()
        {
            var list = await _serviceBrand.Get<List<Model.Brand>>();
            list.Insert(0, new Model.Brand()
            {
                Name = "Choose brand"
            });

            cmbBrand.ValueMember = "Id";
            cmbBrand.DisplayMember = "Name";

            cmbBrand.DataSource = list;
        }
        private void GetTransmission()
        {
            var list = new List<Model.Transmission>();
            list.Insert(0, new Model.Transmission()
            {
                Name = "Choose transmission"
            });

            list.Insert(1, new Model.Transmission()
            {
                Name = "Automatic"
            });

            list.Insert(2, new Model.Transmission()
            {
                Name = "Manual"
            });

            cbTransmission.ValueMember = "Name";
            cbTransmission.DisplayMember = "Name";

            cbTransmission.DataSource = list;
        }

        private async Task GetModel()
        {
            var list = await _serviceVehicleModel.Get<List<Model.VehicleModel>>();
            list.Insert(0, new Model.VehicleModel()
            {
                Name = "Choose model"
            });

            cmbModel.ValueMember = "Id";
            cmbModel.DisplayMember = "Name";

            cmbModel.DataSource = list;
        }

        private static Image GetImage(byte[] data)
        {
            using (MemoryStream ms = new MemoryStream(data))
            {
                return (Image.FromStream(ms));
            }
        }

        public void LockControlValues(System.Windows.Forms.Control Container)
        {
            try
            {
                foreach (Control ctrl in Container.Controls)
                {
                    if (ctrl.GetType() == typeof(TextBox))
                        ((TextBox)ctrl).ReadOnly = true;
                    if (ctrl.GetType() == typeof(ComboBox))
                        ((ComboBox)ctrl).Enabled = false;
                    if (ctrl.GetType() == typeof(CheckBox))
                        ((CheckBox)ctrl).Enabled = false;

                    if(ctrl.GetType() == typeof(RichTextBox))
                        ((RichTextBox)ctrl).Enabled = false;

                    if (ctrl.GetType() == typeof(DateTimePicker))
                        ((DateTimePicker)ctrl).Enabled = false;
                    
                    if (ctrl.Controls.Count > 0)
                        LockControlValues(ctrl);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private async void frmAddVehicle_Load(object sender, EventArgs e)
        {
            if(APIService.loggedUser.RoleId == 2)
            {
                LockControlValues(this);
                btnImage.Visible = false;
                btnSave.Text = "Rent";
            }
            pictureBox1.Image = null;
            if(EditId != 0)
            {
                editVehicle = await _serviceVehicle.GetById<Model.Vehicle>(EditId);
                txtName.Text = editVehicle.Name;
                txtPrice.Text = editVehicle.Price.ToString();
                txtSeats.Text = editVehicle.NumberOfSeats.ToString();
                txtYear.Text = editVehicle.YearManufactured.ToString();
                rtxtDesc.Text = editVehicle.Description;
                cbActive.Checked = editVehicle.IsActive.Value;
                if (editVehicle.Image.Length>0)
                {
                    pictureBox1.Image = GetImage(editVehicle.Image);
                }
                await GetBrand();
                await GetFuel();
                await GetModel();
                GetTransmission();
                cmbFuel.SelectedIndex = editVehicle.Fuel.Id;
                cmbModel.SelectedIndex = editVehicle.VehicleModel.Id;
                cmbBrand.SelectedIndex = editVehicle.Brand.Id;
                
                if(editVehicle.Transmission.StartsWith("Automatic"))
                    cbTransmission.SelectedIndex = 1;
                else if (editVehicle.Transmission.StartsWith("Manual"))
                    cbTransmission.SelectedIndex = 2;
                else cbTransmission.SelectedIndex = 0;
            }
            else
            {
                await GetFuel();
                await GetBrand();
                await GetModel();
                GetTransmission();
            }
        }

        Model.Requests.Vehicle.VehicleInsert request = new Model.Requests.Vehicle.VehicleInsert();
        private bool Validate(Control obj)
        {
            if(obj is ComboBox && int.Parse((obj as ComboBox).SelectedValue.ToString()) == 0)
            {
                err.SetError(obj, "This field is required!");
                obj.Focus();
                return false;
            }else if(obj is TextBox && string.IsNullOrWhiteSpace((obj as TextBox).Text))
            {
                err.SetError(obj, "This field is required!");
                return false;
            }
            err.Clear();
            return true;
        }
        private async void btnSave_Click(object sender, EventArgs e)
        {
            if(APIService.loggedUser.RoleId == 2)
            {
                if (!editVehicle.IsActive.Value)
                {
                    MessageBox.Show("Can not rent vehicle that is not active.", "Status", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
                else
                {

                frmRentCar frm = new frmRentCar(editVehicle.Id,editVehicle.Price);
                frm.ShowDialog();
                }
            }
            else
            {
                try
                {
                    if (Validate(txtName) && Validate(txtPrice) && Validate(cmbFuel) && Validate(cmbBrand) && Validate(cmbModel))
                    {
                        request.Description = rtxtDesc.Text;
                        request.NumberOfSeats = int.Parse(txtSeats.Text);
                        request.YearManufactured = int.Parse(txtYear.Text);
                        request.Name = txtName.Text;
                        request.BrandId = int.Parse(cmbBrand.SelectedValue.ToString());
                        request.FuelId = int.Parse(cmbFuel.SelectedValue.ToString());
                        request.IsActive = cbActive.Checked;
                        request.VehicleModelId = int.Parse(cmbModel.SelectedValue.ToString());
                        request.VehicleTypeId = 1;
                        request.Price = int.Parse(txtPrice.Text);
                        request.Transmission = cbTransmission.SelectedValue.ToString();


                    if (EditId != 0)
                    {
                        await _serviceVehicle.Update<Model.Vehicle>(editVehicle.Id, request);
                        MessageBox.Show("Vehicle sucessfully updated!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        await _serviceVehicle.Insert<Model.Vehicle>(request);
                        MessageBox.Show("Vehicle sucessfully added!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    throw;
                }
            }

        }

        private void btnImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();

            if (open.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Image = new Bitmap(open.FileName);
                    var fileName = open.FileName;
                    var file = File.ReadAllBytes(fileName);
                    request.Image = file;

                Image img = Image.FromFile(fileName);
                    pictureBox1.Image = img;
                    //pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            var msg = MessageBox.Show("Are you sure?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if(msg == DialogResult.Yes)
            {
                this.Close();
                
            }
        }

       
        private void btnAddModel_Click(object sender, EventArgs e)
        {
            frmAddVehicleModel frmModel = new frmAddVehicleModel();
            frmModel.FormClosed += async delegate {
                await GetModel();
            };
            frmModel.ShowDialog();
        }
    }
    }

