namespace Alpine.Reports
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;
    using System.Data;
    using Alpine.Core.Domain.Payment;
    using Alpine.Services.Implementations;
    using Alpine.Services.Interfaces;
    using Alpine.Services.Messaging.PaymentService;
    using Alpine.Services.Cache;
    using Alpine.Repository.NHibernate.Repositories;
    using Alpine.Repository.NHibernate;
    using System.Net;
    using System.Configuration;
    using System.Text;
    

    /// <summary>
    /// Summary description for Report1.
    /// </summary>
    public partial class Report1 : Telerik.Reporting.Report
    {


        private readonly IPaymentService _service;

        public Report1()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

        }

        double payment1Total = 0;
        double payment2Total = 0;
        double payment3Total = 0;
        double finalPaymentTotal = 0;
        double yearToDateTotal = 0;
        double assessmentsTotal = 0;
        double miscPayment1Total = 0;
        double miscPayment2Total = 0;
        double miscPayment3Total = 0;
        double miscFinalPaymentTotal = 0;
        double miscYearToDateTotal = 0;

        string payment1Date = "";
        string payment2Date = "";
        string payment3Date = "";
        string finalPaymentDate = "";

        private void textBox50_ItemDataBound(object sender, EventArgs e)
        {

        }

        private void textBox52_ItemDataBound(object sender, EventArgs e)
        {

        }

        private void tblProgressPayment3_ItemDataBound(object sender, EventArgs e)
        {
            Telerik.Reporting.Processing.Table table = sender as Telerik.Reporting.Processing.Table;
            if (table.Rows.Count < 1)
            {
                table.Visible = false;
            }
        }

        private void tbPP1Total_ItemDataBound(object sender, EventArgs e)
        {
            Telerik.Reporting.Processing.TextBox txt = (Telerik.Reporting.Processing.TextBox)sender;
            Telerik.Reporting.Processing.IDataObject dataObject = (Telerik.Reporting.Processing.IDataObject)txt.DataObject;
            if (((Telerik.Reporting.Processing.TextBox)sender).Value != null &&
                !string.IsNullOrEmpty(((Telerik.Reporting.Processing.TextBox)sender).Value.ToString()))
            {
                payment1Total = Convert.ToDouble(((Telerik.Reporting.Processing.TextBox)sender).Value.ToString());

                
            }
            if (dataObject.RawData != null && (DateTime)dataObject["PaymentDate"] != null)
            {
                payment1Date = ((DateTime)dataObject["PaymentDate"]).ToString("MM/dd/yy");
                var p = new Payment();
                p.ID = ((int)dataObject["ID"]);
                p.Amount = (decimal)payment1Total;

                using (var client = new WebClient())
                {
                    client.Headers[HttpRequestHeader.ContentType] = "application/json";
                    client.Headers[HttpRequestHeader.Accept] = "application/json";
                    var data = Encoding.UTF8.GetBytes(p.ToJSON());
                    byte[] result = client.UploadData(ConfigurationManager.AppSettings["BASEURL"] + "api/Payments/UpdatePaymentByReport", "POST", data);
                }
            }
            else
            {
                ((Telerik.Reporting.Processing.TextBox)sender).Parent.Visible = false;
                this.Items[8].Items["tbPayment1DetailLabel"].Visible = false;
                this.Items[8].Items["tblMiscProgressPayment1"].Visible = false;
                this.Items[8].Items["tbProgressPayment1Total"].Visible = false;
                this.Items[8].Items["tblOther1"].Visible = false;
            }

        }

        private void tbAssessmentsTotal_ItemDataBound(object sender, EventArgs e)
        {
            if (((Telerik.Reporting.Processing.TextBox)sender).Value != null &&
                !string.IsNullOrEmpty(((Telerik.Reporting.Processing.TextBox)sender).Value.ToString()))
            {
                assessmentsTotal = Convert.ToDouble(((Telerik.Reporting.Processing.TextBox)sender).Value.ToString());
            }
            else 
            {
                ((Telerik.Reporting.Processing.TextBox)sender).Value = 0;
            }
        }

        private void tbMiscPayment1_ItemDataBound(object sender, EventArgs e)
        {
            if (((Telerik.Reporting.Processing.TextBox)sender).Value != null &&
                !string.IsNullOrEmpty(((Telerik.Reporting.Processing.TextBox)sender).Value.ToString()))
                miscPayment1Total = Convert.ToDouble(((Telerik.Reporting.Processing.TextBox)sender).Value.ToString());
        }

        private void tbProgressPayment1Total_ItemDataBound(object sender, EventArgs e)
        {
            ((Telerik.Reporting.Processing.TextBox)sender).Value = string.Format("{0:C}", payment1Total + (assessmentsTotal * -1) + miscPayment1Total);
        }

        private void tbProgressPayment2Total_ItemDataBound(object sender, EventArgs e)
        {
            ((Telerik.Reporting.Processing.TextBox)sender).Value = string.Format("{0:C}", payment2Total  + miscPayment2Total);
        }

        private void tbPP2Total_ItemDataBound(object sender, EventArgs e)
        {
            if (((Telerik.Reporting.Processing.TextBox)sender).Value != null && 
                !string.IsNullOrEmpty(((Telerik.Reporting.Processing.TextBox)sender).Value.ToString()))
                payment2Total = Convert.ToDouble(((Telerik.Reporting.Processing.TextBox)sender).Value.ToString());
            Telerik.Reporting.Processing.TextBox txt = (Telerik.Reporting.Processing.TextBox)sender;
            Telerik.Reporting.Processing.IDataObject dataObject = (Telerik.Reporting.Processing.IDataObject)txt.DataObject;
            if (dataObject.RawData != null && (DateTime)dataObject["PaymentDate"] != null)
            {
                payment2Date = ((DateTime)dataObject["PaymentDate"]).ToString("MM/dd/yy");

                var p = new Payment();
                p.ID = ((int)dataObject["ID"]);
                p.Amount = (decimal)payment2Total;

                using (var client = new WebClient())
                {
                    client.Headers[HttpRequestHeader.ContentType] = "application/json";
                    client.Headers[HttpRequestHeader.Accept] = "application/json";
                    var data = Encoding.UTF8.GetBytes(p.ToJSON());
                    byte[] result = client.UploadData(ConfigurationManager.AppSettings["BASEURL"] + "api/Payments/UpdatePaymentByReport", "POST", data);
                }
            }
            else
            {
                ((Telerik.Reporting.Processing.TextBox)sender).Parent.Visible = false;
                this.Items[8].Items["tbPayment2DetailLabel"].Visible = false;
                this.Items[8].Items["tblMiscProgressPayment2"].Visible = false;
                this.Items[8].Items["tbProgressPayment2Total"].Visible = false;
                this.Items[8].Items["tblOther2"].Visible = false;
            }
        }

        private void tbMiscPayment2_ItemDataBound(object sender, EventArgs e)
        {
            if (((Telerik.Reporting.Processing.TextBox)sender).Value != null &&
                !string.IsNullOrEmpty(((Telerik.Reporting.Processing.TextBox)sender).Value.ToString()))
                miscPayment2Total = Convert.ToDouble(((Telerik.Reporting.Processing.TextBox)sender).Value.ToString());
        }

        private void tbPP3Total_ItemDataBound(object sender, EventArgs e)
        {
            if (((Telerik.Reporting.Processing.TextBox)sender).Value != null &&
                !string.IsNullOrEmpty(((Telerik.Reporting.Processing.TextBox)sender).Value.ToString()))
                payment3Total = Convert.ToDouble(((Telerik.Reporting.Processing.TextBox)sender).Value.ToString());
            Telerik.Reporting.Processing.TextBox txt = (Telerik.Reporting.Processing.TextBox)sender;
            Telerik.Reporting.Processing.IDataObject dataObject = (Telerik.Reporting.Processing.IDataObject)txt.DataObject;
            if (dataObject.RawData != null && (DateTime)dataObject["PaymentDate"] != null)
            {
                payment3Date = ((DateTime)dataObject["PaymentDate"]).ToString("MM/dd/yy");

                var p = new Payment();
                p.ID = ((int)dataObject["ID"]);
                p.Amount = (decimal)payment3Total;

                using (var client = new WebClient())
                {
                    client.Headers[HttpRequestHeader.ContentType] = "application/json";
                    client.Headers[HttpRequestHeader.Accept] = "application/json";
                    var data = Encoding.UTF8.GetBytes(p.ToJSON());
                    byte[] result = client.UploadData(ConfigurationManager.AppSettings["BASEURL"] + "api/Payments/UpdatePaymentByReport", "POST", data);
                }
            }
            else
            {
                ((Telerik.Reporting.Processing.TextBox)sender).Parent.Visible = false;
                this.Items[8].Items["tbPayment3DetailLabel"].Visible = false;
                this.Items[8].Items["tblMiscProgressPayment3"].Visible = false;
                this.Items[8].Items["tbProgressPayment3"].Visible = false;
                this.Items[8].Items["tblOther3"].Visible = false;
            }
        }

        private void tbMiscPayment3_ItemDataBound(object sender, EventArgs e)
        {
            if (((Telerik.Reporting.Processing.TextBox)sender).Value != null &&
                !string.IsNullOrEmpty(((Telerik.Reporting.Processing.TextBox)sender).Value.ToString()))
                miscPayment3Total = Convert.ToDouble(((Telerik.Reporting.Processing.TextBox)sender).Value.ToString());
        }

        private void tbProgressPayment3_ItemDataBound(object sender, EventArgs e)
        {
            ((Telerik.Reporting.Processing.TextBox)sender).Value = string.Format("{0:C}", payment3Total + miscPayment3Total);
        }

        private void tbFinalPaymentTotal_ItemDataBound(object sender, EventArgs e)
        {
            if (((Telerik.Reporting.Processing.TextBox)sender).Value != null &&
                !string.IsNullOrEmpty(((Telerik.Reporting.Processing.TextBox)sender).Value.ToString()))
                finalPaymentTotal = Convert.ToDouble(((Telerik.Reporting.Processing.TextBox)sender).Value.ToString());
            Telerik.Reporting.Processing.TextBox txt = (Telerik.Reporting.Processing.TextBox)sender;
            Telerik.Reporting.Processing.IDataObject dataObject = (Telerik.Reporting.Processing.IDataObject)txt.DataObject;
            if (dataObject.RawData != null && (DateTime)dataObject["PaymentDate"] != null)
            {
                finalPaymentDate = ((DateTime)dataObject["PaymentDate"]).ToString("MM/dd/yy");

                var p = new Payment();
                p.ID = ((int)dataObject["ID"]);
                p.Amount = (decimal)finalPaymentTotal;

                using (var client = new WebClient())
                {
                    client.Headers[HttpRequestHeader.ContentType] = "application/json";
                    client.Headers[HttpRequestHeader.Accept] = "application/json";
                    var data = Encoding.UTF8.GetBytes(p.ToJSON());
                    byte[] result = client.UploadData(ConfigurationManager.AppSettings["BASEURL"] + "api/Payments/UpdatePaymentByReport", "POST", data);
                }
            }
            else
            {
                ((Telerik.Reporting.Processing.TextBox)sender).Parent.Visible = false;
                this.Items[8].Items["tbFinalPaymentDetailLabel"].Visible = false;
                this.Items[8].Items["tblFinalPayment"].Visible = false;
                this.Items[8].Items["tblMiscFinalPayment"].Visible = false;
                this.Items[8].Items["tbFinalPayment"].Visible = false;
                this.Items[8].Items["tblOtherFinal"].Visible = false;
            }
        }

        private void tbMiscFinal_ItemDataBound(object sender, EventArgs e)
        {
            if (((Telerik.Reporting.Processing.TextBox)sender).Value != null &&
                !string.IsNullOrEmpty(((Telerik.Reporting.Processing.TextBox)sender).Value.ToString()))
                miscFinalPaymentTotal = Convert.ToDouble(((Telerik.Reporting.Processing.TextBox)sender).Value.ToString());
        }

        private void tbFinalPayment_ItemDataBound(object sender, EventArgs e)
        {
            ((Telerik.Reporting.Processing.TextBox)sender).Value = string.Format("{0:C}", finalPaymentTotal + miscFinalPaymentTotal);
        }

        private void tbYearToDateTotal_ItemDataBound(object sender, EventArgs e)
        {
            if (((Telerik.Reporting.Processing.TextBox)sender).Value != null &&
                !string.IsNullOrEmpty(((Telerik.Reporting.Processing.TextBox)sender).Value.ToString()))
                yearToDateTotal = Convert.ToDouble(((Telerik.Reporting.Processing.TextBox)sender).Value.ToString());
        }

        private void tbYearToDateMisc_ItemDataBound(object sender, EventArgs e)
        {
            miscYearToDateTotal = miscPayment1Total + miscPayment2Total + miscPayment3Total + miscFinalPaymentTotal;

            ((Telerik.Reporting.Processing.TextBox)sender).Value = string.Format("{0:C}", miscYearToDateTotal);
        }

        private void tbYearToDate_ItemDataBound(object sender, EventArgs e)
        {
            ((Telerik.Reporting.Processing.TextBox)sender).Value = string.Format("{0:C}", miscYearToDateTotal + yearToDateTotal + (assessmentsTotal * -1));
        }

        private void tbPayment1DetailLabel_ItemDataBound(object sender, EventArgs e)
        {
            ((Telerik.Reporting.Processing.TextBox)sender).Value = "Payment #1 - " + payment1Date;
        }

        private void tbPayment2DetailLabel_ItemDataBound(object sender, EventArgs e)
        {
            ((Telerik.Reporting.Processing.TextBox)sender).Value = "Payment #2 - " + payment2Date;
        }

        private void tbPayment3DetailLabel_ItemDataBound(object sender, EventArgs e)
        {
            ((Telerik.Reporting.Processing.TextBox)sender).Value = "Payment #3 - " + payment3Date;
        }

        private void tbFinalPaymentDetailLabel_ItemDataBound(object sender, EventArgs e)
        {
            ((Telerik.Reporting.Processing.TextBox)sender).Value = "Final Payment - " + finalPaymentDate;
        }

        private void tbPayeeAmount_ItemDataBound(object sender, EventArgs e)
        {
            Telerik.Reporting.Processing.TextBox txt = (Telerik.Reporting.Processing.TextBox)sender;
            Telerik.Reporting.Processing.IDataObject dataObject = (Telerik.Reporting.Processing.IDataObject)txt.DataObject;

            ((Telerik.Reporting.Processing.TextBox)sender).Value = string.Format("{0:C}", (((int)dataObject["SplitPercent"]) * 0.01) * (miscYearToDateTotal + yearToDateTotal + (assessmentsTotal * -1)));
        }

        private void tbFinalAssessment_ItemDataBound(object sender, EventArgs e)
        {
            ((Telerik.Reporting.Processing.TextBox)sender).Value = string.Format("{0:C}", (assessmentsTotal * -1));
        }

        private void tblOther2_ItemDataBound(object sender, EventArgs e)
        {
            Telerik.Reporting.Processing.Table table = sender as Telerik.Reporting.Processing.Table;
            if (table.Rows.Count < 2)
            {
                table.Visible = false;
            }
        }

        private void tblOtherPayment1_ItemDataBound(object sender, EventArgs e)
        {
            Telerik.Reporting.Processing.Table table = sender as Telerik.Reporting.Processing.Table;
            if (table.Rows.Count < 2)
            {
                table.Visible = false;
            }
        }

        private void tblOther3_ItemDataBound(object sender, EventArgs e)
        {
            Telerik.Reporting.Processing.Table table = sender as Telerik.Reporting.Processing.Table;
            if (table.Rows.Count < 2)
            {
                table.Visible = false;
            }
        }

        private void tblOtherFinal_ItemDataBound(object sender, EventArgs e)
        {
            Telerik.Reporting.Processing.Table table = sender as Telerik.Reporting.Processing.Table;
            if (table.Rows.Count < 2)
            {
                table.Visible = false;
            }
        }
    }
}