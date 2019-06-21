using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace my_app.DAL.Entities
{
    [Table("Department")]
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }


        [Required]
        [StringLength(100)]
        public string DepartmentName { get; set; }
    }
}
