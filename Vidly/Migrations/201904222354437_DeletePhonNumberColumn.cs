namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeletePhonNumberColumn : DbMigration
    {
        public override void Up()
        {
            Sql("ALTER TABLE AspNetUsers DROP COLUMN PhoneNumber");
        }
        
        public override void Down()
        {
        }
    }
}
