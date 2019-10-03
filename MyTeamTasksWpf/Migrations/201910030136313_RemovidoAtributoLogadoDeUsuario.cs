namespace MyTeamTasksWpf.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovidoAtributoLogadoDeUsuario : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Usuarios", "Logado");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Usuarios", "Logado", c => c.String());
        }
    }
}
