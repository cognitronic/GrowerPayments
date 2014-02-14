using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpine.Infrastructure.Domain;
using System.Runtime.Serialization;

namespace Alpine.Core.Domain.Grower
{
    public interface IPayee :  ISystemObject, IAuditable
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string CheckMadeTo { get; set; }
        string Email { get; set; }
        string Fax { get; set; }
        string WorkPhone { get; set; }
        string CellPhone { get; set; }
        int SplitPercent { get; set; }
        int GrowerID { get; set; }
        string Address { get; set; }
        string City { get; set; }
        string State { get; set; }
        string Zip { get; set; }
    }
}
