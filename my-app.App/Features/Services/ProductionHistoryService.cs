using my_app.App.Dtos;
using my_app.App.Features.Interfaces;
using my_app.DAL;
using my_app.DAL.Entities;
using my_app.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace my_app.App.Features.Services
{
    public class ProductionHistoryService : IDisposable, IService<ProductionHistoryDto>
    {

        private AppDBContext _contex;
        private ProductionHistoryRepository _repository;

        public ProductionHistoryService(AppDBContext context, ProductionHistoryRepository repo)
        {
            _contex = context;
            _repository = repo;
        }


        public List<ProductionHistoryDto> GetInfo()
        {
            var result = _repository.GetAll();
            List<ProductionHistoryDto> list = new List<ProductionHistoryDto>();

            foreach (var item in result)
            {
                list.Add(new ProductionHistoryDto(item));
            }

            return list;

        }


        public ProductionHistoryDto Add(ProductionHistoryDto item)
        {
            var depto = _contex.Department.First(q => q.DepartmentId == item.DepartmentId);
            var empl = _contex.Employee.First(q => q.EmployeeId == item.EmployeeId);

            var newph = new ProductionHistory
            {
                ProductionHistoryId = item.ProductionHistoryId,
                EmployeeId = item.EmployeeId,
                DepartamentoId = item.DepartmentId,
                Date = item.Date,
                Employee = empl,
                Department = depto
            };

            _contex.ProductionHistory.Add(newph);
            _contex.SaveChanges();

            return item;
        }



        public async Task<ProductionHistoryDto> AddAsync(ProductionHistoryDto item)
        {
            var depto = _contex.Department.First(q => q.DepartmentId == item.DepartmentId);
            var empl = _contex.Employee.First(q => q.EmployeeId == item.EmployeeId);

            var newph = new ProductionHistory
            {
                ProductionHistoryId = item.ProductionHistoryId,
                EmployeeId = item.EmployeeId,
                DepartamentoId = item.DepartmentId,
                Date = item.Date,
                Employee = empl,
                Department = depto
            };

            _contex.ProductionHistory.Add(newph);
            await _contex.SaveChangesAsync();

            return item;
        }



        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
