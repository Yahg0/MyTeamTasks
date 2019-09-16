namespace MyTeamTasksWpf.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionadoProjetoEmCliente : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Projetos", "Status", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Projetos", "Status", c => c.Boolean(nullable: false));
        }
    }
}
