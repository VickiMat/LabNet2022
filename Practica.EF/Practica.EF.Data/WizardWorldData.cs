using Newtonsoft.Json;
using Practica.EF.Entities.WizardWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
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


        //static readonly HttpClient client = new HttpClient();

        //string BaseUrl = "https://wizard-world-api.herokuapp.com/houses";
        
        //List<HouseDto> HouseList = new List<HouseDto>();
        //HouseDto hous = new HouseDto();
        //public async Task<HouseDto> ObtainHouses()
        //{
        //    using(client)
        //    {
        //        client.BaseAddress = new Uri(BaseUrl);
        //        client.DefaultRequestHeaders.Clear();
        //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //        HttpResponseMessage Res = await client.GetAsync(BaseUrl);

        //        if (Res.IsSuccessStatusCode)
        //        {
        //            var HouseResponse = Res.Content.ReadAsStringAsync().Result;
        //            hous = JsonConvert.DeserializeObject<HouseDto>(HouseResponse);
        //        }
        //        return hous;
        //    }
        //}

    }
}
