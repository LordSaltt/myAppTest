using my_app.DAL.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace my_app.DAL.Repository
{
    public class ProductionHistoryRepository : IProductionHitory
    {

        private AppDBContext _context;

        public ProductionHistoryRepository(AppDBContext context)
        {
            _context = context;
        }

        public void Add(ProductionHistory production)
        {
            _context.ProductionHistory.Add(production);
            _context.SaveChanges();
        }

        public void Edit(ProductionHistory production)
        {
            _context.Entry(production).State = EntityState.Modified;
        }

        public ProductionHistory FindById(int id)
        {
            return _context.ProductionHistory.First(q => q.ProductionHistoryId == id);

        }

        public IEnumerable<ProductionHistory> GetAll()
        {
            return _context.ProductionHistory
                        .Include(d=> d.Department)
                        .Include(e=> e.Employee);
        }

        public void Remove(int id)
        {
            ProductionHistory p = _context.ProductionHistory.Find(id);
            _context.ProductionHistory.Remove(p);
            _context.SaveChanges();
        }
    }
}
