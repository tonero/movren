namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenre : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Id, Name) Values(1, 'Action')");
            Sql("INSERT INTO Genres (Id, Name) Values(2, 'Drama')");
            Sql("INSERT INTO Genres (Id, Name) Values(3, 'Sci-Fi')");
            Sql("INSERT INTO Genres (Id, Name) Values(4, 'Thriller')");
        }
        
        public override void Down()
        {
        }
    }
}
