using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpine.Infrastructure.Domain;
using System.Runtime.Serialization;
using Alpine.Core.Domain.Assessment;
using Newtonsoft.Json;

namespace Alpine.Core.Domain.Grower
{
    [Serializable]
    [DataContract]
    public class GrowerAssessment : EntityBase, IGrowerAssessment
    {
        public GrowerAssessment()
        {
           
        }

        protected override void Validate()
        {
            
        }

        #region IGrowerAssessment Members
        [DataMember]
        public virtual int ID { get; set; }
        [DataMember]
        public virtual int GrowerID { get; set; }
        [DataMember]
        public virtual string CropYear { get; set; }
        [DataMember]
        public virtual int AssessmentID { get; set; }
        [DataMember]
        public virtual IAssessment Assessment { get; set; }
        [DataMember]
        public virtual DateTime DateCreated { get; set; }
        [DataMember]
        public virtual DateTime LastUpdated { get; set; }
        [DataMember]
        public virtual int EnteredBy { get; set; }
        [DataMember]
        public virtual int ChangedBy { get; set; }

        #endregion

        #region ISystemObject Members

        [DataMember]
        public virtual Guid SystemID { get; set; }
        [DataMember]
        public virtual string Type { get; set; }

        #endregion
    }
}
