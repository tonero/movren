namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnPhoneNumber : DbMigration
    {
        public override void Up()
        {
            Sql("ALTER TABLE AspNetUsers ADD PhoneNumber VARCHAR(255)");
        }
        
        public override void Down()
        {
        }
    }
}
