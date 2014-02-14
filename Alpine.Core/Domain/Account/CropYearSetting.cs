using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Alpine.Infrastructure.Domain;
using Newtonsoft.Json;

namespace Alpine.Core.Domain.Account
{
    [Serializable]
    public class CropYearSetting : EntityBase, ICropYearSetting
    {
        public CropYearSetting(){}

        protected override void Validate()
        {
            
        }

        #region ICropYearSetting Members
        [DataMember]
        public virtual int ID { get; set; }
        [DataMember]
        public virtual int AccountID { get; set; }
        [DataMember]
        public virtual string CropYear { get; set; }
        [DataMember]
        public virtual bool PaymentSetupComplete { get; set; }

        #endregion

        #region ISystemObject Members

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
    }
}
