using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpine.Core.Domain.Assessment;
using Alpine.Core.Domain.Grower;
using Alpine.Core.Domain.Payment;
using System.Web.Mvc;

namespace Alpine.Controllers.ViewModels.Growers
{
    public class GrowersView
    {
        public GrowersView()
        {
            SideBar = new SideBarView();
            PaymentCount = 0;
            CropYears = new List<SelectListItem>() {
                  new SelectListItem() {
                    Text = DateTime.Now.AddYears(1).Year.ToString(), Value = DateTime.Now.AddYears(1).Year.ToString()   
                  },
                  new SelectListItem() {
                    Text = DateTime.Now.Year.ToString(), Value = DateTime.Now.Year.ToString()   
                  },
                  new SelectListItem() {
                    Text = DateTime.Now.AddYears(-1).Year.ToString(), Value = DateTime.Now.AddYears(-1).Year.ToString()   
                  },
                  new SelectListItem() {
                    Text = DateTime.Now.AddYears(-2).Year.ToString(), Value = DateTime.Now.AddYears(-2).Year.ToString()   
                  },
                  new SelectListItem() {
                    Text = DateTime.Now.AddYears(-3).Year.ToString(), Value = DateTime.Now.AddYears(-3).Year.ToString()   
                  }
              };
            GrowerNotesStatusFilter = new List<SelectListItem>() { 
                new SelectListItem(){
                    Text = "Active", Value = "True"
                },
                new SelectListItem(){
                    Text = "Inactive", Value = "False"
                }
            };
        }
        public IList<IAssessment> Assessments { get; set; }
        public IList<IPayee> Payees { get; set; }
        public IPayee SelectedPayee { get; set; }
        public IList<IGrowerAssessment> GrowerAssessments { get; set; }
        public IList<IGrowerNote> GrowerNotes { get; set; }
        public SideBarView SideBar { get; set; }
        public IEnumerable<SelectListItem> AssessmentsDDL { get; set; }
        public IList<IPayment> GrowerPayments { get; set; }
        public IPayment SelectedPayment { get; set; }
        public IList<SelectListItem> CropYears { get; set; }
        public IList<SelectListItem> GrowerNotesStatusFilter { get; set; }
        public IEnumerable<SelectListItem> Growers { get; set; }
        public IEnumerable<SelectListItem> GrowerPaymentsDDL { get; set; }
        public IEnumerable<SelectListItem> PaymentTypes { get; set; }
        public bool IsStandardSchedule { get; set; }
        public int GrowerProfileID { get; set; }
        public int PaymentCount { get; set; }
    }
}
