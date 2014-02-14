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
    public class GrowerNoteView
    {
        [DataMember]
        public IGrowerNote GrowerNote { get; set; }
        [DataMember]
        public IList<IGrowerNote> GrowerNotes { get; set; }

        public virtual string ToJSON()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}