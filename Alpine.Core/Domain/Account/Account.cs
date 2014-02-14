using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpine.Infrastructure.Domain;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Alpine.Core.Domain.Account
{
    [Serializable]
    [DataContract]
    public class Account : EntityBase, IAccount
    {
        protected override void Validate()
        {
            throw new NotImplementedException();
        }

        #region IAccount Members

        [DataMember]
        public virtual string Name { get; set; }

        [DataMember]
        public virtual string PathToLogo { get; set; }

        [DataMember]
        public virtual string Phone { get; set; }

        [DataMember]
        public virtual string Fax { get; set; }

        [DataMember]
        public virtual string WebsiteUrl { get; set; }

        [DataMember]
        public virtual string DomainName { get; set; }

        [DataMember]
        public virtual string Email { get; set; }


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

        public Account()
        {
            this.Type = "Account";
        }

        public virtual string ToJSON()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
