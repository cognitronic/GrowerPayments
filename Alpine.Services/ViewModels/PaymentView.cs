using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Alpine.Core.Domain.Payment;
using Newtonsoft.Json;

namespace Alpine.Services.ViewModels
{
    [Serializable]
    [DataContract]
    public class PaymentView
    {
        [DataMember]
        public IPayment Payment { get; set; }

        public virtual string ToJSON()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
