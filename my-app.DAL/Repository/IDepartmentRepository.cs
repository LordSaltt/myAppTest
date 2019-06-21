using my_app.DAL.Entities;
using System.Collections.Generic;

namespace my_app.DAL.Repository
{
    interface IProductionHitory
    {

        void Add(ProductionHistory production);

        void Edit(ProductionHistory production);

        void Remove(int id);

        IEnumerable<ProductionHistory> GetAll();

        ProductionHistory FindById(int id);
    }
}
