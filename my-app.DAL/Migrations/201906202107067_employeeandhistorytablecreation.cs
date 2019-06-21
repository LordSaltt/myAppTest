namespace my_app.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class employeeandhistorytablecreation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        EmployeeName = c.String(maxLength: 255),
                        DepartamentId = c.Int(nullable: false),
                        Departamento_DepartmentId = c.Int(),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.Department", t => t.Departamento_DepartmentId)
                .Index(t => t.Departamento_DepartmentId);
            
            CreateTable(
                "dbo.ProductionHistory",
                c => new
                    {
                        ProductionHistoryId = c.Int(nullable: false, identity: true),
                        EmpleadoId = c.Int(nullable: false),
                        DepartamentoId = c.Int(nullable: false),
                        Fecha = c.DateTime(nullable: false),
                        Department_DepartmentId = c.Int(),
                        Employee_EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductionHistoryId)
                .ForeignKey("dbo.Department", t => t.Department_DepartmentId)
                .ForeignKey("dbo.Employee", t => t.Employee_EmployeeId)
                .Index(t => t.Department_DepartmentId)
                .Index(t => t.Employee_EmployeeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductionHistory", "Employee_EmployeeId", "dbo.Employee");
            DropForeignKey("dbo.ProductionHistory", "Department_DepartmentId", "dbo.Department");
            DropForeignKey("dbo.Employee", "Departamento_DepartmentId", "dbo.Department");
            DropIndex("dbo.ProductionHistory", new[] { "Employee_EmployeeId" });
            DropIndex("dbo.ProductionHistory", new[] { "Department_DepartmentId" });
            DropIndex("dbo.Employee", new[] { "Departamento_DepartmentId" });
            DropTable("dbo.ProductionHistory");
            DropTable("dbo.Employee");
        }
    }
}
