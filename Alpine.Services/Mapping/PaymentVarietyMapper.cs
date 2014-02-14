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
    public static class PaymentVarietyMapper
    {
        public static PaymentVarietyView ConvertToPaymentVarietyView(this IPaymentVariety paymentvariety)
        {
            return Mapper.Map<IPaymentVariety, PaymentVarietyView>(paymentvariety);
        }

        public static PaymentVariety ConvertToPaymentVariety(this PaymentVarietyView view)
        {
            return Mapper.Map<PaymentVarietyView, PaymentVariety>(view);
        }

        public static IList<PaymentVarietyView> ConvertToPaymentVarietyViewList(this IList<IPaymentVariety> paymentvarieties)
        {
            return Mapper.Map<IList<IPaymentVariety>, IList<PaymentVarietyView>>(paymentvarieties);
        }
    }
}
