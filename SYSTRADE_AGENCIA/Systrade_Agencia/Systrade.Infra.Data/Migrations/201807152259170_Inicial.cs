namespace Systrade.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Agencia",
                c => new
                {
                    AgenciaId = c.Guid(nullable: false),
                    NomeFantasia = c.String(nullable: false, maxLength: 100, unicode: false),
                    RazaoSocial = c.String(nullable: false, maxLength: 100, unicode: false),
                    CNPJ = c.String(nullable: false, maxLength: 14, unicode: false),
                    TelefoneFixo = c.String(maxLength: 10, unicode: false),
                    DataCadastro = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.AgenciaId);

            CreateTable(
                "dbo.AgenciaUsuario",
                c => new
                {
                    UsuarioId = c.String(nullable: false, maxLength: 100, unicode: false),
                    AgenciaId = c.Guid(nullable: false),
                    Nome = c.String(nullable: false, maxLength: 100, unicode: false),
                    Sobrenome = c.String(nullable: false, maxLength: 100, unicode: false),
                    CPF = c.String(nullable: false, maxLength: 11, unicode: false),
                    Celular = c.String(nullable: false, maxLength: 11, unicode: false),
                    TelefoneFixo = c.String(maxLength: 10, unicode: false),
                    Email = c.String(nullable: false, maxLength: 100, unicode: false),
                    Descricao = c.String(maxLength: 150, unicode: false),
                    Status = c.Boolean(nullable: false),
                    DataCadastro = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.UsuarioId)
                .ForeignKey("dbo.Agencia", t => t.AgenciaId)
                .Index(t => t.AgenciaId)
                .Index(t => t.CPF, unique: true);

            CreateTable(
                "dbo.Enderecos",
                c => new
                {
                    EnderecoId = c.Guid(nullable: false),
                    AgenciaId = c.Guid(nullable: false),
                    Descricao = c.String(maxLength: 150, unicode: false),
                    Logradouro = c.String(nullable: false, maxLength: 150, unicode: false),
                    Complemento = c.String(maxLength: 100, unicode: false),
                    Numero = c.String(nullable: false, maxLength: 6, unicode: false),
                    Cidade = c.String(nullable: false, maxLength: 150, unicode: false),
                    Estado = c.String(nullable: false, maxLength: 2, unicode: false),
                    Cep = c.String(maxLength: 8, unicode: false),
                })
                .PrimaryKey(t => t.EnderecoId)
                .ForeignKey("dbo.Agencia", t => t.AgenciaId)
                .Index(t => t.AgenciaId);

            CreateTable(
                "dbo.AspNetClaims",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    ClaimValue = c.String(nullable: false, maxLength: 256, unicode: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.RegistroUsuario",
                c => new
                {
                    RegistroUsuarioId = c.Guid(nullable: false),
                    UsuarioId = c.Guid(nullable: false),
                    Login = c.String(nullable: false, maxLength: 100, unicode: false),
                    IP = c.String(nullable: false, maxLength: 100, unicode: false),
                    Registro = c.String(maxLength: 100, unicode: false),
                    DataCadastro = c.DateTime(nullable: false, precision: 0, storeType: "datetime2"),
                })
                .PrimaryKey(t => t.RegistroUsuarioId);

        }

        public override void Down()
        {
            DropForeignKey("dbo.Enderecos", "AgenciaId", "dbo.Agencia");
            DropForeignKey("dbo.AgenciaUsuario", "AgenciaId", "dbo.Agencia");
            DropIndex("dbo.Enderecos", new[] { "AgenciaId" });
            DropIndex("dbo.AgenciaUsuario", new[] { "CPF" });
            DropIndex("dbo.AgenciaUsuario", new[] { "AgenciaId" });
            DropTable("dbo.RegistroUsuario");
            DropTable("dbo.AspNetClaims");
            DropTable("dbo.Enderecos");
            DropTable("dbo.AgenciaUsuario");
            DropTable("dbo.Agencia");
        }
    }
}
