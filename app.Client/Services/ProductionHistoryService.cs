using my_app.App.Dtos;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;

namespace app.Client.Services
{
    public class ProductionHistoryService
    {
        public List<ProductionHistoryDto> GetInfo(string urlApi)
        {
            var listaProductionHistoryDto = new List<ProductionHistoryDto>();
            var client = new HttpClient();
            Task<HttpResponseMessage> response = client.GetAsync(urlApi);

            var settings = new DataContractJsonSerializerSettings
            {
                DateTimeFormat = new System.Runtime.Serialization.DateTimeFormat("yyyy-MM-dd'T'HH:mm:ss")

            };

            if (response.Result.IsSuccessStatusCode)
            {
                var body = response.Result.Content.ReadAsStreamAsync().Result;
                var serializado = new DataContractJsonSerializer(typeof(List<ProductionHistoryDto>), settings);
                listaProductionHistoryDto = (List<ProductionHistoryDto>)serializado.ReadObject(body);
            }

            return listaProductionHistoryDto;
        }
    }
}