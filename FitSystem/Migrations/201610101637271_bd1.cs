namespace FitSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bd1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Dias", "DiaDesc", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Dias", "DiaDesc", c => c.Int(nullable: false));
        }
    }
}
