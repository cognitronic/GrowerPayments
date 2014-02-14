using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Alpine.Core.Domain.Grower;
using Newtonsoft.Json;

namespace Alpine.Services.ViewModels
{
    [Serializable]
    [DataContract]
    public class GrowerAssessmentView
    {
        [DataMember]
        public IGrowerAssessment GrowerAssessment { get; set; }
        [DataMember]
        public IList<IGrowerAssessment> GrowerAssessments { get; set; }

        public virtual string ToJSON()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}