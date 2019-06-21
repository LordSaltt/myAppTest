using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace my_app.DAL.Entities
{
    [Table("ProductionHistory")]
    public class ProductionHistory
    {
        [Key]
        public int ProductionHistoryId { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        [Required]
        public int DepartamentoId { get; set; }

        public DateTime Date { get; set; }

        public Employee Employee { get; set; }

        public Department Department { get; set; }

    }
}
