using my_app.App.Features.Services;
using System.Web.Http;

namespace my_app.Host.Controllers
{
    public class ProductionHistoryController : ApiController
    {
        private ProductionHistoryService _service;

        public ProductionHistoryController(ProductionHistoryService service)
        {
            _service = service;
        }

        public IHttpActionResult Get()
        {
            var serviceResult = _service.GetInfo();
            return Ok(serviceResult);
        }

    }
}
