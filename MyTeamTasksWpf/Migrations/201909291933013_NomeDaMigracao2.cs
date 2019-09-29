namespace MyTeamTasksWpf.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NomeDaMigracao2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pessoas",
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
                        Assinatura_UsuarioId = c.Int(),
                        Cliente_PessoaId = c.Int(),
                        Projeto_ProjetoId = c.Int(),
                        Requisitante_UsuarioId = c.Int(),
                    })
                .PrimaryKey(t => t.TarefaId)
                .ForeignKey("dbo.Usuarios", t => t.Assinatura_UsuarioId)
                .ForeignKey("dbo.Clientes", t => t.Cliente_PessoaId)
                .ForeignKey("dbo.Projetos", t => t.Projeto_ProjetoId)
                .ForeignKey("dbo.Usuarios", t => t.Requisitante_UsuarioId)
                .Index(t => t.Assinatura_UsuarioId)
                .Index(t => t.Cliente_PessoaId)
                .Index(t => t.Projeto_ProjetoId)
                .Index(t => t.Requisitante_UsuarioId);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        UsuarioId = c.Int(nullable: false, identity: true),
                        Cargo = c.String(),
                        Nickname = c.String(),
                        Senha = c.String(),
                        CriadoEm = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UsuarioId);
            
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        PessoaId = c.Int(nullable: false),
                        ClienteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PessoaId)
                .ForeignKey("dbo.Pessoas", t => t.PessoaId)
                .Index(t => t.PessoaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Clientes", "PessoaId", "dbo.Pessoas");
            DropForeignKey("dbo.Tarefas", "Requisitante_UsuarioId", "dbo.Usuarios");
            DropForeignKey("dbo.Tarefas", "Projeto_ProjetoId", "dbo.Projetos");
            DropForeignKey("dbo.Tarefas", "Cliente_PessoaId", "dbo.Clientes");
            DropForeignKey("dbo.Tarefas", "Assinatura_UsuarioId", "dbo.Usuarios");
            DropForeignKey("dbo.Projetos", "Cliente_PessoaId", "dbo.Clientes");
            DropIndex("dbo.Clientes", new[] { "PessoaId" });
            DropIndex("dbo.Tarefas", new[] { "Requisitante_UsuarioId" });
            DropIndex("dbo.Tarefas", new[] { "Projeto_ProjetoId" });
            DropIndex("dbo.Tarefas", new[] { "Cliente_PessoaId" });
            DropIndex("dbo.Tarefas", new[] { "Assinatura_UsuarioId" });
            DropIndex("dbo.Projetos", new[] { "Cliente_PessoaId" });
            DropTable("dbo.Clientes");
            DropTable("dbo.Usuarios");
            DropTable("dbo.Tarefas");
            DropTable("dbo.Projetos");
            DropTable("dbo.Pessoas");
        }
    }
}
