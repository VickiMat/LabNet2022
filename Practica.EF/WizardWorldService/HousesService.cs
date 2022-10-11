using Practica.EF.Entities.WizardWorld;
using Practica.EF.Logic.WizardWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica.EF.Service
{
    public class HousesService
    {
        HousesLogic housesLogic = new HousesLogic();

        public async Task<List<RootDto>> ListHouses()
        {
            return await housesLogic.GetAllHousesDto();

        }
    }
}
