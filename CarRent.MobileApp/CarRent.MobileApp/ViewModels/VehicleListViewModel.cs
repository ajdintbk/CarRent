using CarRent.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CarRent.MobileApp.ViewModels
{
    public class VehicleListViewModel : BaseViewModel
    {
        private readonly APIService _serviceVehicles = new APIService("Vehicle");
        private readonly APIService _serviceBrands = new APIService("Brand");
        public VehicleListViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }
        public ObservableCollection<Vehicle> VehicleList { get; set; } = new ObservableCollection<Vehicle>();
        public ObservableCollection<Brand> BrandList { get; set; } = new ObservableCollection<Brand>();
        

        Brand _selectedBrand = null;
        public Brand SelectedBrand
        {
            get { return _selectedBrand; }
            set { 
                SetProperty(ref _selectedBrand, value); 
                if(value != null)
                {
                    InitCommand.Execute(null);
                }
            }
        }

        public ICommand InitCommand { get; set; }
    
        public async Task Init()
        {
            IsBusy = true;

            if(BrandList.Count == 0)
            {
                var brandList = await _serviceBrands.Get<IEnumerable<Brand>>(null);
                foreach (var brand in brandList)
                {
                    BrandList.Add(brand);
                }
                BrandList.Insert(0, new Brand()
                {
                    Name = null
                });
            }

            if (SelectedBrand != null)
            {
                var request = new Model.Requests.Vehicle.VehicleSearchRequest()
                {
                    BrandId = SelectedBrand.Id
                };
                var list = await _serviceVehicles.Get<IEnumerable<Vehicle>>(request);
                VehicleList.Clear();
                foreach (var vehicle in list)
                {
                    VehicleList.Add(vehicle);
                }
            }
            else
            {
                var list = await _serviceVehicles.Get<IEnumerable<Vehicle>>(null);
                VehicleList.Clear();
                foreach (var vehicle in list)
                {
                    VehicleList.Add(vehicle);
                }
            }

            IsBusy = false;
        }
    }
}
