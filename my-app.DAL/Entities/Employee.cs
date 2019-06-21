using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace my_app.DAL.Entities
{
    [Table("Employee")]
    public class Employee
    {

        [Key]
        public int EmployeeId { get; set; }

        [StringLength(255)]
        public string EmployeeName { get; set; }

        public int DepartamentId { get; set; }

        public Department Departamento { get; set; }
    }
}
