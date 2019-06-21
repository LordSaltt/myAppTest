using my_app.DAL.Entities;
using System;
using System.Runtime.Serialization;

namespace my_app.App.Dtos
{
    [DataContract]
    public class ProductionHistoryDto
    {

        public ProductionHistoryDto()
        {

        }

        public ProductionHistoryDto(ProductionHistory item)
        {
            ProductionHistoryId = item.ProductionHistoryId;
            EmployeeId = item.EmployeeId;
            DepartmentId = item.DepartamentoId;
            Date = item.Date;
            EmployeeName = item.Employee.EmployeeName;
            DepartmentName = item.Department.DepartmentName;
        }



        [DataMember(Name = "ProductionHistoryId")]
        public int ProductionHistoryId { get; set; }

        [DataMember(Name = "EmployeeId")]
        public int EmployeeId { get; set; }

        [DataMember(Name = "DepartmentId")]
        public int DepartmentId { get; set; }

        [DataMember(Name = "Date")]
        public DateTime Date { get; set; }

        [DataMember(Name = "EmployeeName")]
        public string EmployeeName { get; set; }

        [DataMember(Name = "DepartmentName")]
        public string DepartmentName { get; set; }

    }
}