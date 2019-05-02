namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserAndAdminSeedData : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'30c7cc1f-3639-46c0-b10e-dd1de91a1e38', N'admin@vidly.com', 0, N'AAN6hErAR8ouxgopfOG9/cG85YPc+ZTDocd6VXjI//cMMg8P32AxM2ZRTG7k8XRFYQ==', N'9dcecf3d-6a7d-4a56-9703-74f45a438a0b', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'411ad01c-f0b5-4971-98e2-1e8e99ed1907', N'guest@vidly.com', 0, N'ALY14XLh1eS0ERTH/m8lj4w30mF3nsTICF6anGt8laS1eTPr2MkUrbRzQurM5ZZq9g==', N'53916c44-e407-4faf-8990-60d1637957c2', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'6178ee6e-9d8d-4b33-8e17-ef52f577134f', N'CanManageMovies')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'30c7cc1f-3639-46c0-b10e-dd1de91a1e38', N'6178ee6e-9d8d-4b33-8e17-ef52f577134f')
");
        }
        
        public override void Down()
        {
        }
    }
}
