namespace MyTeamTasksWpf.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addPropLogadoNoUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Usuarios", "Logado", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Usuarios", "Logado");
        }
    }
}
