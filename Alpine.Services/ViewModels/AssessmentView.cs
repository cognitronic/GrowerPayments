using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Alpine.Core.Domain.Assessment;
using Newtonsoft.Json;

namespace Alpine.Services.ViewModels
{
    [Serializable]
    [DataContract]
    public class AssessmentView
    {
        [DataMember]
        public IAssessment Assessment { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string PricePerInShellPound { get; set; }
        [DataMember]
        public string CropYear { get; set; }
        [DataMember]
        public string ID { get; set; }
        [DataMember]
        public bool AppliedToAll { get; set; }

        public virtual string ToJSON()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
