using app.Client.Services;
using my_app.App.Dtos;
using System.Collections.Generic;

namespace app.Client.Models
{
    public class ViewModelProductionHistory
    {
        const string url = "http://localhost:57973/api/ProductionHistory";
        public List<ProductionHistoryDto> ProductionHistoryDto { get; set; }

        public void GetAllProductionHistory()
        {
            var result = new ProductionHistoryService();
            ProductionHistoryDto = result.GetInfo(url);
        }
    }
}