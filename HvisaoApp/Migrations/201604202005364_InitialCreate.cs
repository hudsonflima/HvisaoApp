namespace HvisaoApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Lentes",
                c => new
                    {
                        SolicitacaoId = c.Int(nullable: false, identity: true),
                        Registro = c.Int(nullable: false),
                        Paciente = c.String(maxLength: 255, unicode: false),
                        Descricao = c.String(maxLength: 255, unicode: false),
                        DataPedido = c.DateTime(nullable: false),
                        Entregue = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.SolicitacaoId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Lentes");
        }
    }
}
