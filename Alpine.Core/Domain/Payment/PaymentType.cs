using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpine.Core.Domain.Payment
{
    public enum PaymentType
    {
        Progress_Payment_1 = 1,
        Progress_Payment_2 = 2,
        Prgoress_Payment_3 = 3,
        Progress_Payment_4 = 4,
        Progress_Payment_5 = 5,
        Bonus_Payment = 6,
        Final_Payment = 7,
        Misc_Transaction = -1,
        Void_Payment = 9
    }
}
