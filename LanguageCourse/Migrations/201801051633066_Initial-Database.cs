namespace LanguageCourse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Certificates",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        CourseId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.CertificateLinks",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CertificateId = c.Guid(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Certificates", t => t.CertificateId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.CertificateId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserType = c.Byte(nullable: false),
                        EducationId = c.Guid(nullable: false),
                        ContactId = c.Guid(nullable: false),
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
                .ForeignKey("dbo.Contacts", t => t.ContactId, cascadeDelete: true)
                .ForeignKey("dbo.Educations", t => t.EducationId, cascadeDelete: true)
                .Index(t => t.EducationId)
                .Index(t => t.ContactId)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Phone = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CourseLinks",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CourseId = c.Guid(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.CourseId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        Comment = c.String(),
                        LessonId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Lessons", t => t.LessonId, cascadeDelete: true)
                .Index(t => t.LessonId);
            
            CreateTable(
                "dbo.Lessons",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Pays",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        PayType = c.Byte(nullable: false),
                        Total = c.Double(nullable: false),
                        CourseId = c.Guid(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.CourseId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Educations",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        GraduationStatus = c.Byte(nullable: false),
                        SchoolName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "Id", "dbo.Users");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.Users");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "EducationId", "dbo.Educations");
            DropForeignKey("dbo.CourseLinks", "UserId", "dbo.Users");
            DropForeignKey("dbo.Pays", "UserId", "dbo.Users");
            DropForeignKey("dbo.Pays", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Courses", "LessonId", "dbo.Lessons");
            DropForeignKey("dbo.CourseLinks", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Certificates", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Users", "ContactId", "dbo.Contacts");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.Users");
            DropForeignKey("dbo.CertificateLinks", "UserId", "dbo.Users");
            DropForeignKey("dbo.CertificateLinks", "CertificateId", "dbo.Certificates");
            DropIndex("dbo.AspNetUsers", new[] { "Id" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.Pays", new[] { "UserId" });
            DropIndex("dbo.Pays", new[] { "CourseId" });
            DropIndex("dbo.Courses", new[] { "LessonId" });
            DropIndex("dbo.CourseLinks", new[] { "UserId" });
            DropIndex("dbo.CourseLinks", new[] { "CourseId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.Users", "UserNameIndex");
            DropIndex("dbo.Users", new[] { "ContactId" });
            DropIndex("dbo.Users", new[] { "EducationId" });
            DropIndex("dbo.CertificateLinks", new[] { "UserId" });
            DropIndex("dbo.CertificateLinks", new[] { "CertificateId" });
            DropIndex("dbo.Certificates", new[] { "CourseId" });
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.Educations");
            DropTable("dbo.Pays");
            DropTable("dbo.Lessons");
            DropTable("dbo.Courses");
            DropTable("dbo.CourseLinks");
            DropTable("dbo.Contacts");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.Users");
            DropTable("dbo.CertificateLinks");
            DropTable("dbo.Certificates");
        }
    }
}
