using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpine.Services.Messaging.VarietyService;

namespace Alpine.Services.Interfaces
{
    public interface IVarietyService
    {
        CreateVarietyResponse CreateVariety(CreateVarietyRequest request);
        UpdateVarietyResponse UpdateVariety(UpdateVarietyRequest request);
        DeleteVarietyResponse DeleteVariety(DeleteVarietyRequest request);
        GetVarietyByIDResponse GetVarietyByID(GetVarietyByIDRequest request);
        GetVarietiesResponse GetAllVarieties();
        GetVarietiesResponse GetVarietiesByAccountID(GetVarietiesByAccountIDRequest request);
    }
}
