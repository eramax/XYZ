namespace XYZ.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdminClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsDeleted = c.Boolean(),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Admin", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AdminLogin",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.Admin", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AdminRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.Admin", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.RoleForAdmin", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Admin",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(),
                        Active = c.Boolean(),
                        MobileNumber = c.String(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Email, unique: true, name: "UserEmailIndex")
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CreationDate = c.DateTime(),
                        LastUpdate = c.DateTime(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RoleForAdmin",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.RoleForUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.UserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.RoleForUser", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.TagLogs",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TagId = c.Long(nullable: false),
                        UserToId = c.String(maxLength: 128),
                        UserFromId = c.String(maxLength: 128),
                        CreationDate = c.DateTime(),
                        LastUpdate = c.DateTime(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tags", t => t.TagId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserFromId)
                .ForeignKey("dbo.User", t => t.UserToId)
                .Index(t => t.TagId)
                .Index(t => t.UserToId)
                .Index(t => t.UserFromId);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Body = c.String(),
                        ExpiryDate = c.DateTime(),
                        GroupId = c.Long(nullable: false),
                        TagStatusId = c.Long(nullable: false),
                        CreationDate = c.DateTime(),
                        LastUpdate = c.DateTime(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Groups", t => t.GroupId, cascadeDelete: true)
                .ForeignKey("dbo.TagStatus", t => t.TagStatusId, cascadeDelete: true)
                .Index(t => t.GroupId)
                .Index(t => t.TagStatusId);
            
            CreateTable(
                "dbo.TagStatus",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        CreationDate = c.DateTime(),
                        LastUpdate = c.DateTime(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(),
                        CountryCode = c.String(),
                        Name = c.String(),
                        Photo = c.String(),
                        MobileNumber = c.String(nullable: false),
                        Active = c.Boolean(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Email, unique: true, name: "UserEmailIndex")
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.UserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsDeleted = c.Boolean(),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserLogin",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserDevices",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        DeviceToken = c.String(),
                        UserId = c.String(nullable: false, maxLength: 128),
                        OSType = c.String(nullable: false),
                        CreationDate = c.DateTime(),
                        LastUpdate = c.DateTime(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserFriends",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        UserId1 = c.String(maxLength: 128),
                        UserId2 = c.String(maxLength: 128),
                        CreationDate = c.DateTime(),
                        LastUpdate = c.DateTime(),
                        IsDeleted = c.Boolean(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId1)
                .ForeignKey("dbo.User", t => t.UserId2)
                .ForeignKey("dbo.User", t => t.User_Id)
                .Index(t => t.UserId1)
                .Index(t => t.UserId2)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.UserFriendBlocks",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        BlockedUserId = c.String(maxLength: 128),
                        CreationDate = c.DateTime(),
                        LastUpdate = c.DateTime(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.BlockedUserId)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.BlockedUserId);
            
            CreateTable(
                "dbo.UserGroups",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        GroupId = c.Long(nullable: false),
                        CreationDate = c.DateTime(),
                        LastUpdate = c.DateTime(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Groups", t => t.GroupId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.GroupId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserGroups", "UserId", "dbo.User");
            DropForeignKey("dbo.UserGroups", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.UserFriendBlocks", "UserId", "dbo.User");
            DropForeignKey("dbo.UserFriendBlocks", "BlockedUserId", "dbo.User");
            DropForeignKey("dbo.TagLogs", "UserToId", "dbo.User");
            DropForeignKey("dbo.TagLogs", "UserFromId", "dbo.User");
            DropForeignKey("dbo.UserFriends", "User_Id", "dbo.User");
            DropForeignKey("dbo.UserFriends", "UserId2", "dbo.User");
            DropForeignKey("dbo.UserFriends", "UserId1", "dbo.User");
            DropForeignKey("dbo.UserDevices", "UserId", "dbo.User");
            DropForeignKey("dbo.UserRole", "UserId", "dbo.User");
            DropForeignKey("dbo.UserLogin", "UserId", "dbo.User");
            DropForeignKey("dbo.UserClaim", "UserId", "dbo.User");
            DropForeignKey("dbo.TagLogs", "TagId", "dbo.Tags");
            DropForeignKey("dbo.Tags", "TagStatusId", "dbo.TagStatus");
            DropForeignKey("dbo.Tags", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.UserRole", "RoleId", "dbo.RoleForUser");
            DropForeignKey("dbo.AdminRole", "RoleId", "dbo.RoleForAdmin");
            DropForeignKey("dbo.AdminRole", "UserId", "dbo.Admin");
            DropForeignKey("dbo.AdminLogin", "UserId", "dbo.Admin");
            DropForeignKey("dbo.AdminClaim", "UserId", "dbo.Admin");
            DropIndex("dbo.UserGroups", new[] { "GroupId" });
            DropIndex("dbo.UserGroups", new[] { "UserId" });
            DropIndex("dbo.UserFriendBlocks", new[] { "BlockedUserId" });
            DropIndex("dbo.UserFriendBlocks", new[] { "UserId" });
            DropIndex("dbo.UserFriends", new[] { "User_Id" });
            DropIndex("dbo.UserFriends", new[] { "UserId2" });
            DropIndex("dbo.UserFriends", new[] { "UserId1" });
            DropIndex("dbo.UserDevices", new[] { "UserId" });
            DropIndex("dbo.UserLogin", new[] { "UserId" });
            DropIndex("dbo.UserClaim", new[] { "UserId" });
            DropIndex("dbo.User", "UserNameIndex");
            DropIndex("dbo.User", "UserEmailIndex");
            DropIndex("dbo.Tags", new[] { "TagStatusId" });
            DropIndex("dbo.Tags", new[] { "GroupId" });
            DropIndex("dbo.TagLogs", new[] { "UserFromId" });
            DropIndex("dbo.TagLogs", new[] { "UserToId" });
            DropIndex("dbo.TagLogs", new[] { "TagId" });
            DropIndex("dbo.UserRole", new[] { "RoleId" });
            DropIndex("dbo.UserRole", new[] { "UserId" });
            DropIndex("dbo.RoleForUser", "RoleNameIndex");
            DropIndex("dbo.RoleForAdmin", "RoleNameIndex");
            DropIndex("dbo.Admin", "UserNameIndex");
            DropIndex("dbo.Admin", "UserEmailIndex");
            DropIndex("dbo.AdminRole", new[] { "RoleId" });
            DropIndex("dbo.AdminRole", new[] { "UserId" });
            DropIndex("dbo.AdminLogin", new[] { "UserId" });
            DropIndex("dbo.AdminClaim", new[] { "UserId" });
            DropTable("dbo.UserGroups");
            DropTable("dbo.UserFriendBlocks");
            DropTable("dbo.UserFriends");
            DropTable("dbo.UserDevices");
            DropTable("dbo.UserLogin");
            DropTable("dbo.UserClaim");
            DropTable("dbo.User");
            DropTable("dbo.TagStatus");
            DropTable("dbo.Tags");
            DropTable("dbo.TagLogs");
            DropTable("dbo.UserRole");
            DropTable("dbo.RoleForUser");
            DropTable("dbo.RoleForAdmin");
            DropTable("dbo.Groups");
            DropTable("dbo.Admin");
            DropTable("dbo.AdminRole");
            DropTable("dbo.AdminLogin");
            DropTable("dbo.AdminClaim");
        }
    }
}
