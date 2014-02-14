using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpine.Infrastructure.Domain;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Alpine.Core.Domain.Grower
{
    [Serializable]
    [DataContract]
    public class Grower : EntityBase, IGrower
    {
        public Grower()
        {
            this.Type = "Grower";    
        }

        protected override void Validate()
        {
            if (string.IsNullOrEmpty(Name))
                base.AddBrokenRule(GrowerBusinessRules.NameRequired);
        }

        #region IGrower Members
        [DataMember]
        public virtual string Name { get; set; }

        [DataMember]
        public virtual DateTime GrowerSince { get; set; }

        [DataMember]
        public virtual int AccountID { get; set; }

        [DataMember]
        public virtual bool IsStandardSchedule { get; set; }
        #endregion

        #region IHasAddress Members
        [DataMember]
        public virtual string Address1 { get; set; }

        [DataMember]
        public virtual string Address2 { get; set; }

        [DataMember]
        public virtual string City { get; set; }

        [DataMember]
        public virtual string State { get; set; }

        [DataMember]
        public virtual string Zip { get; set; }

        #endregion

        #region ISystemObject Members
        [DataMember]
        public virtual int ID { get; set; }

        [DataMember]
        public virtual Guid SystemID { get; set; }

        [DataMember]
        public virtual string Type { get; set; }

        #endregion

        public virtual string ToJSON()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
