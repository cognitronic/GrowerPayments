using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpine.Infrastructure.Domain;

namespace Alpine.Core.Domain.Account
{
    public interface IAccount : IHasAddress, ISystemObject, IAuditable
    {
        new int ID { get; set; }
        string Name { get; set; }
        string PathToLogo { get; set; }
        string Phone { get; set; }
        string Fax { get; set; }
        string WebsiteUrl { get; set; }
        string DomainName { get; set; }
        string Email { get; set; }
    }
}
