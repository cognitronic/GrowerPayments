using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpine.Infrastructure.Domain;
using System.Runtime.Serialization;

namespace Alpine.Core.Domain.Grower
{
    [Serializable]
    public class GrowerProfile : EntityBase, IGrowerProfile
    {
        #region IGrowerProfile Members
        [DataMember]
        public virtual int ID { get; set; }
        [DataMember]
        public virtual int GrowerID { get; set; }
        [DataMember]
        public virtual bool IsStandardSchedule { get; set; }

        [DataMember]
        public virtual IGrower Grower { get; set; }

        #endregion

        #region ISystemObject Members

        [DataMember]
        public virtual Guid SystemID { get; set; }
        [DataMember]
        public virtual string Type { get; set; }

        #endregion

        protected override void Validate()
        {
            
        }
    }
}
