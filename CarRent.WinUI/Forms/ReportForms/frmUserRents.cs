using CarRent.Model;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRent.WinUI.Forms.ReportForms
{
    public partial class frmUserRents : Form
    {
        private List<Rent> rents;

        public frmUserRents()
        {
            InitializeComponent();
        }

        public frmUserRents(List<Rent> rents):this()
        {
            this.rents = rents;
        }

        private void frmUserRents_Load(object sender, EventArgs e)
        {
            ReportParameterCollection rpc = new ReportParameterCollection();
            rpc.Add(new ReportParameter("Username", rents[0].User.FirstName + " " + rents[0].User.LastName));

            List<object> UserRentList = new List<object>();
            int i = 0;
            string status;
            foreach (var rent in rents)
            {
                if (rent.IsReviewed)
                    status = "Reviewed";
                else
                    status = "Not reviewed";
                if (rent.IsCanceled)
                    status = "Canceled";
                
                
                UserRentList.Add(new
                {
                    Rn = ++i,
                    VehicleName = rent.Vehicle.Name.ToString(),
                    StartDate = rent.StartDate.Date.ToString("dd.mm.yyyy"),
                    EndDate = rent.EndDate.Date.ToString("dd.mm.yyyy"),
                    Status = status,
                    TotalPrice = rent.TotalPrice.ToString() + "KM"
                });
                
            }

            ReportDataSource rds = new ReportDataSource();
            rds.Name = "DataSet1";
            rds.Value = UserRentList;

            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.LocalReport.SetParameters(rpc);

            this.reportViewer1.RefreshReport();
        }
    }
}
