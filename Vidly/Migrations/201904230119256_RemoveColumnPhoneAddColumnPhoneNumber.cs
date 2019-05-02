namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveColumnPhoneAddColumnPhoneNumber : DbMigration
    {
        public override void Up()
        {
            Sql("EXEC sp_RENAME 'AspNetUsers.Phone', 'PhoneNumber', 'COLUMN'");


        }
        
        public override void Down()
        {
        }
    }
}
