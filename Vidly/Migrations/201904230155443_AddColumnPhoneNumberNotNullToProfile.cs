namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnPhoneNumberNotNullToProfile : DbMigration
    {
        public override void Up()
        {
            Sql("ALTER TABLE AspNetUsers DROP COLUMN PhoneNumber");
            Sql("ALTER TABLE AspNetUsers ADD PhoneNumber VARCHAR(255) DEFAULT ' '");
        }
        
        public override void Down()
        {
        }
    }
}
