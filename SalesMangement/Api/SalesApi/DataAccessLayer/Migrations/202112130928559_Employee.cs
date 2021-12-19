namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Employee : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeID = c.Int(nullable: false, identity: true),
                        EmailID = c.String(),
                        Password = c.String(),
                        ContactNo = c.String(),
                    })
                .PrimaryKey(t => t.EmployeeID);
            
            DropTable("dbo.Users");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        EmailID = c.String(),
                        Password = c.String(),
                        ContactNo = c.String(),
                    })
                .PrimaryKey(t => t.UserID);
            
            DropTable("dbo.Employees");
        }
    }
}
