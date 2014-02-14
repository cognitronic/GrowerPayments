using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Alpine.Core.Domain.Account;
using Alpine.Infrastructure.Domain;
using Newtonsoft.Json;

namespace Alpine.Core.Domain.Assessment
{
    [Serializable]
    [DataContract]
    public class Assessment : EntityBase, IAssessment
    {
        #region IAssessment Members

        [DataMember]
        public virtual string Name { get; set; }

        [DataMember]
        public virtual IAccount Account { get; set; }

        [DataMember]
        public virtual decimal PricePerInShellPound { get; set; }

        [DataMember]
        public virtual string CropYear { get; set; }

        [DataMember]
        public virtual int AccountID { get; set; }

        [DataMember]
        public virtual bool AppliedToAll { get; set; }

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
            if (string.IsNullOrEmpty(Name))
                base.AddBrokenRule(AssessmentBusinessRules.NameRequired);
            if (string.IsNullOrEmpty(CropYear))
                base.AddBrokenRule(AssessmentBusinessRules.CropYearRequired);
            if (PricePerInShellPound <= 0)
                base.AddBrokenRule(AssessmentBusinessRules.PricePerInShellPoundRequired);
        }

        //public Assessment()
        //{
        //    this.Type = "Assessment";
        //}

        public virtual string ToJSON()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
