namespace PlayLend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BoardGameModelUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BoardGames", "PlayerRange", c => c.String());
            DropColumn("dbo.BoardGames", "NumOfPlayers");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BoardGames", "NumOfPlayers", c => c.Int(nullable: false));
            DropColumn("dbo.BoardGames", "PlayerRange");
        }
    }
}
