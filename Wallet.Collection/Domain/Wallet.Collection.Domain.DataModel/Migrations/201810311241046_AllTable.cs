namespace Wallet.Collection.Domain.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AllTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Account",
                c => new
                {
                    Id = c.Long(nullable: false, identity: true),
                    AccountNumber = c.String(),
                    Status = c.Int(nullable: false),
                    UserId = c.Long(nullable: false),
                    AccountTypeId = c.Int(nullable: false),
                    CreatedOn = c.DateTime(nullable: false),
                    CreatedBy = c.Long(nullable: false)
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AccountType", t => t.AccountTypeId)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.AccountTypeId);

            CreateTable(
                "dbo.AccountType",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Code = c.String(),
                    Type = c.Int(nullable: false),
                    CurrenyCode = c.Int(nullable: false),
                    CreatedOn = c.DateTime(nullable: false),
                    CreatedBy = c.Long(nullable: false)
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Transaction",
                c => new
                {
                    Id = c.Long(nullable: false, identity: true),
                    AccountId = c.Long(nullable: false),
                    ProvisionId = c.Long(nullable: false),
                    TransactionStatus = c.Int(nullable: false),
                    TransactionDateTime = c.DateTime(nullable: false),
                    AcceptanceDateTime = c.DateTime(),
                    BalanceType = c.Int(nullable: false),
                    Money_Amount = c.Long(nullable: false),
                    Money_CurrencyCode = c.Int(nullable: false),
                    CreatedOn = c.DateTime(nullable: false),
                    CreatedBy = c.Long(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Account", t => t.AccountId)
                .ForeignKey("dbo.Provision", t => t.ProvisionId)
                .Index(t => t.AccountId)
                .Index(t => t.ProvisionId);

            CreateTable(
                "dbo.Provision",
                c => new
                {
                    Id = c.Long(nullable: false, identity: true),
                    ExternalProvision = c.String(),
                    UserId = c.Long(nullable: false),
                    CreatedOn = c.DateTime(nullable: false),
                    CreatedBy = c.Long(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId);

            CreateTable(
                "dbo.User",
                c => new
                {
                    Id = c.Long(nullable: false, identity: true),
                    UserCode = c.String(),
                    Email = c.String(),
                    Password = c.String(),
                    Status = c.Int(nullable: false),
                    CreatedOn = c.DateTime(nullable: false),
                    CreatedBy = c.Long(nullable: false),
                })
                .PrimaryKey(t => t.Id);

        }

        public override void Down()
        {
            DropForeignKey("dbo.Provision", "UserId", "dbo.User");
            DropForeignKey("dbo.Account", "UserId", "dbo.User");
            DropForeignKey("dbo.Transaction", "ProvisionId", "dbo.Provision");
            DropForeignKey("dbo.Transaction", "AccountId", "dbo.Account");
            DropForeignKey("dbo.Account", "AccountTypeId", "dbo.AccountType");
            DropIndex("dbo.Provision", new[] { "UserId" });
            DropIndex("dbo.Transaction", new[] { "ProvisionId" });
            DropIndex("dbo.Transaction", new[] { "AccountId" });
            DropIndex("dbo.Account", new[] { "AccountTypeId" });
            DropIndex("dbo.Account", new[] { "UserId" });
            DropTable("dbo.User");
            DropTable("dbo.Provision");
            DropTable("dbo.Transaction");
            DropTable("dbo.AccountType");
            DropTable("dbo.Account");
        }
    }
}
