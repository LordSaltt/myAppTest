using app.Client.Models;

using System.Web.Mvc;

namespace app.Client.Controllers
{
    public class ProductionHistoryController : Controller
    {
        private ViewModelProductionHistory _viewModel;

        public ProductionHistoryController()
        {
            _viewModel = new ViewModelProductionHistory();
        }

        // GET: ProductionHistory
        public ActionResult Index()
        {
            _viewModel.GetAllProductionHistory();
            return View("ProductionHistory", _viewModel);
        }


    }
}
