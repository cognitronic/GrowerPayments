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
    public class GrowerNote : EntityBase, IGrowerNote
    {
        public GrowerNote()
        {
           
        }

        protected override void Validate()
        {
            
        }

        #region IGrowerNote Members

        [DataMember]
        public virtual int ID { get; set; }
        [DataMember]
        public virtual string Note { get; set; }
        [DataMember]
        public virtual int GrowerID { get; set; }
        [DataMember]
        public virtual DateTime DateCreated { get; set; }
        [DataMember]
        public virtual DateTime LastUpdated { get; set; }
        [DataMember]
        public virtual int EnteredBy { get; set; }
        [DataMember]
        public virtual int ChangedBy { get; set; }
        [DataMember]
        public virtual bool IsActive { get; set; }

        #endregion

        #region ISystemObject Members


        [DataMember]
        public virtual Guid SystemID { get; set; }

        [DataMember]
        public virtual string Type { get; set; }

        #endregion
    }
}
