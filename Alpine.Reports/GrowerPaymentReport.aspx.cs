using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Reporting;
using Telerik.Reporting.Processing;

namespace Alpine.Reports
{
    public partial class GrowerPaymentReport1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCropYears();
                ddlCropYear.SelectedIndex = 1;
                RunReport();
            }
        }

        private void LoadCropYears()
        { 
            ddlCropYear.Items.Add( new ListItem(DateTime.Today.AddYears(1).Year.ToString(), DateTime.Today.AddYears(1).Year.ToString()));
            ddlCropYear.Items.Add(new ListItem(DateTime.Today.Year.ToString(), DateTime.Today.Year.ToString()));
            ddlCropYear.Items.Add(new ListItem(DateTime.Today.AddYears(-1).Year.ToString(), DateTime.Today.AddYears(-1).Year.ToString()));
            ddlCropYear.Items.Add(new ListItem(DateTime.Today.AddYears(-2).Year.ToString(), DateTime.Today.AddYears(-2).Year.ToString()));
            ddlCropYear.Items.Add(new ListItem(DateTime.Today.AddYears(-3).Year.ToString(), DateTime.Today.AddYears(-3).Year.ToString()));
            ddlCropYear.Items.Add(new ListItem(DateTime.Today.AddYears(-4).Year.ToString(), DateTime.Today.AddYears(-4).Year.ToString()));
        }

        private void RunReport()
        {
            var fpp = new GrowerPaymentReport();
            fpp.ReportParameters["cropyear"].Value = ddlCropYear.SelectedValue;
            ReportViewer1.ReportSource = fpp;
        }

        protected void CropYearChanged(object o, EventArgs e)
        {
            RunReport();
        }
    }
}