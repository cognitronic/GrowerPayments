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
    public class Payee : EntityBase, IPayee
    {
        protected override void Validate()
        {
            if (string.IsNullOrEmpty(FirstName))
                base.AddBrokenRule(PayeeBusinessRules.FirstNameRequired);
            if (string.IsNullOrEmpty(LastName))
                base.AddBrokenRule(PayeeBusinessRules.LastNameRequired);
            if (string.IsNullOrEmpty(Email))
                base.AddBrokenRule(PayeeBusinessRules.EmailRequired);
            if (string.IsNullOrEmpty(CheckMadeTo))
                base.AddBrokenRule(PayeeBusinessRules.CheckMadeToRequired);
            if (string.IsNullOrEmpty(Address))
                base.AddBrokenRule(PayeeBusinessRules.AddressRequired);
            if (string.IsNullOrEmpty(City))
                base.AddBrokenRule(PayeeBusinessRules.CityRequired);
            if (string.IsNullOrEmpty(State))
                base.AddBrokenRule(PayeeBusinessRules.StateRequired);
            if (string.IsNullOrEmpty(Zip))
                base.AddBrokenRule(PayeeBusinessRules.ZipRequired);
            if (Convert.ToDecimal(SplitPercent) < 0 || Convert.ToDecimal(SplitPercent) > 100)
                base.AddBrokenRule(PayeeBusinessRules.SplitPercentRange);
        }

        #region IPayee Members

        [DataMember]
        public virtual string FirstName { get; set; }

        [DataMember]
        public virtual string LastName { get; set; }

        [DataMember]
        public virtual string CheckMadeTo { get; set; }

        [DataMember]
        public virtual string Email { get; set; }

        [DataMember]
        public virtual string Fax { get; set; }

        [DataMember]
        public virtual string WorkPhone { get; set; }

        [DataMember]
        public virtual string CellPhone { get; set; }

        [DataMember]
        public virtual int SplitPercent { get; set; }

        [DataMember]
        public virtual int GrowerID { get; set; }

        #endregion

        #region IHasAddress Members

        [DataMember]
        public virtual string Address { get; set; }

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

        public Payee()
        {
            this.Type = "Payee";
        }

        public virtual string ToJSON()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
