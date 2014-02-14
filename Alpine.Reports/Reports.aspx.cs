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
    public partial class Reports : System.Web.UI.Page
    {
        protected void GoBackClicked(object o, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["cid"]) && !string.IsNullOrEmpty(Request.QueryString["cy"]))
            {
                Response.Redirect("/GrowerProfile.aspx?cid=" + Request.QueryString["cid"] + "&cy=" + Request.QueryString["cy"]);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var fpp = new Report1();
                fpp.ReportParameters["customerid"].Value = Request.QueryString["cid"];
                fpp.ReportParameters["cropyear"].Value = Request.QueryString["cy"];
                fpp.ReportParameters["paymenttype"].Value = Request.QueryString["pt"];
                ReportViewer1.ReportSource = fpp;
            }
        }

        void ExportToPDF(Telerik.Reporting.Report reportToExport)
        {
            ReportProcessor reportProcessor = new ReportProcessor();
            RenderingResult result = reportProcessor.RenderReport("PDF", reportToExport, null);

            string fileName = result.DocumentName + ".pdf";

            Response.Clear();
            Response.ContentType = result.MimeType;
            Response.Cache.SetCacheability(HttpCacheability.Private);
            Response.Expires = -1;
            Response.Buffer = true;

            Response.AddHeader("Content-Disposition",
                               string.Format("{0};FileName=\"{1}\"",
                                             "attachment",
                                             fileName));

            Response.BinaryWrite(result.DocumentBytes);
            Response.End();
        }    
    }
}