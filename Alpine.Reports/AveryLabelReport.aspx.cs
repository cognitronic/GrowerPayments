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
    public partial class AveryLabelReport1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RunReport();
            }
        }

        

        private void RunReport()
        {
            var fpp = new AveryLabelReport();
            ReportViewer1.ReportSource = fpp;
        }
    }
}