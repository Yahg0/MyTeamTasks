namespace MyTeamTasksWpf.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removidoAtributoRepetidoDeUsuarioNaTarefa : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tarefas", "Usuario_UsuarioId", "dbo.Usuarios");
            DropIndex("dbo.Tarefas", new[] { "Usuario_UsuarioId" });
            DropColumn("dbo.Tarefas", "Usuario_UsuarioId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tarefas", "Usuario_UsuarioId", c => c.Int());
            CreateIndex("dbo.Tarefas", "Usuario_UsuarioId");
            AddForeignKey("dbo.Tarefas", "Usuario_UsuarioId", "dbo.Usuarios", "UsuarioId");
        }
    }
}
