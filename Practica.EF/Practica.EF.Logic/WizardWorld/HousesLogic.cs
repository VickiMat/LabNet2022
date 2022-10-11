using Practica.EF.Data;
using Practica.EF.Entities.WizardWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practica.EF.Logic.WizardWorld
{
    public class HousesLogic
    {
        protected WizardWorldData _wwdata;
        public HousesLogic()
        {
            _wwdata = new WizardWorldData();
        }

        public async Task<List<RootDto>> GetAllHousesDto()
        {
            try
            {
                var houses = await _wwdata.GetHousesAsync();

                List<RootDto> result = houses.Select(h => new RootDto
                {
                    id = h.id,
                    name = h.name,
                    houseColours = h.houseColours,
                    founder = h.founder,
                    animal = h.animal,
                    element = h.element
                }).ToList();

                return result;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
