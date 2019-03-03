namespace SchoolApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categoria",
                c => new
                    {
                        CategoriaId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 30),
                        Descricao = c.String(),
                    })
                .PrimaryKey(t => t.CategoriaId);
            
            CreateTable(
                "dbo.Cursos",
                c => new
                    {
                        CursoId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 40),
                        Professor = c.String(nullable: false),
                        QtdVagas = c.Int(nullable: false),
                        Valor = c.Double(nullable: false),
                        Duracao = c.Int(nullable: false),
                        Imagem = c.String(),
                        Descricao = c.String(maxLength: 2000),
                        Categoria_CategoriaId = c.Int(),
                        Modalidade_ModalidadeId = c.Int(),
                        Turno_TurnoId = c.Int(),
                    })
                .PrimaryKey(t => t.CursoId)
                .ForeignKey("dbo.Categoria", t => t.Categoria_CategoriaId)
                .ForeignKey("dbo.Modalidade", t => t.Modalidade_ModalidadeId)
                .ForeignKey("dbo.Turnos", t => t.Turno_TurnoId)
                .Index(t => t.Categoria_CategoriaId)
                .Index(t => t.Modalidade_ModalidadeId)
                .Index(t => t.Turno_TurnoId);
            
            CreateTable(
                "dbo.Modalidade",
                c => new
                    {
                        ModalidadeId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 20),
                        Descricao = c.String(),
                    })
                .PrimaryKey(t => t.ModalidadeId);
            
            CreateTable(
                "dbo.Turnos",
                c => new
                    {
                        TurnoId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.TurnoId);
            
            CreateTable(
                "dbo.Endereco",
                c => new
                    {
                        EnderecoId = c.Int(nullable: false, identity: true),
                        Cep = c.String(),
                        Estado = c.String(nullable: false),
                        Cidade = c.String(nullable: false, maxLength: 50),
                        Bairro = c.String(nullable: false, maxLength: 50),
                        Rua = c.String(nullable: false, maxLength: 50),
                        Numero = c.Int(nullable: false),
                        Complemento = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.EnderecoId);
            
            CreateTable(
                "dbo.Matricula",
                c => new
                    {
                        IdMatricula = c.Int(nullable: false, identity: true),
                        Curso_CursoId = c.Int(),
                        Usuario_UsuarioId = c.Int(),
                    })
                .PrimaryKey(t => t.IdMatricula)
                .ForeignKey("dbo.Cursos", t => t.Curso_CursoId)
                .ForeignKey("dbo.Usuario", t => t.Usuario_UsuarioId)
                .Index(t => t.Curso_CursoId)
                .Index(t => t.Usuario_UsuarioId);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        UsuarioId = c.Int(nullable: false, identity: true),
                        Cpf = c.String(nullable: false),
                        Nome = c.String(nullable: false, maxLength: 50),
                        Telefone = c.String(nullable: false, maxLength: 20),
                        Sexo = c.String(nullable: false),
                        DataNasc = c.DateTime(nullable: false),
                        Email = c.String(nullable: false),
                        Senha = c.String(nullable: false, maxLength: 15),
                        Endereco_EnderecoId = c.Int(),
                        Role_RoleId = c.Int(),
                    })
                .PrimaryKey(t => t.UsuarioId)
                .ForeignKey("dbo.Endereco", t => t.Endereco_EnderecoId)
                .ForeignKey("dbo.Role", t => t.Role_RoleId)
                .Index(t => t.Endereco_EnderecoId)
                .Index(t => t.Role_RoleId);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                    })
                .PrimaryKey(t => t.RoleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Matricula", "Usuario_UsuarioId", "dbo.Usuario");
            DropForeignKey("dbo.Usuario", "Role_RoleId", "dbo.Role");
            DropForeignKey("dbo.Usuario", "Endereco_EnderecoId", "dbo.Endereco");
            DropForeignKey("dbo.Matricula", "Curso_CursoId", "dbo.Cursos");
            DropForeignKey("dbo.Cursos", "Turno_TurnoId", "dbo.Turnos");
            DropForeignKey("dbo.Cursos", "Modalidade_ModalidadeId", "dbo.Modalidade");
            DropForeignKey("dbo.Cursos", "Categoria_CategoriaId", "dbo.Categoria");
            DropIndex("dbo.Usuario", new[] { "Role_RoleId" });
            DropIndex("dbo.Usuario", new[] { "Endereco_EnderecoId" });
            DropIndex("dbo.Matricula", new[] { "Usuario_UsuarioId" });
            DropIndex("dbo.Matricula", new[] { "Curso_CursoId" });
            DropIndex("dbo.Cursos", new[] { "Turno_TurnoId" });
            DropIndex("dbo.Cursos", new[] { "Modalidade_ModalidadeId" });
            DropIndex("dbo.Cursos", new[] { "Categoria_CategoriaId" });
            DropTable("dbo.Role");
            DropTable("dbo.Usuario");
            DropTable("dbo.Matricula");
            DropTable("dbo.Endereco");
            DropTable("dbo.Turnos");
            DropTable("dbo.Modalidade");
            DropTable("dbo.Cursos");
            DropTable("dbo.Categoria");
        }
    }
}
