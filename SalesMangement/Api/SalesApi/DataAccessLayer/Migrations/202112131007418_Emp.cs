namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Emp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "EmployeeName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "EmployeeName");
        }
    }
}
