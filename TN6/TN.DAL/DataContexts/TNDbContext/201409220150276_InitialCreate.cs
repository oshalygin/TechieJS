namespace TN.DAL.DataContexts.TNDbContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AnonymousSubscriptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmailAddress = c.String(nullable: false),
                        DateSubscribed = c.DateTime(nullable: false),
                        UnsubscribedDate = c.DateTime(),
                        Unsubscribed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AnonymousSubscriptions");
        }
    }
}
