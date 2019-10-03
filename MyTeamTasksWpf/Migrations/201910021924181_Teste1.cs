namespace MyTeamTasksWpf.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Teste1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        PessoaId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        CriadoEm = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PessoaId);
            
            CreateTable(
                "dbo.Projetos",
                c => new
                    {
                        ProjetoId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Status = c.String(),
                        CriadoEm = c.DateTime(nullable: false),
                        Cliente_PessoaId = c.Int(),
                    })
                .PrimaryKey(t => t.ProjetoId)
                .ForeignKey("dbo.Clientes", t => t.Cliente_PessoaId)
                .Index(t => t.Cliente_PessoaId);
            
            CreateTable(
                "dbo.Tarefas",
                c => new
                    {
                        TarefaId = c.Int(nullable: false, identity: true),
                        Titulo = c.String(),
                        Tipo = c.String(),
                        Status = c.String(),
                        Prioridade = c.String(),
                        Resolucao = c.String(),
                        Descricao = c.String(),
                        CriadoEm = c.DateTime(nullable: false),
                        Assinatura_PessoaId = c.Int(),
                        Cliente_PessoaId = c.Int(),
                        Projeto_ProjetoId = c.Int(),
                        Requisitante_PessoaId = c.Int(),
                    })
                .PrimaryKey(t => t.TarefaId)
                .ForeignKey("dbo.Usuarios", t => t.Assinatura_PessoaId)
                .ForeignKey("dbo.Clientes", t => t.Cliente_PessoaId)
                .ForeignKey("dbo.Projetos", t => t.Projeto_ProjetoId)
                .ForeignKey("dbo.Usuarios", t => t.Requisitante_PessoaId)
                .Index(t => t.Assinatura_PessoaId)
                .Index(t => t.Cliente_PessoaId)
                .Index(t => t.Projeto_ProjetoId)
                .Index(t => t.Requisitante_PessoaId);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        PessoaId = c.Int(nullable: false, identity: true),
                        Cargo = c.String(),
                        Nickname = c.String(),
                        Senha = c.String(),
                        Logado = c.Boolean(nullable: false),
                        Nome = c.String(),
                        CriadoEm = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PessoaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tarefas", "Requisitante_PessoaId", "dbo.Usuarios");
            DropForeignKey("dbo.Tarefas", "Projeto_ProjetoId", "dbo.Projetos");
            DropForeignKey("dbo.Tarefas", "Cliente_PessoaId", "dbo.Clientes");
            DropForeignKey("dbo.Tarefas", "Assinatura_PessoaId", "dbo.Usuarios");
            DropForeignKey("dbo.Projetos", "Cliente_PessoaId", "dbo.Clientes");
            DropIndex("dbo.Tarefas", new[] { "Requisitante_PessoaId" });
            DropIndex("dbo.Tarefas", new[] { "Projeto_ProjetoId" });
            DropIndex("dbo.Tarefas", new[] { "Cliente_PessoaId" });
            DropIndex("dbo.Tarefas", new[] { "Assinatura_PessoaId" });
            DropIndex("dbo.Projetos", new[] { "Cliente_PessoaId" });
            DropTable("dbo.Usuarios");
            DropTable("dbo.Tarefas");
            DropTable("dbo.Projetos");
            DropTable("dbo.Clientes");
        }
    }
}
