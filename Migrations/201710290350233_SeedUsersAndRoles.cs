namespace Cashflow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsersAndRoles : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                    INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'125d38d5-bdc8-4b4a-ac1b-be683422b5fd', N'admin')
                    INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'47ee818f-97c0-4ce1-98a6-2c5ae61ffa0a', N'user')

                    INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'107cae41-3567-4a0d-a75c-cc9c66804d3b', N'admin@cashflow.com', 0, N'ALXICyDP+Jpn0XJXgo69Nt5j2e98IOFncUQPDHjLkncWl5ySRhq/repXsDrJEtvhEA==', N'af31b2aa-c301-465c-b5ba-42b7e1764ea4', NULL, 0, 0, NULL, 1, 0, N'admin@cashflow.com')
                    INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'999a58d3-03a6-4044-b21f-7a5d34452ce6', N'random@cashflow.com', 0, N'AFLr8x6uE+MkKL1Kwtvy3FpyMVubhaGX9ZD5FBAzVK5UzXkCFuTF5VUwxOVFh53RqA==', N'f8403979-ca1f-456c-800e-d206a8516084', NULL, 0, 0, NULL, 1, 0, N'random@cashflow.com')                    
                    
                    INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'107cae41-3567-4a0d-a75c-cc9c66804d3b', N'125d38d5-bdc8-4b4a-ac1b-be683422b5fd')
                    INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'999a58d3-03a6-4044-b21f-7a5d34452ce6', N'47ee818f-97c0-4ce1-98a6-2c5ae61ffa0a')

                ");
        }
        
        public override void Down()
        {
        }
    }
}
