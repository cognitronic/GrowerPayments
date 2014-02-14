using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Alpine.Core.Domain.Variety;
using Newtonsoft.Json;

namespace Alpine.Services.ViewModels
{
    [Serializable]
    [DataContract]
    public class VarietyView
    {
        [DataMember]
        public int AccountID { get; set; }
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public IVariety Variety { get; set; }

        public virtual string ToJSON()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
