using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Susteni.Models
{
    public interface IMinSideRepository
    {
        Task<Models.MinSideViewModel> GetMinSideById(string sRessursGuid);
    }
}
