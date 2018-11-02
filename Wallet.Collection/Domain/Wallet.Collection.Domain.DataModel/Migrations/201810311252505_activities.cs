namespace Wallet.Collection.Domain.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class activities : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccountActivities",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ProvisionId = c.Long(nullable: false),
                        TransactionId = c.Long(nullable: false),
                        AccountId = c.Long(nullable: false),
                        Money_Amount = c.Long(nullable: false),
                        Money_CurrencyCode = c.Int(nullable: false),
                        BalanceType = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        CreatedBy = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Account", t => t.AccountId)
                .ForeignKey("dbo.Provision", t => t.ProvisionId)
                .ForeignKey("dbo.Transaction", t => t.TransactionId)
                .Index(t => t.ProvisionId)
                .Index(t => t.TransactionId)
                .Index(t => t.AccountId);
            
            AlterColumn("dbo.Transaction", "Money_CurrencyCode", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AccountActivities", "TransactionId", "dbo.Transaction");
            DropForeignKey("dbo.AccountActivities", "ProvisionId", "dbo.Provision");
            DropForeignKey("dbo.AccountActivities", "AccountId", "dbo.Account");
            DropIndex("dbo.AccountActivities", new[] { "AccountId" });
            DropIndex("dbo.AccountActivities", new[] { "TransactionId" });
            DropIndex("dbo.AccountActivities", new[] { "ProvisionId" });
            AlterColumn("dbo.Transaction", "Money_CurrencyCode", c => c.Short(nullable: false));
            DropTable("dbo.AccountActivities");
        }
    }
}
