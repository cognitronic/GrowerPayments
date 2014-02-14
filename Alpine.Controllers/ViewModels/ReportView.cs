using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpine.Core.Domain.Payment;
using System.Web.Mvc;

namespace Alpine.Controllers.ViewModels
{
    public class ReportView
    {
        public ReportView()
        {
            UserAccount = new UserAccount.UserAccountView();
        }
        public UserAccount.UserAccountView UserAccount { get; set; }
        public IList<IPayment> Payments { get; set; }
    }
}
