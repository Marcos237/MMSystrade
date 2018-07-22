namespace Systrade.Core.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Auditoria01 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CadastroAuditoria",
                c => new
                    {
                        CadastroAuditoriaId = c.Guid(nullable: false),
                        UsuarioId = c.Guid(nullable: false),
                        Id = c.Guid(nullable: false),
                        UserName = c.String(maxLength: 150, unicode: false),
                        Login = c.String(maxLength: 150, unicode: false),
                        Permissao = c.String(maxLength: 150, unicode: false),
                        Versao = c.Int(nullable: false),
                        DataOcorrencia = c.DateTime(nullable: false),
                        Menssagem = c.String(nullable: false, maxLength: 150, unicode: false),
                    })
                .PrimaryKey(t => t.CadastroAuditoriaId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CadastroAuditoria");
        }
    }
}
