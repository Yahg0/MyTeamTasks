namespace MyTeamTasksWpf.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class correcaoDoTipoNickNameDoUsuario : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Usuarios", "Nickname", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Usuarios", "Nickname", c => c.Int(nullable: false));
        }
    }
}
