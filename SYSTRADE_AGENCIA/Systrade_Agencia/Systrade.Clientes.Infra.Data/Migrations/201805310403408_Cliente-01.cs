namespace Systrade.Clientes.Infra.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class Cliente01 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Agencia",
                c => new
                    {
                        CelulaId = c.Guid(nullable: false),
                        AgenciaId = c.Guid(nullable: false),
                        NomeCelula = c.String(nullable: false, maxLength: 150, unicode: false),
                        DataCadastro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CelulaId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Agencia");
        }
    }
}
