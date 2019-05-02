namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipType : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MembershipTypes (Id, Name, DurationInMonths, SignUpFee, Discount) VALUES (1, 'Pay As You Go', 0, 0, 0)");
            Sql("INSERT INTO MembershipTypes (Id, Name, DurationInMonths, SignUpFee, Discount) VALUES (2, 'Monthly', 1, 30, 10)");
            Sql("INSERT INTO MembershipTypes (Id, Name, DurationInMonths, SignUpFee, Discount) VALUES (3, 'Quarterly', 3, 90, 15)");
            Sql("INSERT INTO MembershipTypes (Id, Name, DurationInMonths, SignUpFee, Discount) VALUES (4, 'Yearly', 12, 300, 20)");
        }
        
        public override void Down()
        {
        }
    }
}
