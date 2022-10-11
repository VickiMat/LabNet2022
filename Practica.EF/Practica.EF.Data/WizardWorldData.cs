using Newtonsoft.Json;
using Practica.EF.Entities.WizardWorld;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Practica.EF.Data
{
    public class WizardWorldData
    {
        static readonly HttpClient client = new HttpClient();
        public async Task<List<Root>> GetHousesAsync()
        {
            try
            {
                var json = await client.GetStringAsync("https://wizard-world-api.herokuapp.com/houses");
                var list = JsonConvert.DeserializeObject<List<Root>>(json);
                return list;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        } 
    }
}
