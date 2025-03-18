using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Susteni.Models
{
    public interface iSchedulerRepository
    {
        Task<List<Models.KalenderItem>> Read();
    }
}
