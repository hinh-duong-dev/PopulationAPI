using PopulationAPI.Data;
using PopulationAPI.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PopulationAPI.Services
{
    public class PopulationService : IPopulationService
    {
        private readonly PopulationDbContext _populationDbContext;

        public PopulationService(PopulationDbContext populationDbContext)
        {
            _populationDbContext = populationDbContext;
        }
        public Task<IEnumerable<PopulationModel>> GetByState(int[] state)
        {

            var actualsData = (from a in _populationDbContext.Actuals
                               where state.Contains(a.State)
                               select new PopulationModel
                               {
                                   Population = a.ActualPopulation,
                                   State = a.State
                               }).AsEnumerable();


            var estimates = (from es in _populationDbContext.Estimates
                             where state.Contains(es.State)
                             select es).AsEnumerable();

            var estimatesData = from ed in estimates
                                group ed by ed.State into g
                                select new PopulationModel
                                {
                                    Population = g.Sum(x => x.EstimatesPopulation),
                                    State = g.Key
                                };

            var result = actualsData.Union(estimatesData).GroupBy(x => x.State).Select(x => x.First());

            return Task.FromResult(result);
        }
    }
}
