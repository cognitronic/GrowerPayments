using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpine.Services.ViewModels;
using Alpine.Core.Domain.Payment;
using AutoMapper;

namespace Alpine.Services.Mapping
{
    public static class PaymentMapper
    {
        public static PaymentView ConvertToPaymentView(this IPayment payment)
        {
            return Mapper.Map<IPayment, PaymentView>(payment);
        }

        public static Payment ConvertToPayment(this PaymentView view)
        {
            return Mapper.Map<PaymentView, Payment>(view);
        }

        public static IList<PaymentView> ConvertToPaymentViewList(this IList<IPayment> payments)
        {
            return Mapper.Map<IList<IPayment>, IList<PaymentView>>(payments);
        }
    }
}
