using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Alpine.Infrastructure.Domain;
using Newtonsoft.Json;

namespace Alpine.Core.Domain.Payment
{
    [Serializable]
    public class PaymentVariety : EntityBase, IPaymentVariety
    {
        #region IPaymentVariety Members
        [DataMember]
        public virtual int VarietyID { get; set; }
        [DataMember]
        public virtual Variety.IVariety Variety { get; set; }
        [DataMember]
        public virtual decimal Price { get; set; }
        [DataMember]
        public virtual int PaymentID { get; set; }
        [DataMember]
        public virtual int NutwareID { get; set; }

        #endregion

        #region ISystemObject Members
        [DataMember]
        public virtual int ID { get; set; }
        [DataMember]
        public virtual Guid SystemID { get; set; }
        [DataMember]
        public virtual string Type { get; set; }

        #endregion

        protected override void Validate()
        {
            throw new NotImplementedException();
        }

        public virtual string ToJSON()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
