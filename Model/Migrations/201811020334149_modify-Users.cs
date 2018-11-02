namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyUsers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Branches",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Alias = c.String(maxLength: 128, unicode: false),
                        BranchName = c.String(nullable: false, maxLength: 128, unicode: false),
                        Description = c.String(maxLength: 512),
                        CreatedDate = c.DateTime(storeType: "date"),
                        UpdatedDate = c.DateTime(storeType: "date"),
                        Createdby = c.String(maxLength: 128),
                        UpdatedBy = c.String(maxLength: 128),
                        Image = c.String(unicode: false),
                        Status = c.Boolean(),
                        DisplayOrder = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 128),
                        Alias = c.String(maxLength: 128),
                        BranchID = c.Int(),
                        Image = c.String(unicode: false),
                        MoreImages = c.String(storeType: "xml"),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PromotionPrice = c.Decimal(precision: 18, scale: 2),
                        CreatedDate = c.DateTime(storeType: "date"),
                        UpdatedDate = c.DateTime(storeType: "date"),
                        Quantity = c.Int(nullable: false),
                        Createdby = c.String(maxLength: 128),
                        UpdatedBy = c.String(maxLength: 128),
                        Warranty = c.Int(),
                        Content = c.String(),
                        Description = c.String(nullable: false, maxLength: 500),
                        Status = c.Boolean(),
                        ViewCount = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Branches", t => t.BranchID)
                .Index(t => t.BranchID);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        UserID = c.Int(),
                        ProductID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Products", t => t.ProductID)
                .ForeignKey("dbo.Users", t => t.UserID)
                .Index(t => t.UserID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.CommentDetails",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        CommentID = c.Int(),
                        Content = c.String(maxLength: 512),
                        CreatedDate = c.DateTime(storeType: "date"),
                        Status = c.Boolean(),
                        ParentID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Comments", t => t.CommentID)
                .ForeignKey("dbo.CommentDetails", t => t.ParentID)
                .Index(t => t.CommentID)
                .Index(t => t.ParentID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 128),
                        Address = c.String(maxLength: 256),
                        Phone = c.String(nullable: false, maxLength: 16, unicode: false),
                        BirthDay = c.DateTime(storeType: "date"),
                        Gender = c.String(maxLength: 16, unicode: false),
                        CreatedDate = c.DateTime(storeType: "date"),
                        UpdatedDate = c.DateTime(storeType: "date"),
                        Status = c.Boolean(nullable: false),
                        Username = c.String(nullable: false, maxLength: 128, unicode: false),
                        Password = c.String(nullable: false, maxLength: 128, unicode: false),
                        RoleID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Roles", t => t.RoleID)
                .Index(t => t.Username, unique: true)
                .Index(t => t.RoleID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                        DestinateAdress = c.String(maxLength: 256),
                        Total = c.Decimal(precision: 18, scale: 2),
                        Note = c.String(),
                        PaymentMethod = c.String(maxLength: 256),
                        CreatedDate = c.DateTime(),
                        PaymentStatus = c.Boolean(),
                        Status = c.Boolean(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.UserID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        OrderID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        Quantity = c.Int(),
                    })
                .PrimaryKey(t => new { t.OrderID, t.ProductID })
                .ForeignKey("dbo.Orders", t => t.OrderID)
                .ForeignKey("dbo.Products", t => t.ProductID)
                .Index(t => t.OrderID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        ProductID = c.Int(),
                        UserID = c.Int(),
                        Status = c.Boolean(),
                        Mark = c.Int(),
                        Feedback = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Products", t => t.ProductID)
                .ForeignKey("dbo.Users", t => t.UserID)
                .Index(t => t.ProductID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        RoleName = c.String(maxLength: 10, fixedLength: true),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetails", "ProductID", "dbo.Products");
            DropForeignKey("dbo.Users", "RoleID", "dbo.Roles");
            DropForeignKey("dbo.Ratings", "UserID", "dbo.Users");
            DropForeignKey("dbo.Ratings", "ProductID", "dbo.Products");
            DropForeignKey("dbo.Orders", "UserID", "dbo.Users");
            DropForeignKey("dbo.OrderDetails", "OrderID", "dbo.Orders");
            DropForeignKey("dbo.Comments", "UserID", "dbo.Users");
            DropForeignKey("dbo.Comments", "ProductID", "dbo.Products");
            DropForeignKey("dbo.CommentDetails", "ParentID", "dbo.CommentDetails");
            DropForeignKey("dbo.CommentDetails", "CommentID", "dbo.Comments");
            DropForeignKey("dbo.Products", "BranchID", "dbo.Branches");
            DropIndex("dbo.Ratings", new[] { "UserID" });
            DropIndex("dbo.Ratings", new[] { "ProductID" });
            DropIndex("dbo.OrderDetails", new[] { "ProductID" });
            DropIndex("dbo.OrderDetails", new[] { "OrderID" });
            DropIndex("dbo.Orders", new[] { "UserID" });
            DropIndex("dbo.Users", new[] { "RoleID" });
            DropIndex("dbo.Users", new[] { "Username" });
            DropIndex("dbo.CommentDetails", new[] { "ParentID" });
            DropIndex("dbo.CommentDetails", new[] { "CommentID" });
            DropIndex("dbo.Comments", new[] { "ProductID" });
            DropIndex("dbo.Comments", new[] { "UserID" });
            DropIndex("dbo.Products", new[] { "BranchID" });
            DropTable("dbo.Roles");
            DropTable("dbo.Ratings");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Orders");
            DropTable("dbo.Users");
            DropTable("dbo.CommentDetails");
            DropTable("dbo.Comments");
            DropTable("dbo.Products");
            DropTable("dbo.Branches");
        }
    }
}
