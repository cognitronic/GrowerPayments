using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Alpine.Infrastructure.Domain;
using Newtonsoft.Json;

namespace Alpine.Core.Domain.Schedule
{
    [Serializable]
    public class Schedule : EntityBase, ISchedule
    {
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
        public virtual IList<Payment.IPaymentVariety> Varieties { get; set; }
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
