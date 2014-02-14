using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpine.Core.Domain.Grower;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Alpine.Services.ViewModels
{
    [Serializable]
    public class PayeeView
    {
        [DataMember]
        public IPayee Payee { get; set; }

        [DataMember]
        public IList<IPayee> Payees { get; set; }

        public virtual string ToJSON()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
