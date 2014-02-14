using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Alpine.Infrastructure.Authentication;
using System.Web.Mvc;

namespace Alpine.Controllers.ViewModels.UserAccount
{
    public class UserAccountView : IUserAccount
    {
        public UserAccountView()
        {
            CallBackSettings = new CallBackSettings();
            SideBar = new SideBarView();
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

            GrowerPaymentsDDL = new List<SelectListItem>();
        }

        public CallBackSettings CallBackSettings { get; set; }
        public bool HasIssue { get; set; }
        public string Message { get; set; }
        public bool IsAuthenticated { get; set; }
        public string AuthenticationToken { get; set; }
        public IList<SelectListItem> GrowerNotesStatusFilter { get; set; }
        public SideBarView SideBar { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Type { get; set; }
        public int UserID { get; set; }
        public bool CanRunNewYearSetup { get; set; }
        public IList<SelectListItem> CropYears { get; set; }
        public IEnumerable<SelectListItem> Growers { get; set; }
        public IList<SelectListItem> GrowerPaymentsDDL { get; set; }

        [Required]
        [Display(Name = "Username (email address)")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}
