namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'44afead7-382f-41c3-a9a5-111cc5967357', N'guest@vidly.com', 0, N'AMNNQEzDDZFDOLQI4WkzQ8AN5ADlvVhb4ighRxrsHFYcf6z6e9d/xBR3VdeRQWp2jw==', N'6e36d604-e347-471e-b721-36af6dd16e09', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'a8c4d627-112e-430b-bb31-727cd5dc5b58', N'admin@vidly.com', 0, N'AKzl4yQUMd6z/fFC8ZUZo9nL9xV6XBEKWkN9TdEumJ1HF3c69n522wLnJAsNrQuCkg==', N'2a0fc4d5-566d-44b9-8cae-6a1f28b544ab', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
            INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'b4d2a822-b286-42a6-b445-08c20bd8c300', N'CanManageMovies')
            INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'a8c4d627-112e-430b-bb31-727cd5dc5b58', N'b4d2a822-b286-42a6-b445-08c20bd8c300')
            ");
        }
        
        public override void Down()
        {
        }
    }
}
