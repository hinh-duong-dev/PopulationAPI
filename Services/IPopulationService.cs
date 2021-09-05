using PopulationAPI.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PopulationAPI.Services
{
    public interface IPopulationService
    {
        Task<IEnumerable<PopulationModel>> GetByState(int[] state);
    }
}
