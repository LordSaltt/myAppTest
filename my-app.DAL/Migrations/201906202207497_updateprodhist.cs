namespace my_app.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateprodhist : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.ProductionHistory", name: "Employee_EmployeeId", newName: "EmployeeId");
            RenameIndex(table: "dbo.ProductionHistory", name: "IX_Employee_EmployeeId", newName: "IX_EmployeeId");
            AddColumn("dbo.ProductionHistory", "Date", c => c.DateTime(nullable: false));
            DropColumn("dbo.ProductionHistory", "EmpleadoId");
            DropColumn("dbo.ProductionHistory", "Fecha");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProductionHistory", "Fecha", c => c.DateTime(nullable: false));
            AddColumn("dbo.ProductionHistory", "EmpleadoId", c => c.Int(nullable: false));
            DropColumn("dbo.ProductionHistory", "Date");
            RenameIndex(table: "dbo.ProductionHistory", name: "IX_EmployeeId", newName: "IX_Employee_EmployeeId");
            RenameColumn(table: "dbo.ProductionHistory", name: "EmployeeId", newName: "Employee_EmployeeId");
        }
    }
}
