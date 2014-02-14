using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpine.Core.Domain.Payment;
using System.Web.Mvc;

namespace Alpine.Controllers.ViewModels
{
    public class PaymentView
    {
        public PaymentView()
        {
            SideBar = new SideBarView();
        }
        public SideBarView SideBar { get; set; }
        public IList<IPayment> Payments { get; set; }
        public IPayment SelectedPayment { get; set; }
        public IEnumerable<SelectListItem> PaymentTypes { get; set; }
        public IEnumerable<SelectListItem> VarietiesDDL { get; set; }
    }
}
