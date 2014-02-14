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
    public class Payment : EntityBase, IPayment
    {
        #region IPayment Members
        [DataMember]
        public virtual int GrowerID { get; set; }
        [DataMember]
        public virtual PaymentType PaymentType { get; set; }
        [DataMember]
        public virtual decimal Amount { get; set; }
        [DataMember]
        public virtual DateTime? TransactionDate { get; set; }
        [DataMember]
        public virtual bool SplitHartley { get; set; }
        [DataMember]
        public virtual string Note { get; set; }
        [DataMember]
        public virtual bool IsTemplate { get; set; }
        [DataMember]
        public virtual int TemplateID { get; set; }
        [DataMember]
        public virtual bool TransactionCompleted { get; set; }
        [DataMember]
        public virtual bool IsMiscPayment { get; set; }
        #endregion

        #region ISchedule Members
        [DataMember]
        public virtual string Name { get; set; }
        [DataMember]
        public virtual string Description { get; set; }
        [DataMember]
        public virtual DateTime PaymentDate { get; set; }
        [DataMember]
        public virtual string CropYear { get; set; }
        [DataMember]
        public virtual IList<IPaymentVariety> Varieties { get; set; }
        [DataMember]
        public virtual int AccountID { get; set; }

        #endregion

        #region ISystemObject Members
        [DataMember]
        public virtual int ID { get; set; }
        [DataMember]
        public virtual Guid SystemID { get; set; }
        [DataMember]
        public virtual string Type { get; set; }

        #endregion

        #region IAuditable Members
        [DataMember]
        public virtual int EnteredBy { get; set; }
        [DataMember]
        public virtual int ChangedBy { get; set; }
        [DataMember]
        public virtual DateTime DateCreated { get; set; }
        [DataMember]
        public virtual DateTime LastUpdated { get; set; }

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
