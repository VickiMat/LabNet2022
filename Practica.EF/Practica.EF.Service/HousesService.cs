using Practica.EF.Entities.WizardWorld;
using Practica.EF.Logic.WizardWorld;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Practica.EF.Service
{
    public class HousesService
    {
        HousesLogic housesLogic = new HousesLogic();

        public async Task<List<RootDto>> ListHouses()
        {
            try
            {
                var houses = await housesLogic.GetAllHousesDto();
                if(houses == null)
                {
                    throw new Exception("An error ocurred trying to get rootDto List");
                }
                return houses;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
